using GroupAssignment.Common;
using GroupAssignment.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Search
{
    class clsSearchLogic
    {

        /// <summary>
        /// THis will be an ivoice to be added
        /// </summary>
        clsInvoice Invoice;

        private List<clsInvoice> InvoiceList;

        //GetInvoices(InvoiceNumber, InvoiceDate, TotalCost)

        clsDataAccess db = new clsDataAccess();



        ///SelectInvoice

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
                DataSet ds = db.ExecuteSQLStatement(clsMainSQL.SelectInvoice(invoiceNumber), ref itemCounter);
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

        public List<string> GetDistinctInvoiceNum() 
        {
            try
            {
                List<string> InvoiceNumList = new List<string>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectDistinctNum(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string num = row["InvoiceNum"].ToString();
                    InvoiceNumList.Add(num);
                }

                return InvoiceNumList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public List<string> GetDistinctInvoiceDate() 
        {
            try
            {
                List<string> InvoiceDateList = new List<string>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectDistinctDate(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string num = row["InvoiceDate"].ToString();
                    InvoiceDateList.Add(num);
                }

                return InvoiceDateList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public List<string> GetDistinctCost() 
        {
            try
            {
                List<string> InvoiceCostList = new List<string>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectDistinctCost(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string num = row["TotalCost"].ToString();
                    InvoiceCostList.Add(num);
                }

                return InvoiceCostList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
