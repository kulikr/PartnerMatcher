using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for Search_window.xaml
    /// </summary>
    public partial class Search_window : Window
    {
        IController controller;
        OleDbConnection connection;
        Dictionary<string, string> interestArea;
        public Search_window(IController _controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            controller = _controller;

            string connectionString = PartnerMatcher.Properties.Settings.Default.DBconnection;
            connection = new OleDbConnection(connectionString);
            try
            {
                interestArea = new Dictionary<string, string>();
                connection.Open();
                getPossibleInterestAreas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// This function implements the query which gets the current interest areas in the DB
        /// </summary>
        /// <param name="connection">The DB connection</param>
        private void getPossibleInterestAreas()
        {
            OleDbCommand command = new OleDbCommand("select * from InterestArea", connection);
            OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            DataRow[] rows = dt.Select();
            HashSet<string> areas = new HashSet<string>();
            foreach (DataRow dr in rows)
            {
                areas.Add(dr[1].ToString());
                interestArea.Add(dr[1].ToString(), dr[0].ToString());
            }
            box_interest.ItemsSource = areas;
        }

        /// <summary>
        /// This function sets the possible location of partnership for each interest area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void box_interestSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand("select city from Partnerships" + interestArea[box_interest.SelectedItem.ToString()], connection);
            OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            DataRow[] rows = dt.Select();
            if (rows.Length == 0)
            {
                box_location.Visibility = Visibility.Hidden;
                header_location.Visibility = Visibility.Hidden;
                MessageBox.Show(" לא קיימות מודעות שותפות בתחום זה. אנא נסה במועד מאוחר יותר");
            }
            else
            {
                box_location.Visibility = Visibility.Visible;
                header_location.Visibility = Visibility.Visible;
            }
            HashSet<string> locations = new HashSet<string>();
            foreach (DataRow dr in rows)
            {
                locations.Add(dr[0].ToString());
            }
            box_location.ItemsSource = locations;
        }

        private void box_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.Visibility = Visibility.Hidden;
            if (box_location.SelectedItem != null)
            {
                if (box_location.SelectedItem.ToString() != "")
                {
                    b_showResults.Visibility = Visibility.Visible;
                }
                else
                    b_showResults.Visibility = Visibility.Hidden;
            }
            else
                b_showResults.Visibility = Visibility.Hidden;
        }

        private void b_showResults_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand command = new OleDbCommand("select * from Partnerships" + interestArea[box_interest.SelectedItem.ToString()] + " where City = '" + box_location.SelectedItem + "'", connection);
            OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            DataRow[] rows = dt.Select();
            List<advertisment> ads = new List<advertisment>();
            //Get all the relevant data for an advertisment to display
            foreach (DataRow r in rows)
            {
                advertisment a = new advertisment()
                {
                    Id = r[0].ToString(),
                    ManagerMail = r[1].ToString(),
                    City = r[2].ToString(),
                    Date = r[3].ToString(),
                    Type = interestArea[box_interest.SelectedItem.ToString()]
                };
                ads.Add(a);
            }
            listView.ItemsSource = ads;
            listView.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            advertisment ad = button.DataContext as advertisment;
            OleDbCommand command = new OleDbCommand("select * from Partnerships" + ad.Type + " where ID = " + ad.Id, connection);
            OleDbDataAdapter tableAdapter = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            DataRow[] rows = dt.Select();
            ViewPartnership vp = new ViewPartnership(rows[0]);
            vp.Show();

        }
    }
}

public class advertisment
{
    public string Id { get; set; }
    public string Date { get; set; }
    public string City { get; set; }
    public string ManagerMail { get; set; }

    public string Type { get; set; }
}
