using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment.Common
{
    public class clsItem
    {
        /// <summary>
        /// Placeholder for Item Code
        /// </summary>
        private string sItemCode;

        /// <summary>
        /// Placeholder for Item Desc
        /// </summary>
        private string sItemDesc;

        /// <summary>
        /// Placeholder for ItemCost
        /// </summary>
        private string sItemCost;

        /// <summary>
        /// ItemCode getter and setter
        /// </summary>
        public string ItemCode 
        { 
            get 
            { 
                try
                {
                    return sItemCode; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
            set 
            {  
                try
                {
                    sItemCode = value; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
        }

        /// <summary>
        /// ItemDesc getter and setter
        /// </summary>
        public string ItemDesc 
        { 
            get 
            {  
                try
                {
                    return sItemDesc; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
            set 
            { 
                try
                {
                    sItemDesc = value; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
        }

        /// <summary>
        /// Item Cost getter and setter
        /// </summary>
        public string ItemCost 
        { 
            get 
            {  
                try
                {
                    return sItemCost; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
            set 
            { 
                try
                {
                    sItemCost = value; 
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                        + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                        + ex.Message);
                }
            } 
        }

        /// <summary>
        /// Override of ToString Method.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            try
            {
                return sItemDesc;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name
                                    + "." + MethodInfo.GetCurrentMethod().Name + " -> "
                                    + ex.Message);
            }
        }
    }
}
