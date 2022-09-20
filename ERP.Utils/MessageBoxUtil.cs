using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Utils
{
    public class MessageBoxUtil
    {
        public static void ShowError(string message)
        {
            XtraMessageBox.Show(message, "ERROR", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        public static void ShowErrorBita(int idError)
        {
            XtraMessageBox.Show("Ocurrió un error inesperado, revise el registro de bitácora ["+idError.ToString()+"]", 
                "ERROR", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message)
        {
            XtraMessageBox.Show(message, "ERROR", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        public static void ShowOk()
        {
            XtraMessageBox.Show("El proceso terminó con éxito", "OK", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }
    }
}
