using GroupAssignment.Common;
using GroupAssignment.Items;
using GroupAssignment.Main;
using GroupAssignment.Search;
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
        clsSearchLogic SearchLogic;

        /// <summary>
        /// Flag to see if selected an invoice.
        /// </summary>
        bool SelectedAnInvoice;

        public wndSearch()
        {
            InitializeComponent();

            MainLogic = new clsMainLogic();
            handler = new clsHandleError();
            SearchLogic = new clsSearchLogic();
            cbInvoiceNum.ItemsSource = SearchLogic.GetDistinctInvoiceNum();
            cbInoiveDate.ItemsSource = SearchLogic.GetDistinctInvoiceDate();
            cbTotalCost.ItemsSource = SearchLogic.GetDistinctCost();
            dgInvoice.ItemsSource = SearchLogic.GetAllInvoices();
        }

        #region Methods

        /// <summary>
        /// BUtton that will send the user to the mainscreen after unputing invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgInvoice.SelectedValue != null)
                {
                    CurrentInvoice = (clsInvoice)dgInvoice.SelectedValue;
                    SelectedAnInvoice = true;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnClear_Click(sender, e);
                SelectedAnInvoice = false;
                this.Hide();
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cb = sender as ComboBox;
                if (cb.SelectedIndex == -1) { return; }
                if (cbInoiveDate.SelectedValue == null )
                {
                    if (cbTotalCost.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNum(cb.SelectedValue.ToString());
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByCostNum(cbTotalCost.Text, cb.SelectedValue.ToString());
                }
                else
                {
                    if (cbTotalCost.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNumDate(cbInoiveDate.Text, cb.SelectedValue.ToString());
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNumDateCost(cb.SelectedValue.ToString(), cbInoiveDate.Text, cbTotalCost.Text);
                }

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbInoiveDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cb = sender as ComboBox;
                if (cb.SelectedIndex == -1) { return; }
                if (cbInvoiceNum.SelectedValue == null )
                {
                    if (cbTotalCost.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByDate(cb.SelectedValue.ToString());
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByCostDate(cbTotalCost.Text, cb.SelectedValue.ToString());
                }
                else
                {
                    if (cbTotalCost.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNumDate(cb.SelectedValue.ToString(), cbInvoiceNum.Text);
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNumDateCost(cbInvoiceNum.Text, cb.SelectedValue.ToString(), cbTotalCost.Text);
                }

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbTotalCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cb = sender as ComboBox;
                if (cb.SelectedIndex == -1) { return; }
                if (cbInvoiceNum.SelectedValue == null )
                {
                    if (cbInoiveDate.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByCost(cb.SelectedValue.ToString());
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByCostDate(cb.SelectedValue.ToString(), cbInoiveDate.Text);
                }
                else
                {
                    if (cbInoiveDate.SelectedValue == null) 
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByCostNum(cb.SelectedValue.ToString(), cbInvoiceNum.Text);
                    else
                        dgInvoice.ItemsSource = SearchLogic.SelectInvoicesByNumDateCost(cbInvoiceNum.Text, cbInoiveDate.Text, cb.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cbInvoiceNum.SelectedIndex = -1;
                cbInoiveDate.SelectedIndex = -1;
                cbTotalCost.SelectedIndex = -1;
                dgInvoice.ItemsSource = SearchLogic.GetAllInvoices();
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        
        public void refreshInvoices()
        {
            try
            {
                cbInvoiceNum.ItemsSource = SearchLogic.GetDistinctInvoiceNum();
                cbInoiveDate.ItemsSource = SearchLogic.GetDistinctInvoiceDate();
                cbTotalCost.ItemsSource = SearchLogic.GetDistinctCost();
                dgInvoice.ItemsSource = SearchLogic.GetAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region PublicProperty
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

        public clsInvoice selectedInvoice
        {
            get
            {
                try
                {
                    return CurrentInvoice;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        #endregion
    }
}
