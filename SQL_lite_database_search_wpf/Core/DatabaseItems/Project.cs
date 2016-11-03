using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_lite_database_search_wpf.Core
{
    public class Project : calendarObject
    {
        // load default parameters for a project
        public Project()
        {
            tableName = Core.AppCore.dCore.TableProject;
            isDateUsed.value = false;

        }
        public bool isAutomated = true;
        public List<calendarObject> events { get; set; }
        string projecttablename = "";

        public string projectTableName
        {
            get
            {
                if (isAutomated) { return name.value + "Events"; }
                else { return projecttablename; }
            }
            set
            {
                projecttablename = value;
                isAutomated = false;
            }
        }
    }
}
