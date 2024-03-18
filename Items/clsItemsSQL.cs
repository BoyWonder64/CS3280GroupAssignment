using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Items
{
    class clsItemsSQL
    {
        public static string SelectInvoice()
        {
            try
            {
                string sSQL = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string SelectDistinctInvoiceNumber()
        {
            try
            {
                string sSQL = "SELECT distinct(InvoiceNum) from LineItems where ItemCode = 'A'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public static string UpdateItemDesc()
        {
            try
            {
                string sSQL = "Update ItemDesc Set ItemDesc = 'abcdef', Cost = 123 where ItemCode = 'A'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        public static string InsertIntoItemDesc()
        {
            try
            {
                string sSQL = "Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('ABC', 'blah', 321)";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
     

        public static string DeleteItem()
        {
            try
            {
                string sSQL = "Delete from ItemDesc Where ItemCode = 'ABC'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }//End of Class
}
