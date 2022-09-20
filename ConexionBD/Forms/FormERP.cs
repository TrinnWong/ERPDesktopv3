using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionBD.Forms
{
    public partial class FormERP : Form
    {
        public ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public int accionForm { get; set; }
        public int idForm { get; set; }
        public FormERP()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void FormERP_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void FormERP_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
        }
    }
}
