using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Search
{
    public class clsSearchSQL
    {
        /// <summary>
        /// Select Everything From Invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectAll()
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Invoice
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceNum(string sInvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNumber;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Number and Date
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceNumDate(string sInvoiceDate, string sInvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNumber + "AND InvoiceDate = #" + sInvoiceDate + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Number, Date, and Cost
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceNumDateCost(string sInvoiceNumber, string sInvoiceDate, string sTotalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNumber + "AND InvoiceDate = #" + sInvoiceDate + "# AND TotalCost = " + sTotalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Cost
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceCost(string sTotalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + sTotalCost;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Cost and Date
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceCostDate(string sTotalCost, string sInvoiceDate)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + sTotalCost + "AND InvoiceDate = #" + sInvoiceDate + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Cost and Date
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceCostNum(string sTotalCost, string sInvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + sTotalCost + "AND InvoiceNum = " + sInvoiceNumber;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Everything From Selected Date
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectInvoiceDate(string sInvoiceDate)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = #" + sInvoiceDate + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Distinct Number From Invoices
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectDistinctNum()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Distinct Date From Invoices
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectDistinctDate()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Select Distinct Cost From Invoices
        /// </summary>
        /// <param name="sTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string SelectDistinctCost()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /*
        SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum
        SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate
        SELECT DISTINCT(TotalCost) From Invoices order by TotalCost */

        }
}
