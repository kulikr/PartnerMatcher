using PartnerMatcher.myModel;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PartnerMatcher.myController
{
    public class Controller : IController
    {
        IModel model;
        IView view;
        public Controller()
        {}

        /// <summary>
        /// Sets the controller view
        /// </summary>
        /// <param name="_view">The view to set</param>
        public void setView(IView _view)
        {
            view = _view;
        }

        /// <summary>
        /// Sets the controller model
        /// </summary>
        /// <param name="_model">The model to set</param>
        public void setModel(IModel _model)
        {
            model = _model;
        }

        public DataTable getFirstNameData(string mail)
        {
            string query = ("select firstName from Users where mail='" + mail + "'");
            return model.executeQuery(query);
        }

        public DataTable connect(string mail, string password)
        {
            string query = "select * from Users where mail = '" + mail + "'" + " and password = '" + password + "'";
            return model.executeQuery(query);
        }

        public bool createNewUser(string mail, string password, string firstName, string lastName, string birthDate, string city, string phone)
        {
            string command = "Insert Into Users values('" + mail + "', '" +password + "', '" + firstName + "', '" + lastName + "', '" + birthDate + "', '" + city + "', '" + phone + "')";
            return model.executeNonQuery(command);
        }

        public bool sendConfirmationMail(string mail, string firstName)
        {
           return model.sendConfirmationMail(mail, firstName);
        }

        public DataTable getAreas()
        {
            string query = "select * from InterestArea";
            return model.executeQuery(query);
        }
        
        public DataTable getAadvertisments(string type, string id)
        {
            string query = "select * from Partnerships" + type + " where ID = " +id;
            return model.executeQuery(query);
        }


        public DataTable getPartnershipsByCity(string type, string city)
        {
            string query = "select * from Partnerships" + type + " where City = '" + city + "'";
            return model.executeQuery(query);
        }

        public DataTable getCitiesParnterShips(string type)
        {
            string query = "select city from Partnerships" + type;
            return model.executeQuery(query);
        }
    }
}
