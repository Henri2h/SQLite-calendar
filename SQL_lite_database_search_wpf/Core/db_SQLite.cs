using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace SQL_lite_database_search_wpf
{


    public class db_SQLite
    {
        //definition
        string TableName = "Data";
        string inputFile = @"D:\sqlite\cal.sqlite";
        public SQLiteConnection m_dbConnection;
        public List<calendarObject> celements;
        public List<calendarObject> cElements
        {
            get
            {
                readTable();
                return celements;
            }

        }

        public db_SQLite() { OpenDataBase(); }

        public void OpenDataBase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + inputFile + ";Version=3;");
            celements = new List<calendarObject>();
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
                createTable();
            }
        }
        public void createTable()
        {
            //create a table
            string sql_command = "CREATE TABLE " + TableName + " (ID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,name Text, domaine Text, priorite INT, description TEXT, time_start TEXT, time_end TEXT, completion INT, equipe TEXT)";
            SQLiteCommand command_sql = new SQLiteCommand(sql_command, m_dbConnection);
            //execute the command
            command_sql.ExecuteNonQuery();
        }

        //read data of the table
        public string readDataTable()
        {
            StringBuilder output = new StringBuilder();
            string sql = "select * from " + TableName + " order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                output.AppendLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            }
            return output.ToString();
        }
        //add data
        public void addDataTable(string row, string values)
        {
            try
            {
                string sql_addTable = "insert into " + TableName + " (" + row + ") values (" + values + ")";
                SQLiteCommand command_addTable = new SQLiteCommand(sql_addTable, m_dbConnection);
                command_addTable.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                ex.Source = "db_SQLite.addDataTable";
                ErrorHandeler.ErrorMessage.printOut(ex);

                Core.AppCore.Wi.showMessageBox(ex.Message, "SQLite Error");
            }
        }
        public void addCObjectInTable(calendarObject c)
        {
            RequestBuilder rb = new RequestBuilder();
            rb.addElement("name", c.name);
            rb.addElement("priorite", c.priorite);
            rb.addElement("time_start", c.startTime.ToBinary());
            rb.addElement("description", c.description);
            rb.addElement("time_end", c.endTime.ToBinary());
            rb.addElement("completion", c.completion);
            rb.addElement("equipe", c.equipe);

            string elements = rb.elementsValue;
            string elementsNames = rb.elementsNamesValue;

            addDataTable(elementsNames, elements);
        }

        public void updateObject(string element, string value, int id)
        {
            string sql_addTable = "update " + TableName + " set '" + element + "'='" + value + "' where '_rowid_'='" + id + "'";
            SQLiteCommand command_addTable = new SQLiteCommand(sql_addTable, m_dbConnection);
            command_addTable.ExecuteNonQuery();
        }

        public void addElement(StringBuilder sb, StringBuilder sE, string name, byte[] value)
        {
            sb.Append(value);
            sE.Append(name);
        }

        public void CloseDatabase()
        {
            m_dbConnection.Close();
        }

        public void readTable()
        {
            string sql = "select * from " + TableName + " order by ID ASC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

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
                    celements.Add(obj);
                }
            }

        }
    }


}
