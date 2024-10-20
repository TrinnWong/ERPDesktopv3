﻿namespace FlorMaiz.Desktop
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
            this.uiRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.uiMenuNuevaVenta = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuConfigBascula = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.uiProductoSobrante = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDesperdicioMasa = new DevExpress.XtraBars.BarButtonItem();
            this.uiDesperdicioTortilla = new DevExpress.XtraBars.BarButtonItem();
            this.uiTraspasos = new DevExpress.XtraBars.BarButtonItem();
            this.uiDevoluciones = new DevExpress.XtraBars.BarButtonItem();
            this.uiEntradaDirecta = new DevExpress.XtraBars.BarButtonItem();
            this.uiSalidaDirecta = new DevExpress.XtraBars.BarButtonItem();
            this.uiSincronizar = new DevExpress.XtraBars.BarButtonItem();
            this.uiRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.uiRibbonPageControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPedidos = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.uiRibbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // uiRibbonControl
            // 
            this.uiRibbonControl.ExpandCollapseItem.Id = 0;
            this.uiRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.uiRibbonControl.ExpandCollapseItem,
            this.uiMenuNuevaVenta,
            this.uiMenuConfigBascula,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.uiProductoSobrante,
            this.barButtonItem11,
            this.barButtonItem12,
            this.btnDesperdicioMasa,
            this.uiDesperdicioTortilla,
            this.uiTraspasos,
            this.uiDevoluciones,
            this.uiEntradaDirecta,
            this.uiSalidaDirecta,
            this.uiSincronizar});
            this.uiRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.uiRibbonControl.MaxItemId = 23;
            this.uiRibbonControl.Name = "uiRibbonControl";
            this.uiRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.uiRibbonPage,
            this.ribbonPedidos,
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.uiRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.uiRibbonControl.Size = new System.Drawing.Size(1083, 52);
            this.uiRibbonControl.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // uiMenuNuevaVenta
            // 
            this.uiMenuNuevaVenta.Caption = "Nueva Venta";
            this.uiMenuNuevaVenta.Id = 1;
            this.uiMenuNuevaVenta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuNuevaVenta.ImageOptions.Image")));
            this.uiMenuNuevaVenta.Name = "uiMenuNuevaVenta";
            this.uiMenuNuevaVenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuNuevaVenta_ItemClick);
            // 
            // uiMenuConfigBascula
            // 
            this.uiMenuConfigBascula.Caption = "Configuración Báscula";
            this.uiMenuConfigBascula.Id = 2;
            this.uiMenuConfigBascula.Name = "uiMenuConfigBascula";
            this.uiMenuConfigBascula.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuConfigBascula_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Buscar Ticket";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Configuración Báscula";
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Retiros";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Gastos";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Corte de Caja";
            this.barButtonItem5.Id = 7;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Impresora";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Impresora Ticket";
            this.barButtonItem7.Id = 9;
            this.barButtonItem7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.ImageOptions.Image")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Salir";
            this.barButtonItem8.Id = 10;
            this.barButtonItem8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.ImageOptions.Image")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Corte de Caja";
            this.barButtonItem9.Id = 11;
            this.barButtonItem9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.ImageOptions.Image")));
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Pendientes";
            this.barButtonItem10.Id = 12;
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // uiProductoSobrante
            // 
            this.uiProductoSobrante.Caption = "Producto Sobrante";
            this.uiProductoSobrante.Id = 13;
            this.uiProductoSobrante.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiProductoSobrante.ImageOptions.Image")));
            this.uiProductoSobrante.Name = "uiProductoSobrante";
            this.uiProductoSobrante.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiProductoSobrante_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "Registro Inventario Real";
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem11.ImageOptions.Image")));
            this.barButtonItem11.Name = "barButtonItem11";
            this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem11_ItemClick);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "Recepción de Traspasos";
            this.barButtonItem12.Id = 15;
            this.barButtonItem12.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem12.ImageOptions.Image")));
            this.barButtonItem12.Name = "barButtonItem12";
            this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // btnDesperdicioMasa
            // 
            this.btnDesperdicioMasa.Caption = "Desperdicio de Masa";
            this.btnDesperdicioMasa.Id = 16;
            this.btnDesperdicioMasa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDesperdicioMasa.ImageOptions.Image")));
            this.btnDesperdicioMasa.Name = "btnDesperdicioMasa";
            this.btnDesperdicioMasa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDesperdicioMasa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDesperdicioMasa_ItemClick);
            // 
            // uiDesperdicioTortilla
            // 
            this.uiDesperdicioTortilla.Caption = "Desperdicio Tortilla";
            this.uiDesperdicioTortilla.Id = 17;
            this.uiDesperdicioTortilla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiDesperdicioTortilla.ImageOptions.Image")));
            this.uiDesperdicioTortilla.Name = "uiDesperdicioTortilla";
            this.uiDesperdicioTortilla.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.uiDesperdicioTortilla.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiDesperdicioTortilla_ItemClick);
            // 
            // uiTraspasos
            // 
            this.uiTraspasos.Caption = "Traspasos";
            this.uiTraspasos.Id = 18;
            this.uiTraspasos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiTraspasos.ImageOptions.Image")));
            this.uiTraspasos.Name = "uiTraspasos";
            this.uiTraspasos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiTraspasos_ItemClick);
            // 
            // uiDevoluciones
            // 
            this.uiDevoluciones.Caption = "Devoluciones";
            this.uiDevoluciones.Id = 19;
            this.uiDevoluciones.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiDevoluciones.ImageOptions.Image")));
            this.uiDevoluciones.Name = "uiDevoluciones";
            this.uiDevoluciones.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiDevoluciones_ItemClick);
            // 
            // uiEntradaDirecta
            // 
            this.uiEntradaDirecta.Caption = "Entrada Directa";
            this.uiEntradaDirecta.Id = 20;
            this.uiEntradaDirecta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiEntradaDirecta.ImageOptions.Image")));
            this.uiEntradaDirecta.Name = "uiEntradaDirecta";
            this.uiEntradaDirecta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiEntradaDirecta_ItemClick);
            // 
            // uiSalidaDirecta
            // 
            this.uiSalidaDirecta.Caption = "Salida Directa";
            this.uiSalidaDirecta.Id = 21;
            this.uiSalidaDirecta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiSalidaDirecta.ImageOptions.Image")));
            this.uiSalidaDirecta.Name = "uiSalidaDirecta";
            this.uiSalidaDirecta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiSalidaDirecta_ItemClick);
            // 
            // uiSincronizar
            // 
            this.uiSincronizar.Caption = "Sincronizar";
            this.uiSincronizar.Id = 22;
            this.uiSincronizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiSincronizar.ImageOptions.Image")));
            this.uiSincronizar.Name = "uiSincronizar";
            this.uiSincronizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiSincronizar_ItemClick);
            // 
            // uiRibbonPage
            // 
            this.uiRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.uiRibbonPageControl});
            this.uiRibbonPage.Name = "uiRibbonPage";
            this.uiRibbonPage.Text = "Caja";
            // 
            // uiRibbonPageControl
            // 
            this.uiRibbonPageControl.ItemLinks.Add(this.uiMenuNuevaVenta);
            this.uiRibbonPageControl.ItemLinks.Add(this.barButtonItem1);
            this.uiRibbonPageControl.ItemLinks.Add(this.uiDevoluciones);
            this.uiRibbonPageControl.ItemLinks.Add(this.barButtonItem3);
            this.uiRibbonPageControl.ItemLinks.Add(this.barButtonItem4);
            this.uiRibbonPageControl.ItemLinks.Add(this.barButtonItem9);
            this.uiRibbonPageControl.ItemLinks.Add(this.uiProductoSobrante);
            this.uiRibbonPageControl.Name = "uiRibbonPageControl";
            this.uiRibbonPageControl.Text = "ribbonPageGroup1";
            // 
            // ribbonPedidos
            // 
            this.ribbonPedidos.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPedidos.Name = "ribbonPedidos";
            this.ribbonPedidos.Text = "Pedidos";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem10);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Inventarios";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem12);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDesperdicioMasa);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiDesperdicioTortilla);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiTraspasos);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiEntradaDirecta);
            this.ribbonPageGroup1.ItemLinks.Add(this.uiSalidaDirecta);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Confguraciones";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup2.ItemLinks.Add(this.uiSincronizar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Sesión";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 450);
            this.Controls.Add(this.uiRibbonControl);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "PUNTO DE VENTA-FLOR DE MAIZ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiRibbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl uiRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage uiRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup uiRibbonPageControl;
        private DevExpress.XtraBars.BarButtonItem uiMenuNuevaVenta;
        private DevExpress.XtraBars.BarButtonItem uiMenuConfigBascula;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPedidos;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem uiProductoSobrante;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem btnDesperdicioMasa;
        private DevExpress.XtraBars.BarButtonItem uiDesperdicioTortilla;
        private DevExpress.XtraBars.BarButtonItem uiTraspasos;
        private DevExpress.XtraBars.BarButtonItem uiDevoluciones;
        private DevExpress.XtraBars.BarButtonItem uiEntradaDirecta;
        private DevExpress.XtraBars.BarButtonItem uiSalidaDirecta;
        private DevExpress.XtraBars.BarButtonItem uiSincronizar;
    }
}