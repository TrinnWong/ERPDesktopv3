namespace ERPv1.Inventarios
{
    partial class frmSucursalProductoRecepcion2
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSucursalProductoRecepcion2));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.uGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnDel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colsucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.uiProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.uiAgregar);
            this.layoutControl1.Controls.Add(this.uiProducto);
            this.layoutControl1.Controls.Add(this.uiSucursal);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiGrid
            // 
            this.uiGrid.Location = new System.Drawing.Point(18, 128);
            this.uiGrid.MainView = this.uGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBtnDel});
            this.uiGrid.Size = new System.Drawing.Size(764, 304);
            this.uiGrid.TabIndex = 8;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uGridView});
            // 
            // uGridView
            // 
            this.uGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDelete,
            this.colsucursalId,
            this.colproductoId,
            this.colclave,
            this.coldescripcion});
            this.uGridView.GridControl = this.uiGrid;
            this.uGridView.Name = "uGridView";
            this.uGridView.OptionsFind.AlwaysVisible = true;
            this.uGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repBtnDel;
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 0;
            // 
            // repBtnDel
            // 
            this.repBtnDel.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repBtnDel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnDel.Name = "repBtnDel";
            this.repBtnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnDel.Click += new System.EventHandler(this.repBtnDel_Click);
            // 
            // colsucursalId
            // 
            this.colsucursalId.FieldName = "sucursalId";
            this.colsucursalId.Name = "colsucursalId";
            // 
            // colproductoId
            // 
            this.colproductoId.FieldName = "productoId";
            this.colproductoId.Name = "colproductoId";
            // 
            // colclave
            // 
            this.colclave.FieldName = "clave";
            this.colclave.Name = "colclave";
            this.colclave.Visible = true;
            this.colclave.VisibleIndex = 1;
            this.colclave.Width = 126;
            // 
            // coldescripcion
            // 
            this.coldescripcion.FieldName = "descripcion";
            this.coldescripcion.Name = "coldescripcion";
            this.coldescripcion.Visible = true;
            this.coldescripcion.VisibleIndex = 2;
            this.coldescripcion.Width = 615;
            // 
            // uiAgregar
            // 
            this.uiAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiAgregar.ImageOptions.Image")));
            this.uiAgregar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiAgregar.Location = new System.Drawing.Point(18, 82);
            this.uiAgregar.Name = "uiAgregar";
            this.uiAgregar.Size = new System.Drawing.Size(764, 40);
            this.uiAgregar.StyleController = this.layoutControl1;
            this.uiAgregar.TabIndex = 7;
            this.uiAgregar.Text = "AGREGAR";
            this.uiAgregar.Click += new System.EventHandler(this.uiAgregar_Click);
            // 
            // uiProducto
            // 
            this.uiProducto.Location = new System.Drawing.Point(322, 50);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiProducto.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clave", "Clave"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Producto")});
            this.uiProducto.Properties.DisplayMember = "Descripcion";
            this.uiProducto.Properties.NullText = "(Selecciona un Producto)";
            this.uiProducto.Properties.ValueMember = "ProductoId";
            this.uiProducto.Size = new System.Drawing.Size(460, 26);
            this.uiProducto.StyleController = this.layoutControl1;
            this.uiProducto.TabIndex = 6;
            this.uiProducto.EditValueChanged += new System.EventHandler(this.uiProducto_EditValueChanged);
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(322, 18);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DataSource = this.catsucursalesBindingSource;
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Selecciona una Sucursal)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(460, 26);
            this.uiSucursal.StyleController = this.layoutControl1;
            this.uiSucursal.TabIndex = 5;
            this.uiSucursal.EditValueChanged += new System.EventHandler(this.uiSucursal_EditValueChanged);
            // 
            // catsucursalesBindingSource
            // 
            this.catsucursalesBindingSource.DataSource = typeof(ConexionBD.cat_sucursales);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.Text = "Productos Recepción por Sucursal";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiSucursal;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(770, 32);
            this.layoutControlItem2.Text = "1. Selecciona una Sucursal";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(299, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiProducto;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(770, 32);
            this.layoutControlItem3.Text = "2. Selecciona el producto para el cual se habilitará la recepción";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(299, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 310);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiAgregar;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(770, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmSucursalProductoRecepcion2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSucursalProductoRecepcion2";
            this.Text = "Productos Recepción por Sucursal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSucursalProductoRecepcion2_FormClosing);
            this.Load += new System.EventHandler(this.frmSucursalProductoRecepcion2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit uiProducto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton uiAgregar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnDel;
        private DevExpress.XtraGrid.Columns.GridColumn colsucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colproductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colclave;
        private DevExpress.XtraGrid.Columns.GridColumn coldescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
    }
}