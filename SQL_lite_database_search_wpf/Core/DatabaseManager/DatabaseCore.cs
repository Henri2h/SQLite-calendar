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
        public DatabaseCore(string databasePath)
        {
            this.databasePath = databasePath;
            ObjManager = new ObjectManager(this);
            EquipeMemberManager = new EquipeManager();
            CalendarObjectManager = new CalendarObjectManager();

        }


        // control types
        public ObjectManager ObjManager { get; set; }
        public EquipeManager EquipeMemberManager { get; set; }
        public CalendarObjectManager CalendarObjectManager { get; set; }

        // sqlite
        private string databasePath;

        //definition

        public SQLiteConnection M_dbConnection { get; set; }

        public bool OpenDataBase()
        {
            M_dbConnection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;");
            bool isTheFileJustCreated = false;
            string direct = Directory.GetParent(databasePath).FullName;

            if (Directory.Exists(direct) == false) { Directory.CreateDirectory(direct); }
            if (File.Exists(databasePath) == false)
            {
                SQLiteConnection.CreateFile(databasePath);
                isTheFileJustCreated = true;
            }

            // just open the database in order to make changes or just dislay the infos
            M_dbConnection.Open();

            if (isTheFileJustCreated == true)
            {
                CalendarObjectManager.CreateCalendarTable(AppCore.mainProjectTableName);
                EquipeMemberManager.createEquipeTable();
            }

            return isTheFileJustCreated;

        }


        public void DelElement(string tableName, sqliteInt rowID)
        {
            string sql = "DELETE FROM " + tableName + " WHERE " + rowID.valueName + " = " + rowID.value;
            SQLiteCommandsExecuter.executeNonQuery(sql, M_dbConnection);
        }

        public void DelTable(string tableName)
        {
            string sql = "DROP TABLE " + tableName; ;
            SQLiteCommandsExecuter.executeNonQuery(sql, M_dbConnection);
        }

        public void UpdateElement(sqliteBase sb, sqliteBase seletcter, string tableName)
        {
            string request = "UPDATE " + tableName + " SET " + sb.valueName + " = " + "@param" + " WHERE " + seletcter.valueName + " = " + seletcter.baseValue;

            SQLiteCommand Command = new SQLiteCommand(request, M_dbConnection);
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
                Usefull_Tools.ErrorHandeler.printOut(ex);
            }
        }
    }
}
