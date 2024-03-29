using GroupAssignment.Common;
using GroupAssignment.Items;
using GroupAssignment.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        /// This will grab the main screen window
        /// </summary>
        wndMain MainScreen;

        /// <summary>
        /// This will serve as the handle 
        /// </summary>
        clsHandleError handler;

        /// <summary>
        /// This adds the Invoice Class
        /// </summary>
        clsInvoice Invoice;

        /// <summary>
        /// This will serve as the itemLogic link
        /// </summary>
        clsItemsLogic ItemLogic;

        public wndSearch()
        {
            InitializeComponent();
            MainLogic = new clsMainLogic();
            MainScreen = new wndMain();
            handler = new clsHandleError();
            Invoice = new clsInvoice();
            ItemLogic = new clsItemsLogic();

            dgInvoice.ItemsSource = ItemLogic.GetAllItems();

        }

        /// <summary>
        /// BUtton that will send the user to the mainscreen after unputing invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainScreen.ShowDialog();
            this.Show();
        }

    }
}
