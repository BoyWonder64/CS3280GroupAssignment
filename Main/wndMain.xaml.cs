using System;
using System.Collections.Generic;
using System.Data;
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
            SearchScreen = new wndSearch();

            ItemLogic = new clsItemsLogic();
            MainLogic = new clsMainLogic();
            cbMenuItemList.ItemsSource = ItemLogic.GetAllItems();
            currentInvoice.InvoiceDate = DateTime.Today.ToShortDateString();
            dp_InvoiceDate.SelectedDate = DateTime.Today;
        }

        #region ButtonClickMethods

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
                    currentInvoice = SearchScreen.selectedInvoice;
                    dp_InvoiceDate.SelectedDate = DateTime.Parse(currentInvoice.InvoiceDate);
                    txt_InvoiceNumber.Text = currentInvoice.InvoiceNumber;
                    txt_TotalCost.Text = currentInvoice.TotalCost;

                    currentInvoice.InvoiceItems = MainLogic.GetInvoiceItems(currentInvoice.InvoiceNumber);
                    dg_InvoiceItemDisplay.ItemsSource = currentInvoice.InvoiceItems;

                    dg_InvoiceItemDisplay.ItemsSource = currentInvoice.InvoiceItems;
                    txt_InvoiceNumber.Text = currentInvoice.InvoiceNumber;
                    txt_TotalCost.Text = "$" + currentInvoice.TotalCost + ".00";
                    dp_InvoiceDate.Text = currentInvoice.InvoiceDate;

                    btn_EditInvoice.IsEnabled = true;
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

        /// <summary>
        /// Creates new invoice.
        /// </summary>
        /// <param name="sender">create invoice button</param>
        /// <param name="e">click</param>
        private void btn_CreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt_InvoiceNumber.Text = "TBD";
                //currentInvoice = new clsInvoice();
                cbMenuItemList.IsEnabled = true;
                dp_InvoiceDate.IsEnabled = true;
                dg_InvoiceItemDisplay.IsEnabled = true;
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Allows user to edit pre-existing invoices.
        /// </summary>
        /// <param name="sender">edit invoice</param>
        /// <param name="e">click</param>
        private void btn_EditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentInvoice.InvoiceItems.Count > 0) 
                { 
                    btn_AddItem.IsEnabled = true;
                    btn_RemoveItem.IsEnabled = true;
                }

                cbMenuItemList.IsEnabled = true;
                dg_InvoiceItemDisplay.IsEnabled = true;
                dp_InvoiceDate.IsEnabled = true;

                btn_EditInvoice.IsEnabled = false;
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Allows user to add new item to their invoice using the combo box selection.
        /// </summary>
        /// <param name="sender">add item button</param>
        /// <param name="e">click</param>
        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dp_InvoiceDate.SelectedDate != null) 
                {
                    btn_SaveInvoice.IsEnabled = true;
                }
                if (cbMenuItemList.SelectedValue == null)
                {
                    return;
                }

                currentInvoice.InvoiceItems.Add((clsItem)cbMenuItemList.SelectedValue);
                dg_InvoiceItemDisplay.ItemsSource = currentInvoice.InvoiceItems;
                dg_InvoiceItemDisplay.Items.Refresh();
                txt_TotalCost.Text = MainLogic.updateTotalCost(currentInvoice);

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

        /// <summary>
        /// Allows user to remove the selected item on the datagrid from the invoice.
        /// </summary>
        /// <param name="sender">remove item button</param>
        /// <param name="e">click</param>
        private void btn_RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dg_InvoiceItemDisplay.SelectedItem == null)
                {
                    return;
                }
                currentInvoice.InvoiceItems.Remove((clsItem)dg_InvoiceItemDisplay.SelectedValue);
                dg_InvoiceItemDisplay.ItemsSource = currentInvoice.InvoiceItems;
                dg_InvoiceItemDisplay.Items.Refresh();
                txt_TotalCost.Text = MainLogic.updateTotalCost(currentInvoice);
                btn_SaveInvoice.IsEnabled = true;

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

        /// <summary>
        /// Clears the screen.
        /// </summary>
        /// <param name="sender">clear button</param>
        /// <param name="e">click</param>
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dp_InvoiceDate.SelectedDate = DateTime.Today;
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
                dg_InvoiceItemDisplay.IsEnabled = false;
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Saves the currently edited invoice. Checks to see if invoice is new or if it is exists.
        /// </summary>
        /// <param name="sender">save invoice button</param>
        /// <param name="e">click</param>
        private void btn_SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentInvoice.InvoiceNumber != null)
                {
                    //update invoice using main logic.
                    MainLogic.UpdateCurrentInvoice(currentInvoice);
                }
                else
                {
                    // Save invoice using mainlogic.
                    txt_InvoiceNumber.Text = MainLogic.SaveNewInvoice(currentInvoice);
                }

                btn_AddItem.IsEnabled = false;
                btn_RemoveItem.IsEnabled = false;
                cbMenuItemList.IsEnabled = false;
                dg_InvoiceItemDisplay.IsEnabled = false;
                btn_SaveInvoice.IsEnabled = false;
                dp_InvoiceDate.IsEnabled = false;

                btn_EditInvoice.IsEnabled = true;
                SearchScreen.refreshInvoices();
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Checks to see if an item has been selected from the combo box.
        /// </summary>
        /// <param name="sender">selected item from combo box</param>
        /// <param name="e">click</param>
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

        /// <summary>
        /// Checks to see if date has been selected.
        /// </summary>
        /// <param name="sender">date picker</param>
        /// <param name="e">selected date</param>
        private void dp_InvoiceDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentInvoice.InvoiceDate = dp_InvoiceDate.SelectedDate.Value.Date.ToShortDateString();
                if (currentInvoice.InvoiceItems.Count == 0) 
                {
                    return;
                }
                btn_SaveInvoice.IsEnabled = true;
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion
    }
}
