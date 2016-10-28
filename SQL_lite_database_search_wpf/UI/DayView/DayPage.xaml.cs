using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQL_lite_database_search_wpf.UI.DayView
{
    /// <summary>
    /// Interaction logic for DayPage.xaml
    /// </summary>
    public partial class DayPage : UserControl
    {
        List<Day> days = new List<Day>();

        public DayPage()
        {
            InitializeComponent();
            setElements();
            loadElements();
        }
        public void loadElements()
        {

            foreach (Day d in days)
            {
                DayUI day = new DayUI(d);
                DayList.Children.Add(day);
            }

        }
        public void setElements()
        {
            string dayW = DateTime.Today.DayOfWeek.ToString();

            int dayPos = 0;

            string[] daysName = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (daysName.Contains(dayW))
            {
                for (int i = 0; i < daysName.Length; i++)
                {
                    if (dayW == daysName[i]) { dayPos = i; }
                }
            }

            for (int i = 0; i < daysName.Length; i++)
            {
                Day day = new Day();
                day.name = daysName[i];

                day.Date = DateTime.Today.AddDays(i - dayPos);
                days.Add(day);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
