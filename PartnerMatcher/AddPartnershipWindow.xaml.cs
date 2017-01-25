using PartnerMatcher.myController;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddPartnershipWindow.xaml
    /// </summary>
    public partial class AddPartnershipWindow : Window
    {
        IController controller;
        Profile profile;
        string tableName;

        /// <summary>
        /// Add Partnership Window ctor
        /// </summary>
        /// <param name="profile">profile of the user</param>
        /// <param name="controller">controller for the view layer</param>
        public AddPartnershipWindow(Profile profile, IController controller)
        {
            this.controller = controller;
            this.profile = profile;
            InitializeComponent();
            headline.Text = headline.Text + " " + profile.Area;

            //extruct the table name from db
            DataTable areas = controller.getAreas();
            foreach (DataRow row in areas.Rows)
                if (row[1].ToString() == profile.Area)
                {
                    tableName = row[0].ToString();
                    break;
                }

            if (profile.Area == "דיור")
                apartmentsInit();
            else if (profile.Area == "דייטים")
                datesInit();
            else if (profile.Area == "ספורט")
                sportInit();
            else if (profile.Area == "טיולים")
                tripsInit();
        }

        #region Aprtments
        /// <summary>
        /// appartments data init
        /// </summary>
        private void apartmentsInit()
        {
            if (profile.Type != "מנהל שותפות")
            {
                sp_text.Children.Add(new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + "מייל מנהל",
                    FontSize = 14,
                    Height = 26,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                });
                sp_data.Children.Add(new TextBox()
                {
                    Name = "tb_managerMail",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Height = 26,
                    Text = "",
                    Width = 176
                });
            }

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "עיר",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_city",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "רחוב",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_street",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מספר בית",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_houseNumber",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "ריהוט",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_furniture",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "קומה",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_floor",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מעשנים בדירה",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            ComboBox smoking = new ComboBox()
            {
                Name = "cb_smoking",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            };
            smoking.ItemsSource = new List<string>(new string[2] { "כן", "לא" });
            sp_data.Children.Add(smoking);

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "בעלי חיים בדירה",
                FontSize = 14,

                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            ComboBox animals = new ComboBox()
            {
                Name = "cb_animals",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            };
            animals.ItemsSource = new List<string>(new string[2] { "כן", "לא" });
            sp_data.Children.Add(animals);

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מטר רבוע",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_squareFt",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מספר שותפים",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_numOfPartners",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            });
        }

        /// <summary>
        /// get data from window
        /// </summary>
        private void apartmentsFinish()
        {
            int numOfChildren;
            if (profile.Type != "מנהל שותפות")
                numOfChildren = 10;
            else
                numOfChildren = 9;

            List<string> data = new List<string>();
            for (int i = 0; i < numOfChildren; i++)
            {
                if (sp_data.Children[i] is TextBox)
                    data.Add((sp_data.Children[i] as TextBox).Text);
                else
                    data.Add((sp_data.Children[i] as ComboBox).Text);
            }
            if (!validInputAprt(data))
                return;
            AddPartnership(data);
        }

       /// <summary>
       /// validate input data
       /// </summary>
       /// <param name="data">data to test</param>
       /// <returns>if the data is valid</returns>
        private bool validInputAprt(List<string> data)
        {
            foreach (string str in data)
            {
                if (str == "")
                {
                    MessageBox.Show("אנא וודא שהזנת את כל השדות");
                    return false;
                }
            }

            if (data.Count == 10 && !isMenagerMailValid(data[0]))
            {
                MessageBox.Show("המייל מנהל שהוזן אינו תקין, אנא הזן מייל שוב");
                return false;
            }

            int tmp;
            if (!Int32.TryParse(data[data.Count - 7], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר בית' הינו מספר");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 5], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'קומה' הינו מספר");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 2], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מטר רבוע' הינו מספר");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 1], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר");
                return false;
            }
            else if (tmp < 2)
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר הגדול מ2 ");
                return false;
            }

            return true;
        }

        #endregion

        #region Trips
        /// <summary>
        /// trips data init
        /// </summary>
        private void tripsInit()
        {
            if (profile.Type != "מנהל שותפות")
            {
                sp_text.Children.Add(new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + "מייל מנהל",
                    FontSize = 14,
                    Height = 26,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                });
                sp_data.Children.Add(new TextBox()
                {
                    Name = "tb_managerMail",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Height = 26,
                    Text = "",
                    Width = 176
                });
            }

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "עיר",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_city",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "יעד",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_destenation",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "תאריך יציאה משוער",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new DatePicker()
            {
                Name = "tb_departueDate",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "תאריך חזרה משוער",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new DatePicker()
            {
                Name = "tb_returnDate",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מספר שותפים",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_numOfPartners",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            });

        }

        /// <summary>
        /// get data from window
        /// </summary>
        private void tripsFinish()
        {
            int numOfChildren;
            if (profile.Type != "מנהל שותפות")
                numOfChildren = 6;
            else
                numOfChildren = 5;

            List<string> data = new List<string>();
            for (int i = 0; i < numOfChildren; i++)
            {
                if (sp_data.Children[i] is TextBox)
                    data.Add((sp_data.Children[i] as TextBox).Text);
                else
                    data.Add((sp_data.Children[i] as DatePicker).Text);

            }
            if (!validInputTrip(data))
                return;
            AddPartnership(data);
        }

        /// <summary>
        /// validate input data
        /// </summary>
        /// <param name="data">data to test</param>
        /// <returns>if the data is valid</returns>
        private bool validInputTrip(List<string> data)
        {
            foreach (string str in data)
            {
                if (str == "")
                {
                    MessageBox.Show("אנא וודא שהזנת את כל השדות");
                    return false;
                }
            }

            if (data.Count == 6 && !isMenagerMailValid(data[0]))
            {
                MessageBox.Show("המייל מנהל שהוזן אינו תקין, אנא הזן מייל שוב");
                return false;
            }
            DateTime returnDate = DateTime.Parse(data[data.Count - 2]);
            DateTime departureDate = DateTime.Parse(data[data.Count - 3]);

            if (returnDate.Date < departureDate.Date)
            {
                MessageBox.Show("אנא וודא שהתאריך חזרה משוער מאוחר יותר מהתאריך יציאה משוער");
                return false;
            }

            if (returnDate.Date < DateTime.Now)
            {
                MessageBox.Show(" אנא וודא שתאריך החזרה המשוער גדול מהתאריך הנוכחי");
                return false;
            }

            if (departureDate.Date < DateTime.Now)
            {
                MessageBox.Show(" אנא וודא שתאריך היציאה המשוער גדול מהתאריך הנוכחי");
                return false;
            }

            int tmp;
            if (!Int32.TryParse(data[data.Count - 1], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר");
                return false;
            }
            else if (tmp < 2)
            {
                MessageBox.Show(" אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר הגדול מ2");
                return false;
            }



            return true;
        }

        #endregion

        #region Sports
        /// <summary>
        /// sports data init
        /// </summary>
        private void sportInit()
        {
            if (profile.Type != "מנהל שותפות")
            {
                sp_text.Children.Add(new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + "מייל מנהל",
                    FontSize = 14,
                    Height = 26,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                });
                sp_data.Children.Add(new TextBox()
                {
                    Name = "tb_managerMail",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Height = 26,
                    Text = "",
                    Width = 176
                });
            }

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "עיר",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_city",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "סוג הספורט",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_sportsName",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "תאריך הפעילות",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new DatePicker()
            {
                Name = "tb_activityTime",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "רמת המשחק",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            ComboBox levelOfPlay = new ComboBox()
            {
                Name = "cb_levelOfPlay",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            };
            levelOfPlay.ItemsSource = new string[] { "1", "2", "3", "4", "5" };
            sp_data.Children.Add(levelOfPlay);

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מספר שותפים",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_numOfPartners",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            });
        }

        /// <summary>
        /// get data from window
        /// </summary>
        private void sportFinish()
        {
            int numOfChildren;
            if (profile.Type != "מנהל שותפות")
                numOfChildren = 6;
            else
                numOfChildren = 5;

            List<string> data = new List<string>();
            for (int i = 0; i < numOfChildren; i++)
            {
                if (sp_data.Children[i] is TextBox)
                    data.Add((sp_data.Children[i] as TextBox).Text);
                else if ((sp_data.Children[i] is ComboBox))
                    data.Add((sp_data.Children[i] as ComboBox).Text);
                else
                    data.Add((sp_data.Children[i] as DatePicker).Text);

            }
            if (!validInputSport(data))
                return;
            AddPartnership(data);
        }

        /// <summary>
        /// Validate input data
        /// </summary>
        /// <param name="data">list of data</param>
        /// <returns>if data is valid</returns>
        private bool validInputSport(List<string> data)
        {
            foreach (string str in data)
            {
                if (str == "")
                {
                    MessageBox.Show("אנא וודא שהזנת את כל השדות");
                    return false;
                }
            }

            if (data.Count == 6 && !isMenagerMailValid(data[0]))
            {
                MessageBox.Show("המייל מנהל שהוזן אינו תקין, אנא הזן מייל שוב");
                return false;
            }

            int tmp;
            if (!Int32.TryParse(data[data.Count - 2], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'רמת משחק' הינו מספר");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 1], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר");
                return false;
            }
            else if (tmp < 2)
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר הגדול מ2");
                return false;
            }
            if (DateTime.Parse(data[data.Count - 3]).Date < DateTime.Now)
            {
                MessageBox.Show(" אנא וודא שתאריך המשחק גדול מהתאריך הנוכחי");
                return false;
            }

            return true;
        }

        #endregion

        #region Dates

        /// <summary>
        /// get data from window
        /// </summary>
        private void datesFinish()
        {
            int numOfChildren;
            if (profile.Type != "מנהל שותפות")
                numOfChildren = 6;
            else
                numOfChildren = 5;

            List<string> data = new List<string>();
            for (int i = 0; i < numOfChildren; i++)
            {
                if (sp_data.Children[i] is TextBox)
                    data.Add((sp_data.Children[i] as TextBox).Text);
                else
                    data.Add((sp_data.Children[i] as ComboBox).Text);

            }
            if (!validInputDate(data))
                return;
            AddPartnership(data);
        }

        /// <summary>
        /// validate input data
        /// </summary>
        /// <param name="data">data to test</param>
        /// <returns>if the data is valid</returns>
        private bool validInputDate(List<string> data)
        {
            foreach (string str in data)
            {
                if (str == "")
                {
                    MessageBox.Show("אנא וודא שהזנת את כל השדות");
                    return false;
                }
            }

            if (data.Count == 6 && !isMenagerMailValid(data[0]))
            {
                MessageBox.Show("המייל מנהל שהוזן אינו תקין, אנא הזן מייל שוב");
                return false;
            }

            int tmp;
            if (!Int32.TryParse(data[data.Count - 3], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'גיל מינימלי' הינו מספר");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 4], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'גיל מקסימלי' הינו מספר");
                return false;
            }
            if (data[data.Count - 4].CompareTo(data[data.Count - 3]) > 0)
            {
                MessageBox.Show("אנא וודא שהנתון 'גיל מקסימלי' גדול מהנתון 'גיל מינימלי', או שווה לו");
                return false;
            }
            if (!Int32.TryParse(data[data.Count - 1], out tmp))
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר");
                return false;
            }
            else if (tmp < 2)
            {
                MessageBox.Show("אנא וודא שהנתון שהזנת בשדה 'מספר שותפים' הינו מספר הגדול מ2");
                return false;
            }
            return true;
        }

        /// <summary>
        /// initialize dates
        /// </summary>
        private void datesInit()
        {
            if (profile.Type != "מנהל שותפות")
            {
                sp_text.Children.Add(new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Text = "        :  " + "מייל מנהל",
                    FontSize = 14,
                    Height = 26,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Guttman Aharoni")
                });
                sp_data.Children.Add(new TextBox()
                {
                    Name = "tb_managerMail",
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Right,
                    Height = 26,
                    Text = "",
                    Width = 176
                });
            }

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "עיר",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_city",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "גיל מינימלי",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_minAge",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "גיל מקסימלי",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_maxAge",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            });

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מין מועדף",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            ComboBox genders = new ComboBox()
            {
                Name = "cb_gender",
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 26,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Text = "",
                Width = 176
            };
            genders.ItemsSource = new List<string>(new string[2] { "זכר", "נקבה" });
            sp_data.Children.Add(genders);

            sp_text.Children.Add(new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Text = "        :  " + "מספר שותפים",
                FontSize = 14,
                Height = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Guttman Aharoni")
            });
            sp_data.Children.Add(new TextBox()
            {
                Name = "tb_numOfPartners",
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Height = 26,
                Text = "",
                Width = 176
            });
        }

        #endregion

        /// <summary>
        /// Call finish()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_finish_Click(object sender, RoutedEventArgs e)
        {
            if (profile.Area == "דיור")
                apartmentsFinish();
            else if (profile.Area == "דייטים")
                datesFinish();
            else if (profile.Area == "ספורט")
                sportFinish();
            else if (profile.Area == "טיולים")
                tripsFinish();
        }

        /// <summary>
        /// Insert data to the database
        /// </summary>
        /// <param name="data">list of data</param>
        private void AddPartnership(List<string> data)
        {
            string managerMail = profile.Mail;
            if (profile.Type != "מנהל שותפות")
            {
                managerMail = data[0];
                data.RemoveAt(0);
            }

            if (controller.createNewPartnership(managerMail, data, tableName))
            {
                DataTable dt = controller.getPartnershipByFildes(managerMail, data, tableName);
                if (dt != null)
                {
                    string partnershipId = dt.Rows[0][0].ToString();
                    if (managerMail == profile.Mail)
                    {
                        controller.AddNewPartnerToPartnerShip(profile.Id, partnershipId, tableName);
                    }
                    else
                    {
                        DataTable manager = controller.getManagersPreferencesByMail(managerMail, tableName);
                        string managerId = manager.Rows[0][0].ToString();
                        controller.AddNewPartnerToPartnerShip(managerId, partnershipId, tableName);
                        controller.AddNewPartnerToPartnerShip(profile.Id, partnershipId, tableName);
                    }
                    MessageBox.Show("השותפות נוצרה בהצלחה");
                    Close();
                    return;
                }
            }
            MessageBox.Show("משהו השתבש נסה שוב");
        }

        /// <summary>
        /// Validate manager mail
        /// </summary>
        /// <param name="menagerMail">manager mail</param>
        /// <returns>if the mail is valid</returns>
        private bool isMenagerMailValid(string menagerMail)
        {
            DataTable menager = controller.getManagersPreferencesByMail(menagerMail, tableName);
            return menager != null;
        }
    }
}

