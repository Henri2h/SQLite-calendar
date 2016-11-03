using SQL_lite_database_search_wpf.Core;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SQL_lite_database_search_wpf.UI.EventView
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : UserControl
    {
        public ListPage()
        {
            InitializeComponent();
            loadElements();
            UIControls.RefreshISNeeded += loadElements;
        }

        void loadElements()
        {
            UIStackData.Children.Clear();
            Project pro = new Project();
            pro.name.value = "Projects";
            pro.projectTableName = Core.AppCore.dCore.TableProject;

            UIStackData.Children.Add(new ProjectView(pro));

            foreach (Project pr in Core.AppCore.projects)
            {
                UIStackData.Children.Add(new ProjectView(pr));
            }

        }


    }
}
