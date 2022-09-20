namespace ERP.Common.Produccion
{
    partial class frmProduccionSolicitudAceptacionList
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduccionSolicitudAceptacionList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.produccionSolicitudGridModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnVer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colproduccionSolicitudId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldeSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colparaSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcompletada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colactiva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionSolicitudGridModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiRefresh);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1051, 548);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.produccionSolicitudGridModelBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 64);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBtnVer});
            this.uiGrid.Size = new System.Drawing.Size(1015, 466);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // produccionSolicitudGridModelBindingSource
            // 
            this.produccionSolicitudGridModelBindingSource.DataSource = typeof(ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVer,
            this.colproduccionSolicitudId,
            this.coldeSucursal,
            this.colparaSucursal,
            this.colCreadoEl,
            this.colcompletada,
            this.colactiva});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colVer
            // 
            this.colVer.ColumnEdit = this.repBtnVer;
            this.colVer.Name = "colVer";
            this.colVer.Visible = true;
            this.colVer.VisibleIndex = 0;
            this.colVer.Width = 101;
            // 
            // repBtnVer
            // 
            this.repBtnVer.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repBtnVer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnVer.Name = "repBtnVer";
            this.repBtnVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnVer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repBtnVer_ButtonClick);
            // 
            // colproduccionSolicitudId
            // 
            this.colproduccionSolicitudId.Caption = "ID";
            this.colproduccionSolicitudId.FieldName = "produccionSolicitudId";
            this.colproduccionSolicitudId.Name = "colproduccionSolicitudId";
            this.colproduccionSolicitudId.OptionsColumn.AllowEdit = false;
            this.colproduccionSolicitudId.Visible = true;
            this.colproduccionSolicitudId.VisibleIndex = 1;
            this.colproduccionSolicitudId.Width = 66;
            // 
            // coldeSucursal
            // 
            this.coldeSucursal.Caption = "De Sucursal";
            this.coldeSucursal.FieldName = "deSucursal";
            this.coldeSucursal.Name = "coldeSucursal";
            this.coldeSucursal.OptionsColumn.AllowEdit = false;
            this.coldeSucursal.Visible = true;
            this.coldeSucursal.VisibleIndex = 2;
            this.coldeSucursal.Width = 160;
            // 
            // colparaSucursal
            // 
            this.colparaSucursal.Caption = "Para Sucursal";
            this.colparaSucursal.FieldName = "paraSucursal";
            this.colparaSucursal.Name = "colparaSucursal";
            this.colparaSucursal.OptionsColumn.AllowEdit = false;
            this.colparaSucursal.Visible = true;
            this.colparaSucursal.VisibleIndex = 3;
            this.colparaSucursal.Width = 160;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.Caption = "Fecha Registro";
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            this.colCreadoEl.Visible = true;
            this.colCreadoEl.VisibleIndex = 4;
            this.colCreadoEl.Width = 160;
            // 
            // colcompletada
            // 
            this.colcompletada.Caption = "Completada";
            this.colcompletada.FieldName = "completada";
            this.colcompletada.Name = "colcompletada";
            this.colcompletada.OptionsColumn.AllowEdit = false;
            this.colcompletada.Visible = true;
            this.colcompletada.VisibleIndex = 5;
            this.colcompletada.Width = 160;
            // 
            // colactiva
            // 
            this.colactiva.Caption = "Activo";
            this.colactiva.FieldName = "activa";
            this.colactiva.Name = "colactiva";
            this.colactiva.OptionsColumn.AllowEdit = false;
            this.colactiva.Visible = true;
            this.colactiva.VisibleIndex = 6;
            this.colactiva.Width = 185;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1051, 548);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1021, 472);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // uiRefresh
            // 
            this.uiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiRefresh.ImageOptions.Image")));
            this.uiRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiRefresh.Location = new System.Drawing.Point(18, 18);
            this.uiRefresh.Name = "uiRefresh";
            this.uiRefresh.Size = new System.Drawing.Size(504, 40);
            this.uiRefresh.StyleController = this.layoutControl1;
            this.uiRefresh.TabIndex = 5;
            this.uiRefresh.Text = "Refrescar";
            this.uiRefresh.Click += new System.EventHandler(this.uiRefresh_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiRefresh;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(510, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(510, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(511, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmProduccionSolicitudAceptacionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 548);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmProduccionSolicitudAceptacionList";
            this.Text = "Aceptaciones de Producción";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduccionSoicitudEjecucionList_FormClosing);
            this.Load += new System.EventHandler(this.frmProduccionSoicitudEjecucionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produccionSolicitudGridModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnVer)).EndInit();
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
        private System.Windows.Forms.BindingSource produccionSolicitudGridModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colproduccionSolicitudId;
        private DevExpress.XtraGrid.Columns.GridColumn coldeSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colparaSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colcompletada;
        private DevExpress.XtraGrid.Columns.GridColumn colactiva;
        private DevExpress.XtraGrid.Columns.GridColumn colVer;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnVer;
        private DevExpress.XtraEditors.SimpleButton uiRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}