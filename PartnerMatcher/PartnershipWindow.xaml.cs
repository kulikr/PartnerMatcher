using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for PartnershipWindow.xaml
    /// </summary>
    /// 
    public partial class PartnershipWindow : Window
    {
        IController _controller;
        Dictionary<string, string> _interestArea;
        string _userMail;
        public PartnershipWindow(IController controller, string userMail)
        {
            InitializeComponent();
            _controller = controller;
            _interestArea = new Dictionary<string, string>();
            _userMail = userMail;
            getPossibleInterestAreas();
        }


        /// <summary>
        /// This function implements the query which gets the current interest areas in the DB
        /// </summary>
        /// <param name="connection">The DB connection</param>
        private void getPossibleInterestAreas()
        {
            DataTable dt = _controller.getAreas();

            DataRow[] rows = dt.Select();
            List<string> areas = new List<string>();
            foreach (DataRow dr in rows)
            {
                areas.Add(dr[1].ToString());
                _interestArea.Add(dr[1].ToString(), dr[0].ToString());
            }
            box_interest.ItemsSource = areas;
        }

        /// <summary>
        /// This function sets the possible location of partnership for each interest area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void box_interestSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = _interestArea[box_interest.SelectedItem.ToString()];

            DataTable dt = _controller.getCitiesPartnerShips(type);

            DataRow[] rows = dt.Select();
            if (rows.Length == 0)
            {

                MessageBox.Show(" לא קיימות לך שותפויות בתחום זה.");
            }

            HashSet<string> locations = new HashSet<string>();
            foreach (DataRow dr in rows)
            {
                locations.Add(dr[0].ToString());
            }
        }

        /// <summary>
        /// view partnership details button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Partnership ad = button.DataContext as Partnership;

            DataTable dt = _controller.getAdvertisments(ad.Type, ad.Id);

            DataRow[] rows = dt.Select();
            ViewPartnership vp = new ViewPartnership(ref _controller, rows[0], ad.Id, _userMail, ad.Type, ad.ManagerMail, false, rows[0][7].ToString());
            vp.Show();
        }

        /// <summary>
        /// Display current user partnerships window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void display_Click(object sender, RoutedEventArgs e)
        {
            string type = _interestArea[box_interest.SelectedItem.ToString()];
            List<Partnership> ads = new List<Partnership>();
            //Get user partnerships
            DataTable dt = _controller.getPreferencesForUserByType(type, _userMail);
            DataRow[] rows;
            if (dt != null)
            {
                //Display all partnerships
                rows = dt.Select();
                foreach (DataRow r in rows)
                {
                    string id = r[0].ToString();
                    DataTable prefercencePartners = _controller.getPartnershipsIdByPreferenceId(type, id);
                    if (prefercencePartners != null)
                    {
                        foreach (DataRow partnershipId in prefercencePartners.Rows)
                        {
                            DataTable partnership = _controller.getPartnershipById(type, partnershipId[0].ToString());
                            if (partnership != null)
                            {
                                foreach (DataRow result in partnership.Select())
                                {
                                    Partnership a = new Partnership()
                                    {
                                        Id = result[0].ToString(),
                                        ManagerMail = result[1].ToString(),
                                        Date = result[3].ToString(),
                                        Type = _interestArea[box_interest.SelectedItem.ToString()],
                                        NumOfPartners = result[7].ToString(),
                                    };
                                    ads.Add(a);
                                }
                            }
                        }

                    }

                }
                listView.ItemsSource = ads;
                listView.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("לא קיימות לך שותפויות בתחום.");
            }
        }
    }

    /// <summary>
    /// This class represents a partnership
    /// </summary>
    public class Partnership
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string ManagerMail { get; set; }
        public string Type { get; set; }
        public string NumOfPartners { get; set; }
    }

}
