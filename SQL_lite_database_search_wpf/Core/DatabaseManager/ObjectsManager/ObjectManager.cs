using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using SQL_lite_database_search_wpf.Core.DatabaseManager.Request;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Media;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class ObjectManager
    {

        public const string elementID = "elementID";

        public DatabaseCore dCore { get; set; }

        public ObjectManager(DatabaseCore d) { dCore = d; }




        public void createElementTable<T>(string tableName) where T : DatabaseItem, new()
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
            SQLiteCommandsExecuter.executeNonQuery(sql_command, dCore.m_dbConnection);
        }


        public void addElement(DatabaseItem ioElem, bool createAssociatedTable = false)
        {
            try
            {
                if (ioElem.tableName == null) { throw new ArgumentNullException(); }


                RequestBuilder rb = new RequestBuilder(ioElem.tableName);
                foreach (sqliteBase sb in ioElem.values)
                {
                    rb.addElement(sb.valueName, sb.baseValue);
                }

                SQLiteCommand cmd = CommandBuilder.getCommand(rb, dCore.m_dbConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorHandeler.ErrorMessage.logError(ex);
            }

        }
        public void deleteElement(int id, string tableName)
        {
            sqliteInt sIntID = new sqliteInt("elementID");
            sIntID.value = id;

            dCore.delElement(tableName, sIntID);
        }

        public T getElement<T>(int objectID, string tableName) where T : DatabaseItem, new()
        {
            string sql = "select * from " + tableName + " where (" + elementID + "=" + objectID + ")  order by _rowid_ ASC LIMIT 1";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, dCore.m_dbConnection);
            T Objects = readerToElement<T>(reader, tableName);
            return Objects;

        }


        public List<T> listIOElements<T>(string tableName) where T : DatabaseItem, new()
        {
            string sql = "select * from " + tableName + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, dCore.m_dbConnection);
            List<T> ioElems = readerToElements<T>(reader, tableName);
            return ioElems;
        }




        // update or save, the same thing
        public void updateElement<T>(DatabaseItem Obj) where T : DatabaseItem, new()
        {

            T old = getElement<T>(Obj.elementID.value, Obj.tableName);
            for (int i = 0; i < Obj.values.Length; i++)
            {
                if (Obj.values[i].Equals(old.values[i]) == false)
                {

                    dCore.updateElement(Obj.values[i], Obj.elementID, Obj.tableName);
                }
            }

        }






        T readerToElement<T>(SQLiteDataReader reader, string tableName, bool useReaderRead = true) where T : DatabaseItem, new()
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
        List<T> readerToElements<T>(SQLiteDataReader reader, string tableName) where T : DatabaseItem, new()
        {
            List<T> ioElems = new List<T>();
            while (reader.Read())
            {
                if (reader != null)
                {
                    ioElems.Add(readerToElement<T>(reader, tableName, false));
                }
            }
            return ioElems;
        }
    }
}
