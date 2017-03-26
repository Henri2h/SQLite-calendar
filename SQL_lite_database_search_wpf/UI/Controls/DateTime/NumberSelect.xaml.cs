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
    // TODO : to sîmplify
    public partial class NumberSelect : UserControl
    {
        List<int> objects = new List<int>();
        public List<int> Items
        {
            set
            {
                objects = value;
                displayList();
            }
            get
            {
                displayList();
                return objects; ;
            }


        }
        public int value { get { return objects.ToArray()[PosSelect]; } }
        public int PosSelect = 0;

        int size { get { return objects.ToArray().Length; } }
        int maxPos { get { return size - 1; } }
        void displayList()
        {
            List<object> obj = new List<object>();
            if (size >= 3)
            {
                if (PosSelect == 0)
                {
                    obj.Add("");
                    obj.Add(objects[PosSelect]);
                    obj.Add(objects[PosSelect + 1]);
                }
                else if (PosSelect == maxPos)
                {
                    obj.Add(objects[PosSelect - 1]);
                    obj.Add(objects[PosSelect]);
                    obj.Add("");
                }
                else
                {
                    obj.Add(objects[PosSelect - 1]);
                    obj.Add(objects[PosSelect]);
                    obj.Add(objects[PosSelect + 1]);
                }
            }
            else if (size == 2)
            {
                if (PosSelect == 0)
                {
                    obj.Add("");
                    obj.Add(objects[PosSelect]);
                    obj.Add(objects[PosSelect + 1]);
                }
                else if (PosSelect == maxPos)
                {
                    obj.Add(objects[PosSelect - 1]);
                    obj.Add(objects[PosSelect]);
                    obj.Add("");
                }

            }
            else if (size == 1)
            {
                if (PosSelect == 0)
                {
                    obj.Add("");
                    obj.Add(objects[PosSelect]);
                }
                else if (PosSelect == maxPos)
                {
                    obj.Add(objects[PosSelect]);
                    obj.Add("");
                }

            }
            lsElements.ItemsSource = obj;
        }
        public NumberSelect()
        {

            InitializeComponent();
        }

        private void btMinus_Click(object sender, RoutedEventArgs e)
        {
            if (PosSelect > 0)
            {
                PosSelect--;
                displayList();
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (PosSelect < maxPos)
            {
                PosSelect++;
                displayList();
            }
        }

        private void lsElements_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch (Convert.ToInt32(e.NewValue))
            {
                case 4:
                    if (PosSelect > 1)
                    {
                        PosSelect = PosSelect - 2;
                        displayList();
                    }
                    break;
                case 3:
                    if (PosSelect > 0)
                    {
                        PosSelect--;
                        displayList();
                    }
                    break;
                case 1:
                    if (PosSelect < maxPos)
                    {
                        PosSelect++;
                        displayList();
                    }
                    break;
                case 0:
                    if (PosSelect < maxPos - 1)
                    {
                        PosSelect = PosSelect + 2;
                        displayList();
                    }
                    break;
            }
            slider.Value = 2;
            Thread.Sleep(50);

        }

        private void slider_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            slider.Value = 2;
        }


        private void slider_Update(object sender, MouseEventArgs e)
        {
            slider.Value = 2;
        }

        private void slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value = 2;
        }
    }
}
