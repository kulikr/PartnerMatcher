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
    /// Interaction logic for ChooseProfileWindow.xaml
    /// </summary>
    public partial class ChooseProfileWindow : Window
    {
        IController controller;
        List<Profile> profiles;

        /// <summary>
        ///  choose what kind of profile to create partnership for
        /// </summary>
        /// <param name="profiles"></param>
        /// <param name="controller"></param>
        public ChooseProfileWindow(List<Profile> profiles, IController controller)
        {
            this.controller = controller;
            this.profiles = profiles;
            InitializeComponent();
            listBox_profiles.ItemsSource = profiles;
            listBox_profiles.HorizontalContentAlignment = HorizontalAlignment.Right;
        }

        /// <summary>
        /// Confirm adding a partnership for the selected profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_profiles.SelectedItem == null)
            {
                MessageBox.Show("נא לבחור פרופיל");
                return;
            }

            AddPartnershipWindow addPartnershipWindow = new AddPartnershipWindow(listBox_profiles.SelectedItem as Profile, controller);
            Visibility = Visibility.Hidden;
            addPartnershipWindow.Closed += AddPartnershipWindow_Closed;
            addPartnershipWindow.Show();

        }

        /// <summary>
        /// Catch the event for when the window closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPartnershipWindow_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
