namespace ERPv1.Procesos
{
    partial class frmCargoAdicionalConfig
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoAdicionalConfig));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGridCaptura = new DevExpress.XtraGrid.GridControl();
            this.doccargoadicionalconfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colCargoAdicionalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcentajeVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPorcVenta2 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colMontoFijo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repMontoFijo = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_cargos_adicionales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_sucursales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPorcVenta = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repLkpCargosAdicionales = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridCaptura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doccargoadicionalconfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPorcVenta2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMontoFijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPorcVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpCargosAdicionales)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiGridCaptura);
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
            // uiGridCaptura
            // 
            this.uiGridCaptura.DataSource = this.doccargoadicionalconfigBindingSource;
            this.uiGridCaptura.Location = new System.Drawing.Point(18, 50);
            this.uiGridCaptura.MainView = this.uiGridView;
            this.uiGridCaptura.Name = "uiGridCaptura";
            this.uiGridCaptura.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPorcVenta,
            this.repPorcVenta2,
            this.repMontoFijo,
            this.repEdit,
            this.repLkpCargosAdicionales});
            this.uiGridCaptura.Size = new System.Drawing.Size(764, 328);
            this.uiGridCaptura.TabIndex = 5;
            this.uiGridCaptura.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            this.uiGridCaptura.Validating += new System.ComponentModel.CancelEventHandler(this.uiGridCaptura_Validating);
            // 
            // doccargoadicionalconfigBindingSource
            // 
            this.doccargoadicionalconfigBindingSource.DataSource = typeof(ConexionBD.doc_cargo_adicional_config);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEdit,
            this.colCargoAdicionalId,
            this.colSucursalId,
            this.colPorcentajeVenta,
            this.colMontoFijo,
            this.colActivo,
            this.colCreadoEl,
            this.colcat_cargos_adicionales,
            this.colcat_sucursales});
            this.uiGridView.GridControl = this.uiGridCaptura;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.NewItemRowText = "CLIC AQUÍ PARA AGREGAR UN NUEVO REGISTRO";
            this.uiGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.uiGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.uiGridView_ValidateRow);
            this.uiGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.uiGridView_RowUpdated);
            // 
            // colEdit
            // 
            this.colEdit.ColumnEdit = this.repEdit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 0;
            this.colEdit.Width = 66;
            // 
            // repEdit
            // 
            this.repEdit.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repEdit.Name = "repEdit";
            this.repEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repEdit_ButtonClick);
            this.repEdit.Click += new System.EventHandler(this.repEdit_Click);
            // 
            // colCargoAdicionalId
            // 
            this.colCargoAdicionalId.Caption = "Cargo Adicional";
            this.colCargoAdicionalId.ColumnEdit = this.repLkpCargosAdicionales;
            this.colCargoAdicionalId.FieldName = "CargoAdicionalId";
            this.colCargoAdicionalId.Name = "colCargoAdicionalId";
            this.colCargoAdicionalId.Visible = true;
            this.colCargoAdicionalId.VisibleIndex = 1;
            this.colCargoAdicionalId.Width = 282;
            // 
            // colSucursalId
            // 
            this.colSucursalId.FieldName = "SucursalId";
            this.colSucursalId.Name = "colSucursalId";
            // 
            // colPorcentajeVenta
            // 
            this.colPorcentajeVenta.ColumnEdit = this.repPorcVenta2;
            this.colPorcentajeVenta.FieldName = "PorcentajeVenta";
            this.colPorcentajeVenta.Name = "colPorcentajeVenta";
            this.colPorcentajeVenta.Visible = true;
            this.colPorcentajeVenta.VisibleIndex = 2;
            this.colPorcentajeVenta.Width = 149;
            // 
            // repPorcVenta2
            // 
            this.repPorcVenta2.AutoHeight = false;
            this.repPorcVenta2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPorcVenta2.Name = "repPorcVenta2";
            // 
            // colMontoFijo
            // 
            this.colMontoFijo.ColumnEdit = this.repMontoFijo;
            this.colMontoFijo.FieldName = "MontoFijo";
            this.colMontoFijo.Name = "colMontoFijo";
            this.colMontoFijo.Visible = true;
            this.colMontoFijo.VisibleIndex = 3;
            this.colMontoFijo.Width = 151;
            // 
            // repMontoFijo
            // 
            this.repMontoFijo.AutoHeight = false;
            this.repMontoFijo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repMontoFijo.DisplayFormat.FormatString = "c2";
            this.repMontoFijo.Name = "repMontoFijo";
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 4;
            this.colActivo.Width = 93;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            // 
            // colcat_cargos_adicionales
            // 
            this.colcat_cargos_adicionales.FieldName = "cat_cargos_adicionales";
            this.colcat_cargos_adicionales.Name = "colcat_cargos_adicionales";
            // 
            // colcat_sucursales
            // 
            this.colcat_sucursales.FieldName = "cat_sucursales";
            this.colcat_sucursales.Name = "colcat_sucursales";
            // 
            // repPorcVenta
            // 
            this.repPorcVenta.AutoHeight = false;
            this.repPorcVenta.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPorcVenta.Name = "repPorcVenta";
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(61, 18);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DataSource = this.catsucursalesBindingSource;
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Selecciona una sucursal)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(721, 26);
            this.uiSucursal.StyleController = this.layoutControl1;
            this.uiSucursal.TabIndex = 4;
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
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiSucursal;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 32);
            this.layoutControlItem1.Text = "Sucursal";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(40, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 366);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(770, 54);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiGridCaptura;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(770, 334);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // repLkpCargosAdicionales
            // 
            this.repLkpCargosAdicionales.AutoHeight = false;
            this.repLkpCargosAdicionales.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkpCargosAdicionales.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Cargo")});
            this.repLkpCargosAdicionales.DisplayMember = "Descripcion";
            this.repLkpCargosAdicionales.Name = "repLkpCargosAdicionales";
            this.repLkpCargosAdicionales.NullText = "(Selecciona un cargo)";
            this.repLkpCargosAdicionales.ValueMember = "CargoAdicionalId";
            // 
            // frmCargoAdicionalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmCargoAdicionalConfig";
            this.Text = "Cargos Adicionales - Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoAdicionalConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmCargoAdicionalConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridCaptura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doccargoadicionalconfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPorcVenta2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMontoFijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPorcVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpCargosAdicionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl uiGridCaptura;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
        private System.Windows.Forms.BindingSource doccargoadicionalconfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoAdicionalId;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcentajeVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoFijo;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_cargos_adicionales;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_sucursales;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repPorcVenta2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repMontoFijo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repPorcVenta;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLkpCargosAdicionales;
    }
}