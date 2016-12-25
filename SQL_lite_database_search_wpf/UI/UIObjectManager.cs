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
            inputDialog.parentTable = tableSource;
            inputDialog.ShowDialog();

            calendarContentChanged?.Invoke();
        }
        public static void addNewElement()
        {

            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.ShowDialog();

            calendarContentChanged?.Invoke();
        }


        public static calendarObject changeCalendarObjectColor(calendarObject cObj)
        {

            ElementColorPicker inputDialog = new ElementColorPicker(cObj);
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.ShowDialog();



            calendarContentChanged?.Invoke();
            return cObj;
        }

        public static calendarObject changeCalendarObject(calendarObject cObj)
        {

            calendarContentChanged?.Invoke();
            return cObj;
        }
    }
}
