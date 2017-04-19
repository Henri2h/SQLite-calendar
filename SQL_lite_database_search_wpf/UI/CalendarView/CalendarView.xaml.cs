using SQL_lite_database_search_wpf.Core;
using SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager;
using SQL_lite_database_search_wpf.UI.CalendarView.SpecificViews;
using SQL_lite_database_search_wpf.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.CalendarView
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        CalendarViewCore.CalendarViewMethods cViewMethods = CalendarViewCore.CalendarViewMethods.month;
        DateTime selectedDay = DateTime.Now;


        public CalendarView()
        {
            InitializeComponent();

            UIObjectManager.calendarContentChanged += LoadElements;
            UIControls.RefreshISNeeded += LoadElements;
            UIControls.AddNewElementAsked += AddElement;


            LoadComboBoxSelection();

            UIComboBoxSelection.SelectedObjectChanged += UIComboBoxSelection_selectedObjectChanged;

            LoadElements();
        }

        public void AddElement()
        {
            UI.UIObjectManager.AddNewElement();
            LoadElements();
        }


        public void LoadElements()
        {
            LoadContentObject(cViewMethods.ToString());
            UITbSelectedDate.Text = selectedDay.Date.ToLongDateString();
        }

        void LoadComboBoxSelection()
        {
            UIComboBoxSelection.clearElements();
            UIComboBoxSelection.defaultValue = "month";
            UIComboBoxSelection.AddObjectElement("week");
            UIComboBoxSelection.LoadUsers(true);
        }

        void LoadContentObject(string selection)
        {
            UIEventView.Children.Clear();
            switch (selection)
            {
                case "month":
                    cViewMethods = CalendarViewCore.CalendarViewMethods.month;
                    List<DayElement> month = TimeSelectionEvents.GetDayElements(selectedDay, cViewMethods);
                    UIEventView.Children.Add(new MonthView(month));
                    break;

                case "week":
                    cViewMethods = CalendarViewCore.CalendarViewMethods.week;
                    List<DayElement> days = TimeSelectionEvents.GetDayElements(selectedDay, cViewMethods);
                    UIEventView.Children.Add(new WeekView(days));
                    break;


                default:
                    cViewMethods = CalendarViewCore.CalendarViewMethods.month;
                    List<DayElement> monthSel = TimeSelectionEvents.GetDayElements(selectedDay, cViewMethods);
                    UIEventView.Children.Add(new MonthView(monthSel));
                    break;
            }
        }

        private void UIComboBoxSelection_selectedObjectChanged(string selectedObject)
        {
            LoadContentObject(selectedObject);
        }

        private void UIBtBefore_Click(object sender, RoutedEventArgs e)
        {
            EffectTime(-1);
        }

        private void UIBtAfter_Click(object sender, RoutedEventArgs e)
        {
            EffectTime(1);
        }




        void EffectTime(int pos)
        {
            if (cViewMethods == CalendarViewCore.CalendarViewMethods.month)
            {
                selectedDay = selectedDay.AddDays(pos * 35);
            }
            else if (cViewMethods == CalendarViewCore.CalendarViewMethods.week)
            {
                selectedDay = selectedDay.AddDays(pos * 7);
            }
            else if (cViewMethods == CalendarViewCore.CalendarViewMethods.day)
            {
                selectedDay = selectedDay.AddDays(pos);
            }
            LoadElements();
        }

        private void UIBtReturnToday_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = DateTime.Today;
            LoadElements();
        }
    }
}
