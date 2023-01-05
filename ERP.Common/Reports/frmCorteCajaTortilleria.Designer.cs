namespace ERP.Common.Reports
{
    partial class frmCorteCajaTortilleria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorteCajaTortilleria));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiDiferencia = new DevExpress.XtraEditors.SpinEdit();
            this.uiTotalEntregado = new DevExpress.XtraEditors.SpinEdit();
            this.uiTotalDescuentos = new DevExpress.XtraEditors.SpinEdit();
            this.uiTotalAnalisis = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.uiBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.uiFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.pcortecajainventariogeneracionResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFila = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAnalisisCorteCaja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDescuentos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalEntregadoSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDiferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalEntregado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalDescuentos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalAnalisis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcortecajainventariogeneracionResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiDiferencia);
            this.layoutControl1.Controls.Add(this.uiTotalEntregado);
            this.layoutControl1.Controls.Add(this.uiTotalDescuentos);
            this.layoutControl1.Controls.Add(this.uiTotalAnalisis);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.uiBuscar);
            this.layoutControl1.Controls.Add(this.uiFechaIni);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1185, 684);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiDiferencia
            // 
            this.uiDiferencia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiDiferencia.Location = new System.Drawing.Point(975, 640);
            this.uiDiferencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiDiferencia.Name = "uiDiferencia";
            this.uiDiferencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDiferencia.Properties.Appearance.Options.UseFont = true;
            this.uiDiferencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiDiferencia.Properties.DisplayFormat.FormatString = "c2";
            this.uiDiferencia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiDiferencia.Size = new System.Drawing.Size(194, 28);
            this.uiDiferencia.StyleController = this.layoutControl1;
            this.uiDiferencia.TabIndex = 12;
            // 
            // uiTotalEntregado
            // 
            this.uiTotalEntregado.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiTotalEntregado.Location = new System.Drawing.Point(721, 640);
            this.uiTotalEntregado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTotalEntregado.Name = "uiTotalEntregado";
            this.uiTotalEntregado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalEntregado.Properties.Appearance.Options.UseFont = true;
            this.uiTotalEntregado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTotalEntregado.Properties.DisplayFormat.FormatString = "c2";
            this.uiTotalEntregado.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiTotalEntregado.Size = new System.Drawing.Size(146, 28);
            this.uiTotalEntregado.StyleController = this.layoutControl1;
            this.uiTotalEntregado.TabIndex = 11;
            // 
            // uiTotalDescuentos
            // 
            this.uiTotalDescuentos.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiTotalDescuentos.Location = new System.Drawing.Point(392, 640);
            this.uiTotalDescuentos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTotalDescuentos.Name = "uiTotalDescuentos";
            this.uiTotalDescuentos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalDescuentos.Properties.Appearance.Options.UseFont = true;
            this.uiTotalDescuentos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTotalDescuentos.Properties.DisplayFormat.FormatString = "c2";
            this.uiTotalDescuentos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiTotalDescuentos.Size = new System.Drawing.Size(221, 28);
            this.uiTotalDescuentos.StyleController = this.layoutControl1;
            this.uiTotalDescuentos.TabIndex = 10;
            // 
            // uiTotalAnalisis
            // 
            this.uiTotalAnalisis.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiTotalAnalisis.Location = new System.Drawing.Point(118, 640);
            this.uiTotalAnalisis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTotalAnalisis.Name = "uiTotalAnalisis";
            this.uiTotalAnalisis.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalAnalisis.Properties.Appearance.Options.UseFont = true;
            this.uiTotalAnalisis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTotalAnalisis.Properties.DisplayFormat.FormatString = "c2";
            this.uiTotalAnalisis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiTotalAnalisis.Size = new System.Drawing.Size(166, 28);
            this.uiTotalAnalisis.StyleController = this.layoutControl1;
            this.uiTotalAnalisis.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 16);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(245, 24);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Corte de Caja/Tortillería";
            // 
            // uiBuscar
            // 
            this.uiBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiBuscar.ImageOptions.Image")));
            this.uiBuscar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiBuscar.Location = new System.Drawing.Point(380, 46);
            this.uiBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(315, 40);
            this.uiBuscar.StyleController = this.layoutControl1;
            this.uiBuscar.TabIndex = 7;
            this.uiBuscar.Text = "Buscar";
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // uiFechaIni
            // 
            this.uiFechaIni.EditValue = null;
            this.uiFechaIni.Location = new System.Drawing.Point(118, 46);
            this.uiFechaIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiFechaIni.Name = "uiFechaIni";
            this.uiFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaIni.Size = new System.Drawing.Size(256, 22);
            this.uiFechaIni.StyleController = this.layoutControl1;
            this.uiFechaIni.TabIndex = 5;
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.pcortecajainventariogeneracionResultBindingSource;
            this.uiGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiGrid.Location = new System.Drawing.Point(16, 92);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1153, 542);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // pcortecajainventariogeneracionResultBindingSource
            // 
            this.pcortecajainventariogeneracionResultBindingSource.DataSource = typeof(ConexionBD.p_corte_caja_inventario_generacion_Result);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFila,
            this.colTipoMovimiento,
            this.colConcepto,
            this.colAbono,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colMonto,
            this.colTotalAnalisisCorteCaja,
            this.colTotalDescuentos,
            this.colTotalEntregadoSucursal,
            this.colDiferencia});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.GroupCount = 1;
            this.uiGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Monto", this.colMonto, "(Monto: SUMA={0:#.##})")});
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTipoMovimiento, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFila
            // 
            this.colFila.FieldName = "Fila";
            this.colFila.Name = "colFila";
            this.colFila.Visible = true;
            this.colFila.VisibleIndex = 0;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.FieldName = "TipoMovimiento";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.Visible = true;
            this.colTipoMovimiento.VisibleIndex = 1;
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 1;
            // 
            // colAbono
            // 
            this.colAbono.FieldName = "Abono";
            this.colAbono.Name = "colAbono";
            this.colAbono.Visible = true;
            this.colAbono.VisibleIndex = 2;
            // 
            // colCantidad
            // 
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 3;
            // 
            // colPrecioUnitario
            // 
            this.colPrecioUnitario.FieldName = "PrecioUnitario";
            this.colPrecioUnitario.Name = "colPrecioUnitario";
            this.colPrecioUnitario.Visible = true;
            this.colPrecioUnitario.VisibleIndex = 4;
            // 
            // colMonto
            // 
            this.colMonto.FieldName = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.Visible = true;
            this.colMonto.VisibleIndex = 5;
            // 
            // colTotalAnalisisCorteCaja
            // 
            this.colTotalAnalisisCorteCaja.FieldName = "TotalAnalisisCorteCaja";
            this.colTotalAnalisisCorteCaja.Name = "colTotalAnalisisCorteCaja";
            // 
            // colTotalDescuentos
            // 
            this.colTotalDescuentos.FieldName = "TotalDescuentos";
            this.colTotalDescuentos.Name = "colTotalDescuentos";
            // 
            // colTotalEntregadoSucursal
            // 
            this.colTotalEntregadoSucursal.FieldName = "TotalEntregadoSucursal";
            this.colTotalEntregadoSucursal.Name = "colTotalEntregadoSucursal";
            // 
            // colDiferencia
            // 
            this.colDiferencia.FieldName = "Diferencia";
            this.colDiferencia.Name = "colDiferencia";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1185, 684);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1159, 548);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiFechaIni;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 46);
            this.layoutControlItem2.Text = "Fecha Corte";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(98, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiBuscar;
            this.layoutControlItem4.Location = new System.Drawing.Point(364, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(321, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(685, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(474, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1159, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiTotalAnalisis;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 624);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(274, 34);
            this.layoutControlItem5.Text = "Total Análisis";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(98, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiTotalDescuentos;
            this.layoutControlItem6.Location = new System.Drawing.Point(274, 624);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(329, 34);
            this.layoutControlItem6.Text = "Total Descuentos";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(98, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.uiTotalEntregado;
            this.layoutControlItem7.Location = new System.Drawing.Point(603, 624);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(254, 34);
            this.layoutControlItem7.Text = "Total Entregado";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(98, 16);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.uiDiferencia;
            this.layoutControlItem8.Location = new System.Drawing.Point(857, 624);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(302, 34);
            this.layoutControlItem8.Text = "Diferencia";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(98, 16);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(100, 23);
            this.metroLabel1.TabIndex = 0;
            // 
            // frmCorteCajaTortilleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 684);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCorteCajaTortilleria";
            this.Text = "Corte de Caja/Tortillería";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCorteCajaTortilleria_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDiferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalEntregado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalDescuentos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalAnalisis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcortecajainventariogeneracionResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton uiBuscar;
        private DevExpress.XtraEditors.DateEdit uiFechaIni;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private DevExpress.XtraEditors.SpinEdit uiDiferencia;
        private DevExpress.XtraEditors.SpinEdit uiTotalEntregado;
        private DevExpress.XtraEditors.SpinEdit uiTotalDescuentos;
        private DevExpress.XtraEditors.SpinEdit uiTotalAnalisis;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.BindingSource pcortecajainventariogeneracionResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFila;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colAbono;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAnalisisCorteCaja;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDescuentos;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalEntregadoSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferencia;
    }
}