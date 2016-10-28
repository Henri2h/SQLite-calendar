using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ProjectManager
    {
        // in order to simplify the names
        SQLiteConnection m_dbConnection { get { return Core.AppCore.dCore.m_dbConnection; } }
        DatabaseCore dCore { get { return Core.AppCore.dCore; } }

        string TableProject { get { return Core.AppCore.dCore.TableProject; } }

        // project
        public List<Project> loadProject()
        {
            List<Project> projects = new List<Project>();
            string sql = "select * from " + TableProject + " order by _rowid_ ASC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                if (reader != null)
                {
                    Project prj = new Project();
                    prj.events = new List<calendarObject>();
                    prj.name = reader["name"].ToString();
                }
            }
            return projects;
        }
        public List<Project> loadProjectsElements(List<Project> projects)
        {
            foreach (Project prj in projects)
            {
                prj.events = dCore.readTableElements(prj.name + "Events");
            }
            return projects;
        }

    }
}
