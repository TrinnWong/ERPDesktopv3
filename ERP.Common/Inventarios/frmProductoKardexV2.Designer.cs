namespace ERP.Common.Inventarios
{
    partial class frmProductoKardexV2
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
            this.uiProducto = new DevExpress.XtraEditors.TextEdit();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.pinvproductokardexgrdResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolioMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcionCorta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadEntrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtrod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostoUltimaCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colCostoPromedio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colValCostoUltimaCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colValCostoPromedio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colComentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinvproductokardexgrdResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiProducto);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1242, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiProducto
            // 
            this.uiProducto.Enabled = false;
            this.uiProducto.Location = new System.Drawing.Point(68, 18);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Size = new System.Drawing.Size(1156, 26);
            this.uiProducto.StyleController = this.layoutControl1;
            this.uiProducto.TabIndex = 5;
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.pinvproductokardexgrdResultBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 50);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemSpinEdit3,
            this.repositoryItemSpinEdit4});
            this.uiGrid.Size = new System.Drawing.Size(1206, 382);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // pinvproductokardexgrdResultBindingSource
            // 
            this.pinvproductokardexgrdResultBindingSource.DataSource = typeof(ConexionBD.p_inv_producto_kardex_grd_Result);
            // 
            // uiGridView
            // 
            this.uiGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.uiGridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaMov,
            this.colSucursalMov,
            this.colSucursalOrigen,
            this.colSucursalDestino,
            this.colFolioMov,
            this.colMovimiento,
            this.colclave,
            this.colDescripcionCorta,
            this.colCantidadEntrada,
            this.colCantidadSalida,
            this.colExistencia,
            this.colOtrod,
            this.colCostoUltimaCompra,
            this.colCostoPromedio,
            this.colValCostoUltimaCompra,
            this.colValCostoPromedio,
            this.colComentarios,
            this.colValorMovimiento});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.DoubleClick += new System.EventHandler(this.uiGridView_DoubleClick);
            // 
            // colFechaMov
            // 
            this.colFechaMov.FieldName = "FechaMov";
            this.colFechaMov.Name = "colFechaMov";
            this.colFechaMov.OptionsColumn.AllowEdit = false;
            this.colFechaMov.Visible = true;
            this.colFechaMov.VisibleIndex = 0;
            this.colFechaMov.Width = 69;
            // 
            // colSucursalMov
            // 
            this.colSucursalMov.Caption = "Suc. Mov.";
            this.colSucursalMov.FieldName = "SucursalMov";
            this.colSucursalMov.Name = "colSucursalMov";
            this.colSucursalMov.OptionsColumn.AllowEdit = false;
            this.colSucursalMov.Visible = true;
            this.colSucursalMov.VisibleIndex = 1;
            this.colSucursalMov.Width = 78;
            // 
            // colSucursalOrigen
            // 
            this.colSucursalOrigen.Caption = "Suc. Origen";
            this.colSucursalOrigen.FieldName = "SucursalOrigen";
            this.colSucursalOrigen.Name = "colSucursalOrigen";
            this.colSucursalOrigen.OptionsColumn.AllowEdit = false;
            this.colSucursalOrigen.Width = 73;
            // 
            // colSucursalDestino
            // 
            this.colSucursalDestino.Caption = "Suc. Destino";
            this.colSucursalDestino.FieldName = "SucursalDestino";
            this.colSucursalDestino.Name = "colSucursalDestino";
            this.colSucursalDestino.OptionsColumn.AllowEdit = false;
            this.colSucursalDestino.Width = 66;
            // 
            // colFolioMov
            // 
            this.colFolioMov.Caption = "Folio Mov.";
            this.colFolioMov.FieldName = "FolioMov";
            this.colFolioMov.Name = "colFolioMov";
            this.colFolioMov.OptionsColumn.AllowEdit = false;
            this.colFolioMov.Visible = true;
            this.colFolioMov.VisibleIndex = 2;
            this.colFolioMov.Width = 65;
            // 
            // colMovimiento
            // 
            this.colMovimiento.FieldName = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.OptionsColumn.AllowEdit = false;
            this.colMovimiento.Visible = true;
            this.colMovimiento.VisibleIndex = 3;
            this.colMovimiento.Width = 87;
            // 
            // colclave
            // 
            this.colclave.Caption = "Clave";
            this.colclave.FieldName = "clave";
            this.colclave.Name = "colclave";
            this.colclave.OptionsColumn.AllowEdit = false;
            this.colclave.Visible = true;
            this.colclave.VisibleIndex = 4;
            this.colclave.Width = 64;
            // 
            // colDescripcionCorta
            // 
            this.colDescripcionCorta.FieldName = "DescripcionCorta";
            this.colDescripcionCorta.Name = "colDescripcionCorta";
            this.colDescripcionCorta.OptionsColumn.AllowEdit = false;
            this.colDescripcionCorta.Visible = true;
            this.colDescripcionCorta.VisibleIndex = 5;
            this.colDescripcionCorta.Width = 119;
            // 
            // colCantidadEntrada
            // 
            this.colCantidadEntrada.Caption = "Entrada";
            this.colCantidadEntrada.DisplayFormat.FormatString = "n4";
            this.colCantidadEntrada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidadEntrada.FieldName = "CantidadEntrada";
            this.colCantidadEntrada.Name = "colCantidadEntrada";
            this.colCantidadEntrada.OptionsColumn.AllowEdit = false;
            this.colCantidadEntrada.Visible = true;
            this.colCantidadEntrada.VisibleIndex = 6;
            this.colCantidadEntrada.Width = 92;
            // 
            // colCantidadSalida
            // 
            this.colCantidadSalida.Caption = "Salida";
            this.colCantidadSalida.DisplayFormat.FormatString = "n4";
            this.colCantidadSalida.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidadSalida.FieldName = "CantidadSalida";
            this.colCantidadSalida.Name = "colCantidadSalida";
            this.colCantidadSalida.OptionsColumn.AllowEdit = false;
            this.colCantidadSalida.Visible = true;
            this.colCantidadSalida.VisibleIndex = 7;
            this.colCantidadSalida.Width = 92;
            // 
            // colExistencia
            // 
            this.colExistencia.Caption = "Existencia";
            this.colExistencia.DisplayFormat.FormatString = "n4";
            this.colExistencia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistencia.FieldName = "Existencia";
            this.colExistencia.Name = "colExistencia";
            this.colExistencia.OptionsColumn.AllowEdit = false;
            this.colExistencia.Visible = true;
            this.colExistencia.VisibleIndex = 8;
            this.colExistencia.Width = 87;
            // 
            // colOtrod
            // 
            this.colOtrod.Caption = "Otros";
            this.colOtrod.DisplayFormat.FormatString = "c2";
            this.colOtrod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtrod.FieldName = "OtrosCargos";
            this.colOtrod.Name = "colOtrod";
            this.colOtrod.OptionsColumn.AllowEdit = false;
            this.colOtrod.Visible = true;
            this.colOtrod.VisibleIndex = 10;
            this.colOtrod.Width = 67;
            // 
            // colCostoUltimaCompra
            // 
            this.colCostoUltimaCompra.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostoUltimaCompra.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCostoUltimaCompra.Caption = "P.U. Compra";
            this.colCostoUltimaCompra.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colCostoUltimaCompra.FieldName = "CostoUltimaCompra";
            this.colCostoUltimaCompra.Name = "colCostoUltimaCompra";
            this.colCostoUltimaCompra.OptionsColumn.AllowEdit = false;
            this.colCostoUltimaCompra.Visible = true;
            this.colCostoUltimaCompra.VisibleIndex = 9;
            this.colCostoUltimaCompra.Width = 82;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "c2";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colCostoPromedio
            // 
            this.colCostoPromedio.Caption = "Cto. Prom.";
            this.colCostoPromedio.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colCostoPromedio.FieldName = "CostoPromedio";
            this.colCostoPromedio.Name = "colCostoPromedio";
            this.colCostoPromedio.OptionsColumn.AllowEdit = false;
            this.colCostoPromedio.Visible = true;
            this.colCostoPromedio.VisibleIndex = 12;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.DisplayFormat.FormatString = "c2";
            this.repositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // colValCostoUltimaCompra
            // 
            this.colValCostoUltimaCompra.Caption = "Val. Ult. Compra";
            this.colValCostoUltimaCompra.ColumnEdit = this.repositoryItemSpinEdit3;
            this.colValCostoUltimaCompra.FieldName = "ValCostoUltimaCompra";
            this.colValCostoUltimaCompra.Name = "colValCostoUltimaCompra";
            this.colValCostoUltimaCompra.OptionsColumn.AllowEdit = false;
            this.colValCostoUltimaCompra.Visible = true;
            this.colValCostoUltimaCompra.VisibleIndex = 13;
            this.colValCostoUltimaCompra.Width = 62;
            // 
            // repositoryItemSpinEdit3
            // 
            this.repositoryItemSpinEdit3.AutoHeight = false;
            this.repositoryItemSpinEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit3.DisplayFormat.FormatString = "c2";
            this.repositoryItemSpinEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit3.Name = "repositoryItemSpinEdit3";
            // 
            // colValCostoPromedio
            // 
            this.colValCostoPromedio.Caption = "Val. Cto. Prom.";
            this.colValCostoPromedio.ColumnEdit = this.repositoryItemSpinEdit4;
            this.colValCostoPromedio.FieldName = "ValCostoPromedio";
            this.colValCostoPromedio.Name = "colValCostoPromedio";
            this.colValCostoPromedio.OptionsColumn.AllowEdit = false;
            this.colValCostoPromedio.Visible = true;
            this.colValCostoPromedio.VisibleIndex = 14;
            this.colValCostoPromedio.Width = 77;
            // 
            // repositoryItemSpinEdit4
            // 
            this.repositoryItemSpinEdit4.AutoHeight = false;
            this.repositoryItemSpinEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit4.DisplayFormat.FormatString = "c2";
            this.repositoryItemSpinEdit4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit4.Name = "repositoryItemSpinEdit4";
            // 
            // colComentarios
            // 
            this.colComentarios.FieldName = "Comentarios";
            this.colComentarios.Name = "colComentarios";
            this.colComentarios.OptionsColumn.AllowEdit = false;
            this.colComentarios.Visible = true;
            this.colComentarios.VisibleIndex = 15;
            this.colComentarios.Width = 88;
            // 
            // colValorMovimiento
            // 
            this.colValorMovimiento.Caption = "Valor Mov.";
            this.colValorMovimiento.DisplayFormat.FormatString = "c2";
            this.colValorMovimiento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValorMovimiento.FieldName = "ValorMovimiento";
            this.colValorMovimiento.Name = "colValorMovimiento";
            this.colValorMovimiento.OptionsColumn.AllowEdit = false;
            this.colValorMovimiento.Visible = true;
            this.colValorMovimiento.VisibleIndex = 11;
            this.colValorMovimiento.Width = 69;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1242, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1212, 388);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiProducto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1212, 32);
            this.layoutControlItem2.Text = "Producto:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(47, 13);
            // 
            // frmProductoKardexV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmProductoKardexV2";
            this.Text = "frmProductoKardexV2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductoKardexV2_FormClosing);
            this.Load += new System.EventHandler(this.frmProductoKardexV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinvproductokardexgrdResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit4)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit uiProducto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource pinvproductokardexgrdResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaMov;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalMov;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colFolioMov;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colclave;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcionCorta;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadEntrada;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadSalida;
        private DevExpress.XtraGrid.Columns.GridColumn colExistencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoUltimaCompra;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoPromedio;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colValCostoUltimaCompra;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colValCostoPromedio;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn colComentarios;
        private DevExpress.XtraGrid.Columns.GridColumn colValorMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colOtrod;
    }
}