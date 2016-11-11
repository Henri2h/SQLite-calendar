using System;
using System.Text;

namespace SQL_lite_database_search_wpf.Core.DatabaseManager
{
    public class Request
    {
        // DATA
        StringBuilder elements;
        StringBuilder elementsName;

        bool justCreated = false;

        // create the request
        public Request()
        {
            elements = new StringBuilder();
            elementsName = new StringBuilder();
            justCreated = true;
        }

        public void addElement(string name, object value)
        {
            addElements(name, value.ToString());
        }
        public void addElement(string name, byte[] value)
        {
            string valueS = BitConverter.ToString(value);
            addElements(name, valueS);
        }
        public void addElement(string name, string value)
        {
            value = "'" + value + "'";
            addElements(name, value);
        }

        // main method
        private void addElements(string name, string value)
        {
            if (!justCreated) elementsName.Append(",");
            elementsName.Append(name);
            if (!justCreated) elements.Append(",");
            elements.Append(value);
            justCreated = false;
        }

        public string elementsValue { get { return elements.ToString(); } }
        public string elementsNamesValue { get { return elementsName.ToString(); } }
    }
}
