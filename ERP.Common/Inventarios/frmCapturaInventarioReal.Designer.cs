namespace ERP.Common.Inventarios
{
    partial class frmCapturaInventarioReal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturaInventarioReal));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.docinventarioregistroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRegistroInventarioId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadTeorica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_productos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_sucursales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.uiImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinventarioregistroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiImprimir);
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(926, 393);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(299, 343);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(271, 38);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 7;
            this.uiCancelar.Text = "Cancelar";
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(12, 343);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(283, 38);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 6;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.docinventarioregistroBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(12, 32);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(902, 307);
            this.uiGrid.TabIndex = 5;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // docinventarioregistroBindingSource
            // 
            this.docinventarioregistroBindingSource.DataSource = typeof(ConexionBD.doc_inventario_registro);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRegistroInventarioId,
            this.colSucursalId,
            this.colProductoId,
            this.gridColumn1,
            this.colCantidadReal,
            this.colCantidadTeorica,
            this.colDiferencia,
            this.colCreadoEl,
            this.colCreadoPor,
            this.colcat_productos,
            this.colcat_sucursales,
            this.colcat_usuarios});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            // 
            // colRegistroInventarioId
            // 
            this.colRegistroInventarioId.Caption = "ID";
            this.colRegistroInventarioId.FieldName = "RegistroInventarioId";
            this.colRegistroInventarioId.Name = "colRegistroInventarioId";
            this.colRegistroInventarioId.OptionsColumn.AllowEdit = false;
            this.colRegistroInventarioId.Visible = true;
            this.colRegistroInventarioId.VisibleIndex = 0;
            this.colRegistroInventarioId.Width = 86;
            // 
            // colSucursalId
            // 
            this.colSucursalId.FieldName = "SucursalId";
            this.colSucursalId.Name = "colSucursalId";
            this.colSucursalId.OptionsColumn.AllowEdit = false;
            // 
            // colProductoId
            // 
            this.colProductoId.Caption = "Producto";
            this.colProductoId.FieldName = "cat_productos.DescripcionCorta";
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.OptionsColumn.AllowEdit = false;
            this.colProductoId.Visible = true;
            this.colProductoId.VisibleIndex = 1;
            this.colProductoId.Width = 369;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha";
            this.gridColumn1.FieldName = "CreadoEl";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // colCantidadReal
            // 
            this.colCantidadReal.Caption = "Cant. Real";
            this.colCantidadReal.FieldName = "CantidadReal";
            this.colCantidadReal.Name = "colCantidadReal";
            this.colCantidadReal.Visible = true;
            this.colCantidadReal.VisibleIndex = 3;
            this.colCantidadReal.Width = 230;
            // 
            // colCantidadTeorica
            // 
            this.colCantidadTeorica.Caption = "Cant. Teórica";
            this.colCantidadTeorica.FieldName = "CantidadTeorica";
            this.colCantidadTeorica.Name = "colCantidadTeorica";
            this.colCantidadTeorica.OptionsColumn.AllowEdit = false;
            this.colCantidadTeorica.Visible = true;
            this.colCantidadTeorica.VisibleIndex = 2;
            this.colCantidadTeorica.Width = 230;
            // 
            // colDiferencia
            // 
            this.colDiferencia.FieldName = "Diferencia";
            this.colDiferencia.Name = "colDiferencia";
            this.colDiferencia.OptionsColumn.AllowEdit = false;
            this.colDiferencia.Visible = true;
            this.colDiferencia.VisibleIndex = 4;
            this.colDiferencia.Width = 237;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.FieldName = "CreadoPor";
            this.colCreadoPor.Name = "colCreadoPor";
            this.colCreadoPor.OptionsColumn.AllowEdit = false;
            // 
            // colcat_productos
            // 
            this.colcat_productos.FieldName = "cat_productos";
            this.colcat_productos.Name = "colcat_productos";
            this.colcat_productos.OptionsColumn.AllowEdit = false;
            // 
            // colcat_sucursales
            // 
            this.colcat_sucursales.FieldName = "cat_sucursales";
            this.colcat_sucursales.Name = "colcat_sucursales";
            this.colcat_sucursales.OptionsColumn.AllowEdit = false;
            // 
            // colcat_usuarios
            // 
            this.colcat_usuarios.FieldName = "cat_usuarios";
            this.colcat_usuarios.Name = "colcat_usuarios";
            this.colcat_usuarios.OptionsColumn.AllowEdit = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(176, 16);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Captura Real de Inventario";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(926, 393);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(906, 20);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiGrid;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(906, 311);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGuardar;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 331);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(287, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiCancelar;
            this.layoutControlItem4.Location = new System.Drawing.Point(287, 331);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(275, 42);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(765, 331);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(141, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // uiImprimir
            // 
            this.uiImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiImprimir.ImageOptions.Image")));
            this.uiImprimir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiImprimir.Location = new System.Drawing.Point(574, 343);
            this.uiImprimir.Name = "uiImprimir";
            this.uiImprimir.Size = new System.Drawing.Size(199, 38);
            this.uiImprimir.StyleController = this.layoutControl1;
            this.uiImprimir.TabIndex = 8;
            this.uiImprimir.Text = "Imprimir";
            this.uiImprimir.Click += new System.EventHandler(this.uiImprimir_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiImprimir;
            this.layoutControlItem5.Location = new System.Drawing.Point(562, 331);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(203, 42);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmCapturaInventarioReal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 393);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmCapturaInventarioReal";
            this.Text = "Captura de Inventario Real";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCapturaInventarioReal_FormClosing);
            this.Load += new System.EventHandler(this.frmCapturaInventarioReal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinventarioregistroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource docinventarioregistroBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRegistroInventarioId;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadReal;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadTeorica;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_productos;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_sucursales;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton uiImprimir;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}