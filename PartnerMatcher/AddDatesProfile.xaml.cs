using PartnerMatcher.myController;
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

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for AddDatesProfile.xaml
    /// </summary>
    public partial class AddDatesProfile : Window
    {
        IController controller;
        string mail;

        /// <summary>
        /// Add dates profile for this current user
        /// </summary>
        /// <param name="controller">controller for the view layer</param>
        /// <param name="mail">current user mail</param>
        public AddDatesProfile(IController controller, string mail)
        {
            InitializeComponent();
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
        /// Confirm generatin the profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_confirm_Click(object sender, RoutedEventArgs e)
        {
            //validity checks
            if (!isValidPreferences())
                MessageBox.Show("אנא ודא כי מילאת את כל ההעדפות");
            //need to add check for the textbox

            else
            {
                if (!(controller.createNewDatePreference(mail, cb_profiles.SelectedItem.ToString(), tb_minAge.Text + "-" + tb_maxAge.Text, tb_location.Text, cb_gender.Text)))
                    return;
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

            if (cb_gender.SelectedItem == null || cb_profiles.SelectedItem == null || tb_maxAge.Text == "" || tb_minAge.Text == "" || tb_location.Text == "")
            {
                MessageBox.Show("אנא וודא שהזנת את כל השדות");
                return false;
            }

            else if (!(isNumber(tb_minAge.Text) || isNumber(tb_maxAge.Text)))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'גיל מינימלי' או 'גיל מקסימלי' הינו מספר");
                return false;
            }
            else if (Convert.ToInt32(tb_minAge.Text) > Convert.ToInt32(tb_maxAge.Text))
            {
                MessageBox.Show("אנא וודא שהנתון 'גיל מקסימלי' גדול מהנתון 'גיל מינימלי', או שווה לו");
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
