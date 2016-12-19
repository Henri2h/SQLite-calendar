﻿using SQL_lite_database_search_wpf.Core;
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
                calendarObject cObj = new calendarObject(UITbName.Text);


                cObj.description.value = UITbDescription.Text;


                cObj.priorite.value = UIslPriorite.starPosition;
                cObj.completion.value = Convert.ToInt32(UIslCompletion.Value);

                cObj.domaine.value = UITbDomaine.Text;

                // team
                // TODO : change it's value to a JSON array of the ID of the element of the team
                cObj.equipe.value = UITbEquipe.Text;
                cObj.isRepository.value = UIIsMainProject.IsChecked.Value;


                // ====================== other properties =========================
                cObj.tableName = getTableName();

                return cObj;

            }
        }

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



        // menu items
        int NewProject { get { return (UIProject.Items.Count - 2); } }
        int NewProjectEmpty { get { return NewProject + 1; } }


        public void loadMenuItems()
        {
            UIProject.Items.Clear();

            addSelectionInMenuItems("MainProjectTable", Core.AppCore.mainProjectTableName);
            foreach (calendarObject pr in Core.AppCore.projects)
            {
                addSelectionInMenuItems(pr.name.value, pr.projectTableName.value);
            }

            addSelectionInMenuItems("<New project ...>", null);
            addSelectionInMenuItems("<New empty project ...>", null);
        }

        void addSelectionInMenuItems(string name, string tableName)
        {
            ComboBoxItem cItem = new ComboBoxItem();

            cItem.Content = name;
            cItem.Resources.Add("tableName", tableName);

            UIProject.Items.Add(cItem);
        }

        private void UIProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // new project selected
            if (cb.SelectedIndex == NewProject) { MessageBox.Show("Not implemented", "New Project empty"); }
            else if (cb.SelectedIndex == NewProjectEmpty) { MessageBox.Show("Not implemented", "New Project empty"); }
        }
    }
}
