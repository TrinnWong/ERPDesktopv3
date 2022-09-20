namespace ERPv1.Catalogos
{
    partial class frmPoliticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPoliticas));
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.catpoliticasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPoliticaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPolitica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPolitica = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catpoliticasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPolitica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.catpoliticasBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 64);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repPolitica});
            this.uiGrid.Size = new System.Drawing.Size(1069, 368);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            this.uiGrid.Load += new System.EventHandler(this.uiGrid_Load);
            this.uiGrid.Click += new System.EventHandler(this.uiGrid_Click);
            this.uiGrid.Validating += new System.ComponentModel.CancelEventHandler(this.uiGrid_Validating);
            // 
            // catpoliticasBindingSource
            // 
            this.catpoliticasBindingSource.DataSource = typeof(ConexionBD.cat_politicas);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPoliticaId,
            this.colDescripcion,
            this.colPolitica,
            this.colActivo,
            this.colCreadoEl});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.uiGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.uiGridView_InitNewRow);
            this.uiGridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.uiGridView_ValidateRow);
            this.uiGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.uiGridView_RowUpdated);
            // 
            // colPoliticaId
            // 
            this.colPoliticaId.Caption = "ID";
            this.colPoliticaId.FieldName = "PoliticaId";
            this.colPoliticaId.Name = "colPoliticaId";
            this.colPoliticaId.OptionsColumn.AllowEdit = false;
            this.colPoliticaId.OptionsColumn.ReadOnly = true;
            this.colPoliticaId.Visible = true;
            this.colPoliticaId.VisibleIndex = 0;
            this.colPoliticaId.Width = 110;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 221;
            // 
            // colPolitica
            // 
            this.colPolitica.Caption = "Política";
            this.colPolitica.ColumnEdit = this.repPolitica;
            this.colPolitica.FieldName = "Politica";
            this.colPolitica.Name = "colPolitica";
            this.colPolitica.Visible = true;
            this.colPolitica.VisibleIndex = 2;
            this.colPolitica.Width = 586;
            // 
            // repPolitica
            // 
            this.repPolitica.Name = "repPolitica";
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 3;
            this.colActivo.Width = 129;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            // 
            // uiNuevo
            // 
            this.uiNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiNuevo.ImageOptions.Image")));
            this.uiNuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiNuevo.Location = new System.Drawing.Point(18, 18);
            this.uiNuevo.Name = "uiNuevo";
            this.uiNuevo.Size = new System.Drawing.Size(531, 40);
            this.uiNuevo.StyleController = this.layoutControl1;
            this.uiNuevo.TabIndex = 1;
            this.uiNuevo.Text = "Agregar";
            this.uiNuevo.Click += new System.EventHandler(this.uiNuevo_Click);
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
            this.layoutControl1.Size = new System.Drawing.Size(1105, 450);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
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
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1105, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1075, 374);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiNuevo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(537, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(537, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(538, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPoliticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPoliticas";
            this.Text = "Políticas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPoliticas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catpoliticasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPolitica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private System.Windows.Forms.BindingSource catpoliticasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPoliticaId;
        private DevExpress.XtraGrid.Columns.GridColumn colPolitica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repPolitica;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraEditors.SimpleButton uiNuevo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}