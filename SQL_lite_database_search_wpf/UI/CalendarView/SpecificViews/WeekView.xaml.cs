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
        private List<DayElement> days;
        int UIElementHeight = 30;

        public WeekView(List<DayElement> days)
        {
            this.days = days;
            InitializeComponent();

            LoadElements();

        }
        void LoadElements()
        {
            UIGrid.Children.Clear();
            LoadDaysNames();
            LoadSpecificDayContent();
            LoadStaticContent();
            LoadBorders();
        }

        void LoadDaysNames()
        {
            int pos = 0;
            foreach (DayElement name in days)
            {
                TextBlock tb = new TextBlock()
                {
                    Background = new SolidColorBrush(UISettings.defaultColor),
                    Text = name.name
                };
                UIGrid.Children.Add(tb);

                Grid.SetColumn(tb, pos);
                Grid.SetRow(tb, 0);
                pos++;
            }
        }

        //TODO : to complete
        void LoadStaticContent()
        {
            for (int i = 0; i < 7; i++)
            {
                StackPanel sb = new StackPanel();

                foreach (calendarObject cObj in days[i].cobjsDifferentDays)
                {
                    SmallCalendarView sView = new SmallCalendarView(cObj, UIElementHeight);
                    sb.Children.Add(sView);
                }
                UIGrid.Children.Add(sb);
                Grid.SetColumn(sb, i);
                Grid.SetRow(sb, 1);
            }
        }
        void LoadSpecificDayContent()
        {
            for (int i = 0; i < 7; i++)
            {
                StackPanel sb = new StackPanel();

                foreach (calendarObject cObj in days[i].cobjOneDay)
                {
                    SmallCalendarView sView = new SmallCalendarView(cObj, UIElementHeight);
                    sb.Children.Add(sView);
                }
                UIGrid.Children.Add(sb);
                Grid.SetColumn(sb, i);
                Grid.SetRow(sb, 2);
            }
        }
        void LoadBorders()
        {
            for (int i = 0; i < 7; i++)
            {

                Border b = new Border()
                {
                    BorderThickness = new Thickness(5),
                    BorderBrush = new SolidColorBrush(UISettings.defaultBorderColor)
                };
                UIGrid.Children.Add(b);
                Grid.SetColumn(b, i);
            }
        }
    }
}
