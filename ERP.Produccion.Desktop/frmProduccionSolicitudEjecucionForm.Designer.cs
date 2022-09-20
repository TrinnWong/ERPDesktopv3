namespace ERP.Produccion.Desktop
{
    partial class frmProduccionSolicitudEjecucionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduccionSolicitudEjecucionForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiInvRequerido = new DevExpress.XtraEditors.SimpleButton();
            this.uiAjusteUnidades = new DevExpress.XtraEditors.SimpleButton();
            this.uiTerminar = new DevExpress.XtraEditors.SimpleButton();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiIniciar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.docproduccionsolicituddetalleBindingSource = new System.Windows.Forms.BindingSource();
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduccionSolicitudId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_productos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_unidadesmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_produccion_solicitud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldocproduccionsolicitudrequerido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiFechaRequerida = new DevExpress.XtraEditors.DateEdit();
            this.uiID = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproduccionsolicituddetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaRequerida.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaRequerida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiInvRequerido);
            this.layoutControl1.Controls.Add(this.uiAjusteUnidades);
            this.layoutControl1.Controls.Add(this.uiTerminar);
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiIniciar);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.uiFechaRequerida);
            this.layoutControl1.Controls.Add(this.uiID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1126, 522);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiInvRequerido
            // 
            this.uiInvRequerido.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiInvRequerido.ImageOptions.Image")));
            this.uiInvRequerido.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiInvRequerido.Location = new System.Drawing.Point(18, 464);
            this.uiInvRequerido.Name = "uiInvRequerido";
            this.uiInvRequerido.Size = new System.Drawing.Size(226, 40);
            this.uiInvRequerido.StyleController = this.layoutControl1;
            this.uiInvRequerido.TabIndex = 11;
            this.uiInvRequerido.Text = "Inv. Requerido";
            this.uiInvRequerido.Click += new System.EventHandler(this.uiInvRequerido_Click);
            // 
            // uiAjusteUnidades
            // 
            this.uiAjusteUnidades.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiAjusteUnidades.ImageOptions.Image")));
            this.uiAjusteUnidades.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiAjusteUnidades.Location = new System.Drawing.Point(250, 464);
            this.uiAjusteUnidades.Name = "uiAjusteUnidades";
            this.uiAjusteUnidades.Size = new System.Drawing.Size(211, 40);
            this.uiAjusteUnidades.StyleController = this.layoutControl1;
            this.uiAjusteUnidades.TabIndex = 10;
            this.uiAjusteUnidades.Text = "Ajuste Unidades";
            this.uiAjusteUnidades.Click += new System.EventHandler(this.uiAjusteUnidades_Click);
            // 
            // uiTerminar
            // 
            this.uiTerminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiTerminar.ImageOptions.Image")));
            this.uiTerminar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiTerminar.Location = new System.Drawing.Point(678, 464);
            this.uiTerminar.Name = "uiTerminar";
            this.uiTerminar.Size = new System.Drawing.Size(189, 40);
            this.uiTerminar.StyleController = this.layoutControl1;
            this.uiTerminar.TabIndex = 9;
            this.uiTerminar.Text = "Terminar";
            this.uiTerminar.Click += new System.EventHandler(this.uiTerminar_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(873, 464);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(235, 40);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 8;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiIniciar
            // 
            this.uiIniciar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiIniciar.ImageOptions.Image")));
            this.uiIniciar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiIniciar.Location = new System.Drawing.Point(467, 464);
            this.uiIniciar.Name = "uiIniciar";
            this.uiIniciar.Size = new System.Drawing.Size(205, 40);
            this.uiIniciar.StyleController = this.layoutControl1;
            this.uiIniciar.TabIndex = 7;
            this.uiIniciar.Text = "Iniciar";
            this.uiIniciar.Click += new System.EventHandler(this.uiIniciar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.docproduccionsolicituddetalleBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 90);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1090, 368);
            this.uiGrid.TabIndex = 6;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // docproduccionsolicituddetalleBindingSource
            // 
            this.docproduccionsolicituddetalleBindingSource.DataSource = typeof(ConexionBD.doc_produccion_solicitud_detalle);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colProduccionSolicitudId,
            this.colProductoId,
            this.colUnidadId,
            this.colCantidad,
            this.colCreadoEl,
            this.colCreadoPor,
            this.colcat_productos,
            this.colcat_unidadesmed,
            this.coldoc_produccion_solicitud,
            this.coldocproduccionsolicitudrequerido,
            this.gridColumn1});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsBehavior.Editable = false;
            this.uiGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colProduccionSolicitudId
            // 
            this.colProduccionSolicitudId.FieldName = "ProduccionSolicitudId";
            this.colProduccionSolicitudId.Name = "colProduccionSolicitudId";
            this.colProduccionSolicitudId.OptionsColumn.AllowEdit = false;
            // 
            // colProductoId
            // 
            this.colProductoId.Caption = "Clave";
            this.colProductoId.FieldName = "cat_productos.Clave";
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.OptionsColumn.AllowEdit = false;
            this.colProductoId.Visible = true;
            this.colProductoId.VisibleIndex = 1;
            // 
            // colUnidadId
            // 
            this.colUnidadId.Caption = "Unidad";
            this.colUnidadId.FieldName = "cat_unidadesmed.DescripcionCorta";
            this.colUnidadId.Name = "colUnidadId";
            this.colUnidadId.OptionsColumn.AllowEdit = false;
            this.colUnidadId.Visible = true;
            this.colUnidadId.VisibleIndex = 3;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.OptionsColumn.AllowEdit = false;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 4;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.Caption = "Fecha Registro";
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            this.colCreadoEl.Visible = true;
            this.colCreadoEl.VisibleIndex = 5;
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
            // colcat_unidadesmed
            // 
            this.colcat_unidadesmed.FieldName = "cat_unidadesmed";
            this.colcat_unidadesmed.Name = "colcat_unidadesmed";
            this.colcat_unidadesmed.OptionsColumn.AllowEdit = false;
            // 
            // coldoc_produccion_solicitud
            // 
            this.coldoc_produccion_solicitud.FieldName = "doc_produccion_solicitud";
            this.coldoc_produccion_solicitud.Name = "coldoc_produccion_solicitud";
            this.coldoc_produccion_solicitud.OptionsColumn.AllowEdit = false;
            // 
            // coldocproduccionsolicitudrequerido
            // 
            this.coldocproduccionsolicitudrequerido.FieldName = "doc_produccion_solicitud_requerido";
            this.coldocproduccionsolicitudrequerido.Name = "coldocproduccionsolicitudrequerido";
            this.coldocproduccionsolicitudrequerido.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Producto";
            this.gridColumn1.FieldName = "cat_productos.Descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // uiFechaRequerida
            // 
            this.uiFechaRequerida.EditValue = null;
            this.uiFechaRequerida.Enabled = false;
            this.uiFechaRequerida.Location = new System.Drawing.Point(899, 58);
            this.uiFechaRequerida.Name = "uiFechaRequerida";
            this.uiFechaRequerida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaRequerida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaRequerida.Size = new System.Drawing.Size(209, 26);
            this.uiFechaRequerida.StyleController = this.layoutControl1;
            this.uiFechaRequerida.TabIndex = 5;
            // 
            // uiID
            // 
            this.uiID.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiID.Enabled = false;
            this.uiID.Location = new System.Drawing.Point(352, 58);
            this.uiID.Name = "uiID";
            this.uiID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiID.Size = new System.Drawing.Size(207, 26);
            this.uiID.StyleController = this.layoutControl1;
            this.uiID.TabIndex = 4;
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
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.simpleLabelItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1126, 522);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(547, 32);
            this.layoutControlItem1.Text = "ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(329, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiFechaRequerida;
            this.layoutControlItem2.Location = new System.Drawing.Point(547, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(549, 32);
            this.layoutControlItem2.Text = "Fecha Requerida";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(329, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1096, 374);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiIniciar;
            this.layoutControlItem4.Location = new System.Drawing.Point(449, 446);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(211, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiCancelar;
            this.layoutControlItem5.Location = new System.Drawing.Point(855, 446);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(241, 46);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiTerminar;
            this.layoutControlItem6.Location = new System.Drawing.Point(660, 446);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(195, 46);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.uiAjusteUnidades;
            this.layoutControlItem7.Location = new System.Drawing.Point(232, 446);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(217, 46);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.uiInvRequerido;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 446);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(232, 46);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(1096, 40);
            this.simpleLabelItem1.Text = "Solicitud de Producción";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(329, 34);
            // 
            // frmProduccionSolicitudEjecucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 522);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmProduccionSolicitudEjecucionForm";
            this.Text = "Detalle de la Solicitud de Producción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionSolicitudEjecucionForm_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionSolicitudEjecucionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproduccionsolicituddetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaRequerida.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaRequerida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit uiID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit uiFechaRequerida;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource docproduccionsolicituddetalleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colProduccionSolicitudId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadId;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_productos;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_unidadesmed;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_produccion_solicitud;
        private DevExpress.XtraGrid.Columns.GridColumn coldocproduccionsolicitudrequerido;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiIniciar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton uiTerminar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton uiAjusteUnidades;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton uiInvRequerido;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
    }
}