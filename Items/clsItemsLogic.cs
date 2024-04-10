using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GroupAssignment.Common;

namespace GroupAssignment.Items
{
    /// <summary>
    /// Contains the business logic for the Items Screen
    /// </summary>
    public class clsItemsLogic
    {
        /// <summary>
        ///Will hold the full item list to display to the user
        /// </summary>
        public static List<clsItem> ItemList;

        /// <summary>
        /// Creating this to remove redundency
        /// Links to the Data Access
        /// </summary>
         clsDataAccess db;

        /// <summary>
        /// Creating this to remove redundency
        /// Links to the Data Set
        /// </summary>
         DataSet ds;

        /// <summary>
        /// Constructors
        /// </summary>
        public clsItemsLogic()
        {
            ItemList = new List<clsItem>();
            ds = new DataSet();
            db = new clsDataAccess();

        }

        /// <summary>
        /// Gathers a full list of items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetAllItems()
        {
            try
            {
                ItemList = new List<clsItem>();
                //Used as the sql counter
                int iRet = 0;
                //Store the SQL search string inside ItemSQL
                string ItemSQL = clsItemsSQL.SelectItem();

                //Execute the SQL statement using the clsDataAccess Class
                ds = db.ExecuteSQLStatement(ItemSQL, ref iRet);

                for (int i = 0; i < iRet; i++)
                {
                    clsItem Item = new clsItem();
                    Item.ItemCode = ds.Tables[0].Rows[i][0].ToString();
                    Item.ItemDesc = ds.Tables[0].Rows[i][1].ToString();
                    Item.ItemCost = ds.Tables[0].Rows[i][2].ToString();
                    ItemList.Add(Item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                    + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                    + ex.Message);
            }
            //Return the item List
            return ItemList;
        }

        /// <summary>
        /// Performs the Add Item SQL statement and executes the sql statement
        /// </summary>
        /// <param name="NewItem"></param>
        public void AddItem(clsItem NewItem)
        {
            try
            {
                //Used as the sql counter
                int iRet = 0;

                string ItemSQL = clsItemsSQL.AddItem(NewItem.ItemCode, NewItem.ItemDesc, NewItem.ItemCost);

                //Execute the query
                ds = db.ExecuteSQLStatement(ItemSQL, ref iRet);
            }
            catch (Exception ex)
            {

            }
            
        }

        /// <summary>
        /// Performs the EditItem SQL and executes the sql statement
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        public void EditItem(clsItem oldItem, clsItem newItem)
        {
            try
            {
                if (oldItem.Equals(null))
                {
                    MessageBox.Show("Item Cannot be Empty!!!");
                }
                else
                {
                    //Used as the sql counter
                    int iRet = 0;
                    //Store the SQL search string inside ItemSQL
                    string ItemSQL = clsItemsSQL.EditItem(newItem.ItemDesc, newItem.ItemCost, newItem.ItemCode);
                    //Execute the Query
                   iRet = db.ExecuteNonQuery(ItemSQL);

                   if (iRet <= 0)
                   {
                        oldItem.ItemDesc = newItem.ItemDesc;
                        oldItem.ItemCost = newItem.ItemCost;
                        oldItem.ItemCode = newItem.ItemCode;
                   }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
         
        }

        /// <summary>
        /// Performs the Delete Items SQL and then executes the sql statement
        /// </summary>
        /// <param name="ItemToDelete"></param>
        public void DeleteItem(clsItem ItemToDelete)
        {
            try
            {
                if (!IsItemOnInvoice(ItemToDelete))
                {
                    MessageBox.Show("Unable to remove Item, it is currently on an invoice");
                }
                else
                {
                    //Used as the sql counter
                    int iRet = 0;
                    //Store the SQL search string inside ItemSQL
                    string ItemSQL = clsItemsSQL.DeleteItem(ItemToDelete.ItemCode);
                    //Execure the Query
                    iRet = db.ExecuteNonQuery(ItemSQL);
                    //Refresh the List
                    GetAllItems();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }
        
        /// <summary>
        /// Performs the IsItemsOnInvoice SQL statement Then executes the statement
        /// </summary>
        /// <param name="Item"></param>
        private bool IsItemOnInvoice(clsItem Item)
        {
            try
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if (ItemList[i].ItemCode == Item.ItemCode)
                    {
                        return true;
                    }
                }
                //else return false
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
    
    }
}
