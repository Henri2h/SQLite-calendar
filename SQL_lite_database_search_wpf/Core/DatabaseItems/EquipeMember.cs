using SQL_lite_database_search_wpf.Core.DatabaseItems.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems
{
    public class EquipeMember
    {
        public sqliteString name = new sqliteString("name");
        public sqliteInt id = new sqliteInt("memberID");
    }
}
