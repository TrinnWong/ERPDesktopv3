namespace ERP.Common.Productos
{
    partial class frmMaximosMinimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaximosMinimos));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.productoMinMaxModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colproductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclaveProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldisponible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colminimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaximo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsolicitar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoMinMaxModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1067, 554);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.productoMinMaxModelBindingSource;
            this.uiGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiGrid.Location = new System.Drawing.Point(16, 62);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1035, 476);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // productoMinMaxModelBindingSource
            // 
            this.productoMinMaxModelBindingSource.DataSource = typeof(ERP.Models.Producto.ProductoMinMaxModel);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colproductoId,
            this.colclaveProd,
            this.gridColumn1,
            this.coldisponible,
            this.colminimo,
            this.colmaximo,
            this.colsolicitar});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.uiGridView_RowStyle);
            // 
            // colproductoId
            // 
            this.colproductoId.FieldName = "productoId";
            this.colproductoId.Name = "colproductoId";
            this.colproductoId.OptionsColumn.AllowEdit = false;
            // 
            // colclaveProd
            // 
            this.colclaveProd.FieldName = "claveProd";
            this.colclaveProd.Name = "colclaveProd";
            this.colclaveProd.OptionsColumn.AllowEdit = false;
            this.colclaveProd.Visible = true;
            this.colclaveProd.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Descripción";
            this.gridColumn1.FieldName = "descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // coldisponible
            // 
            this.coldisponible.FieldName = "disponible";
            this.coldisponible.Name = "coldisponible";
            this.coldisponible.OptionsColumn.AllowEdit = false;
            this.coldisponible.Visible = true;
            this.coldisponible.VisibleIndex = 2;
            // 
            // colminimo
            // 
            this.colminimo.FieldName = "minimo";
            this.colminimo.Name = "colminimo";
            this.colminimo.OptionsColumn.AllowEdit = false;
            this.colminimo.Visible = true;
            this.colminimo.VisibleIndex = 3;
            // 
            // colmaximo
            // 
            this.colmaximo.FieldName = "maximo";
            this.colmaximo.Name = "colmaximo";
            this.colmaximo.OptionsColumn.AllowEdit = false;
            this.colmaximo.Visible = true;
            this.colmaximo.VisibleIndex = 4;
            // 
            // colsolicitar
            // 
            this.colsolicitar.FieldName = "solicitar";
            this.colsolicitar.Name = "colsolicitar";
            this.colsolicitar.OptionsColumn.AllowEdit = false;
            this.colsolicitar.Visible = true;
            this.colsolicitar.VisibleIndex = 5;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1067, 554);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1041, 482);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(16, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(322, 40);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Actualizar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(328, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(328, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(713, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmMaximosMinimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMaximosMinimos";
            this.Text = "Máximos y Mínimos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaximosMinimos_FormClosing);
            this.Load += new System.EventHandler(this.frmMaximosMinimos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoMinMaxModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource productoMinMaxModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colproductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colclaveProd;
        private DevExpress.XtraGrid.Columns.GridColumn coldisponible;
        private DevExpress.XtraGrid.Columns.GridColumn colminimo;
        private DevExpress.XtraGrid.Columns.GridColumn colmaximo;
        private DevExpress.XtraGrid.Columns.GridColumn colsolicitar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}