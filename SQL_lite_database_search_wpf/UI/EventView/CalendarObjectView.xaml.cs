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
    /// Interaction logic for CalendarObjectView.xaml
    /// </summary>
    public partial class CalendarObjectView : UserControl
    {
        public calendarObject CalendarObject { get; set; }
        public CalendarObjectView(calendarObject cObj)
        {
            InitializeComponent();


            CalendarObject = cObj;
            loadCommponements();
        }

        public void loadCommponements()
        {
            this.Background = new SolidColorBrush(CalendarObject.color);


            UITbName.Text = CalendarObject.name.value;
            UITbDexcription.Text = CalendarObject.description.value;

            UIStarPrirority.starPosition = CalendarObject.priorite.value;
            UISlideCompletion.Text = CalendarObject.completion.value.ToString() + "%";

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add_Project inputDialog = new Add_Project();
            inputDialog.Style = (Style)App.Current.Resources["BlankWindow"];
            inputDialog.parentTable = CalendarObject.tableName;
            inputDialog.ShowDialog();
        }
    }
}
