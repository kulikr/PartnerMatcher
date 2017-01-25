using PartnerMatcher.myModel;
using PartnerMatcher.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.myController
{
    /// <summary>
    /// Defines the functionality of the controller in the system
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Sets the controller view
        /// </summary>
        /// <param name="_view">The view to set</param>
        void setView(IView _view);

        /// <summary>
        /// Sets the controller model
        /// </summary>
        /// <param name="_model">The model to set</param>
        void setModel(IModel _model);

        /// <summary>
        /// Retruns the first name of the user with the specific mail from the database executing a query
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <returns>The users first name</returns>
        DataTable getFirstNameData(string mail);

        /// <summary>
        /// Returns the details of the user with the specific email and password from the database executing a query
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="password">The user password</param>
        /// <returns>The user details</returns>
        DataTable connect(string mail, string password);

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
        bool createNewUser(string mail, string password, string firstName, string lastName, string birthDate, string city, string phone);

        /// <summary>
        /// Sends an confirmation mail using the model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="firstName">The user first name</param>
        /// <returns>True for succesful send otherwise false</returns>
        bool sendConfirmationMail(string mail, string firstName);

        /// <summary>
        /// Returns the interest areas in the partnerMatcher system using model execute query
        /// </summary>
        /// <returns>The interest areas</returns>
        DataTable getAreas();

        /// <summary>
        /// Return the advertisments published in the system on the specific interest area using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <param name="id">advertisment id</param>
        /// <returns>The advertisments of the specific interest area</returns>
        DataTable getAdvertisments(string type, string id);

        /// <summary>
        /// Returns from the database partnership in a specific type in a specific city using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <param name="city">ciry where the partnership is in</param>
        /// <returns>The partnerships in the specific city</returns>
        DataTable getPartnershipsByCity(string type, string city);

        /// <summary>
        /// Returns all the cities of all the partnerships using model execute query
        /// </summary>
        /// <param name="type">user field of interest</param>
        /// <returns>all the cities of all the partnerships</returns>
        DataTable getCitiesPartnerShips(string type);

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
        bool createNewAppartmentPreference(string mail, string profileType, string smoke, string pets, string sqft, string hobbies);

        /// <summary>
        /// Creates a new request by saving the request into the database using model execute non query
        /// </summary>
        /// <param name="userMail">The user mail</param>
        /// <param name="managerMail">The manager mail</param>
        /// <param name="content">The request content</param>
        /// <param name="interestArea">The interest area of the request</param>
        /// <param name="adId">The added advertisment ID</param>
        /// <returns>True for succesful add otherwise false</returns>
        bool createNewRequestForPartnerShip(string userMail, string managerMail, string content, string interestArea, string adId);

        /// <summary>
        /// Returns the user preferences attached to a specific ad using model execute query
        /// </summary>
        /// <param name="userMail">The user mail</param>
        /// <param name="id">The request id</param>
        /// <param name="interestArea">The interest area of the request</param>
        /// <returns>The preferences of the specific user in specific interest area</returns>
        DataTable getPreferencesForUserForAd(string userMail, string id, string interestArea);

        /// <summary>
        /// Returns profiles of a specific user using model execute query
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="userMail">The user mail</param>
        /// <returns>The users profiles in the specific interest area</returns>
        DataTable getPreferencesForUserByType(string type, string userMail);

        /// <summary>
        /// Creates a new user profile by adding his profile preferences executing non query using model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="profileType">The type of the added profile</param>
        /// <param name="ageRange"></param>
        /// <param name="city"></param>
        /// <param name="gender"></param>
        /// <returns>True for succesful add otherwise false</returns>
        bool createNewDatePreference(string mail, string profileType, string ageRange, string city, string gender);

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
        bool createNewSportsPreference(string mail, string profileType, string sportsType, string levelOfPlay, string activityTime, string city, string location);

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
        bool createNewTripsPreference(string mail, string profileType, string destination, string dateOfDeparture, string dateOfReturn, string gender);

        /// <summary>
        /// Gets all of the user profiles in a specific interest area executing query using model
        /// </summary>
        /// <param name="mail">The user mail</param>
        /// <param name="tableName">The interest area to extract from</param>
        /// <returns>The profiles in the specific interest area</returns>
        DataTable getProfilesByArea(string mail, string tableName);

        /// <summary>
        /// Returns all of the manager profiles preferences of a specific user executing query using model
        /// </summary>
        /// <param name="managerMail">The managers mail</param>
        /// <param name="tableName">The interest area</param>
        /// <returns>The manager profiles of the user</returns>
        DataTable getManagersPreferencesByMail(string managerMail, string tableName);

        /// <summary>
        /// Creates new partnership in a specific interest area with a specific manager executing non query using model
        /// </summary>
        /// <param name="managerMail">The managers mail</param>
        /// <param name="data">The data to add to the table</param>
        /// <param name="tableName">The interest area</param>
        /// <returns>True for succesful add otherwise false</returns>
        bool createNewPartnership(string managerMail, List<string> data, string tableName);

        /// <summary>
        /// Returns the partnership of a user with the specific preference ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="preferceId">The preference ID</param>
        /// <returns>The partnership</returns>
        DataTable getPartnershipsIdByPreferenceId(string type, string preferceId);

        /// <summary>
        /// Returns the partnership in a specific interest area with the specific ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="id">The partnership ID</param>
        /// <returns>The partnership</returns>
        DataTable getPartnershipById(string type, string id);

        /// <summary>
        /// Returns the partners of the specific interest area with the specific partnership ID executing query using model
        /// </summary>
        /// <param name="type">The interest area of the partnership</param>
        /// <param name="id">The partnership ID</param>
        /// <returns>The partners of the partnership</returns>
        DataTable getPartnersFromPartnershipById(string type, string id);

        /// <summary>
        /// Adds a new partner to the partnership executing non query using model 
        /// </summary>
        /// <param name="partnerId">The partner ID</param>
        /// <param name="partnershipId">The ID of the partnership</param>
        /// <param name="type">The interest area</param>
        /// <returns>True for succesful add otherwise false</returns>
        bool AddNewPartnerToPartnerShip(string partnerId, string partnershipId, string type);

        /// <summary>
        /// get the the partnership by the guven filed
        /// </summary>
        /// <param name="managerMail">guven manager mail</param>
        /// <param name="data">guven data</param>
        /// <param name="tableName">guvem area table name</param>
        /// <returns></returns>
       DataTable getPartnershipByFildes(string managerMail, List<string> data, string tableName);

       /// <summary>
       /// Transfer messages from the model to the view to display
       /// </summary>
       /// <param name="text">text to display</param>
       void Output(string text);
    }
}
