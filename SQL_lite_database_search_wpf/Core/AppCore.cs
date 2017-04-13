using SQL_lite_database_search_wpf.Core.DatabaseManager;
using System.Collections.Generic;

namespace SQL_lite_database_search_wpf.Core
{
    public class AppCore
    {

        public static string mainProjectTableName = "projects";
        public static MainWindow Wi;
        public static string DatabasePath = @"D:\sqlite\cal.sqlite";

        public static DatabaseCore dCore = new DatabaseCore(DatabasePath);
        public static List<string> Equipe { get { return getEquipe(); } }

        static List<string> getEquipe()
        {
            List<string> equipeMember = new List<string>();

            List<DatabaseItems.EquipeMember> eMemb = dCore.EquipeMemberManager.getEquipeMembers();
            foreach (DatabaseItems.EquipeMember e in eMemb)
            {
                equipeMember.Add(e.name.value);
            }

            return equipeMember;
        }

        public static bool databaseOpened = false;

        public AppCore(MainWindow wi)
        {
            if (dCore == null) { dCore = new DatabaseCore(DatabasePath); }

            wi = Wi;
            dCore.OpenDataBase();
            databaseOpened = true;
        }

    }
}
