using PartnerMatcher.myModel;
using System.Collections.Generic;
using System.Data;
using PartnerMatcher.View;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.myController
{
    /// <summary>
    /// This class represents a controller in the partnerMatcher project
    /// </summary>
    public class Controller : IController
    {
        IModel model; //A model which implements the IModel interface
        IView view;//A view which implements the IModel interface
        public Controller()
        { }

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

        /// <summary>
        /// Retruns the first name of the user with the specific mail from the database executing a query
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <returns>The users first name</returns>
        public DataTable getFirstNameData(string mail)
        {
            string query = ("select firstName from Users where mail='" + mail + "'");
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns the details of the user with the specific email and password from the database executing a query
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="password">The user password</param>
        /// <returns>The user details</returns>
        public DataTable connect(string mail, string password)
        {
            string query = "select * from Users where mail = '" + mail + "'" + " and password = '" + password + "'";
            return model.executeQuery(query);
        }

        /// <summary>
        /// Creates a new user in the database using model executing a non query
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="password">The user password</param>
        /// <param name="firstName">The user first name</param>
        /// <param name="lastName">The user last name</param>
        /// <param name="birthDate"The user birth date></param>
        /// <param name="city">The user city</param>
        /// <param name="phone">The user phone</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewUser(string mail, string password, string firstName, string lastName, string birthDate, string city, string phone)
        {
            string command = "Insert Into Users values('" + mail + "', '" + password + "', '" + firstName + "', '" + lastName + "', '" + birthDate + "', '" + city + "', '" + phone + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Sends an confirmation mail using the model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="firstName">The user first name</param>
        /// <returns>True for succesful send otherwise false</returns>
        public bool sendConfirmationMail(string mail, string firstName)
        {
            return model.sendConfirmationMail(mail, firstName);
        }

        /// <summary>
        /// Returns the interest areas in the partnerMatcher system using model execute query
        /// </summary>
        /// <returns>The interest areas</returns>
        public DataTable getAreas()
        {
            string query = "select * from InterestArea";
            return model.executeQuery(query);
        }

        /// <summary>
        /// Return the advertisments published in the system on the specific interest area using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <param name="id">advertisment id</param>
        /// <returns>The advertisments of the specific interest area</returns>
        public DataTable getAdvertisments(string type, string id)
        {
            string query = "select * from Partnerships" + type + " where ID = " + id; //to add date != null
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns from the database partnership in a specific type in a specific city using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <param name="city">ciry where the partnership is in</param>
        /// <returns>The partnerships in the specific city</returns>
        public DataTable getPartnershipsByCity(string type, string city)
        {
            string query = "select * from Partnerships" + type + " where City = '" + city + "'";
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns all the cities of all the partnerships using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <returns>all the cities of all the partnerships</returns>
        public DataTable getCitiesPartnerShips(string type)
        {
            string query = "select city from Partnerships" + type;
            return model.executeQuery(query);
        }

        /// <summary>
        /// Creates a new profile of apartments prefernces using model execute query
        /// </summary>
        /// <param name="mail">user mail</param>
        /// <param name="profileType">profile type</param>
        /// <param name="smoke">smoking field</param>
        /// <param name="pets">pets field</param>
        /// <param name="sqft">appratment size</param>
        /// <param name="hobbies">possible hobies</param>
        /// <returns>bool that indicates of the creation succeeded</returns>
        public bool createNewAppartmentPreference(string mail, string profileType, string smoke, string pets, string sqft, string hobbies)
        {
            string command = "Insert Into UsersPreferencesApartments (mail, profileType, Smoke, Animals, squareFt, Hobbies) VALUES ('" + mail + "', '" + profileType + "', '" + smoke + "', '" + pets + "', '" + sqft + "', '" + hobbies + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Returns profiles of a specific user using model execute query
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="userMail">The user mail</param>
        /// <returns>The users profiles in the specific interest area</returns>
        public DataTable getPreferencesForUserByType(string tableName, string userMail)
        {
            string query = "select * from UsersPreferences" + tableName + " where mail= '" + userMail + "'";
            return model.executeQuery(query);
        }

        /// <summary>
        /// Creates a new request by saving the request into the database using model execute non query
        /// </summary>
        /// <param name="userMail">The user mail</param>
        /// <param name="managerMail">The manager mail</param>
        /// <param name="content">The request content</param>
        /// <param name="interestArea">The interest area of the request</param>
        /// <param name="adId">The added advertisment ID</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewRequestForPartnerShip(string userMail, string managerMail, string content, string interestArea, string adId)
        {
            string command = "Insert Into Requests values('" + managerMail + "', '" + userMail + "', '" + interestArea + "', '" + content + "', '" + adId + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Returns the user preferences attached to a specific ad using model execute query
        /// </summary>
        /// <param name="userMail">The user mail</param>
        /// <param name="id">The request id</param>
        /// <param name="interestArea">The interest area of the request</param>
        /// <returns>The preferences of the specific user in specific interest area</returns>
        public DataTable getPreferencesForUserForAd(string userMail, string id, string interestArea)
        {
            string query = "select * from Requests" + " where userPreferenceID='" + userMail + "' and AdId='" + id + "' and InterestArea='" + interestArea + "'";
            return model.executeQuery(query);

        }

        /// <summary>
        /// Creates a new user profile by adding his profile preferences executing non query using model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="profileType">The type of the added profile</param>
        /// <param name="ageRange"></param>
        /// <param name="city"></param>
        /// <param name="gender"></param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewDatePreference(string mail, string profileType, string ageRange, string city, string gender)
        {
            string command = "Insert Into UsersPreferencesDates (mail, profileType, ageRange, city, Gender) VALUES ('" + mail + "', '" + profileType + "', '" + ageRange + "', '" + city + "', '" + gender + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Creates a new user profile by adding his profile preferences executing non query using model 
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="profileType">The type of the added profile</param>
        /// <param name="sportsType">The sports type</param>
        /// <param name="levelOfPlay">The level of play</param>
        /// <param name="activityTime">The activity time</param>
        /// <param name="city">The city of the event</param>
        /// <param name="location">The location of the event</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewSportsPreference(string mail, string profileType, string sportsType, string levelOfPlay, string activityTime, string city, string location)
        {
            string command = "Insert Into UsersPreferencesSports (mail, profileType, sportsType, levelOfPlay, activityTime,city,location) VALUES ('" + mail + "', '" + profileType + "', '" + sportsType + "', '" + levelOfPlay + "', '" + activityTime + "', '" + city + "', '" + location + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Creates a new user profile by adding his profile preferences executing non query using model 
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="profileType">The type of the added profile</param>
        /// <param name="destination">The destination of trip</param>
        /// <param name="dateOfDeparture">The departure date</param>
        /// <param name="dateOfReturn">The estimated return date</param>
        /// <param name="gender">The requested gender to travel with</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewTripsPreference(string mail, string profileType, string destination, string dateOfDeparture, string dateOfReturn, string gender)
        {
            string command = "Insert Into UsersPreferencesTrips (mail, profileType, Country, dateOfDeparture, estimatedReturnTime,gender) VALUES ('" + mail + "', '" + profileType + "', '" + destination + "', '" + dateOfDeparture + "', '" + dateOfReturn + "', '" + gender + "')";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Gets all of the user profiles in a specific interest area executing query using model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="tableName">The interest area to extract from</param>
        /// <returns>The profiles in the specific interest area</returns>
        public DataTable getProfilesByArea(string mail, string tableName)
        {
            string query = "select * from UsersPreferences" + tableName + " where mail= '" + mail + "'";
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns all of the manager profiles preferences of a specific user executing query using model
        /// </summary>
        /// <param name="managerMail">The managers mail</param>
        /// <param name="tableName">The interest area</param>
        /// <returns>The manager profiles of the user</returns>
        public DataTable getManagersPreferencesByMail(string managerMail, string tableName)
        {
            string menager = "מנהל שותפות";
            string query = "select * from UsersPreferences" + tableName + " where mail= '" + managerMail + "' and profileType= '" + menager + "'";
            return model.executeQuery(query);
        }


        /// <summary>
        /// get the the partnership by the guven filed
        /// </summary>
        /// <param name="managerMail">guven manager mail</param>
        /// <param name="data">guven data</param>
        /// <param name="tableName">guvem area table name</param>
        /// <returns></returns>
        public DataTable getPartnershipByFildes(string managerMail, List<string> data, string tableName)
        {
            string query = "";
            if (tableName == "Apartments")
            {
                query = "select * from PartnershipsApartments where managerEmail= '" + managerMail + "' and City='" + data[0] + "' and Street= '" + data[1] + "' and houseNumber= " + data[2] + " and Furniture= '" + data[3] + "' and Floor= " + data[4] + " and smoke= '" + data[5] + "' and animals= '" + data[6] + "' and squareFt= '" + data[7] + "' and numberOfPartners= " + data[8];
            }
            else if (tableName == "Dates")
            {
                query = "select * from PartnershipsDates where managerEmail= '" + managerMail + "' and city= '" + data[0] + "' and ageRange= '" + data[1] + "-" + data[2] + "' and requestedGender= '" + data[3] + "' and numberOfPartners=" + data[4] + "";
            }
            else if (tableName == "Sports")
            {
                query = "select * from PartnershipsSports where managerEmail= '" + managerMail + "' and city= '" + data[0] + "' and sportsName= '" + data[1] + "' and meetingTime= '" + data[2] + "' and levelOfPlay= '" + data[3] + "' and numberOfPartners= " + data[4] + "";
            }
            else if (tableName == "Trips")
            {
                query = "select * from PartnershipsTrips where managerEmail= '" + managerMail + "' and city= '" + data[0] + "' and country= '" + data[1] + "' and departureDate= '" + data[2] + "' and returnDate= '" + data[3] + "' and numberOfPartners= " + data[4] + "";
            }
            return model.executeQuery(query);
        }

        /// <summary>
        /// Creates new partnership in a specific interest area with a specific manager executing non query using model
        /// </summary>
        /// <param name="managerMail">The managers mail</param>
        /// <param name="data">The data to add to the table</param>
        /// <param name="tableName">The interest area</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool createNewPartnership(string managerMail, List<string> data, string tableName)
        {
            string command = "";
            if (tableName == "Apartments")
            {
                command = "Insert Into PartnershipsApartments (managerEmail, City, Street, houseNumber , Furniture, Floor , smoke, animals, squareFt, numberOfPartners) VALUES ('" + managerMail + "', '" + data[0] + "', '" + data[1] + "', '" + data[2] + "', '" + data[3] + "', '" + data[4] + "', '" + data[5] + "', '" + data[6] + "', '" + data[7] + "', '" + data[8] + "')";
            }
            else if (tableName == "Dates")
            {
                command = "Insert Into PartnershipsDates (managerEmail, city, ageRange, requestedGender, numberOfPartners) VALUES ('" + managerMail + "', '" + data[0] + "', '" + data[1] + "-" + data[2] + "', '" + data[3] + "', '" + data[4] + "')";
            }
            else if (tableName == "Sports")
            {
                command = "Insert Into PartnershipsSports (managerEmail, city, sportsName, meetingTime, levelOfPlay, numberOfPartners) VALUES ('" + managerMail + "', '" + data[0] + "', '" + data[1] + "', '" + data[2] + "', '" + data[3] + "', '" + data[4] + "')";
            }
            else if (tableName == "Trips")
            {
                command = "Insert Into PartnershipsTrips (managerEmail, city, country, departureDate, returnDate, numberOfPartners) VALUES ('" + managerMail + "', '" + data[0] + "', '" + data[1] + "', '" + data[2] + "', '" + data[3] + "', '" + data[4] + "')";
            }
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Returns the partnership of a user with the specific preference ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="preferceId">The preference ID</param>
        /// <returns>The partnership</returns>
        public DataTable getPartnershipsIdByPreferenceId(string type, string preferceId)
        {
            string query = "select * from Partners" + type + " where ID_Preferences=" + preferceId;
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns the partnership in a specific interest area with the specific ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="id">The partnership ID</param>
        /// <returns>The partnership</returns>
        public DataTable getPartnershipById(string type, string id)
        {
            string query = "select * from Partnerships" + type + " where ID= " + id;
            return model.executeQuery(query);
        }

        /// <summary>
        /// Returns the partners of the specific interest area with the specific partnership ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="id">The partnership ID</param>
        /// <returns>The partners of the partnership</returns>
        public DataTable getPartnersFromPartnershipById(string type, string id)
        {
            string query = "select * from Partners" + type + " where ID_Partnership= " + id;
            return model.executeQuery(query);
        }

        /// <summary>
        /// Adds a new partner to the partnership executing non query using model 
        /// </summary>
        /// <param name="partnerId">The partner ID</param>
        /// <param name="partnershipId">The ID of the partnership</param>
        /// <param name="type">The interest area</param>
        /// <returns>True for succesful add otherwise false</returns>
        public bool AddNewPartnerToPartnerShip(string partnerId, string partnershipId, string type)
        {
            string command = "Insert Into Partners" + type + " VALUES(" + partnershipId + ", " + partnerId + ")";
            return model.executeNonQuery(command);
        }

        /// <summary>
        /// Transfer messages from the model to the view to display
        /// </summary>
        /// <param name="text">text to display</param>
        public void Output(string text)
        {
            view.Output(text);
        }

    }
}
