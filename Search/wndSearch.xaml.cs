using GroupAssignment.Common;
using GroupAssignment.Items;
using GroupAssignment.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GroupAssignment
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        /// <summary>
        /// THis will grab the mains logic
        /// </summary>
        clsMainLogic MainLogic;

        /// <summary>
        /// This will serve as the handle 
        /// </summary>
        clsHandleError handler;

        /// <summary>
        /// This adds the Invoice Class
        /// </summary>
        clsInvoice CurrentInvoice;

        /// <summary>
        /// This will serve as the itemLogic link
        /// </summary>
        clsItemsLogic ItemLogic;

        /// <summary>
        /// Flag to see if selected an invoice.
        /// </summary>
        bool SelectedAnInvoice;

        public wndSearch(clsInvoice currentInvoice)
        {
            InitializeComponent();

            MainLogic = new clsMainLogic();
            handler = new clsHandleError();
            ItemLogic = new clsItemsLogic();
            dgInvoice.ItemsSource = ItemLogic.GetAllItems();
            CurrentInvoice = currentInvoice;
        }

        /// <summary>
        /// BUtton that will send the user to the mainscreen after unputing invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Check if all drop boxes are selected.
                // then...
                CurrentInvoice.InvoiceNumber = dropNum.Text;
                CurrentInvoice.TotalCost = dropCost.Text;
                CurrentInvoice.InvoiceDate = dropDate.Text;
                SelectedAnInvoice = true;
                this.Hide();
            // if not return.
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            SelectedAnInvoice = true;
            this.Hide();
        }

        //USER WILL SELECT AN INVOICE AND THE INVOICE ID WILL HAVE TO BE SENT BACK TO THE MAIN WINDOW,
        //CREATE A (PROPERTY) THAT THE MAIN WINDOW CAN CHECK TO SEE IF AN INVOICE WAS ACTUALLY SELECTED,
        //SO THAT WE CAN LOAD THAT INVOICE INTO THE MAIN WINDOW.


        //SELECT INVOICE CLICK(NEEDS TO SET A LOCAL VARIABLE THAT HOLDS THE INVOICE ID, THEN THE MAIN
        //WINDOW CAN ACCES THAT VIA A PROPERTY AND WILL KNOW WETHER IT HAS BEEN SELECTED SO WE CAN JUMP
        //TO THE MAIN WINDOW.


        //PASS IN WHATEVER THE USER HAS SELECTED OF DATE, NUMBER, AND COST. FOR EACH SELECTION IF DATE
        //HAS BEEN SELECTED PASS IN NULL FOR THE OTHERS UNTIL THEY ARE SELECTED THEN YOU GET THAT
        //FILTERING AFFECT.

        /// <summary>
        /// Public property for to see if there was an invoice selected.
        /// </summary>
        public bool IsSelectedAnInvoice
        {
            get
            {
                try
                {
                    return SelectedAnInvoice;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

    }
}
