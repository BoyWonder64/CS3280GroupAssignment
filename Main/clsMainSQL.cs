using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Main
{
    internal class clsMainSQL
    {

        /// <summary>
        /// Updates the invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string UpdateInvoice()
        {
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = 1200 WHERE InvoiceNum = 123";
                return sSQL;
            }
            catch (Exception ex) 
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the line items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InsertLineItems()
        {
            try
            {
                string sSQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(123, 1, 'AA')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts into invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string InsertInvoice()
        {
            try
            {
                string sSQL = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#4/13/2018#, 100)";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the invoice number, date and cost
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceNumDateCost()
        {
            try
            {
                string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 123";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the item code, item desc, and cost
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectItemCodeItemDescCost()
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
        /// Performs an detailed search for line items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectLineItem()
        {
            try
            {
                string sSQL =
                    "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = 5000";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Performs a Delete for line items where invoice number is a set number
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string DeleteLineItem()
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = 5000";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
