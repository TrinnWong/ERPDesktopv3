namespace ERP.Common.Catalogos
{
    partial class frmImpresoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresoras));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.catimpresorasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImpresoraId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreRed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkpImpresora = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNombreImpresora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActiva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiChkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_sucursales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCmbSucursal = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repLkpSucursal = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catimpresorasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpImpresora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiChkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCmbSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpSucursal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiGuardar);
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
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(16, 16);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(768, 40);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 5;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.catimpresorasBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(16, 62);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.uiChkActivo,
            this.repCmbSucursal,
            this.repLkpSucursal,
            this.repLkpImpresora});
            this.uiGrid.Size = new System.Drawing.Size(768, 372);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // catimpresorasBindingSource
            // 
            this.catimpresorasBindingSource.DataSource = typeof(ConexionBD.cat_impresoras);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImpresoraId,
            this.colNombreRed,
            this.colNombreImpresora,
            this.colActiva,
            this.colCreadoEl,
            this.colcat_sucursales});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.uiGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.uiGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.uiGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.uiGridView_InitNewRow);
            this.uiGridView.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.uiGridView_RowDeleting);
            this.uiGridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.uiGridView_ValidateRow);
            // 
            // colImpresoraId
            // 
            this.colImpresoraId.Caption = "ID";
            this.colImpresoraId.FieldName = "ImpresoraId";
            this.colImpresoraId.Name = "colImpresoraId";
            this.colImpresoraId.Visible = true;
            this.colImpresoraId.VisibleIndex = 0;
            this.colImpresoraId.Width = 66;
            // 
            // colNombreRed
            // 
            this.colNombreRed.Caption = "Impresora Red";
            this.colNombreRed.ColumnEdit = this.repLkpImpresora;
            this.colNombreRed.FieldName = "NombreRed";
            this.colNombreRed.Name = "colNombreRed";
            this.colNombreRed.Visible = true;
            this.colNombreRed.VisibleIndex = 1;
            this.colNombreRed.Width = 175;
            // 
            // repLkpImpresora
            // 
            this.repLkpImpresora.AutoHeight = false;
            this.repLkpImpresora.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkpImpresora.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Impresora")});
            this.repLkpImpresora.DisplayMember = "Nombre";
            this.repLkpImpresora.Name = "repLkpImpresora";
            this.repLkpImpresora.ValueMember = "Clave";
            // 
            // colNombreImpresora
            // 
            this.colNombreImpresora.Caption = "Etiqueta Impresora";
            this.colNombreImpresora.FieldName = "NombreImpresora";
            this.colNombreImpresora.Name = "colNombreImpresora";
            this.colNombreImpresora.Visible = true;
            this.colNombreImpresora.VisibleIndex = 2;
            this.colNombreImpresora.Width = 133;
            // 
            // colActiva
            // 
            this.colActiva.ColumnEdit = this.uiChkActivo;
            this.colActiva.FieldName = "Activa";
            this.colActiva.Name = "colActiva";
            this.colActiva.Visible = true;
            this.colActiva.VisibleIndex = 3;
            this.colActiva.Width = 227;
            // 
            // uiChkActivo
            // 
            this.uiChkActivo.AutoHeight = false;
            this.uiChkActivo.Name = "uiChkActivo";
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            // 
            // colcat_sucursales
            // 
            this.colcat_sucursales.FieldName = "cat_sucursales";
            this.colcat_sucursales.Name = "colcat_sucursales";
            // 
            // repCmbSucursal
            // 
            this.repCmbSucursal.AutoHeight = false;
            this.repCmbSucursal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCmbSucursal.Name = "repCmbSucursal";
            // 
            // repLkpSucursal
            // 
            this.repLkpSucursal.AutoHeight = false;
            this.repLkpSucursal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkpSucursal.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.repLkpSucursal.DisplayMember = "NombreSucursal";
            this.repLkpSucursal.Name = "repLkpSucursal";
            this.repLkpSucursal.ValueMember = "Clave";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(774, 378);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiGuardar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(774, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmImpresoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmImpresoras";
            this.Text = "Impresoras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImpresoras_FormClosing);
            this.Load += new System.EventHandler(this.frmImpresoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catimpresorasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpImpresora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiChkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCmbSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkpSucursal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource catimpresorasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colImpresoraId;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreRed;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreImpresora;
        private DevExpress.XtraGrid.Columns.GridColumn colActiva;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_sucursales;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit uiChkActivo;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLkpSucursal;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repCmbSucursal;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLkpImpresora;
    }
}