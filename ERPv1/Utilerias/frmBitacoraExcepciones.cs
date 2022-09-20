using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Utilerias
{
    public partial class frmBitacoraExcepciones : FormBaseXtraForm
    {
        public frmBitacoraExcepciones()
        {
            InitializeComponent();
        }
        private static frmBitacoraExcepciones _instance;
        public static frmBitacoraExcepciones GetInstance()
        {
            if (_instance == null) _instance = new frmBitacoraExcepciones();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmBitacoraExcepciones_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                gridControl1.DataSource = oContext.sis_bitacora_errores.OrderByDescending(o=> o.IdError).ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmBitacoraExcepciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
