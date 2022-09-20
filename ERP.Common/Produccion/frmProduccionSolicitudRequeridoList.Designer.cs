namespace ERP.Common.Produccion
{
    partial class frmProduccionSolicitudRequeridoList
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiProduccionId = new DevExpress.XtraEditors.SpinEdit();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.pdocsolicitudproduccionrequeridogrdResultBindingSource = new System.Windows.Forms.BindingSource();
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.docproduccionsolicitudrequeridoBindingSource = new System.Windows.Forms.BindingSource();
            this.docproductossobrantesregitroinventarioBindingSource = new System.Windows.Forms.BindingSource();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduccionSolicitudDetalleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoRequeridoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadRequeridaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_productos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_unidadesmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_produccion_solicitud_detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProduccionId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdocsolicitudproduccionrequeridogrdResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproduccionsolicitudrequeridoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproductossobrantesregitroinventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiProduccionId);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1221, 501);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiProduccionId
            // 
            this.uiProduccionId.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiProduccionId.Location = new System.Drawing.Point(498, 39);
            this.uiProduccionId.Name = "uiProduccionId";
            this.uiProduccionId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiProduccionId.Properties.ReadOnly = true;
            this.uiProduccionId.Size = new System.Drawing.Size(285, 20);
            this.uiProduccionId.StyleController = this.layoutControl1;
            this.uiProduccionId.TabIndex = 5;
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.pdocsolicitudproduccionrequeridogrdResultBindingSource;
            this.uiGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.uiGrid.Location = new System.Drawing.Point(12, 63);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1197, 426);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            this.uiGrid.Load += new System.EventHandler(this.uiGrid_Load);
            this.uiGrid.Click += new System.EventHandler(this.uiGrid_Click);
            // 
            // pdocsolicitudproduccionrequeridogrdResultBindingSource
            // 
            this.pdocsolicitudproduccionrequeridogrdResultBindingSource.DataSource = typeof(ConexionBD.p_doc_solicitud_produccion_requerido_grd_Result);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductoId,
            this.colClave,
            this.colProducto,
            this.colUnidadId,
            this.colCantidad1});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            // 
            // colProductoId
            // 
            this.colProductoId.FieldName = "ProductoId";
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.OptionsColumn.AllowEdit = false;
            // 
            // colClave
            // 
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.OptionsColumn.AllowEdit = false;
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 0;
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.OptionsColumn.AllowEdit = false;
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 1;
            // 
            // colUnidadId
            // 
            this.colUnidadId.Caption = " ";
            this.colUnidadId.FieldName = "UnidadId";
            this.colUnidadId.Name = "colUnidadId";
            this.colUnidadId.OptionsColumn.AllowEdit = false;
            this.colUnidadId.Visible = true;
            this.colUnidadId.VisibleIndex = 2;
            // 
            // colCantidad1
            // 
            this.colCantidad1.FieldName = "Cantidad";
            this.colCantidad1.Name = "colCantidad1";
            this.colCantidad1.OptionsColumn.AllowEdit = false;
            this.colCantidad1.Visible = true;
            this.colCantidad1.VisibleIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.simpleLabelItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1221, 501);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1201, 430);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiProduccionId;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(775, 24);
            this.layoutControlItem2.Text = "Solicitud de Producción";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(481, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(775, 27);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(426, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(1201, 27);
            this.simpleLabelItem1.Text = "Solicitud de Producción - Materia Prima Requerida";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(481, 23);
            // 
            // docproduccionsolicitudrequeridoBindingSource
            // 
            this.docproduccionsolicitudrequeridoBindingSource.DataSource = typeof(ConexionBD.doc_produccion_solicitud_requerido);
            // 
            // docproductossobrantesregitroinventarioBindingSource
            // 
            this.docproductossobrantesregitroinventarioBindingSource.DataSource = typeof(ConexionBD.doc_productos_sobrantes_regitro_inventario);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Width = 110;
            // 
            // colProduccionSolicitudDetalleId
            // 
            this.colProduccionSolicitudDetalleId.FieldName = "ProduccionSolicitudDetalleId";
            this.colProduccionSolicitudDetalleId.Name = "colProduccionSolicitudDetalleId";
            this.colProduccionSolicitudDetalleId.OptionsColumn.AllowEdit = false;
            // 
            // colProductoRequeridoId
            // 
            this.colProductoRequeridoId.Caption = "Producto Requerido";
            this.colProductoRequeridoId.FieldName = "cat_productos.Descripcion";
            this.colProductoRequeridoId.Name = "colProductoRequeridoId";
            this.colProductoRequeridoId.OptionsColumn.AllowEdit = false;
            this.colProductoRequeridoId.Visible = true;
            this.colProductoRequeridoId.VisibleIndex = 0;
            this.colProductoRequeridoId.Width = 222;
            // 
            // colUnidadRequeridaId
            // 
            this.colUnidadRequeridaId.Caption = "Unidad Requerida";
            this.colUnidadRequeridaId.FieldName = "cat_unidadesmed.DescripcionCorta";
            this.colUnidadRequeridaId.Name = "colUnidadRequeridaId";
            this.colUnidadRequeridaId.OptionsColumn.AllowEdit = false;
            this.colUnidadRequeridaId.Visible = true;
            this.colUnidadRequeridaId.VisibleIndex = 1;
            this.colUnidadRequeridaId.Width = 262;
            // 
            // colCantidad
            // 
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.OptionsColumn.AllowEdit = false;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            this.colCantidad.Width = 151;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.Caption = "Fecha Registro";
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            this.colCreadoEl.Visible = true;
            this.colCreadoEl.VisibleIndex = 3;
            this.colCreadoEl.Width = 180;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.FieldName = "CreadoPor";
            this.colCreadoPor.Name = "colCreadoPor";
            this.colCreadoPor.OptionsColumn.AllowEdit = false;
            this.colCreadoPor.Width = 83;
            // 
            // colcat_productos
            // 
            this.colcat_productos.FieldName = "cat_productos";
            this.colcat_productos.Name = "colcat_productos";
            this.colcat_productos.OptionsColumn.AllowEdit = false;
            this.colcat_productos.Width = 83;
            // 
            // colcat_unidadesmed
            // 
            this.colcat_unidadesmed.FieldName = "cat_unidadesmed";
            this.colcat_unidadesmed.Name = "colcat_unidadesmed";
            this.colcat_unidadesmed.OptionsColumn.AllowEdit = false;
            this.colcat_unidadesmed.Width = 83;
            // 
            // colcat_usuarios
            // 
            this.colcat_usuarios.FieldName = "cat_usuarios";
            this.colcat_usuarios.Name = "colcat_usuarios";
            this.colcat_usuarios.OptionsColumn.AllowEdit = false;
            this.colcat_usuarios.Width = 83;
            // 
            // coldoc_produccion_solicitud_detalle
            // 
            this.coldoc_produccion_solicitud_detalle.FieldName = "doc_produccion_solicitud_detalle";
            this.coldoc_produccion_solicitud_detalle.Name = "coldoc_produccion_solicitud_detalle";
            this.coldoc_produccion_solicitud_detalle.OptionsColumn.AllowEdit = false;
            this.coldoc_produccion_solicitud_detalle.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Producto a Producir";
            this.gridColumn1.FieldName = "doc_produccion_solicitud_detalle.cat_productos.Descripcion";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // frmProduccionSolicitudRequeridoList
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 501);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "frmProduccionSolicitudRequeridoList";
            this.Text = "Producción - Inventario Requerido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionSolicitudRequeridoList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiProduccionId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdocsolicitudproduccionrequeridogrdResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproduccionsolicitudrequeridoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproductossobrantesregitroinventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit uiProduccionId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource docproductossobrantesregitroinventarioBindingSource;
        private System.Windows.Forms.BindingSource docproduccionsolicitudrequeridoBindingSource;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private System.Windows.Forms.BindingSource pdocsolicitudproduccionrequeridogrdResultBindingSource;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colProduccionSolicitudDetalleId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoRequeridoId;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadRequeridaId;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_productos;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_unidadesmed;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_produccion_solicitud_detalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadId;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad1;
    }
}