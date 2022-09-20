namespace ERP.Common.Inventarios
{
    partial class frmExistenciasV2
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
            this.uiSoloExistencias = new DevExpress.XtraEditors.CheckEdit();
            this.uiExistencias = new DevExpress.XtraGrid.GridControl();
            this.pproductosexistenciaselResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiViewExistencias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaveLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaveFamilia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFamilia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaveSubFamilia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubFamilia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaveProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistenciaSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistenciaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistenciaTeorica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApartado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisponible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSoloExistencias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiExistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pproductosexistenciaselResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiViewExistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiExistencias);
            this.layoutControl1.Controls.Add(this.uiSoloExistencias);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1083, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiSoloExistencias
            // 
            this.uiSoloExistencias.Location = new System.Drawing.Point(12, 12);
            this.uiSoloExistencias.Name = "uiSoloExistencias";
            this.uiSoloExistencias.Properties.Caption = "Solo con Existencias";
            this.uiSoloExistencias.Size = new System.Drawing.Size(1059, 19);
            this.uiSoloExistencias.StyleController = this.layoutControl1;
            this.uiSoloExistencias.TabIndex = 5;
            this.uiSoloExistencias.CheckedChanged += new System.EventHandler(this.uiSoloExistencias_CheckedChanged);
            // 
            // uiExistencias
            // 
            this.uiExistencias.DataSource = this.pproductosexistenciaselResultBindingSource;
            this.uiExistencias.Location = new System.Drawing.Point(12, 35);
            this.uiExistencias.MainView = this.uiViewExistencias;
            this.uiExistencias.Name = "uiExistencias";
            this.uiExistencias.Size = new System.Drawing.Size(1059, 403);
            this.uiExistencias.TabIndex = 4;
            this.uiExistencias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiViewExistencias});
            // 
            // pproductosexistenciaselResultBindingSource
            // 
            this.pproductosexistenciaselResultBindingSource.DataSource = typeof(ConexionBD.p_productos_existencia_sel_Result);
            // 
            // uiViewExistencias
            // 
            this.uiViewExistencias.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSucursalId,
            this.colClaveLinea,
            this.colNombreSucursal,
            this.colLinea,
            this.colClaveFamilia,
            this.colFamilia,
            this.colClaveSubFamilia,
            this.colSubFamilia,
            this.colProductoId,
            this.colClaveProducto,
            this.colProducto,
            this.colExistenciaSucursal,
            this.colExistenciaTotal,
            this.colClave,
            this.colExistenciaTeorica,
            this.colDescripcion,
            this.colApartado,
            this.colDisponible});
            this.uiViewExistencias.GridControl = this.uiExistencias;
            this.uiViewExistencias.Name = "uiViewExistencias";
            this.uiViewExistencias.OptionsFind.AlwaysVisible = true;
            this.uiViewExistencias.DoubleClick += new System.EventHandler(this.uiViewExistencias_DoubleClick);
            // 
            // colSucursalId
            // 
            this.colSucursalId.FieldName = "SucursalId";
            this.colSucursalId.Name = "colSucursalId";
            this.colSucursalId.OptionsColumn.AllowEdit = false;
            // 
            // colClaveLinea
            // 
            this.colClaveLinea.FieldName = "ClaveLinea";
            this.colClaveLinea.Name = "colClaveLinea";
            this.colClaveLinea.OptionsColumn.AllowEdit = false;
            // 
            // colNombreSucursal
            // 
            this.colNombreSucursal.FieldName = "NombreSucursal";
            this.colNombreSucursal.Name = "colNombreSucursal";
            this.colNombreSucursal.OptionsColumn.AllowEdit = false;
            // 
            // colLinea
            // 
            this.colLinea.FieldName = "Linea";
            this.colLinea.Name = "colLinea";
            this.colLinea.OptionsColumn.AllowEdit = false;
            this.colLinea.Visible = true;
            this.colLinea.VisibleIndex = 0;
            // 
            // colClaveFamilia
            // 
            this.colClaveFamilia.FieldName = "ClaveFamilia";
            this.colClaveFamilia.Name = "colClaveFamilia";
            this.colClaveFamilia.OptionsColumn.AllowEdit = false;
            // 
            // colFamilia
            // 
            this.colFamilia.FieldName = "Familia";
            this.colFamilia.Name = "colFamilia";
            this.colFamilia.OptionsColumn.AllowEdit = false;
            this.colFamilia.Visible = true;
            this.colFamilia.VisibleIndex = 1;
            // 
            // colClaveSubFamilia
            // 
            this.colClaveSubFamilia.FieldName = "ClaveSubFamilia";
            this.colClaveSubFamilia.Name = "colClaveSubFamilia";
            this.colClaveSubFamilia.OptionsColumn.AllowEdit = false;
            // 
            // colSubFamilia
            // 
            this.colSubFamilia.FieldName = "SubFamilia";
            this.colSubFamilia.Name = "colSubFamilia";
            this.colSubFamilia.OptionsColumn.AllowEdit = false;
            this.colSubFamilia.Visible = true;
            this.colSubFamilia.VisibleIndex = 2;
            // 
            // colProductoId
            // 
            this.colProductoId.FieldName = "ProductoId";
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.OptionsColumn.AllowEdit = false;
            // 
            // colClaveProducto
            // 
            this.colClaveProducto.FieldName = "ClaveProducto";
            this.colClaveProducto.Name = "colClaveProducto";
            this.colClaveProducto.OptionsColumn.AllowEdit = false;
            this.colClaveProducto.Visible = true;
            this.colClaveProducto.VisibleIndex = 3;
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.OptionsColumn.AllowEdit = false;
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 4;
            // 
            // colExistenciaSucursal
            // 
            this.colExistenciaSucursal.DisplayFormat.FormatString = "n5";
            this.colExistenciaSucursal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistenciaSucursal.FieldName = "ExistenciaSucursal";
            this.colExistenciaSucursal.Name = "colExistenciaSucursal";
            this.colExistenciaSucursal.OptionsColumn.AllowEdit = false;
            this.colExistenciaSucursal.Visible = true;
            this.colExistenciaSucursal.VisibleIndex = 5;
            // 
            // colExistenciaTotal
            // 
            this.colExistenciaTotal.DisplayFormat.FormatString = "n5";
            this.colExistenciaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistenciaTotal.FieldName = "ExistenciaTotal";
            this.colExistenciaTotal.Name = "colExistenciaTotal";
            this.colExistenciaTotal.OptionsColumn.AllowEdit = false;
            this.colExistenciaTotal.Visible = true;
            this.colExistenciaTotal.VisibleIndex = 6;
            // 
            // colClave
            // 
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.OptionsColumn.AllowEdit = false;
            // 
            // colExistenciaTeorica
            // 
            this.colExistenciaTeorica.DisplayFormat.FormatString = "n5";
            this.colExistenciaTeorica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistenciaTeorica.FieldName = "ExistenciaTeorica";
            this.colExistenciaTeorica.Name = "colExistenciaTeorica";
            this.colExistenciaTeorica.OptionsColumn.AllowEdit = false;
            this.colExistenciaTeorica.Visible = true;
            this.colExistenciaTeorica.VisibleIndex = 7;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            // 
            // colApartado
            // 
            this.colApartado.Caption = "Apartado";
            this.colApartado.FieldName = "Apartado";
            this.colApartado.Name = "colApartado";
            this.colApartado.OptionsColumn.AllowEdit = false;
            this.colApartado.Visible = true;
            this.colApartado.VisibleIndex = 8;
            // 
            // colDisponible
            // 
            this.colDisponible.Caption = "Disponible";
            this.colDisponible.DisplayFormat.FormatString = "n5";
            this.colDisponible.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDisponible.FieldName = "Disponible";
            this.colDisponible.Name = "colDisponible";
            this.colDisponible.OptionsColumn.AllowEdit = false;
            this.colDisponible.Visible = true;
            this.colDisponible.VisibleIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1083, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiExistencias;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1063, 407);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiSoloExistencias;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1063, 23);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmExistenciasV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmExistenciasV2";
            this.Text = "Existencias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExistenciasV2_FormClosing);
            this.Load += new System.EventHandler(this.frmExistenciasV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSoloExistencias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiExistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pproductosexistenciaselResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiViewExistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiExistencias;
        private DevExpress.XtraGrid.Views.Grid.GridView uiViewExistencias;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource pproductosexistenciaselResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colClaveLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colLinea;
        private DevExpress.XtraGrid.Columns.GridColumn colClaveFamilia;
        private DevExpress.XtraGrid.Columns.GridColumn colFamilia;
        private DevExpress.XtraGrid.Columns.GridColumn colClaveSubFamilia;
        private DevExpress.XtraGrid.Columns.GridColumn colSubFamilia;
        private DevExpress.XtraGrid.Columns.GridColumn colProductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colClaveProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private DevExpress.XtraGrid.Columns.GridColumn colExistenciaSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colExistenciaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colExistenciaTeorica;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraEditors.CheckEdit uiSoloExistencias;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colApartado;
        private DevExpress.XtraGrid.Columns.GridColumn colDisponible;
    }
}