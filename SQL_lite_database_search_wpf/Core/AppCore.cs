using SQL_lite_database_search_wpf.Core.DatabaseManager;
using System.Collections.Generic;

namespace SQL_lite_database_search_wpf.Core
{
    public class AppCore
    {

        public static string mainProjectTableName = "projects";
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
        }



      



    }
}
