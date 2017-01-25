using System;
using System.Collections.Generic;
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
using PartnerMatcher.myController;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for AddTripsProfile.xaml
    /// </summary>
    public partial class AddTripsProfile : Window
    {
        private IController controller;
        private string mail;

        /// <summary>
        /// Add trip profile for this current user
        /// </summary>
        /// <param name="controller">controller for the view layer</param>
        /// <param name="mail">current user mail</param>
        public AddTripsProfile(IController controller, string mail)
        {
            InitializeComponent();
            this.controller = controller;
            this.mail = mail;
            init();
        }

        /// <summary>
        /// Initialize combo boxes lists
        /// </summary>
        private void init()
        {
            initProfilesCB();
            initGender();
        }

        /// <summary>
        /// Initialize gender combobox
        /// </summary>
        private void initGender()
        {
            cb_gender.Items.Add("ז");
            cb_gender.Items.Add("נ");
        }

        /// <summary>
        /// Initialize profile type combo box
        /// </summary>
        private void initProfilesCB()
        {
            cb_profiles.Items.Add("מנהל שותפות");
            cb_profiles.Items.Add("שותף פעיל");
            cb_profiles.Items.Add("מחפש שותפות");
        }

        /// <summary>
        /// Confirm generate the profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_confirm_Click(object sender, RoutedEventArgs e)
        {
            //validity checks
            if (!isValidPreferences())
                return;
            //need to add check for the textbox

            else
            {
                if (!(controller.createNewTripsPreference(mail, cb_profiles.SelectedItem.ToString(), tb_destination.Text, dp_dateOfDeparture.SelectedDate.ToString(), dp_dateOfReturn.SelectedDate.ToString(), cb_gender.SelectedItem.ToString())))
                    MessageBox.Show("משהו השתבש. אנא נסה שוב");
                else
                {
                    MessageBox.Show("הפרופיל התווסף בהצלחה");
                    Close();
                }
            }
        }

        /// <summary>
        /// Validat entered parameters for this new profile
        /// </summary>
        /// <returns>if the parameters are valid</returns>
        private bool isValidPreferences()
        {
            if (cb_profiles.SelectedItem == null || tb_destination.Text == "" || dp_dateOfDeparture.SelectedDate == null || dp_dateOfReturn.SelectedDate == null || cb_gender.SelectedItem == null)
            {
                MessageBox.Show("אנא ודא כי מילאת את כל ההעדפות");
                return false;
            }

            if (dp_dateOfDeparture.SelectedDate > dp_dateOfReturn.SelectedDate)
            {
                MessageBox.Show("אנא וודא שהתאריך חזרה משוער מאוחר יותר מהתאריך יציאה משוער");
                return false;
            }

            if (dp_dateOfReturn.SelectedDate < DateTime.Now)
            {
                MessageBox.Show(" אנא וודא שתאריך החזרה המשוער גדול מהתאריך הנוכחי");
                return false;
            }

            if (dp_dateOfDeparture.SelectedDate < DateTime.Now)
            {
                MessageBox.Show(" אנא וודא שתאריך היציאה המשוער גדול מהתאריך הנוכחי");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Checks if the string is a number
        /// </summary>
        /// <param name="isNum"></param>
        /// <returns></returns>
        private bool isNumber(string isNum)
        {
            int num;
            if (!Int32.TryParse(isNum, out num))
                return false;
            else
                return true;
        }
    }
}
