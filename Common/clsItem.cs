using System;
using System.Collections.Generic;
using System.Linq;
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
        public string ItemCode { get {  return sItemCode; } set {  sItemCode = value; } }

        /// <summary>
        /// ItemDesc getter and setter
        /// </summary>
        public string ItemDesc { get {  return sItemDesc; } set { sItemDesc = value; } }

        /// <summary>
        /// Item Cost getter and setter
        /// </summary>
        public string ItemCost { get {  return sItemCost; } set { sItemCost = value; } }

        /// <summary>
        /// Override of ToString Method.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return sItemDesc;
        }
    }
}
