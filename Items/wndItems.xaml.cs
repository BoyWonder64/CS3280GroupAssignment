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
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        public wndItems()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Placeholder to help determine if the Items have been changed. If it has 
        /// </summary>
        private bool HasItemsBeenChanged = true;
        //bool HasItemsBeenChanged  //Set to true when an item has been/edited/deleted. Used by main window to know if it needs refreshing items list
        //bool HasItemsBeenChanged  //Property

        public void ItemChangeChecker()
        {
            if (HasItemsBeenChanged == true)
            {

            }
            else
            {
                //Disregard
            }
        }
    }
}//End of Class
