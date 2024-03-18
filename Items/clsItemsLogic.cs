using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupAssignment.Common;

namespace GroupAssignment.Items
{
    /// <summary>
    /// Contains the business logic for the Items Screen
    /// </summary>
    public class clsItemsLogic
    {
        private List<clsItem> ItemList = new List<clsItem>();

        public List<clsItem> GetAllItems()
        {
            return ItemList;
        }
        //GetAllItems returns List<clsItem>
        //AddItem(clsItem)
        //EditItem(clsItem clsOldItem, clsItem clsNewItem)
        //DeleteItem(clsItem clsItemtoDelete)
        //IsItemOnInvoice(clsItem)
    }
}
