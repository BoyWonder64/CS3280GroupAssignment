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
        /// List that will hold all of the items
        /// </summary>
        //private List<clsItems> itemList;

        /// <summary>
        /// The current invoice.
        /// </summary>
        //clsInvoice currentInvoice;

        /// <summary>
        /// The list of items per invoice.
        /// </summary>
        private List<clsItem> ItemList;

        public void SaveNewInvoice(clsInvoice currentInvoice)
        {
            try
            {
                dataAccess.ExecuteNonQuery(clsMainSQL.InsertInvoice(currentInvoice.InvoiceDate, currentInvoice.TotalCost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        //public void CreateNewInvoice()
        //{
        //    try
        //    {
        //        clsInvoice newInvoice = new clsInvoice();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
        //    }
        //}

        //public void EditInvoice(invoiceNew, invoiceOld)
        //{

        //}

        //GetInvoice(InvoiceNumber) returns clsInvoice - Get the invoice and items for the selected invoice and search window
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
