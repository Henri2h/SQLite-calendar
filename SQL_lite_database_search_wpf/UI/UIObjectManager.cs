using System.Windows;

namespace SQL_lite_database_search_wpf.UI
{
    public class UIObjectManager
    {
        public static void addNewElement(string tableSource)
        {

            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.parentTable = tableSource;
            inputDialog.ShowDialog();
        }
        public static void addNewElement()
        {

            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.ShowDialog();
        }
    }
}
