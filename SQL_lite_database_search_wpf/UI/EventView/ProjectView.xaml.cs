using SQL_lite_database_search_wpf.Core;
using SQL_lite_database_search_wpf.Core.DatabaseItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SQL_lite_database_search_wpf.UI.EventView
{
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView(Project pr)
        {

            InitializeComponent();
            UITableName.Text = pr.name.value;
            dataGrid.CanUserAddRows = true;
            loadElement(pr);

        }
        private void loadElement(Project project)
        {
            List<UICalendarObjectView> cView = new List<UICalendarObjectView>();
            foreach (calendarObject cObj in AppCore.dCore.readCObjInTable(project.projectTableName))
            {
                cView.Add(new UICalendarObjectView(cObj));
            }
            dataGrid.ItemsSource = cView;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.CanUserAddRows = true;
        }
    }
}
