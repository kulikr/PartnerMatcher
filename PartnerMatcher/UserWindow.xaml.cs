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
        string mail;
        public UserWindow(string mail)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Closed += UserWindow_Closed;
            this.mail = mail;
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select firstName from Users where mail='"+mail+"'", connection);
                OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                DataRow[] rows = dt.Select();
                txt_firstName.Text = ","+rows[0]["firstName"].ToString()
                    ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        private void UserWindow_Closed(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            Search_window sw = new Search_window();
            sw.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("אופציה זו אינה נתמכת בגירסה הנוכחית");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("אופציה זו אינה נתמכת בגירסה הנוכחית");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("אופציה זו אינה נתמכת בגירסה הנוכחית");
        }
    }
}
