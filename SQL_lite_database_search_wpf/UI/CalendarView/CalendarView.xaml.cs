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
        List<Day> days = new List<Day>();



        public CalendarView()
        {
            InitializeComponent();

            UIObjectManager.calendarContentChanged += loadElements;
            UIControls.RefreshISNeeded += loadElements;
            UIControls.AddNewElementAsked += addElement;


            loadElement();

            UIComboBoxSelection.selectedObjectChanged += UIComboBoxSelection_selectedObjectChanged;
            loadContentObject("Month");
        }

        public void addElement()
        {
            UI.UIObjectManager.addNewElement();
            loadElements();
        }


        public void loadElements()
        {
            loadContentObject(cViewMethods.ToString());
        }

        void loadElement()
        {
            UIComboBoxSelection.clearElements();
            UIComboBoxSelection.AddObjectElement("Month");
            UIComboBoxSelection.AddObjectElement("Week");

        }
        void loadContentObject(string selection)
        {
            UIEventView.Children.Clear();
            switch (selection)
            {
                case "Month":
                    List<DayElement> month = TimeSelectionEvents.GetDayElements(selectedDay, CalendarViewCore.CalendarViewMethods.month);

                    UIEventView.Children.Add(new MonthView(month));
                    break;
                case "Week":
                    List<DayElement> days = TimeSelectionEvents.GetDayElements(selectedDay, CalendarViewCore.CalendarViewMethods.week);

                    CalendarContent cOnt = new CalendarContent();
                    cOnt.content = days;

                    foreach (DayElement d in days) { cOnt.dayNames.Add(d.name); }

                    UIEventView.Children.Add(new WeekView(cOnt));
                    break;


                default:
                    List<DayElement> monthSel = TimeSelectionEvents.GetDayElements(selectedDay, CalendarViewCore.CalendarViewMethods.month);
                    UIEventView.Children.Add(new MonthView(monthSel));
                    break;
            }
        }

        private void UIComboBoxSelection_selectedObjectChanged(string selectedObject)
        {
            //
            loadContentObject(selectedObject);
        }

        private void UIBtBefore_Click(object sender, RoutedEventArgs e)
        {
            effect(-1);
        }

        private void UIBtAfter_Click(object sender, RoutedEventArgs e)
        {
            effect(1);
        }




        void effect(int pos)
        {

        }


    }
}
