using SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews.SpecificControlls;
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

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews
{
    /// <summary>
    /// Interaction logic for MonthView.xaml
    /// </summary>
    public partial class MonthView : UserControl
    {
        private List<DayElement> month;


        public MonthView(List<DayElement> month)
        {
            this.month = month;
            InitializeComponent();
            loadElements();
        }
        void loadElements()
        {
            UIGrid.Children.Clear();

            List<DayElement> dElemInWeek = new List<DayElement>();
            List<WeekCalendarView> wViews = new List<WeekCalendarView>();

            int pos = 0;
            foreach (DayElement d in month)
            {

                dElemInWeek.Add(d);
                pos++;

                if (pos == 7)
                {
                    WeekCalendarView wView = new WeekCalendarView(dElemInWeek.ToArray());
                    wViews.Add(wView);
                    dElemInWeek = new List<DayElement>();

                    pos = 0;
                }

            }

            int position = 0;
            foreach (WeekCalendarView wV in wViews)
            {
                UIGrid.Children.Add(wV);
                Grid.SetRow(wV, position);
                
                position++;
            }
        }
    }
}
