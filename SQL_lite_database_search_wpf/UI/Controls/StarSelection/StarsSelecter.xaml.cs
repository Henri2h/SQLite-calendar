using System.Windows;
using System.Windows.Controls;

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
                StarPosition = value;
                display();
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
