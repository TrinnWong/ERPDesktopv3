namespace ERP.Rec
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.uiConfiguración = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.uiPuntoVenta = new DevExpress.XtraBars.BarButtonItem();
            this.uiERP = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.uiConfiguración,
            this.uiPuntoVenta,
            this.uiERP});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(931, 81);
            // 
            // uiConfiguración
            // 
            this.uiConfiguración.Caption = "Configuración";
            this.uiConfiguración.Id = 1;
            this.uiConfiguración.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiConfiguración.ImageOptions.Image")));
            this.uiConfiguración.Name = "uiConfiguración";
            this.uiConfiguración.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiConfiguración_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menú Principal";
            // 
            // rpg1
            // 
            this.rpg1.ItemLinks.Add(this.uiConfiguración);
            this.rpg1.Name = "rpg1";
            this.rpg1.Text = "Menú";
            // 
            // uiPuntoVenta
            // 
            this.uiPuntoVenta.Caption = "Punto de Venta";
            this.uiPuntoVenta.Id = 2;
            this.uiPuntoVenta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiPuntoVenta.ImageOptions.Image")));
            this.uiPuntoVenta.Name = "uiPuntoVenta";
            this.uiPuntoVenta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uiPuntoVenta_ItemClick);
            // 
            // uiERP
            // 
            this.uiERP.Caption = "ERP";
            this.uiERP.Id = 3;
            this.uiERP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiERP.ImageOptions.Image")));
            this.uiERP.Name = "uiERP";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 597);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg1;
        private DevExpress.XtraBars.BarButtonItem uiConfiguración;
        private DevExpress.XtraBars.BarButtonItem uiPuntoVenta;
        private DevExpress.XtraBars.BarButtonItem uiERP;
    }
}