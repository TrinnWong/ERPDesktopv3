﻿using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Base
{
    public class FormBaseXtraForm:XtraForm
    {

        public ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBaseXtraForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "FormBaseXtraForm";
            this.Load += new System.EventHandler(this.FormBaseXtraForm_Load);
            this.ResumeLayout(false);

        }

        private  void FormBaseXtraForm_Load(object sender, EventArgs e)
        {
            XtraMessageBox.Show("LOAD BASE");
        }

        public void ValidarAcceso(int idusuario, int idSucursal, string idForm)
        {
            if (!ERP.Business.SeguridadBusiness.ValidarAcceso(idusuario, idSucursal, idForm).ok)
            {
                ERP.Utils.MessageBoxUtil.ShowError("No tiene permisos para usar este recurso");
                this.BeginInvoke(new MethodInvoker(Close));
               
            }
        }
    }
}
