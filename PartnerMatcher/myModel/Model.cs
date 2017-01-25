using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PartnerMatcher.myModel
{
    /// <summary>
    /// This class represents our partner matcher project model
    /// </summary>
    public class Model : IModel
    {
        IController controller;

        /// <summary>
        /// Model C'tor
        /// </summary>
        public Model(IController _controller)
        {
            controller = _controller;
        }

        /// <summary>
        /// Implements an execution of a non query on the database
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>The requested dataTable if exists otherwise null</returns>
        public DataTable executeQuery(string query)
        {
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            OleDbConnection connection = new OleDbConnection(connectionString);
            DataTable dt = null;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
                dt = new DataTable();
                tableAdapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                controller.Output("משהו השתבש.."+e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        /// <summary>
        /// Implements an execution of a query on the database
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>True if succeeded otherwise false</returns>
        public bool executeNonQuery(string _command)
        {
            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            OleDbConnection connection = new OleDbConnection(connectionString);
            int numOfAffected = 0;
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(_command);
                command.Connection = connection;
                numOfAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                controller.Output("משהו השתבש..." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if (numOfAffected != 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Sends a confirmation mail to the specific mail
        /// </summary>
        /// <param name="mail">The mail to send to</param>
        /// <param name="firstName">The name of the user</param>
        /// <returns>True if succeeded otherwise false</returns>
        public bool sendConfirmationMail(string mail, string firstName)
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
                email.To.Add(mail);
                email.Subject = "Welcome Message";
                email.Body = "Hi " + firstName + ",\n Welcome to PartnerMatcher! \n Your registration proccess was successfull. \n We hope you will enjoy our system. \n Regards,\n PartnerMatcher team.";

                smtp.Send(email);

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
