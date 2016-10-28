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

        public DatabaseCore() { OpenDataBase(); }

        public void OpenDataBase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + inputFile + ";Version=3;");
            bool create = false;
            string direct = Directory.GetParent(inputFile).FullName;
            if (Directory.Exists(direct) == false)
            {
                Directory.CreateDirectory(direct);
            }
            if (File.Exists(inputFile) == false)
            {
                SQLiteConnection.CreateFile(inputFile);
                create = true;
            }

            m_dbConnection.Open();
            if (create == true)
            {
                createTable(TableProject);
            }
        }
        public void createTable(string name)
        {
            //create a table
            string sql_command = "CREATE TABLE " + name + " (name Text, domaine Text, priorite INT, description TEXT, time_start TEXT, time_end TEXT, completion INT, equipe TEXT)";
            SQLiteCommand command_sql = new SQLiteCommand(sql_command, m_dbConnection);
            //execute the command
            command_sql.ExecuteNonQuery();
        }
        public List<calendarObject> readTableElements(string tableName)
        {
            string sql = "select * from " + tableName + " order by ID ASC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<calendarObject> cObjects = new List<calendarObject>();
            while (reader.Read())
            {

                if (reader != null)
                {
                    calendarObject obj = new calendarObject();
                    obj.name = reader["name"].ToString();
                    obj.ID = Convert.ToInt32(reader["ID"].ToString());
                    obj.domaine = (reader["domaine"].ToString());
                    obj.priorite = int.Parse(reader["priorite"].ToString());
                    obj.description = reader["description"].ToString();
                    obj.completion = int.Parse(reader["completion"].ToString());
                    obj.equipe = reader["equipe"].ToString();
                    obj.startTime = DateTime.FromBinary(long.Parse(reader["time_start"].ToString()));
                    obj.endTime = DateTime.FromBinary(long.Parse(reader["time_end"].ToString()));
                    cObjects.Add(obj);
                }
            }
            return cObjects;
        }
        public void addCalendatObject(calendarObject cObj)
        {
            ObjectManager objManager = new ObjectManager();
            
        }
        public void updateCalandarObject(string tableName, string element, string value, int id)
        {
            string sql_addTable = "update " + tableName + " set '" + element + "'='" + value + "' where '_rowid_'='" + id + "'";
            SQLiteCommand command_addTable = new SQLiteCommand(sql_addTable, m_dbConnection);
            command_addTable.ExecuteNonQuery();
        }

        public void CloseDatabase()
        {
            m_dbConnection.Close();
        }
    }
}
