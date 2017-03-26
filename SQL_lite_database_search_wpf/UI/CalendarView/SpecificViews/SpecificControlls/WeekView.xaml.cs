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
    /// Interaction logic for WeekView.xaml
    /// </summary>
    public partial class WeekCalendarView : UserControl
    {
        private DayElement[] dayElement;


        public WeekCalendarView(DayElement[] elements)
        {
            InitializeComponent();

            if (elements.Length == 7)
                for (int i = 0; i < 7; i++)
                {
                    addChildren(elements[i], i);
                }
        }
        void addChildren(DayElement d, int pos)
        {
            DayElementView dayElement = new DayElementView(d);
            UIGrid.Children.Add(dayElement);
            Grid.SetColumn(dayElement, pos);
        }
    }
}
