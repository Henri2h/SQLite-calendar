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

namespace SQL_lite_database_search_wpf.UI.Controls.StarSelection
{
    /// <summary>
    /// Interaction logic for StarsSelecter.xaml
    /// </summary>
    public partial class StarsSelecter : UserControl
    {
        public bool canChange { get { return CanChange; } set { CanChange = value; } }
        bool CanChange = true;
        public int starPosition
        {
            get { return StarPosition; }
            set
            {
                if (CanChange)
                {
                    StarPosition = value; display();
                }
            }
        }
        int StarPosition = 0;

        public StarsSelecter()
        {
            InitializeComponent();
        }

        private void UIButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanChange)
            {
                StarButton sBt = (StarButton)sender;
                starPosition = sBt.StarPosition;
                display();
            }
        }

        void display()
        {
            UIButton0.isStarEnabled = false;
            UIButton1.isStarEnabled = false;
            UIButton2.isStarEnabled = false;
            UIButton3.isStarEnabled = false;
            UIButton4.isStarEnabled = false;

            if (starPosition >= 0) { UIButton0.isStarEnabled = true; }
            if (starPosition >= 1) { UIButton1.isStarEnabled = true; }
            if (starPosition >= 2) { UIButton2.isStarEnabled = true; }
            if (starPosition >= 3) { UIButton3.isStarEnabled = true; }
            if (starPosition == 4) { UIButton4.isStarEnabled = true; }
        }

    }
}
