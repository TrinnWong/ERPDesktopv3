namespace ERP.Produccion.Desktop
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.uiProduccionNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.uiProduccionPanelInicio = new DevExpress.XtraBars.BarButtonItem();
            this.uiConfiguracionBascula = new DevExpress.XtraBars.BarButtonItem();
            this.uiProduccionEn = new DevExpress.XtraBars.BarButtonItem();
            this.uiProduccionTerminado = new DevExpress.XtraBars.BarButtonItem();
            this.uiTraspasosSalida = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.uiBtnProduccionCocina = new DevExpress.XtraBars.BarButtonItem();
            this.uiBtnProduccionCocinaEjec = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonCocina = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.uiProduccionNuevo,
            this.uiProduccionPanelInicio,
            this.uiConfiguracionBascula,
            this.uiProduccionEn,
            this.uiProduccionTerminado,
            this.uiTraspasosSalida,
            this.barButtonItem1,
            this.barButtonItem2,
            this.uiBtnProduccionCocina,
            this.uiBtnProduccionCocinaEjec,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.barButtonItem1);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage4,
            this.ribbonCocina,
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(1265, 52);
            // 
            // uiProduccionNuevo
            // 
            this.uiProduccionNuevo.Caption = "Nuevo";
            this.uiProduccionNuevo.Id = 1;
            this.uiProduccionNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiProduccionNuevo.ImageOptions.Image")));
            this.uiProduccionNuevo.Name = "uiProduccionNuevo";
            this.uiProduccionNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiProduccionNuevo_ItemClick);
            // 
            // uiProduccionPanelInicio
            // 
            this.uiProduccionPanelInicio.Caption = "Inicio";
            this.uiProduccionPanelInicio.Id = 2;
            this.uiProduccionPanelInicio.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiProduccionPanelInicio.ImageOptions.Image")));
            this.uiProduccionPanelInicio.Name = "uiProduccionPanelInicio";
            this.uiProduccionPanelInicio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.uiProduccionPanelInicio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiProduccionPanelInicio_ItemClick);
            // 
            // uiConfiguracionBascula
            // 
            this.uiConfiguracionBascula.Caption = "Báscula";
            this.uiConfiguracionBascula.Id = 3;
            this.uiConfiguracionBascula.Name = "uiConfiguracionBascula";
            this.uiConfiguracionBascula.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiConfiguracionBascula_ItemClick);
            // 
            // uiProduccionEn
            // 
            this.uiProduccionEn.Caption = "En Producción";
            this.uiProduccionEn.Id = 4;
            this.uiProduccionEn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiProduccionEn.ImageOptions.Image")));
            this.uiProduccionEn.Name = "uiProduccionEn";
            this.uiProduccionEn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.uiProduccionEn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiProduccionEn_ItemClick);
            // 
            // uiProduccionTerminado
            // 
            this.uiProduccionTerminado.Caption = "Terminado Hoy";
            this.uiProduccionTerminado.Id = 5;
            this.uiProduccionTerminado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiProduccionTerminado.ImageOptions.Image")));
            this.uiProduccionTerminado.Name = "uiProduccionTerminado";
            this.uiProduccionTerminado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.uiProduccionTerminado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiProduccionTerminado_ItemClick);
            // 
            // uiTraspasosSalida
            // 
            this.uiTraspasosSalida.Caption = "Traspasos";
            this.uiTraspasosSalida.Id = 6;
            this.uiTraspasosSalida.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiTraspasosSalida.ImageOptions.Image")));
            this.uiTraspasosSalida.Name = "uiTraspasosSalida";
            this.uiTraspasosSalida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiTraspasosSalida_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Báscula Express Caja";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // uiBtnProduccionCocina
            // 
            this.uiBtnProduccionCocina.Caption = "Solicitudes";
            this.uiBtnProduccionCocina.Id = 9;
            this.uiBtnProduccionCocina.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiBtnProduccionCocina.ImageOptions.Image")));
            this.uiBtnProduccionCocina.Name = "uiBtnProduccionCocina";
            this.uiBtnProduccionCocina.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiBtnProduccionCocina_ItemClick);
            // 
            // uiBtnProduccionCocinaEjec
            // 
            this.uiBtnProduccionCocinaEjec.Caption = "Ejecución";
            this.uiBtnProduccionCocinaEjec.Id = 10;
            this.uiBtnProduccionCocinaEjec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiBtnProduccionCocinaEjec.ImageOptions.Image")));
            this.uiBtnProduccionCocinaEjec.Name = "uiBtnProduccionCocinaEjec";
            this.uiBtnProduccionCocinaEjec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiBtnProduccionCocinaEjec_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Aceptación";
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Entrada Directa";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Salida por Ajuste";
            this.barButtonItem5.Id = 13;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Pedidos";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonCocina
            // 
            this.ribbonCocina.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonCocina.Name = "ribbonCocina";
            this.ribbonCocina.Text = "Producción Por Solicitud";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.uiBtnProduccionCocina);
            this.ribbonPageGroup5.ItemLinks.Add(this.uiBtnProduccionCocinaEjec);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Producción";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.uiProduccionPanelInicio);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiProduccionNuevo);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiProduccionEn);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiProduccionTerminado);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Inventario";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.uiTraspasosSalida);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Configuraciones";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.uiConfiguracionBascula);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 578);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem uiProduccionNuevo;
        private DevExpress.XtraBars.BarButtonItem uiProduccionPanelInicio;
        private DevExpress.XtraBars.BarButtonItem uiConfiguracionBascula;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem uiProduccionEn;
        private DevExpress.XtraBars.BarButtonItem uiProduccionTerminado;
        private DevExpress.XtraBars.BarButtonItem uiTraspasosSalida;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonCocina;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem uiBtnProduccionCocina;
        private DevExpress.XtraBars.BarButtonItem uiBtnProduccionCocinaEjec;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    }
}