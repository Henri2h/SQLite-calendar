using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf
{
    public class RequestBuilder
    {
        StringBuilder elements;
        StringBuilder elementsName;
        bool justCreated = false;
        public RequestBuilder()
        {
            elements = new StringBuilder();
            elementsName = new StringBuilder();
            justCreated = true;
        }

        public void addElement(string name, object value)
        {
            if (!justCreated) elementsName.Append(",");
            elementsName.Append(name);
            if (!justCreated) elements.Append(",");
            elements.Append(value);
            justCreated = false;
        }
        public void addElement(string name, string value)
        {
            if (!justCreated) elementsName.Append(",");
            elementsName.Append(name);
            if (!justCreated) elements.Append(",");
            elements.Append("'" + value + "'");
            justCreated = false;
        }
        public void addElement(string name, byte[] value)
        {
            if (!justCreated) elementsName.Append(",");
            elementsName.Append(name);
            if (!justCreated) elements.Append(",");
            elements.Append("'" + value + "'");
            justCreated = false;
        }

        public string elementsValue { get { return elements.ToString(); } }
        public string elementsNamesValue { get { return elementsName.ToString(); } }

    }
}
