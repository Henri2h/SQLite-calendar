using SQL_lite_database_search_wpf.UI.DayView;
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

namespace SQL_lite_database_search_wpf.UI
{
    /// <summary>
    /// Interaction logic for DayUI.xaml
    /// </summary>
    public partial class DayUI : Grid
    {
        public List<calendarObject> elements = new List<calendarObject>();

        public Day day { get; set; }

        public DayUI(Day dayInput)
        {
            day = dayInput;

            InitializeComponent();


            loadComponements();

        }



        public void loadComponements()
        {
            tbDay.Text = day.name;
            tbDate.Text = day.Date.ToShortDateString();

            UIStackDayEvents.Children.Clear();
            foreach (calendarObject element in elements)
            {
                SmallCalendarView scView = new SmallCalendarView(element);
              
                if (Core.Date.isDateBetween(element, day.Date.Date) == false)
                { scView.Visibility = Visibility.Hidden; }

                UIStackDayEvents.Children.Add(scView);

            }
        }
    }
}
