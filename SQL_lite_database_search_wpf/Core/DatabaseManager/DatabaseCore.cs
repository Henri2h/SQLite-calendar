using SQL_lite_database_search_wpf.Core;
using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager;
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
        public DatabaseCore()
        {
            objManager = new ObjectManager(this);
            EquipeMemberManager = new EquipeManager();
            calendarObjectManager = new CalendarObjectManager();
        }

        // control types
        public ObjectManager objManager { get; set; }
        public EquipeManager EquipeMemberManager { get; set; }
        public CalendarObjectManager calendarObjectManager { get; set; }

        // sqlite
        string inputFile = @"D:\sqlite\cal.sqlite";

        //definition

        public SQLiteConnection m_dbConnection { get; set; }

        public bool OpenDataBase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + inputFile + ";Version=3;");
            bool isTheFileJustCreated = false;
            string direct = Directory.GetParent(inputFile).FullName;

            if (Directory.Exists(direct) == false) { Directory.CreateDirectory(direct); }
            if (File.Exists(inputFile) == false)
            {
                SQLiteConnection.CreateFile(inputFile);
                isTheFileJustCreated = true;
            }

            // just open the database in order to make changes or just dislay the infos
            m_dbConnection.Open();

            if (isTheFileJustCreated == true)
            {
                calendarObjectManager.createCalendarTable(AppCore.mainProjectTableName);
                EquipeMemberManager.createEquipeTable();
            }

            return isTheFileJustCreated;

        }


        public void delElement(string tableName, sqliteInt rowID)
        {
            string sql = "DELETE FROM " + tableName + " WHERE " + rowID.valueName + " = " + rowID.value;
            SQLiteCommandsExecuter.executeNonQuery(sql, m_dbConnection);
        }

        public void delTable(string tableName)
        {
            string sql = "DROP TABLE " + tableName; ;
            SQLiteCommandsExecuter.executeNonQuery(sql, m_dbConnection);
        }

        public void updateElement(sqliteBase sb, sqliteBase seletcter, string tableName)
        {
            string request = "UPDATE " + tableName + " SET " + sb.valueName + " = " + "@param" + " WHERE " + seletcter.valueName + " = " + seletcter.baseValue;

            SQLiteCommand Command = new SQLiteCommand(request, m_dbConnection);
            Command.Parameters.AddWithValue("@param", sb.baseValue);

            int updated = Command.ExecuteNonQuery();
        }

        // just close the database anyway
        ~DatabaseCore()
        {


            try
            {
                //m_dbConnection.Close();
            }
            catch (Exception ex)
            {
                ex.Source = "SQL_lite_database_search_wpf.Core.DatabaseManager.DatabaseCore.destructor";
                ErrorHandeler.ErrorMessage.logError(ex);
                Usefull_Tools.ErrorHandeler.printOut(ex);
            }
        }
    }
}
