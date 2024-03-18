using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        private List<clsItem> ItemList;

        /// <summary>
        /// Will serve as an item to be added
        /// </summary>
        clsItem Item;


        ////////////////////////////////////////////////////////////////////////////// ALWAYS SYNC CODE /////////////////////////////////////////

        /// <summary>
        /// Gathers a full list of items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetAllItems()
        {
            try
            {
                //create db object from the clsDataAccess class
                clsDataAccess db = new clsDataAccess();
                //Use the DataSet to create a ds object
                DataSet ds = new DataSet();
                //Used as the sql counter
                int iRet = 0;
                //Create ItemList
                ItemList = new List<clsItem>();
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

        //AddItem(clsItem)
        public void AddItem(clsItem NewItem)
        {
            //create db object from the clsDataAccess class
            clsDataAccess db = new clsDataAccess();
            //Use the DataSet to create a ds object
            DataSet ds = new DataSet();
            //Used as the sql counter
            int iRet = 0;


            string ItemSQL = clsItemsSQL.AddItem(NewItem.ItemCode, NewItem.ItemDesc, NewItem.ItemCost);

            //Execute the query
            ds = db.ExecuteSQLStatement(ItemSQL, ref iRet);


        }

        //EditItem(clsItem clsOldItem, clsItem clsNewItem)
        public void EditItem(clsItem oldItem, clsItem newItem)
        {
            //create db object from the clsDataAccess class
            clsDataAccess db = new clsDataAccess();
            //Use the DataSet to create a ds object
            DataSet ds = new DataSet();
            //Used as the sql counter
            int iRet = 0;
            //Store the SQL search string inside ItemSQL
            string ItemSQL = clsItemsSQL.EditItem(oldItem.ItemCode, oldItem.ItemDesc, oldItem.ItemCost, newItem.ItemCode, newItem.ItemDesc, newItem.ItemDesc);
            ds = db.ExecuteSQLStatement(ItemSQL, ref iRet);
        }

        //DeleteItem(clsItem clsItemtoDelete)
        public void DeleteItem(string ItemToDelete)
        {
            //create db object from the clsDataAccess class
            clsDataAccess db = new clsDataAccess();
            //Use the DataSet to create a ds object
            DataSet ds = new DataSet();
            //Used as the sql counter
            int iRet = 0;

            //Store the SQL search string inside ItemSQL
            string ItemSQL = clsItemsSQL.DeleteItem(ItemToDelete);

            //Execute the SQL statement using the clsDataAccess Class
            ds = db.ExecuteSQLStatement(ItemSQL, ref iRet);

        }
        
        //IsItemOnInvoice(clsItem)
        public void IsItemInInvoice(string Item)
        {

        }
    
    }
}
