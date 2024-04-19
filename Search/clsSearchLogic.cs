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

        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Select Everything in invoices 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> GetAllInvoices() 
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectAll(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select distinct number from invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Select distinct date from invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctInvoiceDate() 
        {
            try
            {
                List<string> InvoiceDateList = new List<string>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectDistinctDate(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string date = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    InvoiceDateList.Add(date);
                }

                return InvoiceDateList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select distinct cost from invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDistinctCost() 
        {
            try
            {
                List<string> InvoiceCostList = new List<string>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectDistinctCost(), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string cost = row["TotalCost"].ToString();
                    InvoiceCostList.Add(cost);
                }

                return InvoiceCostList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select everything from invoice number
        /// </summary>
        /// <param name="sInvoiceNumer"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByNum(string sInvoiceNumer) 
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceNum(sInvoiceNumer), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select everything from invoice date
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByDate(string sInvoiceDate) 
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceDate(sInvoiceDate), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// select everything from invoice cost
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByCost(string sTotalCost)
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceCost(sTotalCost), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// select everything from invoice number and date
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <param name="sInvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByNumDate(string sInvoiceDate, string sInvoiceNumber)
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceNumDate(sInvoiceDate, sInvoiceNumber), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// select everything using invoice number and cost
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <param name="sInvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByCostNum(string sTotalCost, string sInvoiceNumber)
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceCostNum(sTotalCost, sInvoiceNumber), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// select everything from invoice number, date, and cost
        /// </summary>
        /// <param name="sInvoiceNumber"></param>
        /// <param name="sInvoiceDate"></param>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByNumDateCost(string sInvoiceNumber, string sInvoiceDate, string sTotalCost)
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceNumDateCost(sInvoiceNumber, sInvoiceDate, sTotalCost), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// select everything from invoice cost and date
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> SelectInvoicesByCostDate(string sTotalCost, string sInvoiceDate)
        {
            try
            {
                List<clsInvoice> InvoiceList = new List<clsInvoice>();
                int ret = 0;
                DataSet ds = db.ExecuteSQLStatement(clsSearchSQL.SelectInvoiceCostDate(sTotalCost, sInvoiceDate), ref ret);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clsInvoice invoice = new clsInvoice();
                    invoice.InvoiceNumber = row["InvoiceNum"].ToString();
                    invoice.InvoiceDate = DateTime.Parse(row["InvoiceDate"].ToString()).ToShortDateString();
                    invoice.TotalCost = row["TotalCost"].ToString();
                    InvoiceList.Add(invoice);
                }

                return InvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
