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
        //definition



        // control types
        public EquipeManager EquipeMemberManager = new EquipeManager();
        public CalendarObjectManager calendarObjectManager = new CalendarObjectManager();

        // sqlite
        string inputFile = @"D:\sqlite\cal.sqlite";
        public SQLiteConnection m_dbConnection;

        public void OpenDataBase()
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
            }

        }


        public void delElement(string tableName, sqliteInt rowID)
        {
            string sql = "DELETE FROM " + tableName + " WHERE " + rowID.valueName + " = " + rowID.value;

            SQLiteCommandsExecuter.executeNonQuery(sql);
        }


        public void CloseDatabase()
        {
            m_dbConnection.Close();
        }
        // just close the database anyway
        ~DatabaseCore()
        {
            try
            {
                m_dbConnection.Close();
                m_dbConnection.Dispose();
            }
            catch (Exception ex){
                ex.Source = "SQL_lite_database_search_wpf.Core.DatabaseManager.DatabaseCore.destructor";
                ErrorHandeler.ErrorMessage.logError(ex);
            }
        }
    }
}
