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

namespace SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews.SpecificControlls
{
    /// <summary>
    /// Interaction logic for DayElementView.xaml
    /// </summary>
    public partial class DayElementView : UserControl
    {
        private DayElement d;
        public DayElementView(DayElement d)
        {

            this.d = d;

            InitializeComponent();
            loadComponements();

            if (d.isTheSameDay)
            {
                UIGrid.Background = new SolidColorBrush(UISettings.isSameDayColor);
            }
            else
            if (d.isSameMonth == false)
            {
                UIGrid.Background = new SolidColorBrush(UISettings.isDifferentMontColor);
            }
            else
            {
                UIGrid.Background = new SolidColorBrush(UISettings.defaultColor);
            }

            UIBorder.Background = new SolidColorBrush(UISettings.defaultBorderColor);
        }


        public void loadComponements()
        {
            tbDay.Text = d.name;
            tbDate.Text = d.dateTime.ToShortDateString();

            UIStackDayEvents.Children.Clear();
            foreach (calendarObject element in d.cobjs)
            {
                if (element != null)
                {
                    SmallCalendarView scView = new SmallCalendarView(element);

                    if (Core.Date.isDateBetween(element, d.dateTime.Date) == false)
                    { scView.Visibility = Visibility.Hidden; }

                    scView.Height = 30;

                    UIStackDayEvents.Children.Add(scView);
                }
            }
        }
    }
}
