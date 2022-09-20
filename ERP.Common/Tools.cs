using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public class Tools
    {
        public static void RestartApp(int pid, string applicationName)
        {
            // Wait for the process to terminate
            Process process = null;

            try
            {
                process = Process.GetProcessById(pid);
                process.WaitForExit(10000);
            }
            catch (ArgumentException ex)
            {
                // ArgumentException to indicate that the 
                // process doesn't exist?   LAME!!
            }
            //Process.Start(applicationName, "");
        }
    }
}
