namespace ERPv1.Reportes
{
    partial class frmEstadoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadoCuenta));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.prptestadocuentadetalleResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalleMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargoAbono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.uiAl = new DevExpress.XtraEditors.DateEdit();
            this.uiDel = new DevExpress.XtraEditors.DateEdit();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiCargos = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiVentas = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiBalance = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prptestadocuentadetalleResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAl.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDel.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCargos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVentas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiBalance);
            this.layoutControl1.Controls.Add(this.uiVentas);
            this.layoutControl1.Controls.Add(this.uiCargos);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.uiAl);
            this.layoutControl1.Controls.Add(this.uiDel);
            this.layoutControl1.Controls.Add(this.uiSucursal);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1080, 572);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.prptestadocuentadetalleResultBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(16, 90);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1048, 438);
            this.uiGrid.TabIndex = 8;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // prptestadocuentadetalleResultBindingSource
            // 
            this.prptestadocuentadetalleResultBindingSource.DataSource = typeof(ConexionBD.p_rpt_estado_cuenta_detalle_Result);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colSucursal,
            this.colMovimiento,
            this.colDetalleMovimiento,
            this.colTotal,
            this.colCargoAbono,
            this.colTipo});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.GroupCount = 1;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTipo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colSucursal
            // 
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 1;
            // 
            // colMovimiento
            // 
            this.colMovimiento.FieldName = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Visible = true;
            this.colMovimiento.VisibleIndex = 2;
            // 
            // colDetalleMovimiento
            // 
            this.colDetalleMovimiento.FieldName = "DetalleMovimiento";
            this.colDetalleMovimiento.Name = "colDetalleMovimiento";
            this.colDetalleMovimiento.Visible = true;
            this.colDetalleMovimiento.VisibleIndex = 3;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 4;
            // 
            // colCargoAbono
            // 
            this.colCargoAbono.FieldName = "CargoAbono";
            this.colCargoAbono.Name = "colCargoAbono";
            this.colCargoAbono.Visible = true;
            this.colCargoAbono.VisibleIndex = 5;
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(16, 44);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(438, 40);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Buscar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // uiAl
            // 
            this.uiAl.EditValue = null;
            this.uiAl.Location = new System.Drawing.Point(855, 16);
            this.uiAl.Name = "uiAl";
            this.uiAl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiAl.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiAl.Size = new System.Drawing.Size(209, 22);
            this.uiAl.StyleController = this.layoutControl1;
            this.uiAl.TabIndex = 6;
            // 
            // uiDel
            // 
            this.uiDel.EditValue = null;
            this.uiDel.Location = new System.Drawing.Point(509, 16);
            this.uiDel.Name = "uiDel";
            this.uiDel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiDel.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiDel.Size = new System.Drawing.Size(291, 22);
            this.uiDel.StyleController = this.layoutControl1;
            this.uiDel.TabIndex = 5;
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(65, 16);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DataSource = this.catsucursalesBindingSource;
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Selecciona una Sucursal)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(389, 22);
            this.uiSucursal.StyleController = this.layoutControl1;
            this.uiSucursal.TabIndex = 4;
            this.uiSucursal.EditValueChanged += new System.EventHandler(this.uiSucursal_EditValueChanged);
            // 
            // catsucursalesBindingSource
            // 
            this.catsucursalesBindingSource.DataSource = typeof(ConexionBD.cat_sucursales);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1080, 572);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiSucursal;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(444, 28);
            this.layoutControlItem1.Text = "Sucursal";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiDel;
            this.layoutControlItem2.Location = new System.Drawing.Point(444, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(346, 28);
            this.layoutControlItem2.Text = "Del";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiAl;
            this.layoutControlItem3.Location = new System.Drawing.Point(790, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(264, 28);
            this.layoutControlItem3.Text = "Al";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(45, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(444, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(444, 28);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(610, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiGrid;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1054, 444);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // uiCargos
            // 
            this.uiCargos.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiCargos.Location = new System.Drawing.Point(65, 534);
            this.uiCargos.Name = "uiCargos";
            this.uiCargos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCargos.Properties.DisplayFormat.FormatString = "c2";
            this.uiCargos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCargos.Properties.EditFormat.FormatString = "c2";
            this.uiCargos.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCargos.Size = new System.Drawing.Size(278, 22);
            this.uiCargos.StyleController = this.layoutControl1;
            this.uiCargos.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiCargos;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 518);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(333, 28);
            this.layoutControlItem6.Text = "GASTOS";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(45, 13);
            // 
            // uiVentas
            // 
            this.uiVentas.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiVentas.Location = new System.Drawing.Point(398, 534);
            this.uiVentas.Name = "uiVentas";
            this.uiVentas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiVentas.Properties.DisplayFormat.FormatString = "c2";
            this.uiVentas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiVentas.Properties.EditFormat.FormatString = "c2";
            this.uiVentas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiVentas.Size = new System.Drawing.Size(301, 22);
            this.uiVentas.StyleController = this.layoutControl1;
            this.uiVentas.TabIndex = 10;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.uiVentas;
            this.layoutControlItem7.Location = new System.Drawing.Point(333, 518);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(356, 28);
            this.layoutControlItem7.Text = "VENTAS";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(45, 13);
            // 
            // uiBalance
            // 
            this.uiBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiBalance.Location = new System.Drawing.Point(754, 534);
            this.uiBalance.Name = "uiBalance";
            this.uiBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiBalance.Properties.DisplayFormat.FormatString = "c2";
            this.uiBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiBalance.Properties.EditFormat.FormatString = "c2";
            this.uiBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiBalance.Size = new System.Drawing.Size(310, 22);
            this.uiBalance.StyleController = this.layoutControl1;
            this.uiBalance.TabIndex = 11;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.uiBalance;
            this.layoutControlItem8.Location = new System.Drawing.Point(689, 518);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(365, 28);
            this.layoutControlItem8.Text = "BALANCE";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(45, 13);
            // 
            // frmEstadoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 572);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmEstadoCuenta";
            this.Text = "Estado de Cuenta";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.frmEstadoCuenta_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstadoCuenta_FormClosing);
            this.Load += new System.EventHandler(this.frmEstadoCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prptestadocuentadetalleResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAl.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDel.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCargos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiVentas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit uiAl;
        private DevExpress.XtraEditors.DateEdit uiDel;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource prptestadocuentadetalleResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalleMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoAbono;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
        private DevExpress.XtraEditors.SpinEdit uiBalance;
        private DevExpress.XtraEditors.SpinEdit uiVentas;
        private DevExpress.XtraEditors.SpinEdit uiCargos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}