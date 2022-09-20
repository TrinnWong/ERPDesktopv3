namespace ERP.Common.Procesos
{
    partial class frmPuntoVentaCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVentaCargo));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.ppvcargosadicionalesgrdResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSeleccion = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCargoAdicionalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppvcargosadicionalesgrdResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSeleccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiCerrar);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(935, 430);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiCerrar
            // 
            this.uiCerrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCerrar.ImageOptions.Image")));
            this.uiCerrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCerrar.Location = new System.Drawing.Point(499, 372);
            this.uiCerrar.Name = "uiCerrar";
            this.uiCerrar.Size = new System.Drawing.Size(418, 40);
            this.uiCerrar.StyleController = this.layoutControl1;
            this.uiCerrar.TabIndex = 6;
            this.uiCerrar.Text = "Cerrar";
            this.uiCerrar.Click += new System.EventHandler(this.uiCerrar_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(18, 372);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(475, 40);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 5;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.ppvcargosadicionalesgrdResultBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 18);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSeleccion});
            this.uiGrid.Size = new System.Drawing.Size(899, 348);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // ppvcargosadicionalesgrdResultBindingSource
            // 
            this.ppvcargosadicionalesgrdResultBindingSource.DataSource = typeof(ConexionBD.p_pv_cargos_adicionales_grd_Result);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSeleccion,
            this.colCargoAdicionalId,
            this.colDescripcion,
            this.colDetalle});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gcSeleccion
            // 
            this.gcSeleccion.ColumnEdit = this.repSeleccion;
            this.gcSeleccion.FieldName = "Seleccion";
            this.gcSeleccion.Name = "gcSeleccion";
            this.gcSeleccion.Visible = true;
            this.gcSeleccion.VisibleIndex = 3;
            this.gcSeleccion.Width = 191;
            // 
            // repSeleccion
            // 
            this.repSeleccion.AutoHeight = false;
            this.repSeleccion.Name = "repSeleccion";
            // 
            // colCargoAdicionalId
            // 
            this.colCargoAdicionalId.Caption = "ID";
            this.colCargoAdicionalId.FieldName = "CargoAdicionalId";
            this.colCargoAdicionalId.Name = "colCargoAdicionalId";
            this.colCargoAdicionalId.Visible = true;
            this.colCargoAdicionalId.VisibleIndex = 0;
            this.colCargoAdicionalId.Width = 95;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 355;
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 2;
            this.colDetalle.Width = 235;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(935, 430);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(905, 354);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiGuardar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 354);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(481, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiCerrar;
            this.layoutControlItem3.Location = new System.Drawing.Point(481, 354);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(424, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmPuntoVentaCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 430);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPuntoVentaCargo";
            this.Text = "Cargos Adicionales en Venta";
            this.Load += new System.EventHandler(this.frmPuntoVentaCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppvcargosadicionalesgrdResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSeleccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource ppvcargosadicionalesgrdResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoAdicionalId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton uiCerrar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}