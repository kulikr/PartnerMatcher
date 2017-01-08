using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for Register_window.xaml
    /// </summary>
    public partial class Register_window : Window
    {

        /// <summary>
        /// C'tor for the Register window
        /// </summary>
        public Register_window()
        {
            InitializeComponent();

        }

        /// <summary>
        /// the event when the fun button is cliked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_fin_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)!cb_regelations.IsChecked)
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

            if (!sendConfirmationMail())
                return;

            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("Insert Into Users values ('"+tb_mail.Text+"','" + tb_password.Text + "','" + tb_firstName.Text + "','" + tb_lastName.Text + "','" + tb_birthDate.Text + "','" + tb_city.Text + "','" + tb_phone.Text + "')");
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
           Close();
        }

        /// <summary>
        /// This function checks whether an email already exists in the DB
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private bool isMailExists(string mail)
        {
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            int counter = 0;
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from Users where mail ='" +mail+ "'" );
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
            return counter >0;
        }

        /// <summary>
        /// sends a conformation mail to the new user
        /// </summary>
        private bool sendConfirmationMail()
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";

                // set up the Gmail server
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("yad2.partnermatcher@gmail.com", "theAteam");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                // draft the email
                MailAddress fromAddress = new MailAddress("cse445emailservice@gmail.com");
                email.From = fromAddress;
                email.To.Add(tb_mail.Text);
                email.Subject = "Welcome Message";
                email.Body = "Hi "+tb_firstName.Text+ ",\n Welcome to PartnerMatcher! \n Your registration proccess was successfull. \n We hope you will enjoy our system. \n Regards,\n PartnerMatcher team.";

                smtp.Send(email);

            }
            catch (Exception)
            {
                MessageBox.Show("המייל שהוזן אינו תקין! הזן מייל תקין");
                return false;
            }
            return true;
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
            //need to check if the mail is valid and if the phone is valid and if the password is at least 8 chars
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
