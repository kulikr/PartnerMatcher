using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PartnerMatcher.myController;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        private IController _controler;
        private string _partnershipManagerMail;
        private string _userField;
        private string _userMail;
        string _adId;

        /// <summary>
        /// This window opens when a user wants to requet to join a partnership
        /// </summary>
        /// <param name="_controler">controler for the view layer</param>
        /// <param name="_userMail">current user thar asks to join mail adress</param>
        /// <param name="_userField">interest area</param>
        /// <param name="_partnershipManagerMail">partnership manager mail</param>
        /// <param name="adId"></param>
        public RequestWindow(ref IController _controler, string _userMail, string _userField, string _partnershipManagerMail, string adId)
        {
            InitializeComponent();
            _adId = adId;
            this._controler = _controler;
            this._userMail = _userMail;
            this._userField = _userField;
            this._partnershipManagerMail = _partnershipManagerMail;
        }

        /// <summary>
        /// when launch request button was clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void launch_request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool succeede = _controler.createNewRequestForPartnerShip(_userMail, _partnershipManagerMail, request_text.Text, _userField, _adId);
                if (!succeede)
                {
                    MessageBox.Show("משהוא השתבש, אנא נסה שנית.");
                }
                else
                {
                    MessageBox.Show("הבקשה נשלחה בהצלחה.");
                }
                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
