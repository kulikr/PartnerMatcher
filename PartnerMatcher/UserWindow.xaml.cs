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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        IController controller;
        string mail;

        /// <summary>
        /// User window constructor to display to the user option to click on
        /// </summary>
        /// <param name="mail">user mail</param>
        /// <param name="_controller">controler for the view layer</param>
        public UserWindow(string mail, IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
            this.mail = mail;

            DataTable dt = controller.getFirstNameData(mail);
            DataRow[] rows = dt.Select();
            txt_firstName.Text = "," + rows[0]["firstName"].ToString();
        }

        /// <summary>
        /// Search according to location button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            Search_window searchWin = new Search_window(controller, mail);
            Visibility = Visibility.Hidden;
            searchWin.Closed += SearchWin_Closed;
            searchWin.Show();
        }

        /// <summary>
        /// Event to close the corrent window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWin_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// addnew partnership button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_addPartnership_Click(object sender, RoutedEventArgs e)
        {
            DataTable areas = controller.getAreas();
            DataRow[] areasRows = areas.Select();
            List<Profile> profiles = new List<Profile>();
            foreach (DataRow areaRow in areasRows)
            {
                string tableName = areaRow[0].ToString();
                DataTable profileByArea = controller.getProfilesByArea(mail, tableName);

                //no profile for the user in the spesific area
                if (profileByArea == null)
                    continue;

                DataRow[] profileByAreaRows = profileByArea.Select();
                foreach (DataRow profileByAreaRow in profileByAreaRows)
                {
                    Profile profile = new Profile()
                    {
                        Id = profileByAreaRow[0].ToString(),
                        Mail = profileByAreaRow[1].ToString(),
                        Area = areaRow[1].ToString(),
                        Type = profileByAreaRow[2].ToString()
                    };
                    if (profile.Type == "מנהל שותפות" || profile.Type == "שותף פעיל")
                        profiles.Add(profile);
                }
            }
            if (profiles.Count == 0)
            {
                MessageBox.Show("'אין ברשותך פרופילים מסוג 'שותף פעיל' או 'מנהל שותפות', אם ברצונך להוסיף שותפות חדשה וודא שאתה מוסיף פרופיל מהסוג 'שותף פעיל' או 'מנהל שותפות'");
                return;
            }


            ChooseProfileWindow choosProfileWindow = new ChooseProfileWindow(profiles, controller);
            Visibility = Visibility.Hidden;
            choosProfileWindow.Closed += AddPartnershipWindow_Closed;
            choosProfileWindow.Show();
        }

        /// <summary>
        /// Event for aading new partnership window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPartnershipWindow_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// watch partnership button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watch_partnership_Click(object sender, RoutedEventArgs e)
        {
            PartnershipWindow pw = new PartnershipWindow(controller, mail);
            pw.Show();
        }


        /// <summary>
        /// add new profile button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CreateProfileByInterestArea_window addProfileWindow = new CreateProfileByInterestArea_window(controller, mail);
            addProfileWindow.Closed += addProfileWindow_Closed; //close this window when add profile is closed
            this.Visibility = Visibility.Hidden; //hide this window until add profile ended
            addProfileWindow.Show();
        }

        /// <summary>
        /// Catch the event of when the window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void addProfileWindow_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
        }


    }

    /// <summary>
    ///This class represtn's a user Profile 
    /// </summary>
    public class Profile
    {
        public string Id { get; set; }
        public string Mail { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// turns the object to a string represntation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string area = "בתחום " + Area;
            string type = "פרופיל מסוג " + Type;
            string id = "פרופיל מספר " + Id;
            return id + ": " + type + " " + area;
        }
    }
}
