using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Common
{
    public class clsInvoice
    {
        /// <summary>
        /// Contains the invoice number
        /// </summary>
        private string sInvoiceNumber;

        /// <summary>
        /// Contains the Date of the Invoice
        /// </summary>
        private string sInvoiceDate;

        /// <summary>
        /// Contains the Total Cost
        /// </summary>
        private string sTotalCost;

        /// <summary>
        /// The list of the invoice items.
        /// </summary>
        private List<clsItem> lInvoiceItems = new();
        
        /// <summary>
        /// Getter and Setter for Invoice Number
        /// </summary>
        public string InvoiceNumber
        {
            get { return sInvoiceNumber;}
            set { sInvoiceNumber = value; }
        }

        /// <summary>
        /// Getter and Setter for Invoice Date
        /// </summary>
        public string InvoiceDate
        {
            get { return sInvoiceDate; }
            set { sInvoiceDate = value; }
        }

        /// <summary>
        /// Getter and Setter for Total Cost
        /// </summary>
        public string TotalCost
        {
            get { return sTotalCost; }
            set { sTotalCost = value; }
        }

        /// <summary>
        /// Getter and Setter for Total Cost
        /// </summary>
        public List<clsItem> InvoiceItems
        {
            get { return lInvoiceItems; }
            set { lInvoiceItems = value; }
        }
    }
}
