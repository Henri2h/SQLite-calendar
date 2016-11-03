using SQL_lite_database_search_wpf.Core;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class DatabaseCore
    {
        //definition
        public string TableProject = "project";
        string inputFile = @"D:\sqlite\cal.sqlite";
        public SQLiteConnection m_dbConnection;

        public DatabaseCore() { }

        public void OpenDataBase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + inputFile + ";Version=3;");
            bool isTableJustCreated = false;
            string direct = Directory.GetParent(inputFile).FullName;

            if (Directory.Exists(direct) == false) { Directory.CreateDirectory(direct); }
            if (File.Exists(inputFile) == false)
            {
                SQLiteConnection.CreateFile(inputFile);
                isTableJustCreated = true;
            }

            m_dbConnection.Open();
            if (isTableJustCreated == true)
            {
                createTable(TableProject);

                Project prj = new Project();
                prj.name.value = "DefaultTasks";
                prj.isDateUsed.value = false;
                AppCore.projectmanager.addProject(prj);

            }

        }
        public void createTable(string name)
        {
            //create a table
            string sql_command = "CREATE TABLE " + name + " (name Text, domaine Text, priorite INT, description TEXT, time_start TEXT, time_end TEXT, completion INT, equipe TEXT, isDateUsed BLOB)";
            SQLiteCommandsExecuter.executeNonQuery(sql_command);
        }

        /// <summary>
        /// Read all the elements from specific table ordered by ID
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<calendarObject> readCObjInTable(string tableName)
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql);
            List<calendarObject> cObjects = ObjectManager.readerToCobjs(reader);
            return cObjects;
        }

        public void addCalendarObject(calendarObject cObj)
        {
            string request = cObj.createRequest();
            SQLiteCommandsExecuter.executeNonQuery(request);
        }

        public void updateCalandarObject(string tableName, string element, string value, int id)
        {
            string request = "update " + tableName + " set '" + element + "'='" + value + "' where '_rowid_'='" + id + "'";
            SQLiteCommandsExecuter.executeNonQuery(request);
        }

        public void CloseDatabase()
        {
            m_dbConnection.Close();
        }
    }
}
