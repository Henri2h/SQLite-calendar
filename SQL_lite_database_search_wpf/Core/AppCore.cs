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
        public static DatabaseManager.DatabaseCore dCore;
        public static MainWindow Wi;
        public static ProjectManager projectmanager;
        public AppCore(MainWindow wi)
        {
            wi = Wi;
            dCore = new DatabaseManager.DatabaseCore();
            dCore.OpenDataBase();
            projectmanager = new ProjectManager();

        }
    }
}
