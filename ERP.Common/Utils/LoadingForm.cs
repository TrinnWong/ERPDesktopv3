using ERP.Common.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Utils
{
    public class LoadingTool
    {
        LoadingForm oForm;
        public void Show()
        {
            oForm = new LoadingForm("");
            oForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            oForm.Show();
        }

        public void Hide()
        {
            
            oForm.Close();
        }
    }
}
