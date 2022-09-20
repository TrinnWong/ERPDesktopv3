using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos.Restaurante
{
    public partial class frmMesasEdit : XtraForm
    {
        public bool esNuevo { get; set; }
        public int id { get; set; }
        public PuntoVentaContext puntoVentaContext;
        MesasBusiness oMesas;
        ERPProdEntities oContext;
        public frmMesasEdit()
        {
            InitializeComponent();
            oMesas = new MesasBusiness();
            oContext = new ERPProdEntities();
        }

        private static frmMesasEdit _instance;

        public static frmMesasEdit GetInstance()
        {

            if (_instance == null) _instance = new frmMesasEdit();
            return _instance;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                cat_rest_mesas entity = new cat_rest_mesas();
                entity.MesaId = int.Parse(uiID.Value.ToString());
                entity.Activo = esNuevo ? true : uiActivo.Checked;
                entity.Descripcion = uiDescripcion.Text;
                entity.Nombre = uiNombre.Text;
                entity.CreadoPor = puntoVentaContext.usuarioId;
                entity.SucursalId = puntoVentaContext.sucursalId;

                if (esNuevo)
                {
                    error = oMesas.Insertar(ref entity);
                }
                else {
                    error = oMesas.Editar(ref entity,puntoVentaContext.usuarioId);
                }

                if(error.Length > 0)
                {
                    XtraMessageBox.Show(error,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    frmMesas.GetInstance().llenarGrid();
                    this.Close();
                }
              
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al guardar",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmMesasEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmMesasEdit_Load(object sender, EventArgs e)
        {
            if(!esNuevo)
            {
                cat_rest_mesas entity = oContext.cat_rest_mesas
                    .Where(w => w.MesaId == id).FirstOrDefault();

                uiNombre.Text = entity.Nombre;
                uiID.Value = entity.MesaId;
                uiDescripcion.Text = entity.Descripcion;
                uiActivo.Checked = entity.Activo;
            }
        }
    }
}
 