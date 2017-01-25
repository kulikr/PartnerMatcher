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
    /// Interaction logic for AddAppartmentsProfile.xaml
    /// </summary>
    public partial class AddAppartmentsProfile : Window
    {
        IController controller;
        string mail;

        /// <summary>
        /// add apartment profile window constructor
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="mail"></param>
        public AddAppartmentsProfile(IController controller, string mail)
        {
            InitializeComponent();
            this.mail = mail;
            this.controller = controller;
            init();
        }

        /// <summary>
        /// Initialize comboboxes
        /// </summary>
        private void init()
        {
            initProfilesCB();
            initSmoke();
            initPets();
        }

        /// <summary>
        /// Initialize smoke combobox
        /// </summary>
        private void initSmoke()
        {
            cb_smoke.Items.Add("כן");
            cb_smoke.Items.Add("לא");
        }

        /// <summary>
        /// Initialize pets combobox
        /// </summary>
        private void initPets()
        {
            cb_pets.Items.Add("כן");
            cb_pets.Items.Add("לא");
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
                if (!(controller.createNewAppartmentPreference(mail, cb_profiles.SelectedItem.ToString(), cb_smoke.SelectedItem.ToString(), cb_pets.SelectedItem.ToString(), tb_sqft.Text, tb_hobbies.Text)))
                    MessageBox.Show("משהו השתבש. אנא נסה שוב");
                else
                {
                    MessageBox.Show("הפרופיל התווסף בהצלחה");
                    Close();
                }

            }

        }

        /// <summary>
        /// Checks the validity of the data
        /// </summary>
        /// <returns></returns>
        private bool isValidPreferences()
        {
            double num;
            if (cb_smoke.SelectedItem == null || cb_pets.SelectedItem == null || cb_profiles.SelectedItem == null)
            {
                MessageBox.Show("אנא ודא כי מילאת את כל ההעדפות");
                return false;
            }
            else if (!double.TryParse(tb_sqft.Text, out num))
            {
                MessageBox.Show("אנא ודא כי גודל  הדירה במטר רבוע הוכנס בצורה תקינה");
                return false;
            }

            else
                return true;
        }
    }
}
