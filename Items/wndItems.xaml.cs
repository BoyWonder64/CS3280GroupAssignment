﻿using System;
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
        /// The Item window will allow you to add and delete items
        /// Display the items current, and display the code, desc, and cost
        /// </summary>

        /// <summary>
        /// Placeholder to help determine if the Items have been changed.
        /// Set to true when an item has been/edited/deleted.
        /// Used by main window to know if it needs refreshing items list
        /// </summary>
        private bool HasItemsBeenChanged = false;
       
        /// <summary>
        /// Main ItemScreen, setup all objects
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();
                errorReseter();
                handler = new clsHandleError();
                ItemLogic = new clsItemsLogic();
                Item = new clsItem();

                datag_ItemDataGrid.ItemsSource = ItemLogic.GetAllItems();

            }
            catch (Exception ex) 
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        
        /// <summary>
        /// When the add item button is clicked,
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                HasItemsBeenChanged = true;

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Wnen the edit button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt_ItemCodeTextBox.IsEnabled = true;
                txt_ItemDescTextBox.IsEnabled = true;
                txt_ItemCostTextBox.IsEnabled = true;

                HasItemsBeenChanged = true;
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
                HasItemsBeenChanged = true;

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// 
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
                    flag = StringEntryChecker(txt_ItemCodeTextBox.Text);
                    if (flag == true)
                    {
                        //Set the user entry to Uppercase to keep formatting consistent
                        string upperCaseCode = txt_ItemCodeTextBox.Text.ToUpper();
                        //Place the entries into the object
                        Item.ItemCode = upperCaseCode;
                        Item.ItemDesc = txt_ItemDescTextBox.Text;
                        Item.ItemCost = txt_ItemCostTextBox.Text;
                        //Perform the logic and add the item
                        ItemLogic.AddItem(Item);

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
                if (!Regex.IsMatch(userEntry, @"[a-zA-Z/]"))
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
            lblErr_CodeTxtBox.Content = "Must be single letter A-Z";
            lblErr_DescTxtBox.Content = "Must not be empty";
            lblErr_CostTxtBox.Content = "Must be a number";

            lblErr_CodeTxtBox.Visibility = Visibility.Hidden;
            lblErr_DescTxtBox.Visibility = Visibility.Hidden;
            lblErr_CostTxtBox.Visibility = Visibility.Hidden;
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
                clsItem Item = (clsItem)datag_ItemDataGrid.SelectedItem;
                txt_ItemCodeTextBox.Text = Item.ItemCode;
                txt_ItemDescTextBox.Text = Item.ItemDesc;
                txt_ItemCostTextBox.Text = Item.ItemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
         
        }
    }
}//End of Class
