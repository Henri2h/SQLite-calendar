using SQL_lite_database_search_wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for CalendarInformations.xaml
    /// </summary>
    public partial class CalendarInformations : UserControl
    {

        public calendarObject CalendarObject
        {
            get
            {
                // ===================== table elements ==========================
                // create a new calendarObject element with it's name
                calendarObject cObj = new calendarObject();

                cObj.name.value = UITbName.Text;
                cObj.description.value = UITbDescription.Text;


                cObj.priorite.value = UIslPriorite.starPosition;
                cObj.completion.value = Convert.ToInt32(UIslCompletion.Value);

                cObj.domaine.value = UITbDomaine.Text;

                // team
                // TODO : change it's value to a JSON array of the ID of the element of the team
                cObj.equipe.value = UITbEquipe.Text;

                // 
                // ======================   date and time  =========================
                cObj.isDateUsed.value = UIDateTimemanager.isDateUsed;

                if (cObj.isDateUsed.value)
                {
                    cObj.startTime.value = UIDateTimemanager.time_start;
                    cObj.endTime.value = UIDateTimemanager.time_end;
                }


                // ====================== other properties =========================
                cObj.isRepository.value = UIIsMainProject.IsChecked.Value;
                if (isParentTableUsed) { cObj.tableName = parentTable; }
                else
                {
                    cObj.tableName = getTableName();
                }
                return cObj;

            }
        }

        // parent table:
        // =============
        public string ParentTable
        {
            get
            {
                return parentTable;
            }
            set
            {
                parentTable = value;
                isParentTableUsed = true;
                loadMenuItems();
            }
        }


        bool isParentTableUsed = false;
        string parentTable = "";


        public string getTableName()
        {
            ComboBoxItem cItem = (ComboBoxItem)UIProject.SelectedItem;
            object item = cItem.Resources["tableName"];
            return item.ToString();

        }

        public CalendarInformations()
        {
            InitializeComponent();
            try
            {
                loadMenuItems();
            }
            catch (Exception ex)
            {
                ex.Source = "CalendarInformations.constructor";
                ErrorHandeler.ErrorMessage.printOut(ex);
            }
        }



        public void loadMenuItems()
        {

            UIProject.Items.Clear();
            if (isParentTableUsed)
            {
                addSelectionInMenuItems(parentTable, parentTable);
            }
            else
            {
                addSelectionInMenuItems("MainProjectTable", Core.AppCore.mainProjectTableName);
                foreach (calendarObject pr in Core.AppCore.projects)
                {
                    addSelectionInMenuItems(pr.name.value, pr.projectTableName.value);
                }

                addSelectionInMenuItems("<New project ...>", null);
                addSelectionInMenuItems("<New empty project ...>", null);
            }


        }

        void addSelectionInMenuItems(string name, string tableName)
        {
            ComboBoxItem cItem = new ComboBoxItem();

            cItem.Content = name;
            cItem.Resources.Add("tableName", tableName);

            UIProject.Items.Add(cItem);
        }

    }
}
