using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager
{
    public class ProjectManager
    {


        public const string TableProject = "project";

        // in order to simplify the names
        SQLiteConnection m_dbConnection { get { return AppCore.dCore.m_dbConnection; } }
        DatabaseCore dCore { get { return AppCore.dCore; } }


        public List<Project> loadProject()
        {
            string sql = "select * from " + TableProject + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql);
            List<Project> projects = ObjectManager.readerToProjects(reader);
            return projects;
        }

        public void addProject(Project prj)
        {
            AppCore.projects.Add(prj);

            calendarObject c = prj;
            AppCore.dCore.addCalendarObject(c);
            AppCore.dCore.createTable(prj.projectTableName);
        }


        public List<Project> loadProjectsElements(List<Project> projects)
        {
            foreach (Project prj in projects)
            {
                prj.events = dCore.readCObjInTable(prj.projectTableName);
            }
            return projects;
        }
        public Project loadProjectElements(Project project)
        {
            project.events = dCore.readCObjInTable(project.projectTableName);
            return project;
        }
    }
}
