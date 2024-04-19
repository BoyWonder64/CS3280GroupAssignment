using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GroupAssignment.Common;

namespace GroupAssignment.Main
{
    public class clsMainLogic
    {
        /// <summary>
        /// data Access object.
        /// </summary>
        clsDataAccess dataAccess = new clsDataAccess();

        /// <summary>
        /// Saves a newly created invoice to database. This works by inserting a new invoice, looping through the item list and adding each item to the 
        /// line item, then returns the new invoice number.
        /// </summary>
        /// <param name="currentInvoice">current invoice object</param>
        /// <returns>invoice number</returns>
        /// <exception cref="Exception"></exception>
        public string SaveNewInvoice(clsInvoice currentInvoice)
        {
            try
            {
                int counter = 1;
                dataAccess.ExecuteNonQuery(clsMainSQL.InsertInvoice(currentInvoice.InvoiceDate, currentInvoice.TotalCost));
                currentInvoice.InvoiceNumber = dataAccess.ExecuteScalarSQL(clsMainSQL.getNewestInvoice());
                foreach (clsItem item in currentInvoice.InvoiceItems)
                {
                    dataAccess.ExecuteNonQuery(clsMainSQL.InsertLineItems(currentInvoice.InvoiceNumber, counter.ToString(), item.ItemCode));
                    counter++;
                }
                return currentInvoice.InvoiceNumber;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the currently edited invoice. first, deletes all the linked items in line items. second, loops through all new items in invoice and 
        /// adds them to the line items. last, updates the total price.
        /// </summary>
        /// <param name="currentInvoice">current invoice object.</param>
        /// <exception cref="Exception"></exception>
        public void UpdateCurrentInvoice(clsInvoice currentInvoice)
        {
            try
            {
                int counter = 1;
                dataAccess.ExecuteNonQuery(clsMainSQL.DeleteLineItem(currentInvoice.InvoiceNumber));
                foreach (clsItem item in currentInvoice.InvoiceItems)
                {
                    // FIXME: need to figure out what "1" should be instead.
                    dataAccess.ExecuteNonQuery(clsMainSQL.InsertLineItems(currentInvoice.InvoiceNumber, counter.ToString(), item.ItemCode));
                    counter++;
                }
                dataAccess.ExecuteNonQuery(clsMainSQL.UpdateInvoice(currentInvoice.TotalCost, currentInvoice.InvoiceNumber));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /////////////////////////////////MIGHT NOT NEED THIS///////////////////////////////////////////////////
        /// <summary>
        /// Gets the invoice information using invoice number.
        /// </summary>
        /// <param name="invoiceNumber">invoice number</param>
        /// <returns>clsInvoice</returns>
        /// <exception cref="Exception"></exception>
        public clsInvoice GetInvoice(string invoiceNumber) 
        {
            try
            {
                int itemCounter = 0;
                DataSet ds = dataAccess.ExecuteSQLStatement(clsMainSQL.SelectInvoice(invoiceNumber), ref itemCounter);
                if (itemCounter == 1) 
                { 
                    clsInvoice invoice = new clsInvoice();
                    foreach (DataRow row in ds.Tables[0].Rows) 
                    { 
                        invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                        invoice.InvoiceDate = row["InvoiceDate"].ToString();
                        invoice.TotalCost = row["TotalCost"].ToString();
                    }
                    return invoice;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the items in the invoice.
        /// </summary>
        /// <param name="invoiceNum">invoice number.</param>
        /// <returns>list of items</returns>
        public List<clsItem> GetInvoiceItems(string invoiceNum)
        {
            List<clsItem> itemList = new();
            int iRetVal = 0;
            DataSet ds = dataAccess.ExecuteSQLStatement(clsMainSQL.SelectLineItem(invoiceNum), ref iRetVal);
            foreach (DataRow row in ds.Tables[0].Rows )
            {
                clsItem item = new clsItem();
                item.ItemCode = row["ItemCode"].ToString();
                item.ItemDesc = row["ItemDesc"].ToString();
                item.ItemCost = row["Cost"].ToString();
                itemList.Add(item);
            }
            return itemList;
        }

        /// <summary>
        /// Returns a string of the updated cost of all the items in invoice.
        /// </summary>
        /// <param name="CurrentInvoice">the invoice to sum the total.</param>
        /// <returns>string</returns>
        /// <exception cref="Exception"></exception>
        public string updateTotalCost(clsInvoice CurrentInvoice)
        {
            try
            {
                float iTotalCost = 0;
                foreach (clsItem item in CurrentInvoice.InvoiceItems)
                {
                    Int32.TryParse( item.ItemCost, out int result);
                    iTotalCost += (float)result;
                }
                CurrentInvoice.TotalCost = iTotalCost.ToString();
                return $"${Math.Round(iTotalCost, 2).ToString()}";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
