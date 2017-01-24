using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        IController controller;

        public MainWindow(IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
        }

        private void register_click(object sender, RoutedEventArgs e)
        {
            Register_window RegWin = new Register_window(controller);
            Visibility = Visibility.Hidden;
            RegWin.Closed += RegWin_Closed;
            RegWin.Show();
        }

        private void RegWin_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        private void login_click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(controller);
            this.Visibility = Visibility.Hidden;
            loginWindow.Closed += LoginWindow_Closed;
            loginWindow.Show();        
        }

        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }
    }
}
