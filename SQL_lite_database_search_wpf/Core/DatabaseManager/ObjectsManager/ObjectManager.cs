using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.Core.DatabaseManager.Request;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ObjectManager
    {

        public const string elementID = "elementID";

        public DatabaseCore DCore { get; set; }

        public ObjectManager(DatabaseCore d) { DCore = d; }




        public void CreateElementTable<T>(string tableName) where T : DatabaseItem, new()
        {
            T dt = new T();

            StringBuilder sbElements = new StringBuilder();
            {
                bool justCreated = true;

                foreach (sqliteBase sElement in dt.values)
                {
                    if (justCreated) { justCreated = false; }
                    else { sbElements.Append(", "); }
                    sbElements.Append(sElement.valueName + " " + sElement.dataType);

                }
            }

            string sql_command = "CREATE TABLE " + tableName + " ( " + sbElements.ToString() + ")";
            SQLiteCommandsExecuter.executeNonQuery(sql_command, DCore.M_dbConnection);
        }


        public void AddElement(DatabaseItem ioElem, bool createAssociatedTable = false)
        {
            try
            {
                if (ioElem.tableName == null) { throw new ArgumentNullException(); }


                RequestBuilder rb = new RequestBuilder(ioElem.tableName);
                foreach (sqliteBase sb in ioElem.values)
                {
                    rb.addElement(sb.valueName, sb.baseValue);
                }

                SQLiteCommand cmd = CommandBuilder.getCommand(rb, DCore.M_dbConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Usefull_Tools.ErrorHandeler.printOut(ex);
            }

        }
        public void DeleteElement(int id, string tableName)
        {
            sqliteInt sIntID = new sqliteInt("elementID")
            {
                value = id
            };
            DCore.DelElement(tableName, sIntID);
        }

        public T GetElement<T>(int objectID, string tableName) where T : DatabaseItem, new()
        {
            string sql = "select * from " + tableName + " where (" + elementID + "=" + objectID + ")  order by _rowid_ ASC LIMIT 1";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, DCore.M_dbConnection);
            T Objects = ReaderToElement<T>(reader, tableName);
            return Objects;

        }


        public List<T> ListIOElements<T>(string tableName) where T : DatabaseItem, new()
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, DCore.M_dbConnection);
            List<T> ioElems = ReaderToElements<T>(reader, tableName);
            return ioElems;
        }




        // update or save, the same thing
        public void UpdateElement<T>(DatabaseItem Obj) where T : DatabaseItem, new()
        {

            T old = GetElement<T>(Obj.elementID.value, Obj.tableName);
            for (int i = 0; i < Obj.values.Length; i++)
            {
                if (Obj.values[i].Equals(old.values[i]) == false)
                {

                    DCore.UpdateElement(Obj.values[i], Obj.elementID, Obj.tableName);
                }
            }

        }






        T ReaderToElement<T>(SQLiteDataReader reader, string tableName, bool useReaderRead = true) where T : DatabaseItem, new()
        {
            if (useReaderRead) { reader.Read(); }

            if (reader != null)
            {
                bool hasRows = reader.HasRows;

                T ioElem = new T();

                for (int i = 0; i < ioElem.values.Length; i++)
                {
                    ioElem.values[i].baseValue = reader[ioElem.values[i].valueName];
                }

                ioElem.tableName = tableName;

                return ioElem;
            }
            return default(T);
        }

        List<T> ReaderToElements<T>(SQLiteDataReader reader, string tableName) where T : DatabaseItem, new()
        {
            List<T> ioElems = new List<T>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    ioElems.Add(ReaderToElement<T>(reader, tableName, false));
                }
            }
            return ioElems;
        }
    }
}
