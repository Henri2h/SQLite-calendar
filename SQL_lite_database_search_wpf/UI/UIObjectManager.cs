using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.UI.ObjectsModifier;
using System;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    public class UIObjectManager
    {
        public delegate void UIEvent();
        public static UIEvent calendarContentChanged;


        public static void AddNewElement(string tableSource)
        {

            Add_Project inputDialog = new Add_Project()
            {
                Style = (Style)App.Current.Resources["BlankWindow"]
            };
            if (tableSource != "") { inputDialog.parentTable = tableSource; }

            if (inputDialog.ShowDialog().Value)
            {
                try
                {
                    calendarObject obj = inputDialog.CalendarObject;
                    Core.AppCore.dCore.CalendarObjectManager.AddCalendarObject(obj);
                }
                catch (Exception ex)
                {
                    ex.Source = "SQL_lite_database_search_wpf.UI.UIObjectManager.addNewElement(string)";
                    Usefull_Tools.ErrorHandeler.printOut(ex);
                }
                calendarContentChanged?.Invoke();
            }
        }

        public static void AddNewElement() { AddNewElement(""); }


        public static calendarObject ChangeCalendarObjectColor(calendarObject cObj)
        {
            ElementColorPicker inputDialog = new ElementColorPicker(cObj)
            {
                Style = (Style)App.Current.Resources["BlankWindow"]
            };
            if (inputDialog.ShowDialog().Value)
            {
                cObj = inputDialog.CalendarObject;
                Core.AppCore.dCore.CalendarObjectManager.UpdateCalendarObject(cObj.color, cObj.elementID.value, cObj.tableName);
                calendarContentChanged?.Invoke();
            }

            return cObj;
        }

        public static calendarObject ChangeCalendarObject(calendarObject cObj)
        {

            Add_Project inputDialog = new Add_Project(cObj)
            {
                Style = (Style)App.Current.Resources["BlankWindow"]
            };

            if (inputDialog.ShowDialog().Value)
            {
                cObj = inputDialog.UICalendarInformation.CalendarObject;

                // update
                Core.AppCore.dCore.CalendarObjectManager.UpdateCalendarObject(cObj);

                calendarContentChanged?.Invoke();
            }

            return cObj;
        }
    }
}
