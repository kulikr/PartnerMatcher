using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for Search_window.xaml
    /// </summary>
    public partial class Search_window : Window
    {
        IController controller;
        Dictionary<string, string> interestArea;
        string _userMail;

        /// <summary>
        /// Search window constructor
        /// </summary>
        /// <param name="_controller"></param>
        /// <param name="userMail"></param>
        public Search_window(IController _controller, string userMail)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
            interestArea = new Dictionary<string, string>();
            _userMail = userMail;
            getPossibleInterestAreas();

        }

        /// <summary>
        /// This function implements the query which gets the current interest areas in the DB
        /// </summary>
        /// <param name="connection">The DB connection</param>
        private void getPossibleInterestAreas()
        {
            DataTable dt = controller.getAreas();

            DataRow[] rows = dt.Select();
            List<string> areas = new List<string>();
            foreach (DataRow dr in rows)
            {
                areas.Add(dr[1].ToString());
                interestArea.Add(dr[1].ToString(), dr[0].ToString());
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
            string type = interestArea[box_interest.SelectedItem.ToString()];

            DataTable dt = controller.getCitiesPartnerShips(type);

            DataRow[] rows = dt.Select();
            if (rows.Length == 0)
            {
                box_location.Visibility = Visibility.Hidden;
                header_location.Visibility = Visibility.Hidden;
                MessageBox.Show(" לא קיימות מודעות שותפות בתחום זה. אנא נסה במועד מאוחר יותר");
            }
            else
            {
                box_location.Visibility = Visibility.Visible;
                header_location.Visibility = Visibility.Visible;
            }
            HashSet<string> locations = new HashSet<string>();
            foreach (DataRow dr in rows)
            {
                locations.Add(dr[0].ToString());
            }
            box_location.ItemsSource = locations;
        }

        /// <summary>
        /// Displays the location combobox after the user selects interest area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void box_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.Visibility = Visibility.Hidden;
            if (box_location.SelectedItem != null)
            {
                if (box_location.SelectedItem.ToString() != "")
                {
                    b_showResults.Visibility = Visibility.Visible;
                }
                else
                    b_showResults.Visibility = Visibility.Hidden;
            }
            else
                b_showResults.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// displays search results button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_showResults_Click(object sender, RoutedEventArgs e)
        {
            string type = interestArea[box_interest.SelectedItem.ToString()];
            string city = box_location.SelectedItem.ToString();

            DataTable dt = controller.getPartnershipsByCity(type, city);

            DataRow[] rows = dt.Select();
            List<advertisment> ads = new List<advertisment>();

            //Get all the relevant data for an advertisment to display
            foreach (DataRow r in rows)
            {
                if (r[3] != null && r[3].ToString() != string.Empty)
                {
                    advertisment a = new advertisment()
                    {
                        Id = r[0].ToString(),
                        ManagerMail = r[1].ToString(),
                        City = r[2].ToString(),
                        Date = r[3].ToString(),
                        Type = interestArea[box_interest.SelectedItem.ToString()]
                    };
                    ads.Add(a);
                }
            }
            listView.ItemsSource = ads;
            listView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// display partnership details button in the ads list was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            advertisment ad = button.DataContext as advertisment;

            DataTable dt = controller.getAdvertisments(ad.Type, ad.Id);

            DataRow[] rows = dt.Select();
            ViewPartnership vp = new ViewPartnership(ref controller, rows[0], ad.Id, _userMail, ad.Type, ad.ManagerMail, true, "-1");
            vp.Show();
        }
    }
}

/// <summary>
/// This class represents an advertisment
/// </summary>
public class advertisment
{
    public string Id { get; set; }
    public string Date { get; set; }
    public string City { get; set; }
    public string ManagerMail { get; set; }
    public string Type { get; set; }
}
