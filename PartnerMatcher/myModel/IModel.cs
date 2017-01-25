using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.myModel
{
    /// <summary>
    /// Defines the model functionality in the partnerMatcher system
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Implements an execution of a non query on the database
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>The requested dataTable if exists otherwise null</returns>
        DataTable executeQuery(string query);

        /// <summary>
        /// Implements an execution of a query on the database
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>True if succeeded otherwise false</returns>
        bool executeNonQuery(string command);

        /// <summary>
        /// Sends a confirmation mail to the specific mail
        /// </summary>
        /// <param name="mail">The mail to send to</param>
        /// <param name="firstName">The name of the user</param>
        /// <returns>True if succeeded otherwise false</returns>
        bool sendConfirmationMail(string mail, string firstName);
    }
}
