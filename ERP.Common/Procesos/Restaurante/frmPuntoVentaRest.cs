using ConexionBD;
using ConexionBD.Models;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

using DevExpress.XtraReports.UI;
using ERP.Common.Configuracion;
using ERP.Common.Reports;
using ERP.Common.Seguridad;
using ERP.Common.Utils;
using ERP.Models.Cuentas;
using ERP.Models.Ingredientes;
using ERP.Models.PV;
using ERP.Models.Subfamilias;
using ERP.Reports;
using PuntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Procesos.Restaurante
{
    public partial class frmPuntoVentaRest : XtraForm
    {
        public int cuentaId { get; set; }
       public int[] mesasIdInit { get; set; }
        bool cuentaPagada { get; set; }
        string error = "";
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        List<ItemButtonPVModel> lstSubfamilias;        
        List<PVMenuButton> lstBtnSubfamilia;
        int paginaSubfamilia;
        int subfamiliaId;

        List<ItemButtonPVModel> lstPlatillos;
        List<PVMenuButton> lstBtnPlatillos;
        int paginaPlatillo;
        int platilloId;
        string platillo = "";
        string ingredientes = "";
        string adicionales = "";

        List<IngredienteModel> lstIngredientesPlatillo;
        List<ItemButtonPVModel> lstIngredientes;
        List<PVMenuButton> lstBtnIngredientes;
        int paginaIngrediente;
        int ingredienteId;
        List<int> ingredientesId;
        List<int> ingredientesId_orig;

        List<ItemButtonPVModel> lstAdicionales;
        List<PVMenuButton> lstBtnAdicionales;
        int paginaAdicionales;
        List<int> adicionalesId;
        public List<doc_pedidos_orden_cargos> lstCargos; 

        ERP.Common.Procesos.frmVentaFormasPago fpForm;
        cat_configuracion entityConfiguracion;
        int copiasImpresion = 0;




        private static frmPuntoVentaRest _instance;
        public static frmPuntoVentaRest GetInstance()
        {
            if (_instance == null) _instance = new frmPuntoVentaRest();
            return _instance;
        }

        public frmPuntoVentaRest()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            paginaSubfamilia = 1;
            paginaPlatillo = 1;
            
            paginaIngrediente = 1;
            paginaAdicionales = 1;

            lstCargos = new List<doc_pedidos_orden_cargos>();


        }

        #region botones

        private void registrarEventos()
        {
            btnA1Left.Click += btnALeft_Click;
            btnA1Rigt.Click += btnARigt_Click;
            btnA11.Click += btnA1_Click;
            btnA12.Click += btnA1_Click;
            btnA13.Click += btnA1_Click;
            btnA14.Click += btnA1_Click;
            btnA15.Click += btnA1_Click;
            btnA17.Click += btnA1_Click;
            btnA16.Click += btnA1_Click;
            btnA18.Click += btnA1_Click;


            btnB11.Click += btnB1_Click;
            btnB12.Click += btnB1_Click;
            btnB13.Click += btnB1_Click;
            btnB14.Click += btnB1_Click;
            btnB15.Click += btnB1_Click;
            btnB16.Click += btnB1_Click;
            btnB17.Click += btnB1_Click;
            btnB18.Click += btnB1_Click;
            btnB19.Click += btnB1_Click;
            btnB110.Click += btnB1_Click;
            btnB112.Click += btnB1_Click;
            btnB113.Click += btnB1_Click;
            btnB111.Click += btnB1_Click;

            btnC11.Click += btnC1_Click;
            btnC12.Click += btnC1_Click;
            btnC13.Click += btnC1_Click;
            btnC14.Click += btnC1_Click;
            btnC15.Click += btnC1_Click;
            btnC16.Click += btnC1_Click;
            btnC17.Click += btnC1_Click;
            btnC18.Click += btnC1_Click;

            btnD1.Click += btnD1_Click;
            btnD2.Click += btnD1_Click;
            btnD3.Click += btnD1_Click;
            btnD4.Click += btnD1_Click;
            btnD5.Click += btnD1_Click;
            btnD6.Click += btnD1_Click;
            btnD7.Click += btnD1_Click;
            btnD8.Click += btnD1_Click;
        


        }

        private void limpiarBotonesA()
        {
            for (int i = 1; i <= 8; i++)
            {
                Control controlA = Controls.Find("btnA1" + i.ToString(), true).FirstOrDefault();
                
                controlA.AccessibleName = "";
                controlA.Text = "";
                

            }
        }

        private void limpiarColoresA()
        {
            for (int i = 1; i <= 8; i++)
            {
                Control controlA = Controls.Find("btnA1" + i.ToString(), true).FirstOrDefault();

                controlA.BackColor = Color.Transparent;
                controlA.ForeColor = Color.Black;
                Size size = new Size(80, 30);
                controlA.Size = size;

            }
        }

        private void limpiarColoresB()
        {
            for (int i = 1; i <= 13; i++)
            {
                Control controlB = Controls.Find("btnB1" + i.ToString(), true).FirstOrDefault();
                Size size = new Size(80, 30);
                controlB.BackColor = Color.Orange;
                controlB.ForeColor = Color.Black;
                controlB.Size= size;
                


            }
        }

        private void limpiarBotonesB()
        {
            for (int i = 1; i <= 13; i++)
            {
              
                Control controlB = Controls.Find("btnB1" + i.ToString(), true).FirstOrDefault();

               
                controlB.AccessibleName = "";
                controlB.Text = "";

            }
        }

        private void limpiarBotonesC()
        {
            for (int i = 1; i <= 8; i++)
            {

                Control controlB = Controls.Find("btnC1" + i.ToString(), true).FirstOrDefault();


                controlB.AccessibleName = "";
                controlB.Text = "";

            }
        }
        private void limpiarColoresC()
        {
            for (int i = 1; i <= 8; i++)
            {
                Control controlB = Controls.Find("btnC1" + i.ToString(), true).FirstOrDefault();
                Size size = new Size(80, 30);
                controlB.BackColor = Color.Orange;
                controlB.ForeColor = Color.Black;
                controlB.Size = size;

            }
        }

        private void limpiarBotonesD()
        {
            for (int i = 1; i <= 8; i++)
            {

                Control controlB = Controls.Find("btnD" + i.ToString(), true).FirstOrDefault();


                controlB.AccessibleName = "";
                controlB.Text = "";

            }
        }
        private void limpiarColoresD()
        {
            for (int i = 1; i <= 8; i++)
            {
                Control controlB = Controls.Find("btnD" + i.ToString(), true).FirstOrDefault();
                Size size = new Size(80, 30);
                controlB.BackColor = Color.Orange;
                controlB.ForeColor = Color.Black;
                controlB.Size = size;

            }
        }


        #region subfamilia
        private void llenarSubfamilias()
        {
            int orden1 = 0;
            lstSubfamilias = new List<ItemButtonPVModel>();

            lstSubfamilias = oContext.cat_subfamilias
                .Where(
                    w=> w.cat_productos.Where(s=> s.ProdParaVenta == true).Count() > 0
                )
                .Select(
                    s => new ItemButtonPVModel()
                    {
                        descripcion = s.Descripcion.Substring(0,13).ToUpper(),
                        id = s.Clave
                    }
                ).OrderBy(o=> o.descripcion).ToList();

            for (int i = 0; i < lstSubfamilias.Count; i++)
            {
                lstSubfamilias[i].orden = orden1++;
            }
                
        }

        private void crearPaginadoFamilias()
        {
            try
            {
                int paginaCount = 1;
                int paginadoSubfamilias = 8;
                int indexIni = 0;
                int indexFin = paginadoSubfamilias-1;
                lstBtnSubfamilia = new List<PVMenuButton>();

                if (indexFin > (lstSubfamilias.Count - 1))
                {
                    indexFin = lstSubfamilias.Count - 1;
                }

                while (indexFin < lstSubfamilias.Count)
                {
                    PVMenuButton itemBtn = new PVMenuButton();

                    itemBtn.indexIni = indexIni;
                    itemBtn.indexFin = indexFin;
                    itemBtn.pagina = paginaCount;
                    itemBtn.itemsPagina = paginadoSubfamilias;

                    paginaCount++;
                    indexIni = indexFin + 1;
                    indexFin = indexFin + paginadoSubfamilias;

                    if (indexFin > (lstSubfamilias.Count - 1) && indexIni < (lstSubfamilias.Count ))
                    {
                        itemBtn.indexFin = lstSubfamilias.Count - 1;
                        indexFin = itemBtn.indexFin;
                    }


                    lstBtnSubfamilia.Add(itemBtn);

                }


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al crear el paginado de subfamilias",
                    "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void navegarSubfamilia(int posicionesMov)
        {
            try
            {
              
                
                paginaSubfamilia = paginaSubfamilia + posicionesMov;

                if( lstBtnSubfamilia.Where(w=> w.pagina == paginaSubfamilia).Count() ==0)
                {
                    paginaSubfamilia = paginaSubfamilia - posicionesMov;
                    return;
                }
                else
                {
                    limpiarColoresA();
                    limpiarBotonesA();
                    limpiarBotonesB();
                    subfamiliaId = 0;
                }


                int indexIni = lstBtnSubfamilia.Where(w => w.pagina == (paginaSubfamilia )).FirstOrDefault().indexIni;
                int indexFin = lstBtnSubfamilia.Where(w => w.pagina == (paginaSubfamilia )).FirstOrDefault().indexFin;


                int nameBtn = 1;
                for (int i = indexIni; i <= indexFin; i++)
                {
                    Control btn = Controls.Find("btnA1" + nameBtn.ToString(), true).FirstOrDefault();

                    if(btn!=null)
                    {
                        btn.AccessibleName = lstSubfamilias[i].id.ToString();
                        btn.Text = lstSubfamilias[i].descripcion;                        
                    }
                    nameBtn++;
                   
                }
            }
            catch (Exception )
            {
                XtraMessageBox.Show("Ocurrió un error al crear los botones 1", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        #endregion

        #region platillos

        private void llenarPlatillos()
        {
            int orden1 = 0;
            lstPlatillos = new List<ItemButtonPVModel>();

            lstPlatillos = oContext.cat_productos
                .Where(w=> w.ClaveSubFamilia == subfamiliaId && w.Estatus == true && w.ProdParaVenta == true)
                .Select(
                    s => new ItemButtonPVModel()
                    {
                        descripcion = s.DescripcionCorta.Substring(0,13),
                        id = s.ProductoId
                    }
                ).OrderBy(o => o.descripcion).ToList();

            for (int i = 0; i < lstPlatillos.Count; i++)
            {
                lstPlatillos[i].orden = orden1++;
            }
        }

        private void crearPaginadoPlatillos()
        {
            try
            {
                int paginaCount = 1;
                int paginadoPlatillos = 13;
                int indexIni = 0;
                int indexFin = paginadoPlatillos - 1;
                lstBtnPlatillos = new List<PVMenuButton>();

                if(indexFin > (lstPlatillos.Count-1))
                {
                    indexFin = lstPlatillos.Count - 1;
                }


                while (indexIni < lstPlatillos.Count)
                {
                    PVMenuButton itemBtn = new PVMenuButton();

                    itemBtn.indexIni = indexIni;
                    itemBtn.indexFin = indexFin;
                    itemBtn.pagina = paginaCount;
                    itemBtn.itemsPagina = paginadoPlatillos;


                    if (indexFin > (lstPlatillos.Count - 1))
                    {
                        itemBtn.indexFin = lstPlatillos.Count - 1;
                    }


                    paginaCount++;
                    indexIni = indexFin + 1;
                    indexFin = indexFin + paginadoPlatillos;

                   

                    lstBtnPlatillos.Add(itemBtn);

                }


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al crear el paginado de subfamilias",
                    "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void navegarPlatillo(int posicionesMov)
        {
            try
            {
                limpiarBotonesB();
                limpiarColoresB();
                paginaPlatillo = paginaPlatillo + posicionesMov;

                if (lstBtnPlatillos.Where(w => w.pagina == paginaPlatillo).Count() == 0)
                {
                    paginaPlatillo = 1;// paginaPlatillo - posicionesMov;
                   // return;
                }


                int indexIni = lstBtnPlatillos.Where(w => w.pagina == (paginaPlatillo)).FirstOrDefault().indexIni;
                int indexFin = lstBtnPlatillos.Where(w => w.pagina == (paginaPlatillo)).FirstOrDefault().indexFin;


                int nameBtn = 1;
                for (int i = indexIni; i <= indexFin; i++)
                {
                    Control btn = Controls.Find("btnB1" + nameBtn.ToString(), true).FirstOrDefault();

                    if (btn != null)
                    {
                        
                            btn.AccessibleName = lstPlatillos[i].id.ToString();
                            btn.Text = lstPlatillos[i].descripcion;
                        
                      
                    }
                    nameBtn++;

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error al crear los botones 1", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ingredientes
        private void llenarIngredientes()
        {
            ingredientes = "";
            int orden1 = 0;
            lstIngredientes = new List<ItemButtonPVModel>();
            ingredientesId = new List<int>();
            lstIngredientes = oContext.cat_productos_base
                .Where(w => w.ProductoId == platilloId && w.cat_productos1.Estatus == true)
                .Select(
                    s => new ItemButtonPVModel()
                    {
                        descripcion = s.cat_productos1.DescripcionCorta,
                        id = s.ProductoBaseId
                    }
                ).OrderBy(o => o.descripcion).ToList();


            lstIngredientesPlatillo = lstIngredientes.Select(s => new IngredienteModel()
            {
                Id = s.id,
                descripcion = s.descripcion
            }
            ).ToList();

            for (int i = 0; i < lstIngredientes.Count; i++)
            {
                lstIngredientes[i].orden = orden1++;
                ingredientesId.Add(lstIngredientes[i].id);
            }
            ingredientesId_orig = new List<int>();
            foreach (var item in ingredientesId)
            {
                ingredientesId_orig.Add(item);
            }

           
        }

        private void crearPaginadoIngredientes()
        {
            try
            {
                int paginaCount = 1;
                int paginadoIngredientes = 8;
                int indexIni = 0;
                int indexFin = paginadoIngredientes - 1;
                lstBtnIngredientes = new List<PVMenuButton>();

                if (indexFin > (lstIngredientes.Count - 1))
                {
                    indexFin = lstIngredientes.Count - 1;
                }


                while (indexFin < lstIngredientes.Count)
                {
                    PVMenuButton itemBtn = new PVMenuButton();

                    itemBtn.indexIni = indexIni;
                    itemBtn.indexFin = indexFin;
                    itemBtn.pagina = paginaCount;
                    itemBtn.itemsPagina = paginadoIngredientes;

                    paginaCount++;
                    indexIni = indexFin + 1;
                    indexFin = indexFin + paginadoIngredientes;

                    if (indexFin > (lstIngredientes.Count - 1))
                    {
                        itemBtn.indexFin = lstIngredientes.Count - 1;
                    }

                    lstBtnIngredientes.Add(itemBtn);

                }


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al crear el paginado de subfamilias",
                    "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void navegarIngrediente(int posicionesMov)
        {
            try
            {
                paginaIngrediente = paginaIngrediente + posicionesMov;

                if (lstBtnIngredientes.Where(w => w.pagina == paginaIngrediente).Count() == 0)
                {
                    paginaIngrediente = paginaIngrediente - posicionesMov;
                    return;
                }


                int indexIni = lstBtnIngredientes.Where(w => w.pagina == (paginaIngrediente)).FirstOrDefault().indexIni;
                int indexFin = lstBtnIngredientes.Where(w => w.pagina == (paginaIngrediente)).FirstOrDefault().indexFin;


                int nameBtn = 1;
                for (int i = indexIni; i <= indexFin; i++)
                {
                    Control btn = Controls.Find("btnC1" + nameBtn.ToString(), true).FirstOrDefault();

                    if (btn != null)
                    {
                        btn.AccessibleName = lstIngredientes[i].id.ToString();
                        btn.Text = lstIngredientes[i].descripcion;

                        marcarBotonIngrediente(btn.Name,posicionesMov == 0? true:false);
                    }
                    nameBtn++;

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error al crear los botones 1", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void marcarBotonIngrediente(string name,bool cargaInicial)
        {
            try
            {

               

                Control controlA = Controls.Find(name, true).FirstOrDefault();

                if(cargaInicial)
                {                    
                    controlA.ForeColor = Color.Red;
                    return;
                }



                int.TryParse(controlA.AccessibleName, out ingredienteId);
                if (ingredientesId.IndexOf(ingredienteId) >=0)
                {                 
                    controlA.BackColor = Color.Transparent;
                    controlA.ForeColor = Color.Black;

                    if (!cargaInicial)
                    {
                        ingredientesId.Remove(ingredienteId);
                    }

                       

                }
                else
                {
                    controlA.BackColor = Color.Black;
                    controlA.ForeColor = Color.Red;


                    if (!cargaInicial)
                    {
                        ingredientesId.Add(ingredienteId);
                    }
                   
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al obtener la clave",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region adicionales
        private void llenarAdicioanles()
        {
            int orden1 = 0;
            lstAdicionales = new List<ItemButtonPVModel>();
            adicionalesId = new List<int>();

            lstAdicionales = oContext.cat_rest_platillo_adicionales
                .Where(w=> w.MostrarSiempre == true 
                ||
                w.cat_rest_platillo_adicionales_sfam.Where(z=> z.SubfamiliaId == subfamiliaId).Count() > 0
                )
                .Select(
                    s => new ItemButtonPVModel()
                    {
                        descripcion = s.Descripcion.Substring(0, 13).ToUpper(),
                        id = s.Id
                    }
                ).OrderBy(o => o.descripcion).ToList();

            for (int i = 0; i < lstAdicionales.Count; i++)
            {
                lstAdicionales[i].orden = orden1++;
                
            }
            adicionalesId = new List<int>();

        }

        private void crearPaginadoAdicionales()
        {
            try
            {
                int paginaCount = 1;
                int paginado = 8;
                int indexIni = 0;
                int indexFin = paginado - 1;
                lstBtnAdicionales = new List<PVMenuButton>();

                if (indexFin > (lstAdicionales.Count - 1))
                {
                    indexFin = lstAdicionales.Count - 1;
                }

                while (indexFin < lstAdicionales.Count)
                {
                    PVMenuButton itemBtn = new PVMenuButton();

                    itemBtn.indexIni = indexIni;
                    itemBtn.indexFin = indexFin;
                    itemBtn.pagina = paginaCount;
                    itemBtn.itemsPagina = paginado;

                    paginaCount++;
                    indexIni = indexFin + 1;
                    indexFin = indexFin + paginado;

                    if (indexFin > (lstAdicionales.Count - 1))
                    {
                        itemBtn.indexFin = lstAdicionales.Count - 1;
                    }

                    lstBtnAdicionales.Add(itemBtn);

                }


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al crear el paginado de subfamilias",
                    "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void navegarAdicional(int posicionesMov)
        {
            try
            {
                
                
                paginaAdicionales = paginaAdicionales + posicionesMov;

                if (lstBtnAdicionales.Where(w => w.pagina == paginaAdicionales).Count() == 0)
                {
                    paginaAdicionales = paginaAdicionales - posicionesMov;
                    return;
                }


                int indexIni = lstBtnAdicionales.Where(w => w.pagina == (paginaAdicionales)).FirstOrDefault().indexIni;
                int indexFin = lstBtnAdicionales.Where(w => w.pagina == (paginaAdicionales)).FirstOrDefault().indexFin;


                int nameBtn = 1;
                for (int i = indexIni; i <= indexFin; i++)
                {
                    Control btn = Controls.Find("btnD" + nameBtn.ToString(), true).FirstOrDefault();

                    if (btn != null)
                    {
                        btn.AccessibleName = lstAdicionales[i].id.ToString();
                        btn.Text = lstAdicionales[i].descripcion;

                        marcarBotonAdicional(btn.Name, posicionesMov == 0 ? true : false);
                    }
                    nameBtn++;

                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Ocurrió un error al crear los botones 1", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private void btnARigt_Click(object sender, EventArgs e)
        {
            navegarSubfamilia(1);
        }

        private void marcarBotonAdicional(string name, bool cargaInicial)
        {
            try
            {



                Control controlA = Controls.Find(name, true).FirstOrDefault();

                if (cargaInicial)
                {
                    controlA.ForeColor = Color.Black;
                    return;
                }



                int.TryParse(controlA.AccessibleName, out ingredienteId);
                if (adicionalesId.IndexOf(ingredienteId) >= 0)
                {
                    controlA.BackColor = Color.Transparent;
                    controlA.ForeColor = Color.Black;

                    if (!cargaInicial)
                    {
                        adicionalesId.Remove(ingredienteId);
                    }



                }
                else
                {
                    controlA.BackColor = Color.Black;
                    controlA.ForeColor = Color.Red;


                    if (!cargaInicial)
                    {
                        adicionalesId.Add(ingredienteId);
                    }

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al obtener la clave",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region eventos

        private void btnALeft_Click(object sender, EventArgs e)
        {
            navegarSubfamilia(-1);
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            try
            {
                Control btn = (Control)sender;

                int.TryParse(btn.AccessibleName, out subfamiliaId);
                if (subfamiliaId > 0)
                {
                   

                    limpiarColoresA();
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.Red;

                    
                    limpiarBotonesB();
                    limpiarColoresB();
                    limpiarBotonesC();
                    limpiarColoresC();
                    limpiarBotonesD();
                    limpiarColoresD();
                    llenarPlatillos();
                    crearPaginadoPlatillos();
                    navegarPlatillo(0);

                    llenarAdicioanles();
                    crearPaginadoAdicionales();
                    navegarAdicional(0);

                    calcularResumen();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al obtener la clave",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            try
            {
                Control btn = (Control)sender;
                platillo = "";
                int.TryParse(btn.AccessibleName, out platilloId);

                platillo = btn.Text;

                if (platilloId > 0)
                {
                    platillo = btn.Text;

                  

                    limpiarColoresB();
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.Red;

                    limpiarBotonesC();
                    limpiarColoresC();
                    llenarIngredientes();
                    crearPaginadoIngredientes();
                    navegarIngrediente(0);

                  


                }
                calcularResumen();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al obtener la clave",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            try
            {
                Control btn = (Control)sender;

                int.TryParse(btn.AccessibleName, out ingredienteId);
                if (ingredienteId > 0)
                {
                    marcarBotonIngrediente(btn.Name, false);

                    calcularResumen();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al determinar el ingrediente",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

        private void btnB1Left_Click(object sender, EventArgs e)
        {
            navegarPlatillo(-1);
        }

        private void btnB1Rigth_Click(object sender, EventArgs e)
        {
            navegarPlatillo(1);
        }

        private void btnC1Left_Click(object sender, EventArgs e)
        {
            navegarIngrediente(-1);
        }

        private void btnC1Rigth_Click(object sender, EventArgs e)
        {
            navegarIngrediente(1);
        }

        private void btnDLeft_Click(object sender, EventArgs e)
        {
            navegarAdicional(-1);
        }

        private void btnDRigth_Click(object sender, EventArgs e)
        {
            navegarAdicional(1);
        }

        private void btnD1_Click(object sender, EventArgs e)
        {
            try
            {
                int adicionalId;
                Control btn = (Control)sender;

                int.TryParse(btn.AccessibleName, out adicionalId);
                if (adicionalId > 0)
                {

                    marcarBotonAdicional(btn.Name, false);
                    calcularResumen();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al obtener la clave",
                   "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiMesa_EditValueChanged(object sender, EventArgs e)
        {


        }

       

        private void uiMesero_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {


                int[] a = uiMesaView.GetSelectedRows();
               

                string error = "";

                PedidoOrdenBusiness ordenB = new PedidoOrdenBusiness();

                #region orden
                doc_pedidos_orden orden = new doc_pedidos_orden();

                orden.Activo = true;
                orden.ClienteId = uiCliente.EditValue != null ? int.Parse(uiCliente.EditValue.ToString()) : 0;
                orden.ComandaId = null;
                orden.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                orden.CreadoPor = puntoVentaContext.usuarioId;
                orden.Descuento = 0;
                orden.FechaApertura = orden.CreadoEl;
                orden.FechaCierre = orden.CreadoEl;
                orden.Impuestos = 0;
                orden.MotivoCancelacion = "";
                orden.PedidoId = int.Parse(uiCuenta.Value.ToString());
                orden.Personas = byte.Parse(uiPersonas.Value.ToString());
                orden.PorcDescuento = 0;
                orden.Subtotal = 0;
                orden.SucursalId = puntoVentaContext.sucursalId;
                orden.Total = 0;
                orden.Para = uiPara.Text;
               
                #endregion

                #region ordenDetalle
                doc_pedidos_orden_detalle ordenDet = new doc_pedidos_orden_detalle();

                ordenDet.Cantidad = uiCantidad.Value;
                ordenDet.CreadoEl = orden.CreadoEl;
                ordenDet.CreadoPor = puntoVentaContext.usuarioId;
                ordenDet.Descuento = 0;
                ordenDet.Impuestos = 0;
                ordenDet.Notas = uiComentarios.Text;
                ordenDet.PorcDescuento = 0;
                ordenDet.PrecioUnitario = 0;
                ordenDet.ProductoId = platilloId;
                ordenDet.TasaIVA = 0;
                ordenDet.Total = 0;
                ordenDet.TipoDescuentoId = uiTipoDescuento.EditValue == null ? (byte)0 : byte.Parse(uiTipoDescuento.EditValue.ToString());
                ordenDet.Parallevar = uiParaLlevar.Checked;

                #endregion

                int meseroId = uiMesero.EditValue != null ? int.Parse(uiMesero.EditValue.ToString()) : 0;


                #region Sin ingredientes
                List<int> lstSinIngredientes = new List<int>();
                foreach (int item in ingredientesId_orig)
                {
                    if (ingredientesId.IndexOf(item) < 0)
                    {
                        lstSinIngredientes.Add(item);
                    }
                }
                #endregion

                #region mesas
                int[] indexmesas = uiMesaView.GetSelectedRows();
                List<int> mesasId = new List<int>();

                foreach (int item in indexmesas)
                {
                    cat_rest_mesas itemMesa = (cat_rest_mesas)uiMesaView.GetRow(item);
                    mesasId.Add(itemMesa.MesaId);
                }
                #endregion

                int comandaId = uiComanda.EditValue != null ?
                    int.Parse(uiComanda.EditValue.ToString()) : 0;

                error = ordenB.AgregarOrdenDetalle(ref orden, ref ordenDet, mesasId.ToArray(), meseroId, lstSinIngredientes.ToArray(), 
                    adicionalesId.ToArray(),ref comandaId,this.uiParaLlevar.Checked, puntoVentaContext);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else
                {
                    uiCuenta.Value = orden.PedidoId;
                    cuentaId = orden.PedidoId;
                    llenarLkpComanda();
                    uiComanda.EditValue = comandaId;                    
                    llenarGridDetalle();
                    limpiarDetalle();
                    calcularCuentasAbiertas();


                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al intentar actualizar la orden", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void uiCuentasAbiertas_Click(object sender, EventArgs e)
        {
            frmCuentasListado frm = new frmCuentasListado();

            frm.puntoVentaContext = this.puntoVentaContext;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        #region eventos de la forma
        private void frmPuntoVentaRest_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmPuntoVentaRest_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            string copiasImpresionRef=null;
            entityConfiguracion = oContext.cat_configuracion.FirstOrDefault();
            ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId, this.puntoVentaContext.sucursalId,
                "PVTicketCopias", this.puntoVentaContext.usuarioId, ref copiasImpresionRef);
            int.TryParse(copiasImpresionRef, out copiasImpresion);
            _Load();

          

        }
        #endregion


        #endregion


        #region funcionalidad
        private void llenarResumen()
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un problema al obtener el resumen", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarLkpMesas()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;

                uiMesa.Properties.DataSource = oContext.cat_rest_mesas
                     .Where(w => w.SucursalId == sucursalId && w.Activo).ToList();
            }
            catch (Exception )
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarLkpMeseros()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiMesero.Properties.DataSource = oContext.rh_empleados
                     .Where(w => w.Estatus == 1
                     && w.rh_puestos.Descripcion.ToUpper().Contains("MESERO")).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las mesas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarLkpClientes()
        {
            try
            {
                
                byte tipoDescuento = uiTipoDescuento.EditValue == null ? (byte)0 : byte.Parse(uiTipoDescuento.EditValue.ToString());
                bool soloEmpleado = tipoDescuento == 3 ? true:false;
                uiCliente.Properties.DataSource = oContext.cat_clientes.Where(w=> (w.EmpleadoId > 0 && soloEmpleado )|| !soloEmpleado).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener los clientes", "ERROR",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

           
                
        }

        private void calcularResumen()
        {
            try
            {
                calcularResumenIng();
                calcularResumenAdic();
                uiOrden.Text = platillo + ingredientes + adicionales;
              
                ingredientes = "";
                adicionales = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Error al calcular el resumen", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void calcularResumenIng()
        {
            if (ingredientesId == null)
                return;
            if(ingredientesId_orig.Count == ingredientesId.Count)
            {
                ingredientes = "";
            }
            else
            {
                foreach (int itemIng in ingredientesId_orig)
                {
                    if(ingredientesId.IndexOf(itemIng) <0)
                    {
                        var query = lstIngredientes.Where(w => w.id == itemIng).FirstOrDefault();
                        ingredientes = ingredientes + " S/"+query.descripcion;
                    }
                }
            }
        }

        private void calcularResumenAdic()
        {
            if (adicionalesId == null)
            {
                adicionales = "";
                return;
            }
            if(adicionalesId.Count == 0)
            {
                adicionales = "";
                return;
            }
                
           
                foreach (int itemIng in adicionalesId)
                {
                adicionales = adicionales + " /" + lstAdicionales.Where(w => w.id == itemIng).FirstOrDefault().descripcion;
                }
            
        }

        private void calcularCuentasAbiertas()
        {
            try
            {
                int sucursalID = puntoVentaContext.sucursalId;

                int cuentasPendientes = oContext.doc_pedidos_orden.Where(w => w.SucursalId == sucursalID && w.Activo == true).Count();

                uiCuentasAbiertas.Text = "Pend. {0}";

                uiCuentasAbiertas.Text =uiCuentasAbiertas.Text.Replace("{0}", cuentasPendientes.ToString());
            }
            catch (Exception )
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las cuentas pendientes",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void obtenerCuenta(int cuentaId)
        {
            try
            {
                this.cuentaId = cuentaId;

                ConexionBD.PedidoOrdenBusiness.CargoPorTarjeta(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId,this.cuentaId,this.puntoVentaContext.usuarioId,!uCargoTarjeta.Checked);
                oContext = new ERPProdEntities();
                doc_pedidos_orden entity = oContext.doc_pedidos_orden
                    .Where(w => w.PedidoId == cuentaId).FirstOrDefault();

                lstCargos = entity.doc_pedidos_orden_cargos.ToList();

                if (entity != null)
                {
                    cuentaId = entity.PedidoId;
                    uiCuenta.Value = entity.PedidoId;
                    uiPersonas.Value = entity.Personas;
                    uiMesero.EditValue = entity.doc_pedidos_orden_mesero.FirstOrDefault().EmpleadoId;
                    uiApertura.EditValue = entity.FechaApertura;
                    uiCierre.EditValue = entity.FechaCierre;
                    uiCliente.EditValue = entity.ClienteId;
                    uiComanda.EditValue = null;// entity.doc_pedidos_orden_detalle.Max(m => m.ComandaId);
                    cuentaPagada = entity.doc_ventas != null ? true : false;
                    uiUberEats.Checked = entity.UberEats??false;
                    uiPara.Text = entity.Para;
                    #region mesas


                    List<int> mesasId = entity.doc_pedidos_orden_mesa.Select(s => s.MesaId).ToList();

                    

                    List<cat_rest_mesas> lstMesas = (List<cat_rest_mesas>)uiMesa.Properties.DataSource;

                    uiMesa.ShowPopup();

                    for (int i = 0; i < lstMesas.Count; i++)
                    {

                       
                       
                            uiMesaView.UnselectRow(i);
                                            }
                    for (int i = 0; i < lstMesas.Count; i++)
                    {
                        
                        cat_rest_mesas mesa = ((cat_rest_mesas)uiMesaView.GetRow(i));

                    
                       if( mesasId.IndexOf(mesa.MesaId)>=0)
                        {
                            uiMesaView.SelectRow(i);
                        }
                    }
                    #endregion

                    int pedidoId = entity.PedidoId;
                    bool verTodo = uiVerTodaCuenta.Checked;
                    uiGridDetalle.DataSource = entity.doc_pedidos_orden_detalle
                         .Where(
                        w => w.PedidoId == pedidoId &&
                         (w.Cancelado ?? false) == false &&
                        (
                        verTodo ||
                        (
                            w.Impreso == false && !verTodo
                        )
                        )
                    )
                        .Select(
                            s => new CuentasDetalleViewModel()
                            {
                                cantidad = s.Cantidad,
                                cuentaDetalleId = s.PedidoDetalleId,
                                descripcion = s.cat_productos.DescripcionCorta,
                                posicion = 0,
                                total = s.Total,
                                imprimir = s.Impreso ?? false ? false:true,

                                folioComanda = s.cat_rest_comandas != null ? s.cat_rest_comandas.Folio.ToString() : "",
                                paraLlevar = s.Parallevar??false,
                                cancelado = s.Cancelado ?? false
                            }
                        ).OrderBy(o=> o.cuentaDetalleId).ToList();

                    if(cuentaPagada)
                    {
                        uiAgregar.Enabled = false;
                        uiGuardarEnc.Enabled = false;
                        uiImprimirComanda.Enabled = false;
                    }
                    else{
                        uiAgregar.Enabled = true;
                        uiGuardarEnc.Enabled = true;
                        uiImprimirComanda.Enabled = true;

                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("Ocurrió un error al intentar obtener la cuenta",
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al intentar obtener la cuenta",
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        public void nuevaCuenta(int pedidoId)
        {
            cuentaId = pedidoId;
            uiCuenta.EditValue = 0;
            uiPersonas.EditValue = 0;
            llenarLkpMesas();
            uiMesero.EditValue = 0;
            uiApertura.EditValue = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            uiCliente.EditValue = 0;
            limpiarDetalle();
            llenarGridDetalle();

            _Load();

        }

        public void marcarVerTodo(bool value)
        {
            uiVerTodaCuenta.Checked = value;
        }

        public void _Load()
        {
            HabilitarTimerImpresion(true);
            ingredientesId_orig = new List<int>();
            adicionalesId = new List<int>();
            uiApertura.EditValue = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            uiVerTodaCuenta.Checked = false;
            uiPersonas.Value = 1;
            llenarLkpMesas();
            
            llenarLkpMeseros();
            llenarLkpClientes();
            llenarSubfamilias();
            llenarLkpComanda();
            llenarLkpTipoDescuento();
            crearPaginadoFamilias();
            navegarSubfamilia(0);
            limpiarColoresA();
            limpiarColoresB();
            limpiarColoresC();
            limpiarBotonesD();
            registrarEventos();

            calcularCuentasAbiertas();

            if(!puntoVentaContext.solicitarComanda)
            {
                uiComanda.Enabled = false;
                uiComanda.EditValue = null;
            }
            else
            {
                uiComanda.Enabled = true;
            }


            if(cuentaId > 0)
            {
                obtenerCuenta(cuentaId);                                    
            }
            else
            {
                if (mesasIdInit != null)
                {
                    if (mesasIdInit.Length > 0)
                    {
                        MarcarMesas();

                    }

                }
            }
        }

        public void MarcarMesas()
        {
            #region mesas


            List<int> mesasId = mesasIdInit.ToList();


           

            List<cat_rest_mesas> lstMesas = (List<cat_rest_mesas>)uiMesa.Properties.DataSource;

            for (int i = 0; i < lstMesas.Count; i++)
            {
                              
                    uiMesaView.UnselectRow(i);
                
            }

            uiMesa.ShowPopup();
            for (int i = 0; i < lstMesas.Count; i++)
            {

                cat_rest_mesas mesa = ((cat_rest_mesas)uiMesaView.GetRow(i));


                if (mesasId.IndexOf(mesa.MesaId) >= 0)
                {
                    uiMesaView.SelectRow(i);
                }
            }
            #endregion
        }

        private void llenarLkpTipoDescuento()
        {
            try
            {
                uiTipoDescuento.Properties.DataSource = oContext.cat_tipos_descuento.ToList();
            }
            catch (Exception ex)
            {

                
            }
        }
        private void llenarLkpComanda()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;
                int cuentaId = int.Parse(uiCuenta.Value.ToString());

                uiComanda.Properties.DataSource = oContext.cat_rest_comandas
                    .Where(w => w.SucursalId == sucursalId
                    //&& (
                    //    w.doc_pedidos_orden_detalle.Count == 0
                    //    ||
                    //    (
                    //        w.doc_pedidos_orden_detalle.Count > 0 &&
                    //        w.doc_pedidos_orden_detalle.FirstOrDefault().PedidoId == cuentaId
                    //    )
                        
                    //)
                    ).OrderBy(o=> o.Folio).ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener las comandas", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void limpiarDetalle()
        {
            limpiarColoresB();
            limpiarBotonesC();
            limpiarColoresD();
            uiTipoDescuento.EditValue = null;
            uiComentarios.Text = "";
            uiCantidad.Value = 1;
            uiParaLlevar.Checked = false;
            platilloId = 0;
        }

        public void imprimirComanda()
        {
            try
            {
                int pedidoId = int.Parse(uiCuenta.Value.ToString());

                List<p_rpt_Comanda_Result> lstResult = oContext.p_rpt_Comanda(pedidoId, 0, true,uiComentarios.Text.Trim()).ToList();
                

                if (lstResult.Count == 0)
                {
                    XtraMessageBox.Show("No hay comanda por imprimir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();
                cat_impresoras entityImpresora;
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();

                if(puntoVentaContext.nombreImpresoraComanda.Length == 0)
                {
                    entityImpresora = oImpresora.ObtenerComandaImpresora(this.puntoVentaContext.sucursalId);

                    if (entityImpresora == null)
                    {
                        XtraMessageBox.Show("No hay una impresora configurada, vaya a la sección de impresoras", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    entityImpresora = new cat_impresoras();
                    entityImpresora.NombreRed = puntoVentaContext.nombreImpresoraComanda;
                }

               

                rptComanda oReport = new rptComanda();
               

                if(lstResult.Count > 0)
                {
                    oReport.DataSource = lstResult;
                    oReport.CreateDocument();

                    //oReport.Print(conf.NombreImpresora);

                    if(conf.vistaPreviaImpresion == true)
                    {
                        oReport.ShowPreview();
                    }
                    else
                    {
                        oReport.Print(entityImpresora.NombreRed);
                    }


                    this.Close();
                    frmMenuRest.GetInstance().AbrirComanda();                 

                   
                    
                        

                    //using (ReportPrintTool printTool = new ReportPrintTool(oReport))
                    //{

                    //    //printTool.ShowPreviewDialog();

                    //    // Invoke the Print Preview form 
                    //    // with the specified look and feel setting. 
                    //    printTool.ShowPreviewDialog(UserLookAndFeel.Default);

                        
                    //}
                }
                else
                {
                    XtraMessageBox.Show("No hay información pendiente de imprimir",
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                
                

               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message  ,
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);

            }
        }

        public void imprimirCuenta()
        {
            try
            {
                int pedidoId = int.Parse(uiCuenta.Value.ToString());

                if(pedidoId == 0)
                {
                    XtraMessageBox.Show("Es necesario abrir una cuenta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                error = ConexionBD.PedidoOrdenBusiness.CargoPorTarjeta(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId,
                    pedidoId,
                    this.puntoVentaContext.sucursalId,!uCargoTarjeta.Checked);

                if(error.Length  > 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error);
                    return;
                }

                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();


                rptCuenta oReport = new rptCuenta();
               
                int comandaId = int.Parse((uiComanda.EditValue == null ? 0 : uiComanda.EditValue).ToString());

                List<p_rpt_cuenta_Result> lstResult = oContext.p_rpt_cuenta(pedidoId).ToList();

                if (lstResult.Count > 0)
                {
                    oReport.DataSource = lstResult;
                    oReport.CreateDocument();

                    if(conf.vistaPreviaImpresion==true)
                    {
                        oReport.ShowPreview();
                    }
                    else
                    {
                        oReport.Print(conf.NombreImpresora);
                    }

                    

                    //this.Close();

                    //frmMenuRest.GetInstance().AbrirComanda();

                   
                }
                else
                {
                    XtraMessageBox.Show("No hay información pendiente de imprimir",
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }




            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                      "ERROR",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);

            }
        }
        
        private string validarAbrirFormaPago(decimal total)
        {
            string error = "";
            try
            {
                //if (total <= 0)
                //{
                //    error = "No se ha agregado ningun platillo.";

                //}
                
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }
            return error;
        }

        public void abrirFormasPago()
        {
            HabilitarTimerImpresion(false);
            int cuentaid = int.Parse(uiCuenta.Value.ToString());


            if(cuentaid == 0)
            {
                XtraMessageBox.Show("Es necesario abrir una cuenta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #region validar cuenta pagada
            if(cuentaPagada)
            {
                XtraMessageBox.Show("La cuenta ya está pagada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            if (
              oContext.doc_pedidos_orden_detalle
              .Where(w => w.PedidoId == cuentaid
              && (w.Impreso ?? false) == false
              && (w.Cancelado ?? false) == false
              ).Count() > 0
              )
            {
                XtraMessageBox.Show("Existen comandas sin imprimir, no es posible pagar la cuenta",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            decimal total = oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == cuentaid).Count() > 0 ?
                oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == cuentaid && (w.Cancelado ?? false) == false).Sum(S => S.Total) :0;
            string error = validarAbrirFormaPago(total);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            fpForm = new ERP.Common.Procesos.frmVentaFormasPago();
            fpForm.StartPosition = FormStartPosition.CenterParent;
            fpForm.totalVenta = total;
            fpForm.ShowDialog();

            HabilitarTimerImpresion(true);
        }


        public void pagar(List<FormaPagoModel> _formasPago, List<ValeFPModel> _vales, decimal totalRecibido, decimal cambio)
        {
           
            fpForm.Close();
            fpForm.Dispose();

            int _cuentaid = int.Parse(uiCuenta.Value.ToString());
            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

            List<doc_pedidos_orden_detalle> detalleVenta = oContext.doc_pedidos_orden_detalle.Where(w => w.PedidoId == _cuentaid && (w.Cancelado??false) == false).ToList();
            List<ProductoModel0> lstProductos = detalleVenta
                .Select(s=> new ProductoModel0()
                {
                     cantidad = s.Cantidad,
                      clave = s.cat_productos.Clave,
                       descripcion = s.cat_productos.DescripcionCorta,
                        impuestos = s.Impuestos,
                         montoDescuento = s.Descuento,
                          partida = 0,
                           porcDescuento = s.PorcDescuento,
                            porcDescuentoPartida = s.PorcDescuento,
                             porcDescunetoVta = 0,
                              porcImpuestos = 0,
                               precioCompra = 0,
                                precioNeto = 0,
                                 precioUnitario = s.PrecioUnitario,
                                  productoId = s.ProductoId,
                                   total = s.Total,
                                    unidadId = s.cat_productos.ClaveVendidaPor ?? 0,
                                    tipoDescuentoId=s.TipoDescuentoId ?? 0,
                                    promocionCMId = s.PromocionCMId??0,
                                    cargoAdicionalId = s.CargoAdicionalId
                }
                ).ToList();

            decimal total = detalleVenta.Sum(S => S.Total);
            decimal totalDescuento = detalleVenta.Sum(s => s.Descuento);


            List<FormaPagoModel>  lstFormasPago = _formasPago;
            long ventaId = 0;
            int? clienteId = uiCliente.EditValue != null ? int.Parse(uiCliente.EditValue.ToString()) : 0;
            decimal descuentoPartidas = 0;// lstProductos.Sum(s => s.montoDescuento);
            string error = "";

            //error = guarClienteId(ref clienteId);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            error = oData.pagar(ref ventaId, clienteId, "", 0, 0, descuentoPartidas, 0, totalDescuento, total,
                totalRecibido, cambio, false, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId, puntoVentaContext.cajaId, lstProductos, lstFormasPago, _vales, _cuentaid,false);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            else
            {
                //MessageBox.Show("La venta con FOLIO:" + uiFolio.Text + " se ha registrado con éxito");

                try
                {
                    error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);
                    if (error.Length > 0)
                    {
                        XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = "";
                    }

                    cat_configuracion entity = entityConfiguracion;

                    if (total >= (entity.MontoImpresionTicket ?? 0))
                    {
                        if (entity.ImprimirTicketMediaCarta == true)
                        {
                            rptVentaTicket_CartaM oTicket1 = new rptVentaTicket_CartaM();


                            ReportViewer oViewer = new ReportViewer(this.puntoVentaContext,false);

                            oTicket1.DataSource = oContext.p_rpt_VentaTicket(int.Parse(ventaId.ToString())).ToList();

                            oViewer.ShowTicket(oTicket1);
                        }
                        else
                        {
                            rptVentaTicket oTicket2 = new rptVentaTicket();


                            ReportViewer oViewer = new ReportViewer(this.puntoVentaContext, false);

                            var resultRpt = oContext.p_rpt_VentaTicket(int.Parse(ventaId.ToString())).ToList();

                            oTicket2.DataSource = resultRpt;                            
                            oViewer.ShowTicket(oTicket2);

                            if(copiasImpresion >1)
                            {
                                for (int i = 1; i < copiasImpresion; i++)
                                {
                                    oTicket2 = new rptVentaTicket();
                                    oViewer = new ReportViewer(this.puntoVentaContext, false);
                                    oTicket2.DataSource = resultRpt;
                                    oViewer.ShowTicket(oTicket2);
                                }
                            }

                            
                        }


                        //oViewer.Show();
                    }



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrió un error al intentar imprimir el ticket." + ex.Message, "ERROR");
                }

               
                frmComandaNueva frmo = frmComandaNueva.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = frmMenuRest.GetInstance();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.StartPosition = FormStartPosition.CenterParent;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.Show();


                }
                //nuevaCuenta();

                this.Close();

                //frmMenuRest.GetInstance().AbrirComanda();


            }


        }

        public void cancelarCuenta()
        {
            if(uiCuenta.Value > 0)
            {
                if(cuentaPagada)
                {
                    XtraMessageBox.Show("La cuenta ya está pagada, no es posible cancelar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAdminPass oAdmin = new frmAdminPass();
                oAdmin.StartPosition = FormStartPosition.CenterScreen;
                oAdmin.ShowDialog();

                if(oAdmin.DialogResult == DialogResult.OK)
                {
                    frmPedidoCancelacion oform = new frmPedidoCancelacion();
                    oform.pedidoId = cuentaId;
                    oform.puntoVentaContext = this.puntoVentaContext;
                    oform.Show();
                }
               
            }
        }

        public void asignarCargos(List<doc_pedidos_orden_cargos> _lst)
        {
            this.lstCargos = _lst;
            uiCargos.Text = "Cargos ({0})";
            uiCargos.Text = uiCargos.Text.Replace("{0}", lstCargos.Count.ToString());
        }
      
        #endregion

        private void uiMesaView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

            
           
        }

        private void uiMesa_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {

            int[] selectedR = uiMesaView.GetSelectedRows();

            string text = "";

            foreach (var item in selectedR)
            {
                text = text + ";" + ((cat_rest_mesas)uiMesaView.GetRow(item)).Nombre;
            }

            e.DisplayText = text;

            //var editor = sender as GridLookUpEdit;
            //var view = editor.Properties.View;
            //var selectedRowsCount = view.GetSelectedRows().Count();

            //if (selectedRowsCount > 0)
            //    e.DisplayText = "Number of selected rows: " + selectedRowsCount.ToString();
        }

        private void uiMesa_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            (sender as GridLookUpEdit).LookAndFeel.UpdateStyleSettings();

        }

        private void llenarGridDetalle()
        {
            try
            {
                bool verTodo = uiVerTodaCuenta.Checked;
                int id = int.Parse(uiCuenta.Value.ToString());

                oContext = new ERPProdEntities();
                uiGridDetalle.DataSource = oContext.doc_pedidos_orden_detalle
                    .Where(
                        w=> w.PedidoId == id &&
                        (w.Cancelado??false) == false &&
                        (
                        verTodo ||
                        (
                            w.Impreso == false && !verTodo
                        )
                        )
                    ).OrderByDescending(o=>o.CreadoEl)
                       .Select(
                           s => new CuentasDetalleViewModel()
                           {
                               cantidad = s.Cantidad,
                               cuentaDetalleId = s.PedidoDetalleId,
                               descripcion = s.cat_productos.DescripcionCorta,
                               posicion = 0,
                               total = s.Total,
                               imprimir = s.Impreso??false ? false:true,
                               folioComanda = s.cat_rest_comandas != null ? s.cat_rest_comandas.Folio.ToString() : "",
                               paraLlevar = s.Parallevar ??false,
                               cancelado = s.Cancelado??false
                             
                               
                               
                           }
                       ).OrderBy(o=> o.cuentaDetalleId).ToList();
            }
            catch (Exception)
            {

               
            }
        }

        private void repBtnDel_Click(object sender, EventArgs e)
        {
            CuentasDetalleViewModel entity = (CuentasDetalleViewModel)uiGridViewDetalle.GetFocusedRow();

            if (!entity.imprimir)
            {

                if (XtraMessageBox.Show("Está seguro de eliminar el registro",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    frmAdminPass oForm = new frmAdminPass();
                    oForm.StartPosition = FormStartPosition.CenterScreen;
                    oForm.ShowDialog();

                    if (oForm.DialogResult == DialogResult.OK)
                    {

                        if (entity != null)
                        {
                            oContext.p_doc_pedidos_orden_detalle_del(entity.cuentaDetalleId);

                            llenarGridDetalle();
                        }

                    }


                }

            }
            else
            {
                oContext.p_doc_pedidos_orden_detalle_del(entity.cuentaDetalleId);

                llenarGridDetalle();
            }

        }

        private void uiGuardarEnc_Click(object sender, EventArgs e)
        {
            try
            {
                int[] a = uiMesaView.GetSelectedRows();

                string error = "";

                ConexionBD.PedidoOrdenBusiness ordenB = new PedidoOrdenBusiness();

                #region orden
                doc_pedidos_orden orden = new doc_pedidos_orden();

                orden.Activo = true;
                orden.ClienteId = uiCliente.EditValue != null ? int.Parse(uiCliente.EditValue.ToString()) : 0;
                orden.ComandaId = null;
                orden.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                orden.CreadoPor = puntoVentaContext.usuarioId;
                orden.Descuento = 0;
                orden.FechaApertura = orden.CreadoEl;
                orden.FechaCierre = orden.CreadoEl;
                orden.Impuestos = 0;
                orden.MotivoCancelacion = "";
                orden.PedidoId = int.Parse(uiCuenta.Value.ToString());
                orden.Personas = byte.Parse(uiPersonas.Value.ToString());
                orden.PorcDescuento = 0;
                orden.Subtotal = 0;
                orden.SucursalId = puntoVentaContext.sucursalId;
                orden.Total = 0;
                orden.UberEats = uiUberEats.Checked;
                orden.Para = uiPara.Text;
                #endregion


                int meseroId = uiMesero.EditValue != null ? int.Parse(uiMesero.EditValue.ToString()) : 0;


           
                #region mesas
                int[] indexmesas = uiMesaView.GetSelectedRows();
                List<int> mesasId = new List<int>();

                foreach (int item in indexmesas)
                {
                    cat_rest_mesas itemMesa = (cat_rest_mesas)uiMesaView.GetRow(item);
                    mesasId.Add(itemMesa.MesaId);
                }
                #endregion



                error = ordenB.GuardarCuentaEnc(ref orden,mesasId.ToArray(), meseroId );

                if (error.Length > 0)
                {
                    MarcarMesas();
                        
                    XtraMessageBox.Show(error, "ERROR",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show("Se ha guardado la información", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    uiCuenta.Value = orden.PedidoId;
                    cuentaId = orden.PedidoId;
                    llenarGridDetalle();
                    calcularCuentasAbiertas();
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al intentar actualizar la orden", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

       

        private void uiVerTodaCuenta_CheckedChanged_1(object sender, EventArgs e)
        {
            llenarGridDetalle();
        }

        private void btnB1Left_Click_1(object sender, EventArgs e)
        {
            navegarPlatillo(-1);
        }

        private void btnB1Rigth_Click_1(object sender, EventArgs e)
        {
            navegarPlatillo(1);
        }

        private void btnC1Left_Click_1(object sender, EventArgs e)
        {
            navegarIngrediente(-1);
        }

        private void btnC1Rigth_Click_1(object sender, EventArgs e)
        {
            navegarIngrediente(1);
        }

        private void btnDLeft_Click_1(object sender, EventArgs e)
        {
            navegarAdicional(-1);
        }

        private void btnDRigth_Click_1(object sender, EventArgs e)
        {
            navegarAdicional(1);
        }

        private void uiImprimirComanda_Click(object sender, EventArgs e)
        {
            imprimirComanda();
        }

        private void frmPuntoVentaRest_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void uiTipoDescuento_EditValueChanged(object sender, EventArgs e)
        {
            /*byte tipoDescuento = uiTipoDescuento.EditValue == null ? (byte)0 : byte.Parse(uiTipoDescuento.EditValue.ToString());
            if(uiCliente.EditValue == null && tipoDescuento == 3)
            {
                llenarLkpClientes();
            }*/
        }

        private void repChkImprimir_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(uiGridViewDetalle.FocusedRowHandle>=0)
                {
                    CheckEdit obj = (CheckEdit)sender;
                    ERP.Models.Cuentas.CuentasDetalleViewModel entity = (ERP.Models.Cuentas.CuentasDetalleViewModel)uiGridViewDetalle.GetRow(uiGridViewDetalle.FocusedRowHandle);

                    int id = entity.cuentaDetalleId;
                    doc_pedidos_orden_detalle entityUpd = oContext.doc_pedidos_orden_detalle
                        .Where(w => w.PedidoDetalleId == id).FirstOrDefault();

                    entityUpd.Impreso = obj.Checked?false:true;

                    oContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiCargos_Click(object sender, EventArgs e)
        {
            frmPuntoVentaCargo frm = new frmPuntoVentaCargo();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.ShowDialog();
        }

        private void timer_Impresion_Tick(object sender, EventArgs e)
        {
            if(this.puntoVentaContext != null)
            {
                ConexionBD.PedidoOrdenBusiness.ImpresionAutomaticaPedido(this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId,
                    this.puntoVentaContext.cajaId);

            }
        }

        public void HabilitarTimerImpresion(bool enable)
        {
            //timer_Impresion.Enabled = enable;
        }

        private void uCargoTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            error = ConexionBD.PedidoOrdenBusiness.CargoPorTarjeta(this.puntoVentaContext.empresaId,
                this.puntoVentaContext.sucursalId,
                this.cuentaId, this.puntoVentaContext.usuarioId,!uCargoTarjeta.Checked);

            if(error.Length > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowError(error);
            }
            else
            {
                llenarGridDetalle();
            }
        }
    }
}
