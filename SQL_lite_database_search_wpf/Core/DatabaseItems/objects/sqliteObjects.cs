using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SQL_lite_database_search_wpf.Core.DatabaseItems.objects
{

    // ============== boolean ===============
    public class sqliteBool : sqliteBase
    {
        public sqliteBool(string Name) : base(Name)
        {
            this.dataType = "INTEGER";
        }
        public bool value { get { return (bool)base.baseValue; } set { base.baseValue = value; } }


    }

    // ============== integer ===============
    public class sqliteInt : sqliteBase
    {
        public sqliteInt(string Name) : base(Name)
        {
            this.dataType = "INTEGER";
        }
        public sqliteInt(string Name, string dataType) : base(Name, dataType) { }
        public int value { get { return (int)base.baseValue; } set { base.baseValue = value; } }
    }

    // ============== string ===============
    public class sqliteString : sqliteBase
    {
        public sqliteString(string Name) : base(Name)
        {
            this.dataType = "TEXT";
        }


        public string value { get { return (string)base.baseValue; } set { base.baseValue = value; } }
    }

    // ============== dateTime ===============
    public class sqliteDateTime : sqliteBase
    {
        public sqliteDateTime(string Name) : base(Name)
        {

            this.dataType = "TEXT";
        }
        public DateTime value { get { return (DateTime)base.baseValue; } set { base.baseValue = value; } }


    }



    // ============== dateTime ===============
    public class sqliteColor : sqliteBase
    {
        public sqliteColor(string Name) : base(Name) { this.dataType = "TEXT"; }
        public Color value { get { return (Color)ColorConverter.ConvertFromString(base.baseValue.ToString()); } set { base.baseValue = value; } }
    }
}
