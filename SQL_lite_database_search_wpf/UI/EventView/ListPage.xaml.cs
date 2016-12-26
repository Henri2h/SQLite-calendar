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

            UIControls.RefreshISNeeded += UIProjectView.loadElement;
            UIControls.AddNewElementAsked += UIProjectView.addNewElement;

            UI.UIObjectManager.calendarContentChanged += UIProjectView.loadElement;

            UIProjectView.tableSource = AppCore.mainProjectTableName;
            UIProjectView.loadElement();

        }

    }
}
