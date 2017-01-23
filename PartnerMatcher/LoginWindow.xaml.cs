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
        bool flag;
        public LoginWindow(IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            flag = false;
            Closed += LoginWindow_Closed;
            controller = _controller;
        }

        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            if (!flag)
            {
                MainWindow main = new MainWindow(controller);
                main.Show();
            }
        }


        /// <summary>
        /// This function defines the actions taken after the user pressed the 'connect' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_connect_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
           DataTable dt = controller.connect(tb_mail.Text, tb_password.Text);
            if (dt==null)
                MessageBox.Show("שם המשתמש ו/או הסיסמא אינם תקינים, נסה שנית או הרשם למערכת");
            else
            {
                UserWindow uw = new UserWindow(tb_mail.Text,controller);
                uw.Show();
                this.Close();
            }
        }
    }
}
