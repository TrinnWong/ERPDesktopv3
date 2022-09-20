
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Produccion.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;
            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Arial", 11);
            WindowsFormsSettings.TouchScaleFactor = (float)1.5;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
            Localizer.Active = Localizer.CreateDefaultLocalizer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Login());
        }
    }
}
