using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Seguridad
{
    public class SeguridadCommon
    {
        public static bool ShowAdminPass()
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
