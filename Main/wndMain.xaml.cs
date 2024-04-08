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
        private wndItems ItemsScreen;

        /// <summary>
        /// Adding the SearchScreen window
        /// </summary>
        private wndSearch SearchScreen;

        /// <summary>
        /// Adding the ItemLogic class
        /// </summary>
        private clsItemsLogic ItemLogic;

        /// <summary>
        /// The main logic class.
        /// </summary>
        private clsMainLogic MainLogic;

        /// <summary>
        /// Adding the Item class
        /// </summary>
        private clsItem Item;

        /// <summary>
        /// current invoice
        /// </summary>
        private clsInvoice currentInvoice;

        /// <summary>
        /// The current Items for the current invoice.
        /// </summary>
        private List<clsItem> CurrentItems;

        /// <summary>
        /// Displays the error message.
        /// </summary>
        private clsHandleError errorHandler = new();


        /// <summary>
        /// Main Window Constructor.
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            currentInvoice = new clsInvoice();
            ItemsScreen = new wndItems(currentInvoice);
            SearchScreen = new wndSearch(currentInvoice); // may not need to pass the current invoice.

            ItemLogic = new clsItemsLogic();
            MainLogic = new clsMainLogic();
            cbMenuItemList.ItemsSource = ItemLogic.GetAllItems(); 
        }

        #region ButtonClick
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

                if (SearchScreen.IsSelectedAnInvoice == false)
                {
                    this.Show();
                }
                else
                {
                    // FIXME: need to re-enable
                    //dp_InvoiceDate.SelectedDate = DateTime.Parse(currentInvoice.InvoiceDate);
                    //txt_InvoiceNumber.Text = currentInvoice.InvoiceNumber;
                    //txt_TotalCost.Text = currentInvoice.TotalCost;

                    //CurrentItems = MainLogic.GetInvoiceItems(currentInvoice.InvoiceNumber);
                    //dg_InvoiceItemDisplay.ItemsSource = CurrentItems;
                    CurrentItems = MainLogic.GetInvoiceItems("5000");
                    dg_InvoiceItemDisplay.ItemsSource = CurrentItems;
                    btn_RemoveItem.IsEnabled = true;
                    btn_AddItem.IsEnabled = true;
                    this.Show();
                }
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
                if (ItemsScreen.hasItemChangedChecker() == true)
                {
                    cbMenuItemList.ItemsSource = ItemLogic.GetAllItems(); 
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_CreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt_InvoiceNumber.Text = "TBD";
                clsInvoice newInvoice = new clsInvoice();
                CurrentItems = new List<clsItem>();
                cbMenuItemList.IsEnabled = true;
                dp_InvoiceDate.IsEnabled = true;
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_EditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentItems.Add((clsItem)cbMenuItemList.SelectedValue);
                dg_InvoiceItemDisplay.ItemsSource = CurrentItems;
                dg_InvoiceItemDisplay.Items.Refresh();
                txt_TotalCost.Text = updateTotalCost();

                if (dg_InvoiceItemDisplay.Items.Count == 1) 
                { 
                    btn_RemoveItem.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg_InvoiceItemDisplay.SelectedItem == null)
                {
                    return;
                }
                CurrentItems.Remove((clsItem)dg_InvoiceItemDisplay.SelectedValue);
                dg_InvoiceItemDisplay.ItemsSource = CurrentItems;
                dg_InvoiceItemDisplay.Items.Refresh();
                txt_TotalCost.Text = updateTotalCost();

                if (dg_InvoiceItemDisplay.Items.Count == 0)
                {
                    btn_RemoveItem.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                defaultScreen();
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        private void cbMenuItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsItem selectedItem = (clsItem)cbMenuItemList.SelectedItem;
                if (selectedItem != null)
                {
                    txt_ItemCost.Text = selectedItem.ItemCost;
                    btn_AddItem.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Other Methods

        /// <summary>
        /// Sets the default screen.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void defaultScreen()
        {
            try
            {
                dp_InvoiceDate.SelectedDate = null;
                txt_InvoiceNumber.Text = string.Empty;
                txt_TotalCost.Text = string.Empty;
                btn_EditInvoice.IsEnabled = false;
                dg_InvoiceItemDisplay.ItemsSource = null;
                txt_ItemCost.Text = "";
                cbMenuItemList.Text = "";

                btn_AddItem.IsEnabled = false;
                btn_RemoveItem.IsEnabled = false;
                btn_SaveInvoice.IsEnabled = false;
                btn_EditInvoice.IsEnabled = false;

                cbMenuItemList.IsEnabled = false;
                dp_InvoiceDate.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private string updateTotalCost()
        {
            try
            {
                int iTotalCost = 0;
                foreach (clsItem item in dg_InvoiceItemDisplay.ItemsSource)
                {
                    Int32.TryParse( item.ItemCost, out int result);
                    iTotalCost += result;
                }
                currentInvoice.TotalCost = iTotalCost.ToString();
                return iTotalCost.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

    }
}
