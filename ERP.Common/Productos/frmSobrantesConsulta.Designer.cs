namespace ERP.Common.Productos
{
    partial class frmPreferenciaSucursal
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.productoSobranteModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombreSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidadSobrante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidadInventarioTeorico = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidadDiferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.uiFecha = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.docproductossobrantesregistroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoSobranteModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproductossobrantesregistroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.uiFecha);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1047, 566);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.productoSobranteModelBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(16, 72);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1015, 478);
            this.uiGrid.TabIndex = 7;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            this.uiGrid.Load += new System.EventHandler(this.uiGrid_Load);
            // 
            // productoSobranteModelBindingSource
            // 
            this.productoSobranteModelBindingSource.DataSource = typeof(ERP.Models.ProductoSobrante.ProductoSobranteModel);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsucursalId,
            this.colnombreSucursal,
            this.colproductoId,
            this.colproducto,
            this.colcantidadSobrante,
            this.colcantidadInventarioTeorico,
            this.colcantidadDiferencia,
            this.gridColumn1});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colsucursalId
            // 
            this.colsucursalId.FieldName = "sucursalId";
            this.colsucursalId.Name = "colsucursalId";
            this.colsucursalId.OptionsColumn.AllowEdit = false;
            // 
            // colnombreSucursal
            // 
            this.colnombreSucursal.Caption = "Sucursal";
            this.colnombreSucursal.FieldName = "nombreSucursal";
            this.colnombreSucursal.Name = "colnombreSucursal";
            this.colnombreSucursal.OptionsColumn.AllowEdit = false;
            this.colnombreSucursal.Visible = true;
            this.colnombreSucursal.VisibleIndex = 0;
            // 
            // colproductoId
            // 
            this.colproductoId.Caption = "Producto";
            this.colproductoId.FieldName = "productoId";
            this.colproductoId.Name = "colproductoId";
            this.colproductoId.OptionsColumn.AllowEdit = false;
            // 
            // colproducto
            // 
            this.colproducto.Caption = "Producto";
            this.colproducto.FieldName = "producto";
            this.colproducto.Name = "colproducto";
            this.colproducto.OptionsColumn.AllowEdit = false;
            this.colproducto.Visible = true;
            this.colproducto.VisibleIndex = 2;
            // 
            // colcantidadSobrante
            // 
            this.colcantidadSobrante.Caption = "Cantidad Sobrante";
            this.colcantidadSobrante.FieldName = "cantidadSobrante";
            this.colcantidadSobrante.Name = "colcantidadSobrante";
            this.colcantidadSobrante.OptionsColumn.AllowEdit = false;
            this.colcantidadSobrante.Visible = true;
            this.colcantidadSobrante.VisibleIndex = 3;
            // 
            // colcantidadInventarioTeorico
            // 
            this.colcantidadInventarioTeorico.Caption = "Cantidad Solicitada Inv.";
            this.colcantidadInventarioTeorico.FieldName = "cantidadInventarioTeorico";
            this.colcantidadInventarioTeorico.Name = "colcantidadInventarioTeorico";
            this.colcantidadInventarioTeorico.OptionsColumn.AllowEdit = false;
            this.colcantidadInventarioTeorico.Visible = true;
            this.colcantidadInventarioTeorico.VisibleIndex = 4;
            // 
            // colcantidadDiferencia
            // 
            this.colcantidadDiferencia.Caption = "Diferencia";
            this.colcantidadDiferencia.FieldName = "cantidadDiferencia";
            this.colcantidadDiferencia.Name = "colcantidadDiferencia";
            this.colcantidadDiferencia.OptionsColumn.AllowEdit = false;
            this.colcantidadDiferencia.Visible = true;
            this.colcantidadDiferencia.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha";
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "fecha";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(298, 22);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Consulta de Productos Sobrantes";
            // 
            // uiFecha
            // 
            this.uiFecha.EditValue = null;
            this.uiFecha.Location = new System.Drawing.Point(107, 44);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFecha.Size = new System.Drawing.Size(213, 22);
            this.uiFecha.StyleController = this.layoutControl1;
            this.uiFecha.TabIndex = 5;
            this.uiFecha.EditValueChanged += new System.EventHandler(this.uiFecha_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1047, 566);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiFecha;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(310, 28);
            this.layoutControlItem2.Text = "Fecha a Consultar";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1021, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(310, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(711, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1021, 484);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // docproductossobrantesregistroBindingSource
            // 
            this.docproductossobrantesregistroBindingSource.DataSource = typeof(ConexionBD.doc_productos_sobrantes_registro);
            // 
            // frmPreferenciaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 566);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPreferenciaSucursal";
            this.Text = "Productos Sobrantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSobrantesConsulta_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoSobranteModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docproductossobrantesregistroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit uiFecha;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource docproductossobrantesregistroBindingSource;
        private System.Windows.Forms.BindingSource productoSobranteModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colsucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colnombreSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colproductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidadSobrante;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidadInventarioTeorico;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidadDiferencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}