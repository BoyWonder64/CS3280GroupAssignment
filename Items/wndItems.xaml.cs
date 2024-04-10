using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace GroupAssignment
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        /// <summary>
        /// This will serve as the handle 
        /// </summary>
        clsHandleError handler;

        /// <summary>
        /// This will serve as the itemLogic link
        /// </summary>
        clsItemsLogic ItemLogic;

        /// <summary>
        /// This will serve as the item Link
        /// </summary>
        clsItem Item;

        /// <summary>
        /// I may need to use the currentInvoce. Adding this just in case
        /// </summary>
        clsInvoice CurrentInvoice;

        /// <summary>
        /// The Item window will allow you to add and delete items
        /// Display the items current, and display the code, desc, and cost
        /// </summary>

        /// <summary>
        /// Placeholder to help determine if the Items have been changed.
        /// Set to true when an item has been/edited/deleted.
        /// Used by main window to know if it needs refreshing items list
        /// </summary>
        public bool HasItemsBeenChanged = false;

        
       
        /// <summary>
        /// Main ItemScreen, setup all objects
        /// </summary>
        public wndItems(clsInvoice currentInvoice)
        {
            try
            {
                InitializeComponent();
                errorReseter();
                handler = new clsHandleError();
                ItemLogic = new clsItemsLogic();
                Item = new clsItem();
                datag_ItemDataGrid.ItemsSource = ItemLogic.GetAllItems();
                CurrentInvoice = currentInvoice;

            }
            catch (Exception ex) 
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        
        /// <summary>
        /// When the add item button is clicked, we will set the HasItemsBeenChanged to true
        /// so that we can notify the user and the other screens that changes have been made
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create a new Item obj
                clsItem NewItem = new clsItem();
                int ItemCost;

                txt_ItemCodeTextBox.IsEnabled = true;
                txt_ItemDescTextBox.IsEnabled = true;
                txt_ItemCostTextBox.IsEnabled = true;

                txt_ItemCodeTextBox.Text = "";
                txt_ItemDescTextBox.Text = "";
                txt_ItemCostTextBox.Text = "";

                //If none of the text entries are empty

                if (StringEntryChecker(txt_ItemCodeTextBox.Text) && int.TryParse(txt_ItemCostTextBox.Text, out ItemCost) )
                    { 
                        NewItem.ItemCode = txt_ItemCodeTextBox.Text;
                        NewItem.ItemDesc = txt_ItemDescTextBox.Text;
                        NewItem.ItemCost = txt_ItemCostTextBox.Text;

                        ItemLogic.AddItem(NewItem);
                        //Refresh the List
                        datag_ItemDataGrid.ItemsSource = ItemLogic.GetAllItems();
                    
                    HasItemsBeenChanged = true;
                    }
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the edit button is pressed. We will enable the screen
        /// and then allow the user to manipulate the item to fig their needs
        ///
        /// I have decided to not let the code get updated and will force it to remain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt_ItemDescTextBox.IsEnabled = true;
                txt_ItemCostTextBox.IsEnabled = true;
                lblEditBtnHelpMsg.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Will allow the user to delete an item from the database
        ///
        /// However, if an item is on an invoice it will not let them do so.
        /// It will also display an error that states ITEM ON INVOICE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txt_ItemCodeTextBox.Text != null && txt_ItemDescTextBox.Text != null && txt_ItemCostTextBox.Text != null)
                {
                    //Get the ItemCode from the TextBox
                    string sNewItem = txt_ItemCodeTextBox.Text; 
                    //Alight our Item to the obj
                    Item.ItemCode = sNewItem;
                    //Perform the Delete SQL
                    ItemLogic.DeleteItem(Item);
                    //Refresh the List
                    datag_ItemDataGrid.ItemsSource = ItemLogic.GetAllItems();
                    HasItemsBeenChanged = true;

                }
                
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveItem_Click(object sender, RoutedEventArgs e)
        {
            int cost;
            bool flag = false;
            try
            {
                if (txt_ItemCodeTextBox.Text == "")
                {
                    lblErr_CodeTxtBox.Content = "Must be single letter A-Z";
                    lblErr_CodeTxtBox.Visibility = Visibility.Visible;

                }
                else if (!int.TryParse(txt_ItemCostTextBox.Text, out cost))
                {
                    lblErr_CostTxtBox.Content = "Must be a number";
                    lblErr_CostTxtBox.Visibility = Visibility.Visible;
                }

                else if (txt_ItemDescTextBox.Text == "")
                {
                    lblErr_DescTxtBox.Content = "Must not be empty";
                    lblErr_DescTxtBox.Visibility = Visibility.Visible;
                }
                else
                {

                    if (txt_ItemCodeTextBox.Text != null && txt_ItemDescTextBox.Text != null && txt_ItemCostTextBox.Text != null)
                    {
                        string ItemDesc = txt_ItemDescTextBox.Text;
                        string ItemCost = txt_ItemCostTextBox.Text;

                        //Checks that an item selected from the list is valid
                        if (datag_ItemDataGrid.SelectedItem != null)
                        {
                            //Creates an item from the selected Item
                            clsItem selectedItem = (clsItem)datag_ItemDataGrid.SelectedItem;
                            clsItem NewItem = new clsItem();
                            //Set the values for the new Item
                            NewItem.ItemCode = selectedItem.ItemCode;
                            NewItem.ItemDesc = ItemDesc;
                            NewItem.ItemCost = ItemCost;

                            //Perform the Update Logic
                            ItemLogic.EditItem(selectedItem, NewItem);
                            //Update the HasItemBeenChanged flag to notify the main screen to refresh
                            HasItemsBeenChanged = true;

                            //Refresh the List
                            datag_ItemDataGrid.ItemsSource = ItemLogic.GetAllItems();

                            //Disable the boxes
                            txt_ItemDescTextBox.IsEnabled = false;
                            txt_ItemCostTextBox.IsEnabled = false;

                            //Wipe the errors clean
                            errorReseter();
                            
                            //Hide the helpful message
                            lblEditBtnHelpMsg.Visibility = Visibility.Hidden;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This checks the entry given from the user
        /// and checks if it is a letter between A-Z or a-z
        /// I got help for this from the following site
        /// -https://www.codeproject.com/Questions/322818/How-to-Allow-only-Alphabets-in-text-box
        /// </summary>
        /// <param name="userEntry"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool StringEntryChecker(string userEntry)
        {
            try
            {
                if (!Regex.IsMatch(userEntry, @"[a-zA-Z/][0-9]"))
                {
                    lblErr_CodeTxtBox.Content = "Must be single letter A-Z";
                    lblErr_CodeTxtBox.Visibility = Visibility.Visible;
                    return false;
                }
                else
                {
                    lblErr_CodeTxtBox.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return true;
        }

        /// <summary>
        /// This resets the labels to the proper error codes and then hides them
        /// </summary>
        private void errorReseter()
        {
            try
            {
                lblErr_CodeTxtBox.Content = "Must be single letter A-Z";
                lblErr_DescTxtBox.Content = "Must not be empty";
                lblErr_CostTxtBox.Content = "Must be a number";

                lblErr_CodeTxtBox.Visibility = Visibility.Hidden;
                lblErr_DescTxtBox.Visibility = Visibility.Hidden;
                lblErr_CostTxtBox.Visibility = Visibility.Hidden;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }



        /// <summary>
        /// Depending on what is selected, the selected cells
        /// display into the text boxes for the user to isolate
        /// and review
        /// This one took me a really LONG time to figure out.
        /// I got help from  the following stackoverflow article near the bottom
        /// -https://stackoverflow.com/questions/5121186/datagrid-get-selected-rows-column-values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datag_ItemSelected_Click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsItem selectedItem = (clsItem)datag_ItemDataGrid.SelectedItem;

                if (selectedItem != null)
                {
                    txt_ItemCodeTextBox.Text = selectedItem.ItemCode;
                    txt_ItemDescTextBox.Text = selectedItem.ItemDesc;
                    txt_ItemCostTextBox.Text = selectedItem.ItemCost;
                }
                datag_ItemDataGrid.Items.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
         
        }
        /// <summary>
        /// This will take in a value from the main window and compare the bool
        /// to see if an item has been adjusted or not
        /// </summary>
        public bool hasItemChangedChecker()
        {
            if (HasItemsBeenChanged)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}//End of Class
