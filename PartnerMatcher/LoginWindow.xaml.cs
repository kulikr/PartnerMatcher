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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IController controller;

        /// <summary>
        /// C'tor for the LoginWindow class
        /// </summary>
        /// <param name="_controller"></param>
        public LoginWindow(IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
        }

        /// <summary>
        /// This function defines the actions taken after the user pressed the 'connect' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_connect_Click(object sender, RoutedEventArgs e)
        {
           DataTable dt = controller.connect(tb_mail.Text, tb_password.Text);
            if (dt==null)
                MessageBox.Show("שם המשתמש ו/או הסיסמא אינם תקינים, נסה שנית או הרשם למערכת");
            else
            {
                UserWindow userWin = new UserWindow(tb_mail.Text,controller);
                Visibility = Visibility.Hidden;
                userWin.Closed += UserWin_Closed;
                userWin.Show();
            }
        }

        /// <summary>
        /// Ctach the event for when the user window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWin_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
