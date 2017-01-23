using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.myController
{
    public interface IController
    {
        DataTable getFirstNameData(string mail);
        DataTable connect(string mail, string password);
        bool createNewUser(string mail, string password, string firstName, string lastName, string birthDate, string city, string phone);
        bool sendConfirmationMail(string mail, string firstName);
    }
}
