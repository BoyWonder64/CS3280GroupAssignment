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
        //EditItem(clsItem clsOldItem, clsItem clsNewItem)
        //DeleteItem(clsItem clsItemtoDelete)
        //IsItemOnInvoice(clsItem)
    }
}
