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
    /// Interaction logic for WeekView.xaml
    /// </summary>
    public partial class WeekView : UserControl
    {
        private CalendarContent days;


        public WeekView(CalendarContent days)
        {
            this.days = days;
            InitializeComponent();
            loadElements();

            loadDaysNames();
        }
        void loadElements()
        {
            //  WeekCalendarView wViews = new WeekCalendarView(days, CalendarViewCore.CalendarViewMethods.week);

        }

        void loadDaysNames()
        {
            int pos = 0;
            foreach (string name in days.dayNames)
            {
                TextBlock tb = new TextBlock();
                tb.Text = name;
                UIGrid.Children.Add(tb);
                Grid.SetColumn(tb, pos);
                Grid.SetRow(tb, 0);
                pos++;
            }
        }

        void loadStaticContent()
        {
            for (int i = 0; i < 7; i++)
            {
                StackPanel sb = new StackPanel();

            }
        }
        void loadSpecificDayContent() { }
    }
}
