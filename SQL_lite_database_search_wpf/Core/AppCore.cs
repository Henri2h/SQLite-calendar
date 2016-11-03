using SQL_lite_database_search_wpf.Core.DatabaseManager;
using SQL_lite_database_search_wpf.UI.ProjectView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core
{
    public class AppCore
    {
        public static List<Project> projects;
        public static DatabaseManager.DatabaseCore dCore = new DatabaseCore();
        public static ProjectManager projectmanager = new ProjectManager();
        public static MainWindow Wi;


        public AppCore(MainWindow wi)
        {
            if (dCore == null) { dCore = new DatabaseCore(); }
            if (projectmanager == null) { projectmanager = new ProjectManager(); }

            wi = Wi;
            dCore.OpenDataBase();
            projects = projectmanager.loadProject();
        }
    }
}
