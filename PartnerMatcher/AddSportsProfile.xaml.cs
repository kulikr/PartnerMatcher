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
    /// Interaction logic for AddSportsProfile.xaml
    /// </summary>
    public partial class AddSportsProfile : Window
    {
        private IController controller;
        private string mail;

        /// <summary>
        /// Add Sports profile for this current user
        /// </summary>
        /// <param name="controller">controller for the view layer</param>
        /// <param name="mail">current user mail</param>
        public AddSportsProfile(IController controller, string mail)
        {
            InitializeComponent();
            this.mail = mail;
            this.controller = controller;
            init();
        }

        /// <summary>
        /// Initialize combo boxes lists
        /// </summary> 
        private void init()
        {
            initProfilesCB();
            initLevelOfPlay();
        }

        /// <summary>
        /// initialize level of play combobox
        /// </summary>
        private void initLevelOfPlay()
        {
            for (int i = 1; i < 6; i++)
                cb_levelOfPlay.Items.Add(i);
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
        /// Add profile button was clicked
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
                if (!(controller.createNewSportsPreference(mail, cb_profiles.SelectedItem.ToString(), tb_sportsType.Text, cb_levelOfPlay.SelectedItem.ToString(), dp_activityDay.Text, tb_location.Text, tb_exactLocation.Text)))
                    MessageBox.Show("משהו השתבש. אנא נסה שוב");
                else
                {
                    MessageBox.Show("הפרופיל התווסף בהצלחה");
                    Close();
                }
            }
        }

        /// <summary>
        /// checks if the prefernces that was enterd are valid
        /// </summary>
        /// <returns></returns>
        private bool isValidPreferences()
        {
            if (cb_levelOfPlay.SelectedItem == null || cb_profiles.SelectedItem == null || tb_sportsType.Text == "" || tb_exactLocation.Text == "" || tb_location.Text == "" || dp_activityDay.SelectedDate == null)
            {
                MessageBox.Show("אנא ודא כי מילאת את כל ההעדפות");
                return false;
            }
            else if (dp_activityDay.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("אנא ודא כי התאריך שהזנת גדול מהתאריך הנוכחי");
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
