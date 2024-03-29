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
        /// Updates the total cost of the invoice.
        /// </summary>
        /// <param name="totalCost">Total cost</param>
        /// <param name="invoiceNum">Invoice Number</param>
        /// <returns>String</returns>
        /// <exception cref="Exception"></exception>
        public static string UpdateInvoice(string totalCost, string invoiceNum)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = " + totalCost + " " +
                              "WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex) 
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts Item into database.
        /// </summary>
        /// <param name="invoiceNum">Invoice Number</param>
        /// <param name="lineItemNum">Line Item Number</param>
        /// <param name="itemCode">Item Code</param>
        /// <returns>String</returns>
        /// <exception cref="Exception"></exception>
        public static string InsertLineItems(string invoiceNum, string lineItemNum, string itemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) " +
                              "Values(" + invoiceNum + ", " + lineItemNum + ", '" + itemCode + "')";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Inserts into invoices the invoice date and total cost.
        /// </summary>
        /// <param name="invoiceDate">Invoice date</param>
        /// <param name="totalCost">Total Cost</param>
        /// <returns>String</returns>
        /// <exception cref="Exception"></exception>
        public static string InsertInvoice(string invoiceDate, string totalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices(InvoiceDate, TotalCost) " +
                              "Values(#" + invoiceDate + "#, " + totalCost + ")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the invoice number, invoice date, and total cost.
        /// </summary>
        /// <param name="invoiceNum">Invoice Number</param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceNumDateCost(string invoiceNum)
        {
            try
            {
                string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost " +
                              "FROM Invoices " +
                              "WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects item code, item description, and cost from itemDesc.
        /// </summary>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public static string SelectItemCodeItemDescCost()
        {
            try
            {
                // FIXME: maybe wont work.
                string sSQL = "SELECT ItemCode, ItemDesc, Cost " +
                              "FROM ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Selects line item code, item description, and item cost.
        /// </summary>
        /// <param name="invoiceNum">invoice number</param>
        /// <returns>String</returns>
        /// <exception cref="Exception"></exception>
        public static string SelectLineItem(string invoiceNum)
        {
            try
            {
                string sSQL =
                    "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                    "FROM LineItems, ItemDesc " +
                    "Where LineItems.ItemCode = ItemDesc.ItemCode " +
                    "And LineItems.InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes Line Item.
        /// </summary>
        /// <param name="invoiceNum">Invoice Number</param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public static string DeleteLineItem(string invoiceNum)
        {
            try
            {
                string sSQL = "DELETE " +
                              "FROM LineItems " +
                              "WHERE InvoiceNum = " + invoiceNum;
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
