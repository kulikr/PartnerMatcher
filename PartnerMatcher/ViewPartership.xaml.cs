using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for ViewPartership.xaml
    /// </summary>
    public partial class ViewPartership : Window
    {
        Dictionary<string, string> _fields = new Dictionary<string, string>();
        public ViewPartership(DataRow r)
        {
            fillFields();
            InitializeComponent();
            for (int i = 0; i < r.Table.Columns.Count; i++)
            {
                TextBlock text = new TextBlock();
                text.HorizontalAlignment = HorizontalAlignment.Right;
                text.Text = r[i].ToString();
                TextBlock field = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + _fields[r.Table.Columns[i].ToString()],
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                };
                textStack.Children.Add(text);
                fieldsStack.Children.Add(field);
            }

        }

        private void fillFields()
        {
            _fields.Add("ID", "מספר מזהה");
            _fields.Add("managerEmail", "מייל מנהל");
            _fields.Add("city", "עיר");
            _fields.Add("City", "עיר");
            _fields.Add("publishDate", "תאריך פרסום מודעה");
            _fields.Add("returnDate", "תאריך חזרה");
            _fields.Add("departureDate", "תאריך יציאה");
            _fields.Add("Street", "רחוב");
            _fields.Add("houseNumber", "מספר בית");
            _fields.Add("Furniture", "ריהוט");
            _fields.Add("Floor", "קומה");
            _fields.Add("sportsName", "סוג ספורט");
            _fields.Add("meetingTime", "זמן מפגש");
        }
    }
}
