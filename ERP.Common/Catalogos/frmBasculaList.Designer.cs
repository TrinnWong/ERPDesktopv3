namespace ERP.Common.Catalogos
{
    partial class frmBasculaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasculaList));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.catbasculasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colBasculaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalAsignadaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSucursal = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModificadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModificadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_empresas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_sucursales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catbasculasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiNuevo);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiNuevo
            // 
            this.uiNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiNuevo.ImageOptions.Image")));
            this.uiNuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiNuevo.Location = new System.Drawing.Point(12, 12);
            this.uiNuevo.Name = "uiNuevo";
            this.uiNuevo.Size = new System.Drawing.Size(386, 38);
            this.uiNuevo.StyleController = this.layoutControl1;
            this.uiNuevo.TabIndex = 5;
            this.uiNuevo.Text = "Nuevo";
            this.uiNuevo.Click += new System.EventHandler(this.uiNuevo_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.catbasculasBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(12, 54);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBtnEdit,
            this.repSucursal});
            this.uiGrid.Size = new System.Drawing.Size(776, 384);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            this.uiGrid.DoubleClick += new System.EventHandler(this.uiGrid_DoubleClick);
            // 
            // catbasculasBindingSource
            // 
            this.catbasculasBindingSource.DataSource = typeof(ConexionBD.cat_basculas);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colBasculaId,
            this.colEmpresaId,
            this.colAlias,
            this.colMarca,
            this.colModelo,
            this.colSerie,
            this.colSucursalAsignadaId,
            this.colCreadoEl,
            this.colActivo,
            this.colCreadoPor,
            this.colModificadoEl,
            this.colModificadoPor,
            this.colcat_empresas,
            this.colcat_sucursales,
            this.colcat_usuarios,
            this.colcat_usuarios1});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.DoubleClick += new System.EventHandler(this.uiGridView_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "#";
            this.gridColumn1.ColumnEdit = this.repBtnEdit;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 68;
            // 
            // repBtnEdit
            // 
            this.repBtnEdit.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repBtnEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnEdit.Name = "repBtnEdit";
            this.repBtnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repBtnEdit_ButtonClick);
            // 
            // colBasculaId
            // 
            this.colBasculaId.Caption = "ID";
            this.colBasculaId.FieldName = "BasculaId";
            this.colBasculaId.Name = "colBasculaId";
            this.colBasculaId.OptionsColumn.AllowEdit = false;
            this.colBasculaId.Visible = true;
            this.colBasculaId.VisibleIndex = 1;
            this.colBasculaId.Width = 66;
            // 
            // colEmpresaId
            // 
            this.colEmpresaId.FieldName = "EmpresaId";
            this.colEmpresaId.Name = "colEmpresaId";
            this.colEmpresaId.OptionsColumn.AllowEdit = false;
            // 
            // colAlias
            // 
            this.colAlias.Caption = "Alias";
            this.colAlias.FieldName = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.OptionsColumn.AllowEdit = false;
            this.colAlias.Visible = true;
            this.colAlias.VisibleIndex = 2;
            this.colAlias.Width = 114;
            // 
            // colMarca
            // 
            this.colMarca.Caption = "Marca";
            this.colMarca.FieldName = "Marca";
            this.colMarca.Name = "colMarca";
            this.colMarca.OptionsColumn.AllowEdit = false;
            this.colMarca.Visible = true;
            this.colMarca.VisibleIndex = 3;
            this.colMarca.Width = 114;
            // 
            // colModelo
            // 
            this.colModelo.Caption = "Modelo";
            this.colModelo.FieldName = "Modelo";
            this.colModelo.Name = "colModelo";
            this.colModelo.OptionsColumn.AllowEdit = false;
            this.colModelo.Visible = true;
            this.colModelo.VisibleIndex = 4;
            this.colModelo.Width = 114;
            // 
            // colSerie
            // 
            this.colSerie.Caption = "Serie";
            this.colSerie.FieldName = "Serie";
            this.colSerie.Name = "colSerie";
            this.colSerie.OptionsColumn.AllowEdit = false;
            this.colSerie.Visible = true;
            this.colSerie.VisibleIndex = 5;
            this.colSerie.Width = 114;
            // 
            // colSucursalAsignadaId
            // 
            this.colSucursalAsignadaId.Caption = "Sucursal";
            this.colSucursalAsignadaId.ColumnEdit = this.repSucursal;
            this.colSucursalAsignadaId.FieldName = "SucursalAsignadaId";
            this.colSucursalAsignadaId.Name = "colSucursalAsignadaId";
            this.colSucursalAsignadaId.OptionsColumn.AllowEdit = false;
            this.colSucursalAsignadaId.Visible = true;
            this.colSucursalAsignadaId.VisibleIndex = 6;
            this.colSucursalAsignadaId.Width = 132;
            // 
            // repSucursal
            // 
            this.repSucursal.AutoHeight = false;
            this.repSucursal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repSucursal.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clave", "Clave"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.repSucursal.DisplayMember = "NombreSucursal";
            this.repSucursal.Name = "repSucursal";
            this.repSucursal.NullText = "(Sin Sucursal Asignada)";
            this.repSucursal.ValueMember = "Clave";
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.Caption = "Fecha de Creación";
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            this.colCreadoEl.Visible = true;
            this.colCreadoEl.VisibleIndex = 7;
            this.colCreadoEl.Width = 122;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.FieldName = "CreadoPor";
            this.colCreadoPor.Name = "colCreadoPor";
            // 
            // colModificadoEl
            // 
            this.colModificadoEl.FieldName = "ModificadoEl";
            this.colModificadoEl.Name = "colModificadoEl";
            // 
            // colModificadoPor
            // 
            this.colModificadoPor.FieldName = "ModificadoPor";
            this.colModificadoPor.Name = "colModificadoPor";
            // 
            // colcat_empresas
            // 
            this.colcat_empresas.FieldName = "cat_empresas";
            this.colcat_empresas.Name = "colcat_empresas";
            // 
            // colcat_sucursales
            // 
            this.colcat_sucursales.FieldName = "cat_sucursales";
            this.colcat_sucursales.Name = "colcat_sucursales";
            // 
            // colcat_usuarios
            // 
            this.colcat_usuarios.FieldName = "cat_usuarios";
            this.colcat_usuarios.Name = "colcat_usuarios";
            // 
            // colcat_usuarios1
            // 
            this.colcat_usuarios1.FieldName = "cat_usuarios1";
            this.colcat_usuarios1.Name = "colcat_usuarios1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 388);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiNuevo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(390, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(390, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // colActivo
            // 
            this.colActivo.Caption = "Activo";
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.OptionsColumn.AllowEdit = false;
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 8;
            // 
            // frmBasculaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmBasculaList";
            this.Text = "Catálogo de Basculas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBasculaList_FormClosing);
            this.Load += new System.EventHandler(this.frmBasculaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catbasculasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private System.Windows.Forms.BindingSource catbasculasBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colBasculaId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaId;
        private DevExpress.XtraGrid.Columns.GridColumn colAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colMarca;
        private DevExpress.XtraGrid.Columns.GridColumn colModelo;
        private DevExpress.XtraGrid.Columns.GridColumn colSerie;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalAsignadaId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colModificadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colModificadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_empresas;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_sucursales;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnEdit;
        private DevExpress.XtraEditors.SimpleButton uiNuevo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
    }
}