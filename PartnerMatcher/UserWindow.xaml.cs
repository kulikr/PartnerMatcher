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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        IController controller;
        string mail;

        public UserWindow(string mail, IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
            this.mail = mail;

            DataTable dt = controller.getFirstNameData(mail);
            DataRow[] rows = dt.Select();
            txt_firstName.Text = "," + rows[0]["firstName"].ToString();
        }


        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            Search_window searchWin = new Search_window(controller);
            Visibility = Visibility.Hidden;
            searchWin.Closed += SearchWin_Closed;
            searchWin.Show();
        }

        private void SearchWin_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Hidden;
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
