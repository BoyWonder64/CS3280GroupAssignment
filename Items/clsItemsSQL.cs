using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    public class clsItemsSQL
    {
        /// <summary>
        /// Addes the select itemcode, itemdesc and cost from the current items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectItem()
        {
            try
            {
                string sSQL = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Collects a string for searching the LineItems to see if an invoice exists
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string FindInvoiceNumberForItem(string sItemCode)
        {
            try
            {
                string sSQL = "SELECT distinct(InvoiceNum) from LineItems where ItemCode = " + sItemCode;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Collects a string for the update query for the Item
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sItemCode"></param>
        /// <param name="sItemCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public static string EditItem(string sItemDesc, string sItemCost, string sItemCode)
        {
            try
            {
                string sSQL = "UPDATE ItemDesc SET ItemDesc = '" + sItemDesc + "', Cost = " + sItemCost + " WHERE ItemCode = '" + sItemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Performs an insert into the ItemDesc
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string AddItem(string sItemCode, string sItemDesc, string sItemCost)
        {
            try
            {
                string sSQL = "Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values("+ sItemCode +","+ sItemDesc+ ","+ sItemCost+")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
     
        /// <summary>
        /// Performs a delete for the itemCode based on the ItemCode
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string DeleteItem(string sItemCode)
        {
            try
            {
                string sSQL = "Delete from ItemDesc Where ItemCode =" + " '" + sItemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }//End of Class
}
