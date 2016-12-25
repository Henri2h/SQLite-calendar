using SQL_lite_database_search_wpf.Core.DatabaseManager;
using SQL_lite_database_search_wpf.UI;
using SQL_lite_database_search_wpf.UI.ProjectView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQL_lite_database_search_wpf.Core
{
    public class AppCore
    {

        public static string mainProjectTableName = "projects";

        public static List<calendarObject> projects = new List<calendarObject>();
        public static DatabaseCore dCore = new DatabaseCore();
        public static MainWindow Wi;
        public static List<string> Equipe { get; set; }

        public static List<string> getEquipe()
        {
            List<string> equipeMember = new List<string>();

            return equipeMember ;
        }

        public static bool databaseOpened = false;

        public AppCore(MainWindow wi)
        {
            if (dCore == null) { dCore = new DatabaseCore(); }

            wi = Wi;
            dCore.OpenDataBase();
            databaseOpened = true;
            projects = dCore.calendarObjectManager.listCalendarObjects(mainProjectTableName);
        }



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
