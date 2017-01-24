using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows;
using System.Windows.Navigation;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for Register_window.xaml
    /// </summary>
    public partial class Register_window : Window
    {
        IController controller;
        /// <summary>
        /// C'tor for the Register window
        /// </summary>
        public Register_window(IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Closed += Register_window_Closed;
            controller = _controller;
        }

        private void Register_window_Closed(object sender, EventArgs e)
        {
            //MainWindow main = new MainWindow(controller);
            //main.Show();
        }

        /// <summary>
        /// the event when the fun button is cliked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_fin_Click(object sender, RoutedEventArgs e)
        {
            if (!cb_regelations.IsChecked.Value)
            {
                MessageBox.Show("יש לסמן כי קראת את התקנון");
                return;
            }
            if (!IsInputValid())
                return;

            if (isMailExists(tb_mail.Text))

            {
                MessageBox.Show("קיים משתמש עם המייל שהוזן, הזן מייל אחר");
                return;
            }
            if (!controller.sendConfirmationMail(tb_mail.Text, tb_firstName.Text))
            {
                MessageBox.Show("המייל שהוזן אינו תקין! הזן מייל תקין");
                return;
            }
            controller.createNewUser(tb_mail.Text, tb_password.Text, tb_firstName.Text, tb_lastName.Text, tb_birthDate.Text, tb_city.Text, tb_phone.Text);
        }

        /// <summary>
        /// This function checks whether an email already exists in the DB
        /// </summary>
        /// <param name="mail">given mail to check</param>
        /// <returns>true if exists false otherwise</returns>
        private bool isMailExists(string mail)
        {
            DataTable dt = controller.getFirstNameData(mail);
            return dt != null;
        }


        /// <summary>
        /// checks if the input is valid
        /// </summary>
        private bool IsInputValid()
        {
            if (tb_birthDate.Text == "" || tb_city.Text == "" || tb_firstName.Text == "" || tb_lastName.Text == "" || tb_mail.Text == "" || tb_password.Text == "" || tb_phone.Text == "")
            {
                MessageBox.Show("יש למלא את כל השדות");
                return false;
            }
            return true;
            //************************************************************************************************
            //need to check if the mail is valid and if the phone is valid 
        }

        /// <summary>
        /// This function activates the hyperlink to the regulations of yad2 website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
