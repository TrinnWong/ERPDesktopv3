﻿namespace PuntoVenta
{
    partial class frmMenuRest
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
            DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTickets;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuRest));
            this.uiMenuBuscarTicket = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuReimprimirTicket = new DevExpress.XtraBars.BarButtonItem();
            this.uiCancelarTicket = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.uiMenuNuevaCuenta = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuCancelarCuenta = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuImprimirCuenta = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuPagar = new DevExpress.XtraBars.BarButtonItem();
            this.btnCerrarSesion = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuNuevaComanda = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuImprimirComanda = new DevExpress.XtraBars.BarButtonItem();
            this.uiMenuCuentaList = new DevExpress.XtraBars.BarButtonItem();
            this.uiRetiros = new DevExpress.XtraBars.BarButtonItem();
            this.uiGastos = new DevExpress.XtraBars.BarButtonItem();
            this.uiCorteCaja = new DevExpress.XtraBars.BarButtonItem();
            this.uiImpresoras = new DevExpress.XtraBars.BarButtonItem();
            this.uiImpresoraTicketPV = new DevExpress.XtraBars.BarButtonItem();
            this.uiImpresoraComanda = new DevExpress.XtraBars.BarButtonItem();
            this.uiAbrirCajon = new DevExpress.XtraBars.BarButtonItem();
            this.rbComanda = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbCuentas = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbCuenta = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgCuenta = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbTicket = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbCaja = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgCaja = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbImpresora = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgImpresoras = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbSesion = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgTickets = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // rpgTickets
            // 
            rpgTickets.ItemLinks.Add(this.uiMenuBuscarTicket);
            rpgTickets.ItemLinks.Add(this.uiMenuReimprimirTicket);
            rpgTickets.ItemLinks.Add(this.uiCancelarTicket);
            rpgTickets.Name = "rpgTickets";
            rpgTickets.Text = "Tickets";
            // 
            // uiMenuBuscarTicket
            // 
            this.uiMenuBuscarTicket.Caption = "Buscar Ticket";
            this.uiMenuBuscarTicket.Id = 9;
            this.uiMenuBuscarTicket.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuBuscarTicket.ImageOptions.Image")));
            this.uiMenuBuscarTicket.Name = "uiMenuBuscarTicket";
            this.uiMenuBuscarTicket.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuBuscarTicket_ItemClick);
            // 
            // uiMenuReimprimirTicket
            // 
            this.uiMenuReimprimirTicket.Caption = "Reimprimir Ticket";
            this.uiMenuReimprimirTicket.Id = 10;
            this.uiMenuReimprimirTicket.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuReimprimirTicket.ImageOptions.Image")));
            this.uiMenuReimprimirTicket.Name = "uiMenuReimprimirTicket";
            this.uiMenuReimprimirTicket.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuReimprimirTicket_ItemClick);
            // 
            // uiCancelarTicket
            // 
            this.uiCancelarTicket.Caption = "Cancelar Ticket";
            this.uiCancelarTicket.Id = 18;
            this.uiCancelarTicket.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelarTicket.ImageOptions.Image")));
            this.uiCancelarTicket.Name = "uiCancelarTicket";
            this.uiCancelarTicket.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiCancelarTicket_ItemClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.uiMenuNuevaCuenta,
            this.uiMenuCancelarCuenta,
            this.uiMenuImprimirCuenta,
            this.uiMenuPagar,
            this.btnCerrarSesion,
            this.uiMenuNuevaComanda,
            this.uiMenuImprimirComanda,
            this.uiMenuCuentaList,
            this.uiMenuBuscarTicket,
            this.uiMenuReimprimirTicket,
            this.uiRetiros,
            this.uiGastos,
            this.uiCorteCaja,
            this.uiImpresoras,
            this.uiImpresoraTicketPV,
            this.uiImpresoraComanda,
            this.uiCancelarTicket,
            this.uiAbrirCajon});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 20;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbComanda,
            this.rbCuenta,
            this.rbTicket,
            this.rbCaja,
            this.rbImpresora,
            this.rbSesion});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(989, 52);
            // 
            // uiMenuNuevaCuenta
            // 
            this.uiMenuNuevaCuenta.Caption = "Nueva Cuenta";
            this.uiMenuNuevaCuenta.Id = 1;
            this.uiMenuNuevaCuenta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuNuevaCuenta.ImageOptions.Image")));
            this.uiMenuNuevaCuenta.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("uiMenuNuevaCuenta.ImageOptions.LargeImage")));
            this.uiMenuNuevaCuenta.Name = "uiMenuNuevaCuenta";
            this.uiMenuNuevaCuenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuNuevaCuenta_ItemClick);
            // 
            // uiMenuCancelarCuenta
            // 
            this.uiMenuCancelarCuenta.Caption = "Cancelar Cuenta";
            this.uiMenuCancelarCuenta.Id = 2;
            this.uiMenuCancelarCuenta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuCancelarCuenta.ImageOptions.Image")));
            this.uiMenuCancelarCuenta.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("uiMenuCancelarCuenta.ImageOptions.LargeImage")));
            this.uiMenuCancelarCuenta.Name = "uiMenuCancelarCuenta";
            this.uiMenuCancelarCuenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuCancelarCuenta_ItemClick);
            // 
            // uiMenuImprimirCuenta
            // 
            this.uiMenuImprimirCuenta.Caption = "Imprimir Cuenta";
            this.uiMenuImprimirCuenta.Id = 3;
            this.uiMenuImprimirCuenta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuImprimirCuenta.ImageOptions.Image")));
            this.uiMenuImprimirCuenta.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("uiMenuImprimirCuenta.ImageOptions.LargeImage")));
            this.uiMenuImprimirCuenta.Name = "uiMenuImprimirCuenta";
            this.uiMenuImprimirCuenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuImprimirCuenta_ItemClick);
            // 
            // uiMenuPagar
            // 
            this.uiMenuPagar.Caption = "Pagar";
            this.uiMenuPagar.Id = 4;
            this.uiMenuPagar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuPagar.ImageOptions.Image")));
            this.uiMenuPagar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("uiMenuPagar.ImageOptions.LargeImage")));
            this.uiMenuPagar.Name = "uiMenuPagar";
            this.uiMenuPagar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuPagar_ItemClick);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Caption = "Cerrar Sesión";
            this.btnCerrarSesion.Id = 5;
            this.btnCerrarSesion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.ImageOptions.Image")));
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCerrarSesion_ItemClick);
            // 
            // uiMenuNuevaComanda
            // 
            this.uiMenuNuevaComanda.Caption = "Nueva Comanda";
            this.uiMenuNuevaComanda.Id = 6;
            this.uiMenuNuevaComanda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuNuevaComanda.ImageOptions.Image")));
            this.uiMenuNuevaComanda.Name = "uiMenuNuevaComanda";
            this.uiMenuNuevaComanda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuNuevaComanda_ItemClick);
            // 
            // uiMenuImprimirComanda
            // 
            this.uiMenuImprimirComanda.Caption = "Imprimir Comanda";
            this.uiMenuImprimirComanda.Id = 7;
            this.uiMenuImprimirComanda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuImprimirComanda.ImageOptions.Image")));
            this.uiMenuImprimirComanda.Name = "uiMenuImprimirComanda";
            this.uiMenuImprimirComanda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuImprimirComanda_ItemClick);
            // 
            // uiMenuCuentaList
            // 
            this.uiMenuCuentaList.Caption = "Ver Cuentas ";
            this.uiMenuCuentaList.Id = 8;
            this.uiMenuCuentaList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuCuentaList.ImageOptions.Image")));
            this.uiMenuCuentaList.Name = "uiMenuCuentaList";
            this.uiMenuCuentaList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiMenuCuentaList_ItemClick);
            // 
            // uiRetiros
            // 
            this.uiRetiros.Caption = "Retiros";
            this.uiRetiros.Id = 11;
            this.uiRetiros.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiRetiros.ImageOptions.Image")));
            this.uiRetiros.Name = "uiRetiros";
            this.uiRetiros.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiRetiros_ItemClick);
            // 
            // uiGastos
            // 
            this.uiGastos.Caption = "Gastos";
            this.uiGastos.Id = 12;
            this.uiGastos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGastos.ImageOptions.Image")));
            this.uiGastos.Name = "uiGastos";
            this.uiGastos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiGastos_ItemClick);
            // 
            // uiCorteCaja
            // 
            this.uiCorteCaja.Caption = "Corte de Caja";
            this.uiCorteCaja.Id = 13;
            this.uiCorteCaja.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCorteCaja.ImageOptions.Image")));
            this.uiCorteCaja.Name = "uiCorteCaja";
            this.uiCorteCaja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiCorteCaja_ItemClick);
            // 
            // uiImpresoras
            // 
            this.uiImpresoras.Caption = "Impresoras";
            this.uiImpresoras.Id = 14;
            this.uiImpresoras.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiImpresoras.ImageOptions.Image")));
            this.uiImpresoras.Name = "uiImpresoras";
            this.uiImpresoras.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiImpresoras_ItemClick);
            // 
            // uiImpresoraTicketPV
            // 
            this.uiImpresoraTicketPV.Caption = "Impresora Tickets";
            this.uiImpresoraTicketPV.Id = 16;
            this.uiImpresoraTicketPV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiImpresoraTicketPV.ImageOptions.Image")));
            this.uiImpresoraTicketPV.Name = "uiImpresoraTicketPV";
            this.uiImpresoraTicketPV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiImpresoraTicketPV_ItemClick);
            // 
            // uiImpresoraComanda
            // 
            this.uiImpresoraComanda.Caption = "Impresora Comanda";
            this.uiImpresoraComanda.Id = 17;
            this.uiImpresoraComanda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiImpresoraComanda.ImageOptions.Image")));
            this.uiImpresoraComanda.Name = "uiImpresoraComanda";
            this.uiImpresoraComanda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiImpresoraComanda_ItemClick);
            // 
            // uiAbrirCajon
            // 
            this.uiAbrirCajon.Caption = "Abrir Cajón";
            this.uiAbrirCajon.Id = 19;
            this.uiAbrirCajon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiAbrirCajon.ImageOptions.Image")));
            this.uiAbrirCajon.Name = "uiAbrirCajon";
            this.uiAbrirCajon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiAbrirCajon_ItemClick);
            // 
            // rbComanda
            // 
            this.rbComanda.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbCuentas});
            this.rbComanda.Name = "rbComanda";
            this.rbComanda.Text = "Comandas";
            // 
            // rbCuentas
            // 
            this.rbCuentas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("rbCuentas.ImageOptions.Image")));
            this.rbCuentas.ItemLinks.Add(this.uiMenuNuevaComanda);
            this.rbCuentas.ItemLinks.Add(this.uiMenuImprimirComanda);
            this.rbCuentas.Name = "rbCuentas";
            this.rbCuentas.Text = "Comandas";
            // 
            // rbCuenta
            // 
            this.rbCuenta.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgCuenta});
            this.rbCuenta.Name = "rbCuenta";
            this.rbCuenta.Text = "Cuentas";
            // 
            // rbgCuenta
            // 
            this.rbgCuenta.ItemLinks.Add(this.uiMenuImprimirCuenta);
            this.rbgCuenta.ItemLinks.Add(this.uiMenuCancelarCuenta);
            this.rbgCuenta.ItemLinks.Add(this.uiMenuCuentaList);
            this.rbgCuenta.ItemLinks.Add(this.uiMenuPagar);
            this.rbgCuenta.Name = "rbgCuenta";
            this.rbgCuenta.Text = "Cuentas";
            // 
            // rbTicket
            // 
            this.rbTicket.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            rpgTickets});
            this.rbTicket.Name = "rbTicket";
            this.rbTicket.Text = "Tickets";
            // 
            // rbCaja
            // 
            this.rbCaja.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgCaja});
            this.rbCaja.Name = "rbCaja";
            this.rbCaja.Text = "Caja";
            // 
            // rpgCaja
            // 
            this.rpgCaja.ItemLinks.Add(this.uiRetiros);
            this.rpgCaja.ItemLinks.Add(this.uiGastos);
            this.rpgCaja.ItemLinks.Add(this.uiCorteCaja);
            this.rpgCaja.ItemLinks.Add(this.uiAbrirCajon);
            this.rpgCaja.Name = "rpgCaja";
            this.rpgCaja.Text = "Caja";
            // 
            // rbImpresora
            // 
            this.rbImpresora.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgImpresoras});
            this.rbImpresora.Name = "rbImpresora";
            this.rbImpresora.Text = "Impresoras";
            // 
            // rpgImpresoras
            // 
            this.rpgImpresoras.ItemLinks.Add(this.uiImpresoras);
            this.rpgImpresoras.ItemLinks.Add(this.uiImpresoraTicketPV);
            this.rpgImpresoras.ItemLinks.Add(this.uiImpresoraComanda);
            this.rpgImpresoras.Name = "rpgImpresoras";
            this.rpgImpresoras.Text = "Impresoras";
            // 
            // rbSesion
            // 
            this.rbSesion.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rbSesion.Name = "rbSesion";
            this.rbSesion.Text = "Sesión";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCerrarSesion);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Sesión";
            // 
            // frmMenuRest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 642);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmMenuRest";
            this.Text = "frmMenuRest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuRest_FormClosed);
            this.Load += new System.EventHandler(this.frmMenuRest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem uiMenuNuevaCuenta;
        private DevExpress.XtraBars.BarButtonItem uiMenuCancelarCuenta;
        private DevExpress.XtraBars.BarButtonItem uiMenuImprimirCuenta;
        private DevExpress.XtraBars.BarButtonItem uiMenuPagar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbComanda;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbCuentas;
        private DevExpress.XtraBars.BarButtonItem btnCerrarSesion;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbSesion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem uiMenuNuevaComanda;
        private DevExpress.XtraBars.BarButtonItem uiMenuImprimirComanda;
        private DevExpress.XtraBars.BarButtonItem uiMenuCuentaList;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbCuenta;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgCuenta;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbTicket;
        private DevExpress.XtraBars.BarButtonItem uiMenuBuscarTicket;
        private DevExpress.XtraBars.BarButtonItem uiMenuReimprimirTicket;
        private DevExpress.XtraBars.BarButtonItem uiRetiros;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbCaja;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgCaja;
        private DevExpress.XtraBars.BarButtonItem uiGastos;
        private DevExpress.XtraBars.BarButtonItem uiCorteCaja;
        private DevExpress.XtraBars.BarButtonItem uiImpresoras;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbImpresora;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgImpresoras;
        private DevExpress.XtraBars.BarButtonItem uiImpresoraTicketPV;
        private DevExpress.XtraBars.BarButtonItem uiImpresoraComanda;
        private DevExpress.XtraBars.BarButtonItem uiCancelarTicket;
        private DevExpress.XtraBars.BarButtonItem uiAbrirCajon;
    }
}