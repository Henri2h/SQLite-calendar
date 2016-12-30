using SQL_lite_database_search_wpf.Core.DatabaseItems;
using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager.ObjectsManager
{
    public class EquipeManager
    {

        public const string equipeTable = "equipe";
        public const string memberRowID = "memberID";

        public void createEquipeTable()
        {
            EquipeMember eMember = new EquipeMember();

            StringBuilder sbElements = new StringBuilder();
            {
                bool justCreated = true;

                foreach (sqliteBase sElement in eMember.values)
                {
                    if (justCreated) { justCreated = false; }
                    else { sbElements.Append(", "); }
                    sbElements.Append(sElement.valueName + " " + sElement.dataType);

                }
            }

            string sql_command = "CREATE TABLE " + equipeTable + " ( " + sbElements.ToString() + ")";
            SQLiteCommandsExecuter.executeNonQuery(sql_command, Core.AppCore.dCore.m_dbConnection);

        }

        public void addMember(EquipeMember eMember)
        {


            Request.RequestBuilder rb = new Request.RequestBuilder(equipeTable);
            rb.addElement(eMember.name.valueName, eMember.name.value);

            SQLiteCommand cmd = Request.CommandBuilder.getCommand(rb, Core.AppCore.dCore.m_dbConnection);
            cmd.ExecuteNonQuery();
        }

        // equipe manager
        public List<EquipeMember> getEquipeMembers()
        {
            string sql = "select * from " + equipeTable + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql, Core.AppCore.dCore.m_dbConnection);
            return getEquipeFromReader(reader);
        }
        public void deleteEquipeMember(EquipeMember member)
        {
            deleteEquipeMember(member.elementID.value);
        }
        public void deleteEquipeMember(int memberID)
        {
            string sql = "DELETE FROM " + equipeTable + " WHERE " + "memberID" + " = " + memberID;
            SQLiteCommandsExecuter.executeNonQuery(sql, Core.AppCore.dCore.m_dbConnection);
        }



        public List<EquipeMember> getEquipeFromReader(SQLiteDataReader reader)
        {
            List<EquipeMember> equipeMemeber = new List<EquipeMember>();
            while (reader.Read())
            {
                EquipeMember mb = new EquipeMember();
                mb.name.value = reader[mb.name.valueName].ToString();
                mb.elementID.value = int.Parse(reader[mb.elementID.valueName].ToString());


                equipeMemeber.Add(mb);
            }

            return equipeMemeber;

        }

    }
}
