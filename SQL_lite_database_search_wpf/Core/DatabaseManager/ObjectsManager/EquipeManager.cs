using SQL_lite_database_search_wpf.Core.DatabaseItems;
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

        // equipe manager
        public List<EquipeMember> getEquipeMembers()
        {
            string sql = "select * from " + equipeTable + " order by _rowid_ ASC";
            SQLiteDataReader reader = SQLiteCommandsExecuter.executeDataReader(sql);
            return ObjectManager.getEquipeFromReader(reader);
        }
        public void deleteEquipeMember(EquipeMember member)
        {
            deleteEquipeMember(member.id.value);
        }
        public void deleteEquipeMember(int memberID)
        {
            string sql = "DELETE FROM " + equipeTable + " WHERE " + "memberID" + " = " + memberID;
            SQLiteCommandsExecuter.executeNonQuery(sql);
        }
    }
}
