using System;
using System.Collections.Generic;
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
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function defines the actions taken after the user pressed the 'connect' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_connect_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            int counter = 0;
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from Users where mail ='" + tb_mail.Text + "'" + " and password ='" + tb_password.Text + "'");
                command.Connection = connection;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    counter++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if (counter == 0)
                MessageBox.Show("שם המשתמש ו/או הסיסמא אינם תקינים, נסה שנית או הרשם למערכת");
            else
            {
                UserWindow uw = new UserWindow();
                uw.Show();
                this.Close();
            }
        }
    }
}
