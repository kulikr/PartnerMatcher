using PartnerMatcher.myController;
using PartnerMatcher.View;
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
    public partial class MainWindow : Window , IView

    {
        IController controller;

        /// <summary>
        /// Main window constructor
        /// </summary>
        /// <param name="_controller"></param>
        public MainWindow(ref IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;
        }

        public void Output(string text)
        {
            MessageBox.Show(text);
        }

        /// <summary>
        /// Register to the system buton was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void register_click(object sender, RoutedEventArgs e)
        {
            Register_window RegWin = new Register_window(controller);
            Visibility = Visibility.Hidden;
            RegWin.Closed += RegWin_Closed;
            RegWin.Show();
        }

        /// <summary>
        /// Event for when the register window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegWin_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Login to the system button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(controller);
            this.Visibility = Visibility.Hidden;
            loginWindow.Closed += LoginWindow_Closed;
            loginWindow.Show();        
        }

        /// <summary>
        /// Event for when the Login window was closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            Visibility = Visibility.Visible;
        }
    }
}
