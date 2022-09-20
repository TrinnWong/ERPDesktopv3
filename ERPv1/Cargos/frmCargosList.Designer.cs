namespace ERPv1.Cargos
{
    partial class frmCargosList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargosList));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiRefrescar = new DevExpress.XtraEditors.SimpleButton();
            this.uiCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.catclientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.doccargosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCargoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClienteId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_clientes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_productos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_cargos_detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_pagos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_pedidos_orden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDetalle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cattipofactorSATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catclientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doccargosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cattipofactorSATBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiSucursal);
            this.layoutControl1.Controls.Add(this.uiRefrescar);
            this.layoutControl1.Controls.Add(this.uiCliente);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1190, 517);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(57, 12);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Todas)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(340, 20);
            this.uiSucursal.StyleController = this.layoutControl1;
            this.uiSucursal.TabIndex = 7;
            // 
            // catsucursalesBindingSource
            // 
            this.catsucursalesBindingSource.DataSource = typeof(ConexionBD.cat_sucursales);
            // 
            // uiRefrescar
            // 
            this.uiRefrescar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiRefrescar.ImageOptions.Image")));
            this.uiRefrescar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiRefrescar.Location = new System.Drawing.Point(828, 12);
            this.uiRefrescar.Name = "uiRefrescar";
            this.uiRefrescar.Size = new System.Drawing.Size(350, 38);
            this.uiRefrescar.StyleController = this.layoutControl1;
            this.uiRefrescar.TabIndex = 6;
            this.uiRefrescar.Text = "Refrescar";
            this.uiRefrescar.Click += new System.EventHandler(this.uiRefrescar_Click);
            // 
            // uiCliente
            // 
            this.uiCliente.Location = new System.Drawing.Point(446, 12);
            this.uiCliente.Name = "uiCliente";
            this.uiCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCliente.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre/Razón Social"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RFC", "RFC")});
            this.uiCliente.Properties.DataSource = this.catclientesBindingSource;
            this.uiCliente.Properties.DisplayMember = "Nombre";
            this.uiCliente.Properties.NullText = "(Todos)";
            this.uiCliente.Properties.ValueMember = "ClienteId";
            this.uiCliente.Size = new System.Drawing.Size(378, 20);
            this.uiCliente.StyleController = this.layoutControl1;
            this.uiCliente.TabIndex = 5;
            this.uiCliente.EditValueChanged += new System.EventHandler(this.uiCliente_EditValueChanged);
            // 
            // catclientesBindingSource
            // 
            this.catclientesBindingSource.DataSource = typeof(ConexionBD.cat_clientes);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.doccargosBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(12, 54);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repDetalle});
            this.uiGrid.Size = new System.Drawing.Size(1166, 451);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // doccargosBindingSource
            // 
            this.doccargosBindingSource.DataSource = typeof(ConexionBD.doc_cargos);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCargoId,
            this.colClienteId,
            this.colProductoId,
            this.colTotal,
            this.colCredoEl,
            this.colCreadoPor,
            this.colSaldo,
            this.colActivo,
            this.colDescuento,
            this.colDescripcion,
            this.colcat_clientes,
            this.colcat_productos,
            this.coldoc_cargos_detalle,
            this.coldoc_pagos,
            this.coldoc_pedidos_orden,
            this.colDetalle});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", this.colSaldo, "Saldo Cliente ={0:c2}")});
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsView.ShowFooter = true;
            // 
            // colCargoId
            // 
            this.colCargoId.Caption = "ID";
            this.colCargoId.FieldName = "CargoId";
            this.colCargoId.Name = "colCargoId";
            this.colCargoId.OptionsColumn.AllowEdit = false;
            this.colCargoId.Visible = true;
            this.colCargoId.VisibleIndex = 1;
            this.colCargoId.Width = 72;
            // 
            // colClienteId
            // 
            this.colClienteId.Caption = "Cliente";
            this.colClienteId.FieldName = "cat_clientes.Nombre";
            this.colClienteId.Name = "colClienteId";
            this.colClienteId.OptionsColumn.AllowEdit = false;
            this.colClienteId.Visible = true;
            this.colClienteId.VisibleIndex = 2;
            this.colClienteId.Width = 142;
            // 
            // colProductoId
            // 
            this.colProductoId.FieldName = "ProductoId";
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.OptionsColumn.AllowEdit = false;
            // 
            // colTotal
            // 
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            this.colTotal.Width = 142;
            // 
            // colCredoEl
            // 
            this.colCredoEl.Caption = "Fecha Registro";
            this.colCredoEl.DisplayFormat.FormatString = "d";
            this.colCredoEl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCredoEl.FieldName = "CredoEl";
            this.colCredoEl.Name = "colCredoEl";
            this.colCredoEl.OptionsColumn.AllowEdit = false;
            this.colCredoEl.Visible = true;
            this.colCredoEl.VisibleIndex = 4;
            this.colCredoEl.Width = 142;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.Caption = "Registrado Por";
            this.colCreadoPor.FieldName = "cat_usuarios.NombreUsuario";
            this.colCreadoPor.Name = "colCreadoPor";
            this.colCreadoPor.OptionsColumn.AllowEdit = false;
            this.colCreadoPor.Width = 116;
            // 
            // colSaldo
            // 
            this.colSaldo.DisplayFormat.FormatString = "c2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowEdit = false;
            this.colSaldo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", "Saldo Total={0:c2}")});
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 6;
            this.colSaldo.Width = 142;
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.OptionsColumn.AllowEdit = false;
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 7;
            this.colActivo.Width = 163;
            // 
            // colDescuento
            // 
            this.colDescuento.FieldName = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.OptionsColumn.AllowEdit = false;
            this.colDescuento.Width = 116;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            this.colDescripcion.Width = 142;
            // 
            // colcat_clientes
            // 
            this.colcat_clientes.FieldName = "cat_clientes";
            this.colcat_clientes.Name = "colcat_clientes";
            this.colcat_clientes.OptionsColumn.AllowEdit = false;
            // 
            // colcat_productos
            // 
            this.colcat_productos.FieldName = "cat_productos";
            this.colcat_productos.Name = "colcat_productos";
            this.colcat_productos.OptionsColumn.AllowEdit = false;
            // 
            // coldoc_cargos_detalle
            // 
            this.coldoc_cargos_detalle.FieldName = "doc_cargos_detalle";
            this.coldoc_cargos_detalle.Name = "coldoc_cargos_detalle";
            this.coldoc_cargos_detalle.OptionsColumn.AllowEdit = false;
            // 
            // coldoc_pagos
            // 
            this.coldoc_pagos.FieldName = "doc_pagos";
            this.coldoc_pagos.Name = "coldoc_pagos";
            this.coldoc_pagos.OptionsColumn.AllowEdit = false;
            // 
            // coldoc_pedidos_orden
            // 
            this.coldoc_pedidos_orden.FieldName = "doc_pedidos_orden";
            this.coldoc_pedidos_orden.Name = "coldoc_pedidos_orden";
            this.coldoc_pedidos_orden.OptionsColumn.AllowEdit = false;
            // 
            // colDetalle
            // 
            this.colDetalle.Caption = "#";
            this.colDetalle.ColumnEdit = this.repDetalle;
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 0;
            this.colDetalle.Width = 88;
            // 
            // repDetalle
            // 
            this.repDetalle.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repDetalle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repDetalle.Name = "repDetalle";
            this.repDetalle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repDetalle.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repDetalle_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1190, 517);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1170, 455);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiCliente;
            this.layoutControlItem2.Location = new System.Drawing.Point(389, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(427, 42);
            this.layoutControlItem2.Text = "Cliente";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiRefrescar;
            this.layoutControlItem3.Location = new System.Drawing.Point(816, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(354, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiSucursal;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(389, 42);
            this.layoutControlItem4.Text = "Sucursal";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(40, 13);
            // 
            // cattipofactorSATBindingSource
            // 
            this.cattipofactorSATBindingSource.DataSource = typeof(ConexionBD.cat_tipo_factor_SAT);
            // 
            // frmCargosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 517);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmCargosList";
            this.Text = "Cargos Listado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargosList_FormClosing);
            this.Load += new System.EventHandler(this.frmCargosList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catclientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doccargosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cattipofactorSATBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit uiCliente;
        private System.Windows.Forms.BindingSource catclientesBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource doccargosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoId;
        private DevExpress.XtraGrid.Columns.GridColumn colClienteId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCredoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_clientes;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_productos;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_cargos_detalle;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_pagos;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_pedidos_orden;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repDetalle;
        private DevExpress.XtraEditors.SimpleButton uiRefrescar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
        private System.Windows.Forms.BindingSource cattipofactorSATBindingSource;
    }
}