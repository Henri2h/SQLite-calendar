using System;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for CalendarInformations.xaml
    /// </summary>
    public partial class CalendarInformations : UserControl
    {
        calendarObject CObj { get; set; }
        public calendarObject CalendarObject
        {
            get
            {
                // ===================== table elements ==========================
                // create a new calendarObject element with it's name

                if (CObj == null) { CObj = new calendarObject(); }

                CObj.name.value = UITbName.Text;
                CObj.description.value = UITbDescription.Text;


                CObj.priorite.value = UIslPriorite.starPosition;
                CObj.completion.value = Convert.ToInt32(UIslCompletion.Value);

                CObj.domaine.value = UITbDomaine.Text;

                // team
                // TODO : change it's value to a JSON array of the ID of the element of the team
                CObj.equipe.value = UISelTeam.selectedMemberName;

                // 
                // ======================   date and time  =========================
                CObj.isDateUsed.value = UIDateTimemanager.isDateUsed;

                if (CObj.isDateUsed.value)
                {
                    CObj.startTime.value = UIDateTimemanager.time_start;
                    CObj.endTime.value = UIDateTimemanager.time_end;
                }


                // ====================== other properties =========================
                CObj.isRepository.value = UIIsMainProject.IsChecked.Value;
                if (isParentTableUsed) { CObj.tableName = parentTable; }
                else
                {
                    CObj.tableName = GetTableName();
                }
                return CObj;

            }


            set
            {
                CObj = value;


                ParentTable = value.tableName;

                UITbName.Text = value.name.value;
                UITbDescription.Text = value.description.value;

                UITbDomaine.Text = value.domaine.value;
                UISelTeam.selectedMemberName = value.equipe.value;

                UIslPriorite.starPosition = value.priorite.value;
                UIslCompletion.Value = (double)value.completion.value;


                if (value.isDateUsed.value)
                {
                    UIDateTimemanager.isDateUsed = true;
                    UIDateTimemanager.time_start = value.startTime.value;
                    UIDateTimemanager.time_end = value.endTime.value;
                }
                else { UIDateTimemanager.isDateUsed = false; }


                // prevent deleting associated tables
                // should be always false when doing modification because the code will not change the associated tables when the object is updated
                UIIsMainProject.IsEnabled = false;

                if (value.isRepository.value)
                {
                    UIIsMainProject.IsChecked = true;
                }
                else { UIIsMainProject.IsChecked = false; }

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
                LoadMenuItems();
            }
        }


        bool isParentTableUsed = false;
        string parentTable = "";


        public string GetTableName()
        {
            try
            {
                ComboBoxItem cItem = (ComboBoxItem)UIProject.SelectedItem;
                object item = cItem.Resources["tableName"];
                return item.ToString();
            }
            catch
            {
                //               MessageBox.Show("Please, select a project repository for this item");
                Console.WriteLine("Using default project name");
                return Core.AppCore.mainProjectTableName;
            }

        }

        public CalendarInformations()
        {
            InitializeComponent();
            try
            {
                LoadMenuItems();
            }
            catch (Exception ex)
            {
                ex.Source = "CalendarInformations.constructor";
                Usefull_Tools.ErrorHandeler.printOut(ex);
            }
        }



        public void LoadMenuItems()
        {

            UIProject.Items.Clear();
            if (isParentTableUsed)
            {
                AddSelectionInMenuItems(parentTable, parentTable);
            }
            else
            {
                AddSelectionInMenuItems("MainProjectTable", Core.AppCore.mainProjectTableName);
                foreach (calendarObject pr in Core.AppCore.dCore.CalendarObjectManager.ListAllCalendarObjectsBySelection(Core.AppCore.mainProjectTableName, Core.DatabaseManager.ObjectsManager.CalendarObjectManager.SelectionType.isRepository))
                {
                    if (pr.isRepository.value) { AddSelectionInMenuItems(pr.name.value, pr.projectTableName.value); }
                }

                AddSelectionInMenuItems("<New project ...>", null);
                AddSelectionInMenuItems("<New empty project ...>", null);
            }


        }

        void AddSelectionInMenuItems(string name, string tableName)
        {
            ComboBoxItem cItem = new ComboBoxItem()
            {
                Content = name
            };
            cItem.Resources.Add("tableName", tableName);

            UIProject.Items.Add(cItem);
        }

    }
}
