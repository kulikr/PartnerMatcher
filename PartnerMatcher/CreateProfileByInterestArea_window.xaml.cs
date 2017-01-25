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
    /// Interaction logic for CreateProfile_window.xaml
    /// </summary>
    public partial class CreateProfileByInterestArea_window : Window
    {
        IController controller;
        string mail;

        /// <summary>
        /// Create Profile window constructor
        /// </summary>
        /// <param name="controller">controller for the view layer</param>
        /// <param name="mail">mail of the current user in the system</param>
        public CreateProfileByInterestArea_window(IController controller, string mail)
        {
            InitializeComponent();
            this.mail = mail;
            this.controller = controller;
            List<string> interestAreas = new List<string>();
            DataTable dt = controller.getAreas(); //get the interest areas
            for (int i = 0; i < dt.Rows.Count; i++)
                interestAreas.Add(dt.Rows[i][1].ToString()); //add current interest areas to list
            lb_interestArea.ItemsSource = interestAreas; //set list as item source

        }

        /// <summary>
        /// confirm adding button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (lb_interestArea.SelectedItem == null)
                MessageBox.Show("לא נבחר תחום! בחר תחום שותפות רצוי ולחץ על כפתור אשר");
            else
                switch (lb_interestArea.SelectedItem.ToString())
                {
                    case "דיור":
                        {
                            AddAppartmentsProfile appartmentWin = new AddAppartmentsProfile(controller, mail);
                            this.Visibility = Visibility.Hidden;
                            appartmentWin.Closed += appartmentWin_Closed;
                            appartmentWin.Show();
                            break;
                        }
                    case "דייטים":
                        {
                            AddDatesProfile datesWin = new AddDatesProfile(controller, mail);
                            this.Visibility = Visibility.Hidden;
                            datesWin.Closed += DatesWin_Closed;
                            datesWin.Show();

                            break;
                        }
                    case "ספורט":
                        {
                            AddSportsProfile sportsWin = new AddSportsProfile(controller, mail);
                            this.Visibility = Visibility.Hidden;
                            sportsWin.Closed += SportsWin_Closed;
                            sportsWin.Show();
                            break;
                        }
                    case "טיולים":
                        {
                            AddTripsProfile tripsWin = new AddTripsProfile(controller, mail);
                            this.Visibility = Visibility.Hidden;
                            tripsWin.Closed += TripsWin_Closed;
                            tripsWin.Show();
                            break;
                        }
                }
        }

        /// <summary>
        /// Catch the event when the add trip profile window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TripsWin_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Catch the event when the add sports profile window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SportsWin_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Catch the event when the add dates profile window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatesWin_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Catch the event when the add appartment profile window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void appartmentWin_Closed(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
