using System;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using SQL_lite_database_search_wpf.Core;
using System.Collections.Generic;
using System.Windows.Controls;
using SQL_lite_database_search_wpf.UI;

namespace SQL_lite_database_search_wpf
{
    /// <summary>
    /// Logique d'interaction pour Add_window.xaml
    /// </summary>
    public partial class Add_window : ModernWindow
    {
        int NewProject { get { return (UIProject.Items.Count - 2); } }
        int NewProjectEmpty { get { return NewProject + 1; } }
        bool isDateUse { get { return UIDateTimeManager.isDateUsed; } }

        public Add_window()
        {
            InitializeComponent();

            loadMenuItems();

        }
        void loadMenuItems()
        {
            List<ComboBoxItem> mItems = new List<ComboBoxItem>();
            foreach (calendarObject pr in Core.AppCore.projects)
            {
                ComboBoxItem cItem = new ComboBoxItem();
                cItem.Content = pr.name.value;
                cItem.Resources.Add("tableName", pr.projectTableName);
                mItems.Add(cItem);
            }
            ComboBoxItem cItemProject = new ComboBoxItem();
            cItemProject.Content = "<New project ...>";
            mItems.Add(cItemProject);

            ComboBoxItem cItemProjectEmpty = new ComboBoxItem();
            cItemProjectEmpty.Content = "<New empty project...>";
            mItems.Add(cItemProjectEmpty);

            UIProject.ItemsSource = mItems;
        }
        private void btOk_Click(object sender, RoutedEventArgs e) { this.DialogResult = true; }

        public calendarObject Answer
        {
            get
            {
                calendarObject obj = new calendarObject();
                obj.name.value = tbName.Text;
                obj.domaine.value = tbDescription.Text;
                obj.priorite.value = Convert.ToInt32(slPriorite.Value);

                ComboBoxItem cItem = (ComboBoxItem)UIProject.SelectedItem;
                object item = cItem.Resources["tableName"];
                obj.tableName = item.ToString();

                if (isDateUse)
                {
                    obj.isDateUsed.value = true;
                    obj.startTime.value = UIDateTimeManager.time_start;
                    obj.endTime.value = UIDateTimeManager.time_start;
                }
                else
                {
                    obj.isDateUsed.value = false;
                    obj.startTime.value = new DateTime();
                    obj.endTime.value = new DateTime();
                }
                obj.description.value = tbDescription.Text;

                obj.completion.value = Convert.ToInt32(slCompletion.Value);
                obj.equipe.value = tbEquipe.Text;

                return obj;
            }
        }



        private void UIProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex == NewProject)
            {
                MessageBox.Show("Not implemented", "New Project");
                Add_Project addPr = new Add_Project(objectMode.project);
                addPr.Style = (Style)App.Current.Resources["BlankWindow"];
                addPr.ResizeMode = ResizeMode.CanResizeWithGrip;
                bool? result = addPr.ShowDialog();
                loadMenuItems();
            }
            else if (cb.SelectedIndex == NewProjectEmpty) { MessageBox.Show("Not implemented", "New Project empty"); }
        }
    }
}
