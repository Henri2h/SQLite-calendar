using SQL_lite_database_search_wpf.Core;
using System;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.Controls
{
    /// <summary>
    /// Interaction logic for AddElement.xaml
    /// </summary>
    public partial class AddElement : UserControl
    {
        public objectMode Mode { get { return mode; } set { mode = value; loadComponements(); } }
        objectMode mode = objectMode.calendarObject;

        public AddElement()
        {
            InitializeComponent();
            UICalendarInformations.projectModeChanged += UIModeChanged;
            loadComponements();
        }

        public AddElement(objectMode m)
        {
            InitializeComponent();
            UICalendarInformations.projectModeChanged += UIModeChanged;
            Mode = m;
            loadComponements();
        }

        public void loadComponements()
        {
            switch (mode)
            {
                case (objectMode.calendarObject):
                    UICalendarInformations.Mode = objectMode.calendarObject;
                    break;

                case (objectMode.project):
                    UICalendarInformations.Mode = objectMode.project;
                    break;
            }
            UIRdMode.Content = mode;
        }

        public void UIModeChanged(objectMode modeChanged) { Mode = modeChanged; }

        public calendarObject getCalendarObject()
        {
            if (mode == objectMode.project) { throw new NotImplementedException(); }
            calendarObject cObj = getCalendarObjectFromUI();
            cObj.tableName = UICalendarInformations.tableName;
            return cObj;
        }

        public calendarObject getProject()
        {
            if (mode == objectMode.calendarObject) { throw new NotImplementedException(); }

            calendarObject cObj = getCalendarObjectFromUI();


            cObj.isRepository.value = true;
            cObj.tableName = Core.AppCore.mainProjectTableName;

            return cObj;
        }

        calendarObject getCalendarObjectFromUI()
        {
            calendarObject cObj = new calendarObject();
            cObj.name.value = UICalendarInformations.name;
            cObj.description.value = UICalendarInformations.Description;
            cObj.domaine.value = UICalendarInformations.Domaine;
            cObj.equipe.value = UICalendarInformations.Equipe;

            cObj.completion.value = UICalendarInformations.Completion;
            cObj.priorite.value = UICalendarInformations.Priorite;

            cObj.isDateUsed.value = UIDateTimemanager.isDateUsed;
            cObj.startTime.value = UIDateTimemanager.time_start;
            cObj.endTime.value = UIDateTimemanager.time_end;
            cObj.isRepository.value = !UIRdMode.IsChecked.Value;

            return cObj;
        }

        private void UIBtRefresh_Click(object sender, System.Windows.RoutedEventArgs e) { UICalendarInformations.loadMenuItems(); }

        private void UIRdMode_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.IsChecked.Value) { Mode = objectMode.calendarObject; }
            else { Mode = objectMode.project; }
            rd.Content = mode;
        }
    }
}
