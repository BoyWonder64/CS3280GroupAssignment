using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using GroupAssignment.Common;
using GroupAssignment.Items;

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

        /// <summary>
        /// Adding the ItemLogic class
        /// </summary>
        clsItemsLogic ItemLogic;

        /// <summary>
        /// Adding the Item class
        /// </summary>
        clsItem Item;



        /// <summary>
        /// Displays the error message.
        /// </summary>
        clsHandleError errorHandler = new();

        /// <summary>
        /// Main Window Constructor.
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            ItemsScreen = new wndItems();
            SearchScreen = new wndSearch();
            ItemLogic = new clsItemsLogic();
            Item = new clsItem();

            cbMenuItemList.ItemsSource = ItemLogic.GetAllItems(); //////// Displaying differently?
        }

        /// <summary>
        /// When selecting this menu option, it switches to the Search Screen
        /// </summary>
        /// <param name="sender">search button</param>
        /// <param name="e">click</param>
        private void MenuOption_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                SearchScreen.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When selecting this menu option, it switches to the Edit Items Screen 
        /// </summary>
        /// <param name="sender">items button</param>
        /// <param name="e">click</param>
        private void MenuOption_EditItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                ItemsScreen.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
