using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.UI.ObjectsModifier;
using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    public class UIObjectManager
    {
        public delegate void UIEvent();
        public static UIEvent calendarContentChanged;


        public static void addNewElement(string tableSource)
        {

            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];

            if (tableSource != "") { inputDialog.parentTable = tableSource; }

            if (inputDialog.ShowDialog().Value)
            {

                calendarContentChanged?.Invoke();
            }
        }

        public static void addNewElement() { addNewElement(""); }


        public static calendarObject changeCalendarObjectColor(calendarObject cObj)
        {

            ElementColorPicker inputDialog = new ElementColorPicker(cObj);
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            if (inputDialog.ShowDialog().Value)
            {
                cObj = inputDialog.CalendarObject;
                Core.AppCore.dCore.calendarObjectManager.updateCalendarObject((sqliteBase)cObj.color, cObj.elementID.value, cObj.tableName);
                calendarContentChanged?.Invoke();
            }



            return cObj;
        }

        public static calendarObject changeCalendarObject(calendarObject cObj)
        {

            Add_Project inputDialog = new Add_Project(cObj);
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            

            if (inputDialog.ShowDialog().Value)
            {
                cObj = inputDialog.UICalendarInformation.CalendarObject;

                // update
                Core.AppCore.dCore.calendarObjectManager.updateCalendarObject(cObj);

                calendarContentChanged?.Invoke();
            }

            return cObj;
        }
    }
}
