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
using System.Windows.Shapes;

namespace GroupAssignment.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// Adding the ItemsScreen window
        /// </summary>
        wndItems ItemsScreen;

        /// <summary>
        /// Adding the SearchScreen window
        /// </summary>
        wndSearch SearchScreen;

        public wndMain()
        {
            InitializeComponent();

        }

        /// <summary>
        /// When selecting this menu option, it switches to the Search Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOption_Search_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SearchScreen.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// When selecting this menu option, it switches to the Edit Items Screen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOption_EditItems_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ItemsScreen.ShowDialog();
            this.Show();

        }
    }
}
