using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager.Request
{
    public class RequestBuilder
    {
        List<RequestElement> rq;
        int parameterNumber;
        public string tableName;


        public RequestBuilder(string tablename)
        {
            tableName = tablename;
            rq = new List<RequestElement>();
            parameterNumber = 0;
        }
        public void addElement(string name, object value)
        {
            RequestElement re = new RequestElement();
            re.name = name;
            re.parameterName = new System.Data.SQLite.SQLiteParameter("@param" + parameterNumber, value);
            rq.Add(re);
            parameterNumber++;
        }

        public RequestElement[] getElements()
        {
            return rq.ToArray();
        }
        public string[] getStringElementNames()
        {
            RequestElement[] relements = getElements();
            string[] elementNames = new string[relements.Length];

            for (int i = 0; i < relements.Length; i++)
            {
                elementNames[i] = relements[i].name;
            }
            return elementNames;
        }
        public string[] getStringElementParameterNames()
        {
            RequestElement[] relements = getElements();
            string[] elementParameterNames = new string[relements.Length];

            for (int i = 0; i < relements.Length; i++)
            {
                elementParameterNames[i] = relements[i].parameterName.ParameterName;
            }
            return elementParameterNames;
        }


    }
}
