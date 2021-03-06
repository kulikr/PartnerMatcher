﻿using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net.Mail;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for ViewPartnership.xaml
    /// </summary>
    public partial class ViewPartnership : Window
    {
        Dictionary<string, string> _fields = new Dictionary<string, string>();
        string _partnershipManagerMail;
        IController _controler;
        string _userField;
        string _userMail;
        string _partnershipId;
        bool _isAd;
        string _numOfPartners;

        /// <summary>
        /// View partnership constructor
        /// </summary>
        /// <param name="controller">controler for the view level</param>
        /// <param name="r"> data row that represnts this partnership</param>
        /// <param name="id">partnership id</param>
        /// <param name="userMail">user mail of the partnership viewer</param>
        /// <param name="userField">area of interest</param>
        /// <param name="managerMail">partnership manager mail</param>
        /// <param name="isAd">is this view is an advertisment view</param>
        /// <param name="numofPartners">number of partners in this partnership</param>
        public ViewPartnership(ref IController controller, DataRow r, string id, string userMail, string userField, string managerMail, bool isAd, string numofPartners)
        {
            initDictionary();
            _partnershipId = id;
            _isAd = isAd;
            _numOfPartners = numofPartners;
            _partnershipManagerMail = managerMail;
            _controler = controller;
            _userField = userField;
            _userMail = userMail;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            //display partnership content
            for (int i = 0; i < r.Table.Columns.Count; i++)
            {
                TextBlock text = new TextBlock()
                {
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                };
                text.HorizontalAlignment = HorizontalAlignment.Right;
                text.Text = r[i].ToString();
                TextBlock field = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + _fields[r.Table.Columns[i].ToString().ToLower()],
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                };
                textStack.Children.Add(text);
                fieldsStack.Children.Add(field);
            }
            if (isAd) // advertiament watch
                requets_button.Visibility = Visibility.Visible;
            else
            { //partnership watch
                addPartner_block.Visibility = Visibility.Visible;
                OK_button.Visibility = Visibility.Visible;
                partnerMailTextBox.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// Dictionary to display the fields in hebrew
        /// </summary>
        private void initDictionary()
        {
            _fields.Add("id", "מספר מזהה");
            _fields.Add("manageremail", "מייל מנהל");
            _fields.Add("city", "עיר");
            _fields.Add("publishdate", "תאריך פרסום מודעה");
            _fields.Add("returndate", "תאריך חזרה");
            _fields.Add("departuredate", "תאריך יציאה");
            _fields.Add("street", "רחוב");
            _fields.Add("housenumber", "מספר בית");
            _fields.Add("furniture", "ריהוט");
            _fields.Add("floor", "קומה");
            _fields.Add("smoke", "עישון");
            _fields.Add("sportsname", "סוג ספורט");
            _fields.Add("meetingtime", "זמן מפגש");
            _fields.Add("requestedgender", "מין מועדף");
            _fields.Add("squareft", "מטר רבוע");
            _fields.Add("agerange", "טווח גילאים");
            _fields.Add("country", "ארץ");
            _fields.Add("animals", "בעלי חיים");
            _fields.Add("levelofplay", "רמת משחק");
            _fields.Add("numberofpartners", "מספר שותפים");
        }

        /// <summary>
        /// In case this is an advertisment view, when the aplly to join to the partnership button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void requets_button_Click(object sender, RoutedEventArgs e)
        {
            //check if the user is looking for partnership and didn't already apply for request
            bool isSerachingPartnership = false;
            DataTable dt = _controler.getPreferencesForUserByType(_userField, _userMail);
            DataTable dtReq = _controler.getPreferencesForUserForAd(_userMail, _partnershipId, _userField);
            if (dtReq == null && dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[2] != null && dr[2].Equals("מחפש שותפות"))
                    {
                        isSerachingPartnership = true;
                    }
                }
            }
            if (dt == null)
            {
                MessageBox.Show("על מנת להגיש בקשה שותפות עלייך לפתוח פרופיל מחפש שותפות בתחום זה.");
            }
            else if (dtReq != null)
            {
                MessageBox.Show("כבר הגשת בקשה לשותפות למודעה זו.");
            }
            else if (!isSerachingPartnership)
            {
                MessageBox.Show("על מנת להגיש בקשה שותפות עלייך לפתוח פרופיל מחפש שותפות בתחום זה.");
            }
            else
            {
                RequestWindow rw = new RequestWindow(ref _controler, _userMail, _userField, _partnershipManagerMail, _partnershipId);
                rw.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Incase this is a view partnership watch, and the user wants to add a partner to the partnership
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            //Enter mail adress
            if (partnerMailTextBox.Text == string.Empty)
            {
                MessageBox.Show("אנא הכנס מייל שותף קודם");
            }
            else
            {
                //Get the partnership details
                DataTable dt = _controler.getPartnersFromPartnershipById(_userField, _partnershipId);
                if (dt != null && dt.Rows.Count > Convert.ToInt32(_numOfPartners))
                {
                    MessageBox.Show("מספר השותפים בשותפות מלא, על מנת לשנות זאת ערוך את מספר השותפים בשותפות");
                }
                else
                {
                    try
                    {
                        //check if a relevant profile exists
                        string partnerMail = partnerMailTextBox.Text;
                        MailAddress ma = new MailAddress(partnerMail);
                        DataTable partnerProfile = _controler.getPreferencesForUserByType(_userField, partnerMail);
                        DataTable checkIfPartnerAlreadyExists = _controler.getPartnersFromPartnershipById(_userField, _partnershipId);
                        if (partnerProfile == null)
                        {
                            MessageBox.Show("למייל זה לא קיימים פרופילים בתחום זה במערכת");
                        }
                        else
                        {
                            if (checkIfPartnerAlreadyExists != null)
                            {
                                foreach (DataRow r in checkIfPartnerAlreadyExists.Rows)
                                {
                                    string prefId = partnerProfile.Select()[0][0].ToString();
                                    if (r[1].ToString().Equals(prefId))
                                    {
                                        MessageBox.Show("מייל של שותף זה כבר שותף בשותפות זו.");
                                        return;
                                    }
                                }
                            }
                            //check if the profile is an active partner profile 
                            bool isActivePartner = false;
                            foreach (DataRow r in partnerProfile.Rows)
                            {
                                if (r[2].ToString().Equals("שותף פעיל"))
                                {
                                    isActivePartner = true;
                                    string id = r[0].ToString();
                                    bool succese = _controler.AddNewPartnerToPartnerShip(id, _partnershipId, _userField);
                                    if (succese)
                                    {
                                        MessageBox.Show("השותף נוסף לשותפות בהצלחה!");
                                        return;
                                    }

                                }
                            }
                            if (!isActivePartner)
                            {
                                MessageBox.Show("למייל זה לא קיים פרופיל שותף פעיל בתחום זה במערכת");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("כתובת המייל לא הוכנסה בפורמט תקין");
                    }
                }
            }
        }
    }
}
