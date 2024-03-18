using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupAssignment.Common
{
    internal class clsHandleError
    {

        /// <summary>
        /// The handle error takes in the class, method and error message and
        /// writes it to a message box, otherwise it writes out to a text file
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        public void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " ->" + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt",
                    Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
