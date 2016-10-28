using System;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// Logique d'interaction pour Add_window.xaml
    /// </summary>
    public partial class Add_window : ModernWindow
    {
        public Add_window()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public calendarObject Answer
        {
            get
            {
                calendarObject obj = new calendarObject();
                obj.name = tbName.Text;
                obj.domaine = tbDescription.Text;
                obj.priorite = Convert.ToInt32(slPriorite.Value);
                obj.description = tbDescription.Text;
                obj.startTime = dpTime_start.Value;
                obj.endTime = dpTime_end.Value;
                obj.completion = Convert.ToInt32(slCompletion.Value);
                obj.equipe = tbEquipe.Text;

                return obj;
            }
        }
    }
}
