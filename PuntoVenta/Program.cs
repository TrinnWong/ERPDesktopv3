using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;
            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Arial", 11);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             Application.Run(new Login());
            //Application.Run(new PVTacosAna());

        }
    }
}
