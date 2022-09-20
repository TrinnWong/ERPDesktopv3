namespace Productos
{
    partial class frmProductosCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductosCompra));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uiDescuento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.uiSubTotal = new System.Windows.Forms.NumericUpDown();
            this.uiImpuestos = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uiTotal = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.uiCodigoProducto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uiDescripcionProd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.uiPorcDescVenta = new System.Windows.Forms.NumericUpDown();
            this.uiDescPartida = new System.Windows.Forms.RadioButton();
            this.uiDescTodaVenta = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.uiPorcDescPartida = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.uiTotalPartida = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.uiFotoProducto = new System.Windows.Forms.PictureBox();
            this.uiGridProducto = new System.Windows.Forms.DataGridView();
            this.partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcImpuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSup = new System.Windows.Forms.Panel();
            this.uiImprimir = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.uiCancelarCompra = new System.Windows.Forms.Button();
            this.uiBuscarFolio = new System.Windows.Forms.Button();
            this.uiGrabada = new System.Windows.Forms.CheckBox();
            this.uiAfectado = new System.Windows.Forms.CheckBox();
            this.uiLimpiar = new System.Windows.Forms.Button();
            this.btnActualizarPrecio = new System.Windows.Forms.Button();
            this.uiFechaRemision = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.uiRemision = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.uiActivo = new System.Windows.Forms.CheckBox();
            this.uiProductoCompraId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.uiNombreCliente = new System.Windows.Forms.TextBox();
            this.uiProveedorId = new System.Windows.Forms.TextBox();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uiFecha = new System.Windows.Forms.DateTimePicker();
            this.uiBuscarCliente = new System.Windows.Forms.Button();
            this.uiPrecioConIVA = new System.Windows.Forms.CheckBox();
            this.panelCentro = new System.Windows.Forms.Panel();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.uiAgregarIVA = new System.Windows.Forms.CheckBox();
            this.uiPrecioUnitario = new DevExpress.XtraEditors.SpinEdit();
            this.uiCantidad = new DevExpress.XtraEditors.SpinEdit();
            this.uiImpuestosOtros = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.uiTotalOtros = new System.Windows.Forms.NumericUpDown();
            this.uiComisionesTotal2 = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.uiFleteTotal2 = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.grCargos = new DevExpress.XtraEditors.GroupControl();
            this.uiOtrosCargosImpuestos = new DevExpress.XtraEditors.CalcEdit();
            this.uiComisionImpuestos = new DevExpress.XtraEditors.CalcEdit();
            this.uiFleteImpuestos = new DevExpress.XtraEditors.CalcEdit();
            this.label27 = new System.Windows.Forms.Label();
            this.uiComisionProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.catproductospreciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.uiFleteProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.catproveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiOtrosCargosTotal = new DevExpress.XtraEditors.CalcEdit();
            this.uiComisionFecha = new DevExpress.XtraEditors.DateEdit();
            this.uiFleteFecha = new DevExpress.XtraEditors.DateEdit();
            this.label23 = new System.Windows.Forms.Label();
            this.uiComisionRemision = new DevExpress.XtraEditors.TextEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.uiFleteRemision = new DevExpress.XtraEditors.TextEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.uiComisionTotal = new DevExpress.XtraEditors.CalcEdit();
            this.uiFleteTotal = new DevExpress.XtraEditors.CalcEdit();
            this.uiComision = new DevExpress.XtraEditors.CheckEdit();
            this.uiFlete = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescPartida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalPartida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFotoProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridProducto)).BeginInit();
            this.panelSup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProductoCompraId)).BeginInit();
            this.panelCentro.SuspendLayout();
            this.panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioUnitario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestosOtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalOtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionesTotal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteTotal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCargos)).BeginInit();
            this.grCargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiOtrosCargosImpuestos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionImpuestos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteImpuestos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catproductospreciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catproveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiOtrosCargosTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionRemision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteRemision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFlete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "[F3] Buscar Productos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(971, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "DESCUENTO";
            // 
            // uiDescuento
            // 
            this.uiDescuento.DecimalPlaces = 2;
            this.uiDescuento.Enabled = false;
            this.uiDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDescuento.Location = new System.Drawing.Point(1088, 9);
            this.uiDescuento.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiDescuento.Name = "uiDescuento";
            this.uiDescuento.Size = new System.Drawing.Size(120, 26);
            this.uiDescuento.TabIndex = 7;
            this.uiDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(987, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "SUBTOTAL";
            // 
            // uiSubTotal
            // 
            this.uiSubTotal.DecimalPlaces = 2;
            this.uiSubTotal.Enabled = false;
            this.uiSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSubTotal.Location = new System.Drawing.Point(1088, 41);
            this.uiSubTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiSubTotal.Name = "uiSubTotal";
            this.uiSubTotal.Size = new System.Drawing.Size(120, 26);
            this.uiSubTotal.TabIndex = 9;
            this.uiSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uiImpuestos
            // 
            this.uiImpuestos.DecimalPlaces = 2;
            this.uiImpuestos.Enabled = false;
            this.uiImpuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiImpuestos.Location = new System.Drawing.Point(1088, 73);
            this.uiImpuestos.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiImpuestos.Name = "uiImpuestos";
            this.uiImpuestos.Size = new System.Drawing.Size(120, 26);
            this.uiImpuestos.TabIndex = 10;
            this.uiImpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(980, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "IMPUESTOS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1021, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "TOTAL";
            // 
            // uiTotal
            // 
            this.uiTotal.DecimalPlaces = 2;
            this.uiTotal.Enabled = false;
            this.uiTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal.Location = new System.Drawing.Point(1088, 180);
            this.uiTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiTotal.Name = "uiTotal";
            this.uiTotal.Size = new System.Drawing.Size(120, 26);
            this.uiTotal.TabIndex = 13;
            this.uiTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Código del Producto";
            // 
            // uiCodigoProducto
            // 
            this.uiCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCodigoProducto.Location = new System.Drawing.Point(14, 25);
            this.uiCodigoProducto.Name = "uiCodigoProducto";
            this.uiCodigoProducto.Size = new System.Drawing.Size(103, 22);
            this.uiCodigoProducto.TabIndex = 0;
            this.uiCodigoProducto.TextChanged += new System.EventHandler(this.uiCodigoProducto_TextChanged);
            this.uiCodigoProducto.VisibleChanged += new System.EventHandler(this.uiCodigoProducto_VisibleChanged);
            this.uiCodigoProducto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiCodigoProducto_KeyUp);
            this.uiCodigoProducto.Validated += new System.EventHandler(this.uiCodigoProducto_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Cantidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Descripción";
            // 
            // uiDescripcionProd
            // 
            this.uiDescripcionProd.Enabled = false;
            this.uiDescripcionProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDescripcionProd.Location = new System.Drawing.Point(254, 25);
            this.uiDescripcionProd.Name = "uiDescripcionProd";
            this.uiDescripcionProd.Size = new System.Drawing.Size(225, 22);
            this.uiDescripcionProd.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Precio Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.uiPorcDescVenta);
            this.groupBox1.Controls.Add(this.uiDescPartida);
            this.groupBox1.Controls.Add(this.uiDescTodaVenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 73);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descuentos";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "%";
            // 
            // uiPorcDescVenta
            // 
            this.uiPorcDescVenta.Enabled = false;
            this.uiPorcDescVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPorcDescVenta.Location = new System.Drawing.Point(180, 19);
            this.uiPorcDescVenta.Name = "uiPorcDescVenta";
            this.uiPorcDescVenta.Size = new System.Drawing.Size(74, 22);
            this.uiPorcDescVenta.TabIndex = 2;
            this.uiPorcDescVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiPorcDescVenta.ValueChanged += new System.EventHandler(this.uiPorcDescVenta_ValueChanged);
            // 
            // uiDescPartida
            // 
            this.uiDescPartida.AutoSize = true;
            this.uiDescPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDescPartida.Location = new System.Drawing.Point(20, 42);
            this.uiDescPartida.Name = "uiDescPartida";
            this.uiDescPartida.Size = new System.Drawing.Size(92, 20);
            this.uiDescPartida.TabIndex = 1;
            this.uiDescPartida.TabStop = true;
            this.uiDescPartida.Text = "Por partida";
            this.uiDescPartida.UseVisualStyleBackColor = true;
            this.uiDescPartida.CheckedChanged += new System.EventHandler(this.uiDescPartida_CheckedChanged);
            // 
            // uiDescTodaVenta
            // 
            this.uiDescTodaVenta.AutoSize = true;
            this.uiDescTodaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDescTodaVenta.Location = new System.Drawing.Point(20, 19);
            this.uiDescTodaVenta.Name = "uiDescTodaVenta";
            this.uiDescTodaVenta.Size = new System.Drawing.Size(122, 20);
            this.uiDescTodaVenta.TabIndex = 0;
            this.uiDescTodaVenta.TabStop = true;
            this.uiDescTodaVenta.Text = "En toda la venta";
            this.uiDescTodaVenta.UseVisualStyleBackColor = true;
            this.uiDescTodaVenta.CheckedChanged += new System.EventHandler(this.uiDescTodaVenta_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(582, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "% Descuento";
            // 
            // uiPorcDescPartida
            // 
            this.uiPorcDescPartida.Enabled = false;
            this.uiPorcDescPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPorcDescPartida.Location = new System.Drawing.Point(585, 25);
            this.uiPorcDescPartida.Name = "uiPorcDescPartida";
            this.uiPorcDescPartida.Size = new System.Drawing.Size(74, 22);
            this.uiPorcDescPartida.TabIndex = 3;
            this.uiPorcDescPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(181, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "[F4] Buscar Proveedores";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(10, 115);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(176, 36);
            this.btnCobrar.TabIndex = 31;
            this.btnCobrar.Text = "GUARDAR";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // uiTotalPartida
            // 
            this.uiTotalPartida.DecimalPlaces = 2;
            this.uiTotalPartida.Enabled = false;
            this.uiTotalPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalPartida.Location = new System.Drawing.Point(665, 25);
            this.uiTotalPartida.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiTotalPartida.Name = "uiTotalPartida";
            this.uiTotalPartida.Size = new System.Drawing.Size(96, 22);
            this.uiTotalPartida.TabIndex = 4;
            this.uiTotalPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(662, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Total Partida";
            // 
            // uiFotoProducto
            // 
            this.uiFotoProducto.Location = new System.Drawing.Point(17, 162);
            this.uiFotoProducto.Name = "uiFotoProducto";
            this.uiFotoProducto.Size = new System.Drawing.Size(77, 15);
            this.uiFotoProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiFotoProducto.TabIndex = 35;
            this.uiFotoProducto.TabStop = false;
            // 
            // uiGridProducto
            // 
            this.uiGridProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiGridProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partida,
            this.Clave,
            this.Descripcion,
            this.Cantidad,
            this.PrecioNeto,
            this.PrecioCompra,
            this.PorcImpuestos,
            this.Impuestos,
            this.PorcDescuento,
            this.MontoDescuento,
            this.Total});
            this.uiGridProducto.Location = new System.Drawing.Point(3, 0);
            this.uiGridProducto.Name = "uiGridProducto";
            this.uiGridProducto.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGridProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uiGridProducto.Size = new System.Drawing.Size(1325, 293);
            this.uiGridProducto.TabIndex = 4;
            this.uiGridProducto.DataSourceChanged += new System.EventHandler(this.uiGridProducto_DataSourceChanged);
            this.uiGridProducto.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.uiGridProducto_CellBeginEdit);
            this.uiGridProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridProducto_CellContentClick);
            this.uiGridProducto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridProducto_CellEndEdit);
            this.uiGridProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiGridProducto_KeyDown);
            this.uiGridProducto.Validating += new System.ComponentModel.CancelEventHandler(this.uiGridProducto_Validating);
            // 
            // partida
            // 
            this.partida.DataPropertyName = "partida";
            this.partida.HeaderText = "#";
            this.partida.Name = "partida";
            this.partida.ReadOnly = true;
            this.partida.Width = 50;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 430;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 80;
            // 
            // PrecioNeto
            // 
            this.PrecioNeto.DataPropertyName = "precioNeto";
            this.PrecioNeto.HeaderText = "Precio Neto";
            this.PrecioNeto.Name = "PrecioNeto";
            this.PrecioNeto.ReadOnly = true;
            this.PrecioNeto.Visible = false;
            this.PrecioNeto.Width = 90;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.DataPropertyName = "precioCompra";
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 90;
            // 
            // PorcImpuestos
            // 
            this.PorcImpuestos.DataPropertyName = "porcImpuestos";
            this.PorcImpuestos.HeaderText = "% Impuestos";
            this.PorcImpuestos.Name = "PorcImpuestos";
            this.PorcImpuestos.ReadOnly = true;
            this.PorcImpuestos.Width = 90;
            // 
            // Impuestos
            // 
            this.Impuestos.DataPropertyName = "impuestos";
            this.Impuestos.HeaderText = "Impuesto Tot.";
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.ReadOnly = true;
            this.Impuestos.Width = 90;
            // 
            // PorcDescuento
            // 
            this.PorcDescuento.DataPropertyName = "porcDescuento";
            this.PorcDescuento.HeaderText = "% Descuento";
            this.PorcDescuento.Name = "PorcDescuento";
            this.PorcDescuento.ReadOnly = true;
            this.PorcDescuento.Width = 90;
            // 
            // MontoDescuento
            // 
            this.MontoDescuento.DataPropertyName = "montoDescuento";
            this.MontoDescuento.HeaderText = "Descuento Tot.";
            this.MontoDescuento.Name = "MontoDescuento";
            this.MontoDescuento.ReadOnly = true;
            this.MontoDescuento.Width = 90;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.uiImprimir);
            this.panelSup.Controls.Add(this.label20);
            this.panelSup.Controls.Add(this.uiSucursal);
            this.panelSup.Controls.Add(this.label19);
            this.panelSup.Controls.Add(this.uiCancelarCompra);
            this.panelSup.Controls.Add(this.uiBuscarFolio);
            this.panelSup.Controls.Add(this.uiGrabada);
            this.panelSup.Controls.Add(this.uiAfectado);
            this.panelSup.Controls.Add(this.uiLimpiar);
            this.panelSup.Controls.Add(this.btnActualizarPrecio);
            this.panelSup.Controls.Add(this.uiFechaRemision);
            this.panelSup.Controls.Add(this.label18);
            this.panelSup.Controls.Add(this.uiRemision);
            this.panelSup.Controls.Add(this.label17);
            this.panelSup.Controls.Add(this.uiActivo);
            this.panelSup.Controls.Add(this.uiProductoCompraId);
            this.panelSup.Controls.Add(this.label1);
            this.panelSup.Controls.Add(this.uiNombreCliente);
            this.panelSup.Controls.Add(this.uiProveedorId);
            this.panelSup.Controls.Add(this.uiFolio);
            this.panelSup.Controls.Add(this.label2);
            this.panelSup.Controls.Add(this.label14);
            this.panelSup.Controls.Add(this.uiFecha);
            this.panelSup.Controls.Add(this.uiBuscarCliente);
            this.panelSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSup.Location = new System.Drawing.Point(0, 0);
            this.panelSup.Name = "panelSup";
            this.panelSup.Size = new System.Drawing.Size(1325, 106);
            this.panelSup.TabIndex = 36;
            // 
            // uiImprimir
            // 
            this.uiImprimir.Location = new System.Drawing.Point(1134, 9);
            this.uiImprimir.Name = "uiImprimir";
            this.uiImprimir.Size = new System.Drawing.Size(111, 41);
            this.uiImprimir.TabIndex = 58;
            this.uiImprimir.Text = "IMPRIMIR";
            this.uiImprimir.UseVisualStyleBackColor = true;
            this.uiImprimir.Click += new System.EventHandler(this.uiImprimir_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(13, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(171, 20);
            this.label20.TabIndex = 57;
            this.label20.Text = "Entrada por Compra";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.Enabled = false;
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(61, 37);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(162, 21);
            this.uiSucursal.TabIndex = 56;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "Sucursal";
            // 
            // uiCancelarCompra
            // 
            this.uiCancelarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCancelarCompra.Location = new System.Drawing.Point(1025, 52);
            this.uiCancelarCompra.Name = "uiCancelarCompra";
            this.uiCancelarCompra.Size = new System.Drawing.Size(109, 35);
            this.uiCancelarCompra.TabIndex = 54;
            this.uiCancelarCompra.Text = "CANCELAR COMPRA";
            this.uiCancelarCompra.UseVisualStyleBackColor = true;
            this.uiCancelarCompra.Click += new System.EventHandler(this.uiCancelarCompra_Click);
            // 
            // uiBuscarFolio
            // 
            this.uiBuscarFolio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiBuscarFolio.BackgroundImage")));
            this.uiBuscarFolio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiBuscarFolio.Location = new System.Drawing.Point(150, 62);
            this.uiBuscarFolio.Name = "uiBuscarFolio";
            this.uiBuscarFolio.Size = new System.Drawing.Size(34, 34);
            this.uiBuscarFolio.TabIndex = 53;
            this.uiBuscarFolio.UseVisualStyleBackColor = true;
            this.uiBuscarFolio.Click += new System.EventHandler(this.uiBuscarFolio_Click);
            // 
            // uiGrabada
            // 
            this.uiGrabada.AutoSize = true;
            this.uiGrabada.Enabled = false;
            this.uiGrabada.Location = new System.Drawing.Point(611, 39);
            this.uiGrabada.Name = "uiGrabada";
            this.uiGrabada.Size = new System.Drawing.Size(67, 17);
            this.uiGrabada.TabIndex = 52;
            this.uiGrabada.Text = "Grabada";
            this.uiGrabada.UseVisualStyleBackColor = true;
            // 
            // uiAfectado
            // 
            this.uiAfectado.AutoSize = true;
            this.uiAfectado.Enabled = false;
            this.uiAfectado.Location = new System.Drawing.Point(684, 39);
            this.uiAfectado.Name = "uiAfectado";
            this.uiAfectado.Size = new System.Drawing.Size(159, 17);
            this.uiAfectado.TabIndex = 51;
            this.uiAfectado.Text = "Afectado Precios/Inventario";
            this.uiAfectado.UseVisualStyleBackColor = true;
            // 
            // uiLimpiar
            // 
            this.uiLimpiar.Location = new System.Drawing.Point(1134, 52);
            this.uiLimpiar.Name = "uiLimpiar";
            this.uiLimpiar.Size = new System.Drawing.Size(111, 35);
            this.uiLimpiar.TabIndex = 49;
            this.uiLimpiar.Text = "LIMPIAR";
            this.uiLimpiar.UseVisualStyleBackColor = true;
            this.uiLimpiar.Click += new System.EventHandler(this.uiLimpiar_Click);
            // 
            // btnActualizarPrecio
            // 
            this.btnActualizarPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarPrecio.Location = new System.Drawing.Point(1025, 9);
            this.btnActualizarPrecio.Name = "btnActualizarPrecio";
            this.btnActualizarPrecio.Size = new System.Drawing.Size(109, 41);
            this.btnActualizarPrecio.TabIndex = 48;
            this.btnActualizarPrecio.Text = "AFECTAR LISTA DE PRECIOS/INVENTARIO";
            this.btnActualizarPrecio.UseVisualStyleBackColor = true;
            this.btnActualizarPrecio.Click += new System.EventHandler(this.btnActualizarPrecio_Click_1);
            // 
            // uiFechaRemision
            // 
            this.uiFechaRemision.Location = new System.Drawing.Point(815, 66);
            this.uiFechaRemision.Name = "uiFechaRemision";
            this.uiFechaRemision.Size = new System.Drawing.Size(200, 20);
            this.uiFechaRemision.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(731, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 46;
            this.label18.Text = "Fecha Remisión";
            // 
            // uiRemision
            // 
            this.uiRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiRemision.Location = new System.Drawing.Point(657, 65);
            this.uiRemision.Name = "uiRemision";
            this.uiRemision.Size = new System.Drawing.Size(70, 22);
            this.uiRemision.TabIndex = 2;
            this.uiRemision.TextChanged += new System.EventHandler(this.uiRemision_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(576, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Num Remisión";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // uiActivo
            // 
            this.uiActivo.AutoSize = true;
            this.uiActivo.Enabled = false;
            this.uiActivo.Location = new System.Drawing.Point(849, 39);
            this.uiActivo.Name = "uiActivo";
            this.uiActivo.Size = new System.Drawing.Size(77, 17);
            this.uiActivo.TabIndex = 43;
            this.uiActivo.Text = "Cancelada";
            this.uiActivo.UseVisualStyleBackColor = true;
            // 
            // uiProductoCompraId
            // 
            this.uiProductoCompraId.Location = new System.Drawing.Point(1170, 12);
            this.uiProductoCompraId.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiProductoCompraId.Name = "uiProductoCompraId";
            this.uiProductoCompraId.Size = new System.Drawing.Size(120, 20);
            this.uiProductoCompraId.TabIndex = 42;
            this.uiProductoCompraId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Folio";
            // 
            // uiNombreCliente
            // 
            this.uiNombreCliente.Enabled = false;
            this.uiNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNombreCliente.Location = new System.Drawing.Point(352, 65);
            this.uiNombreCliente.Name = "uiNombreCliente";
            this.uiNombreCliente.Size = new System.Drawing.Size(218, 22);
            this.uiNombreCliente.TabIndex = 1;
            // 
            // uiProveedorId
            // 
            this.uiProveedorId.Enabled = false;
            this.uiProveedorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiProveedorId.Location = new System.Drawing.Point(246, 65);
            this.uiProveedorId.Name = "uiProveedorId";
            this.uiProveedorId.Size = new System.Drawing.Size(60, 22);
            this.uiProveedorId.TabIndex = 38;
            // 
            // uiFolio
            // 
            this.uiFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFolio.Location = new System.Drawing.Point(61, 62);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(85, 22);
            this.uiFolio.TabIndex = 0;
            this.uiFolio.Validated += new System.EventHandler(this.uiFolio_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Fecha Captura";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(190, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Proveedor";
            // 
            // uiFecha
            // 
            this.uiFecha.Enabled = false;
            this.uiFecha.Location = new System.Drawing.Point(393, 37);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Size = new System.Drawing.Size(200, 20);
            this.uiFecha.TabIndex = 36;
            // 
            // uiBuscarCliente
            // 
            this.uiBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiBuscarCliente.BackgroundImage")));
            this.uiBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiBuscarCliente.Location = new System.Drawing.Point(312, 62);
            this.uiBuscarCliente.Name = "uiBuscarCliente";
            this.uiBuscarCliente.Size = new System.Drawing.Size(34, 34);
            this.uiBuscarCliente.TabIndex = 40;
            this.uiBuscarCliente.UseVisualStyleBackColor = true;
            this.uiBuscarCliente.Click += new System.EventHandler(this.uiBuscarCliente_Click_1);
            // 
            // uiPrecioConIVA
            // 
            this.uiPrecioConIVA.AutoSize = true;
            this.uiPrecioConIVA.Enabled = false;
            this.uiPrecioConIVA.Location = new System.Drawing.Point(17, 55);
            this.uiPrecioConIVA.Name = "uiPrecioConIVA";
            this.uiPrecioConIVA.Size = new System.Drawing.Size(102, 17);
            this.uiPrecioConIVA.TabIndex = 50;
            this.uiPrecioConIVA.Text = "Precios con IVA";
            this.uiPrecioConIVA.UseVisualStyleBackColor = true;
            this.uiPrecioConIVA.CheckedChanged += new System.EventHandler(this.uiPrecioConIVA_CheckedChanged);
            this.uiPrecioConIVA.Validating += new System.ComponentModel.CancelEventHandler(this.uiPrecioConIVA_Validating);
            this.uiPrecioConIVA.Validated += new System.EventHandler(this.uiPrecioConIVA_Validated);
            // 
            // panelCentro
            // 
            this.panelCentro.Controls.Add(this.groupBox1);
            this.panelCentro.Controls.Add(this.uiGridProducto);
            this.panelCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentro.Location = new System.Drawing.Point(0, 106);
            this.panelCentro.Name = "panelCentro";
            this.panelCentro.Size = new System.Drawing.Size(1325, 532);
            this.panelCentro.TabIndex = 37;
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.uiAgregarIVA);
            this.panelInferior.Controls.Add(this.uiPrecioUnitario);
            this.panelInferior.Controls.Add(this.uiCantidad);
            this.panelInferior.Controls.Add(this.uiImpuestosOtros);
            this.panelInferior.Controls.Add(this.label28);
            this.panelInferior.Controls.Add(this.uiTotalOtros);
            this.panelInferior.Controls.Add(this.uiComisionesTotal2);
            this.panelInferior.Controls.Add(this.label26);
            this.panelInferior.Controls.Add(this.uiFleteTotal2);
            this.panelInferior.Controls.Add(this.label25);
            this.panelInferior.Controls.Add(this.grCargos);
            this.panelInferior.Controls.Add(this.uiDescripcionProd);
            this.panelInferior.Controls.Add(this.uiPrecioConIVA);
            this.panelInferior.Controls.Add(this.label3);
            this.panelInferior.Controls.Add(this.label4);
            this.panelInferior.Controls.Add(this.uiFotoProducto);
            this.panelInferior.Controls.Add(this.uiDescuento);
            this.panelInferior.Controls.Add(this.label16);
            this.panelInferior.Controls.Add(this.label5);
            this.panelInferior.Controls.Add(this.uiTotalPartida);
            this.panelInferior.Controls.Add(this.uiSubTotal);
            this.panelInferior.Controls.Add(this.btnCobrar);
            this.panelInferior.Controls.Add(this.uiImpuestos);
            this.panelInferior.Controls.Add(this.label15);
            this.panelInferior.Controls.Add(this.label6);
            this.panelInferior.Controls.Add(this.label13);
            this.panelInferior.Controls.Add(this.label7);
            this.panelInferior.Controls.Add(this.uiPorcDescPartida);
            this.panelInferior.Controls.Add(this.uiTotal);
            this.panelInferior.Controls.Add(this.label8);
            this.panelInferior.Controls.Add(this.label11);
            this.panelInferior.Controls.Add(this.uiCodigoProducto);
            this.panelInferior.Controls.Add(this.label9);
            this.panelInferior.Controls.Add(this.label10);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 405);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1325, 233);
            this.panelInferior.TabIndex = 38;
            // 
            // uiAgregarIVA
            // 
            this.uiAgregarIVA.AutoSize = true;
            this.uiAgregarIVA.Checked = true;
            this.uiAgregarIVA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiAgregarIVA.Location = new System.Drawing.Point(17, 84);
            this.uiAgregarIVA.Name = "uiAgregarIVA";
            this.uiAgregarIVA.Size = new System.Drawing.Size(163, 17);
            this.uiAgregarIVA.TabIndex = 59;
            this.uiAgregarIVA.Text = "Agregar IVA a precio Compra";
            this.uiAgregarIVA.UseVisualStyleBackColor = true;
            // 
            // uiPrecioUnitario
            // 
            this.uiPrecioUnitario.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiPrecioUnitario.Location = new System.Drawing.Point(481, 29);
            this.uiPrecioUnitario.Name = "uiPrecioUnitario";
            this.uiPrecioUnitario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiPrecioUnitario.Properties.DisplayFormat.FormatString = "c2";
            this.uiPrecioUnitario.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiPrecioUnitario.Properties.EditFormat.FormatString = "c2";
            this.uiPrecioUnitario.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiPrecioUnitario.Size = new System.Drawing.Size(100, 20);
            this.uiPrecioUnitario.TabIndex = 2;
            this.uiPrecioUnitario.ValueChanged += new System.EventHandler(this.uiPrecioUnitario_ValueChanged);
            this.uiPrecioUnitario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiPrecioUnitario_KeyUp);
            // 
            // uiCantidad
            // 
            this.uiCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiCantidad.Location = new System.Drawing.Point(123, 28);
            this.uiCantidad.Name = "uiCantidad";
            this.uiCantidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCantidad.Properties.DisplayFormat.FormatString = "n4";
            this.uiCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Properties.EditFormat.FormatString = "n4";
            this.uiCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Size = new System.Drawing.Size(113, 20);
            this.uiCantidad.TabIndex = 1;
            this.uiCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiCantidad_KeyUp);
            // 
            // uiImpuestosOtros
            // 
            this.uiImpuestosOtros.DecimalPlaces = 2;
            this.uiImpuestosOtros.Enabled = false;
            this.uiImpuestosOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiImpuestosOtros.Location = new System.Drawing.Point(1088, 140);
            this.uiImpuestosOtros.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiImpuestosOtros.Name = "uiImpuestosOtros";
            this.uiImpuestosOtros.Size = new System.Drawing.Size(120, 26);
            this.uiImpuestosOtros.TabIndex = 57;
            this.uiImpuestosOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(980, 144);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 20);
            this.label28.TabIndex = 58;
            this.label28.Text = "IMP. OTROS";
            // 
            // uiTotalOtros
            // 
            this.uiTotalOtros.DecimalPlaces = 2;
            this.uiTotalOtros.Enabled = false;
            this.uiTotalOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalOtros.Location = new System.Drawing.Point(1088, 108);
            this.uiTotalOtros.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiTotalOtros.Name = "uiTotalOtros";
            this.uiTotalOtros.Size = new System.Drawing.Size(120, 26);
            this.uiTotalOtros.TabIndex = 56;
            this.uiTotalOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uiComisionesTotal2
            // 
            this.uiComisionesTotal2.DecimalPlaces = 2;
            this.uiComisionesTotal2.Enabled = false;
            this.uiComisionesTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiComisionesTotal2.Location = new System.Drawing.Point(1235, 139);
            this.uiComisionesTotal2.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiComisionesTotal2.Name = "uiComisionesTotal2";
            this.uiComisionesTotal2.Size = new System.Drawing.Size(78, 26);
            this.uiComisionesTotal2.TabIndex = 55;
            this.uiComisionesTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiComisionesTotal2.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(1015, 110);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 20);
            this.label26.TabIndex = 54;
            this.label26.Text = "OTROS";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // uiFleteTotal2
            // 
            this.uiFleteTotal2.DecimalPlaces = 2;
            this.uiFleteTotal2.Enabled = false;
            this.uiFleteTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFleteTotal2.Location = new System.Drawing.Point(1235, 108);
            this.uiFleteTotal2.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiFleteTotal2.Name = "uiFleteTotal2";
            this.uiFleteTotal2.Size = new System.Drawing.Size(78, 26);
            this.uiFleteTotal2.TabIndex = 53;
            this.uiFleteTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uiFleteTotal2.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(1231, 63);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 20);
            this.label25.TabIndex = 52;
            this.label25.Text = "FLETE";
            this.label25.Visible = false;
            // 
            // grCargos
            // 
            this.grCargos.Controls.Add(this.uiOtrosCargosImpuestos);
            this.grCargos.Controls.Add(this.uiComisionImpuestos);
            this.grCargos.Controls.Add(this.uiFleteImpuestos);
            this.grCargos.Controls.Add(this.label27);
            this.grCargos.Controls.Add(this.uiComisionProveedor);
            this.grCargos.Controls.Add(this.label24);
            this.grCargos.Controls.Add(this.uiFleteProveedor);
            this.grCargos.Controls.Add(this.uiOtrosCargosTotal);
            this.grCargos.Controls.Add(this.uiComisionFecha);
            this.grCargos.Controls.Add(this.uiFleteFecha);
            this.grCargos.Controls.Add(this.label23);
            this.grCargos.Controls.Add(this.uiComisionRemision);
            this.grCargos.Controls.Add(this.label22);
            this.grCargos.Controls.Add(this.uiFleteRemision);
            this.grCargos.Controls.Add(this.label21);
            this.grCargos.Controls.Add(this.uiComisionTotal);
            this.grCargos.Controls.Add(this.uiFleteTotal);
            this.grCargos.Controls.Add(this.uiComision);
            this.grCargos.Controls.Add(this.uiFlete);
            this.grCargos.Location = new System.Drawing.Point(192, 63);
            this.grCargos.Name = "grCargos";
            this.grCargos.Size = new System.Drawing.Size(771, 158);
            this.grCargos.TabIndex = 51;
            this.grCargos.Text = "Otros Cargos";
            // 
            // uiOtrosCargosImpuestos
            // 
            this.uiOtrosCargosImpuestos.Enabled = false;
            this.uiOtrosCargosImpuestos.Location = new System.Drawing.Point(508, 113);
            this.uiOtrosCargosImpuestos.Name = "uiOtrosCargosImpuestos";
            this.uiOtrosCargosImpuestos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOtrosCargosImpuestos.Properties.Appearance.Options.UseFont = true;
            this.uiOtrosCargosImpuestos.Properties.DisplayFormat.FormatString = "c2";
            this.uiOtrosCargosImpuestos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiOtrosCargosImpuestos.Properties.EditFormat.FormatString = "c2";
            this.uiOtrosCargosImpuestos.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiOtrosCargosImpuestos.Size = new System.Drawing.Size(88, 20);
            this.uiOtrosCargosImpuestos.TabIndex = 18;
            // 
            // uiComisionImpuestos
            // 
            this.uiComisionImpuestos.Enabled = false;
            this.uiComisionImpuestos.Location = new System.Drawing.Point(508, 83);
            this.uiComisionImpuestos.Name = "uiComisionImpuestos";
            this.uiComisionImpuestos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiComisionImpuestos.Properties.DisplayFormat.FormatString = "c2";
            this.uiComisionImpuestos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiComisionImpuestos.Properties.EditFormat.FormatString = "c2";
            this.uiComisionImpuestos.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiComisionImpuestos.Size = new System.Drawing.Size(88, 20);
            this.uiComisionImpuestos.TabIndex = 17;
            // 
            // uiFleteImpuestos
            // 
            this.uiFleteImpuestos.Enabled = false;
            this.uiFleteImpuestos.Location = new System.Drawing.Point(509, 49);
            this.uiFleteImpuestos.Name = "uiFleteImpuestos";
            this.uiFleteImpuestos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFleteImpuestos.Properties.DisplayFormat.FormatString = "c2";
            this.uiFleteImpuestos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiFleteImpuestos.Properties.EditFormat.FormatString = "c2";
            this.uiFleteImpuestos.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiFleteImpuestos.Size = new System.Drawing.Size(88, 20);
            this.uiFleteImpuestos.TabIndex = 16;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(507, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 15;
            this.label27.Text = "Impuestos";
            // 
            // uiComisionProveedor
            // 
            this.uiComisionProveedor.Enabled = false;
            this.uiComisionProveedor.Location = new System.Drawing.Point(120, 84);
            this.uiComisionProveedor.Name = "uiComisionProveedor";
            this.uiComisionProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiComisionProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RFC", "RFC"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.uiComisionProveedor.Properties.DataSource = this.catproductospreciosBindingSource;
            this.uiComisionProveedor.Properties.DisplayMember = "Nombre";
            this.uiComisionProveedor.Properties.NullText = "(Selecciona un Proveedor)";
            this.uiComisionProveedor.Properties.ValueMember = "ProveedorId";
            this.uiComisionProveedor.Size = new System.Drawing.Size(203, 20);
            this.uiComisionProveedor.TabIndex = 14;
            // 
            // catproductospreciosBindingSource
            // 
            this.catproductospreciosBindingSource.DataSource = typeof(ConexionBD.cat_productos_precios);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(118, 29);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 13);
            this.label24.TabIndex = 13;
            this.label24.Text = "Proveedor";
            // 
            // uiFleteProveedor
            // 
            this.uiFleteProveedor.Enabled = false;
            this.uiFleteProveedor.Location = new System.Drawing.Point(120, 48);
            this.uiFleteProveedor.Name = "uiFleteProveedor";
            this.uiFleteProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFleteProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RFC", "RFC"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.uiFleteProveedor.Properties.DataSource = this.catproveedoresBindingSource;
            this.uiFleteProveedor.Properties.DisplayMember = "Nombre";
            this.uiFleteProveedor.Properties.NullText = "(Selecciona un proveedor)";
            this.uiFleteProveedor.Properties.ValueMember = "ProveedorId";
            this.uiFleteProveedor.Size = new System.Drawing.Size(203, 20);
            this.uiFleteProveedor.TabIndex = 12;
            // 
            // catproveedoresBindingSource
            // 
            this.catproveedoresBindingSource.DataSource = typeof(ConexionBD.cat_proveedores);
            // 
            // uiOtrosCargosTotal
            // 
            this.uiOtrosCargosTotal.Enabled = false;
            this.uiOtrosCargosTotal.Location = new System.Drawing.Point(606, 113);
            this.uiOtrosCargosTotal.Name = "uiOtrosCargosTotal";
            this.uiOtrosCargosTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOtrosCargosTotal.Properties.Appearance.Options.UseFont = true;
            this.uiOtrosCargosTotal.Properties.DisplayFormat.FormatString = "c2";
            this.uiOtrosCargosTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiOtrosCargosTotal.Properties.EditFormat.FormatString = "c2";
            this.uiOtrosCargosTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiOtrosCargosTotal.Size = new System.Drawing.Size(88, 20);
            this.uiOtrosCargosTotal.TabIndex = 11;
            this.uiOtrosCargosTotal.EditValueChanged += new System.EventHandler(this.uiOtrosCargosTotal_EditValueChanged);
            // 
            // uiComisionFecha
            // 
            this.uiComisionFecha.EditValue = null;
            this.uiComisionFecha.Enabled = false;
            this.uiComisionFecha.Location = new System.Drawing.Point(325, 83);
            this.uiComisionFecha.Name = "uiComisionFecha";
            this.uiComisionFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiComisionFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiComisionFecha.Size = new System.Drawing.Size(100, 20);
            this.uiComisionFecha.TabIndex = 10;
            // 
            // uiFleteFecha
            // 
            this.uiFleteFecha.EditValue = null;
            this.uiFleteFecha.Enabled = false;
            this.uiFleteFecha.Location = new System.Drawing.Point(325, 48);
            this.uiFleteFecha.Name = "uiFleteFecha";
            this.uiFleteFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFleteFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFleteFecha.Size = new System.Drawing.Size(100, 20);
            this.uiFleteFecha.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(322, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Fecha";
            // 
            // uiComisionRemision
            // 
            this.uiComisionRemision.Enabled = false;
            this.uiComisionRemision.Location = new System.Drawing.Point(429, 83);
            this.uiComisionRemision.Name = "uiComisionRemision";
            this.uiComisionRemision.Size = new System.Drawing.Size(73, 20);
            this.uiComisionRemision.TabIndex = 7;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(428, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Remisión";
            // 
            // uiFleteRemision
            // 
            this.uiFleteRemision.Enabled = false;
            this.uiFleteRemision.Location = new System.Drawing.Point(430, 48);
            this.uiFleteRemision.Name = "uiFleteRemision";
            this.uiFleteRemision.Size = new System.Drawing.Size(73, 20);
            this.uiFleteRemision.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(654, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Total";
            // 
            // uiComisionTotal
            // 
            this.uiComisionTotal.Enabled = false;
            this.uiComisionTotal.Location = new System.Drawing.Point(606, 83);
            this.uiComisionTotal.Name = "uiComisionTotal";
            this.uiComisionTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiComisionTotal.Properties.DisplayFormat.FormatString = "c2";
            this.uiComisionTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiComisionTotal.Properties.EditFormat.FormatString = "c2";
            this.uiComisionTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiComisionTotal.Size = new System.Drawing.Size(88, 20);
            this.uiComisionTotal.TabIndex = 3;
            this.uiComisionTotal.ValueChanged += new System.EventHandler(this.uiComisionTotal_ValueChanged);
            this.uiComisionTotal.Leave += new System.EventHandler(this.uiComisionTotal_Leave);
            // 
            // uiFleteTotal
            // 
            this.uiFleteTotal.Enabled = false;
            this.uiFleteTotal.Location = new System.Drawing.Point(606, 49);
            this.uiFleteTotal.Name = "uiFleteTotal";
            this.uiFleteTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFleteTotal.Properties.DisplayFormat.FormatString = "c2";
            this.uiFleteTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiFleteTotal.Properties.EditFormat.FormatString = "c2";
            this.uiFleteTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiFleteTotal.Size = new System.Drawing.Size(88, 20);
            this.uiFleteTotal.TabIndex = 2;
            this.uiFleteTotal.ValueChanged += new System.EventHandler(this.uiFleteTotal_ValueChanged);
            this.uiFleteTotal.Leave += new System.EventHandler(this.uiFleteTotal_Leave);
            // 
            // uiComision
            // 
            this.uiComision.Location = new System.Drawing.Point(6, 85);
            this.uiComision.Name = "uiComision";
            this.uiComision.Properties.Caption = "Otras comisiones";
            this.uiComision.Size = new System.Drawing.Size(109, 19);
            this.uiComision.TabIndex = 1;
            this.uiComision.CheckedChanged += new System.EventHandler(this.uiComision_CheckedChanged);
            // 
            // uiFlete
            // 
            this.uiFlete.Location = new System.Drawing.Point(6, 49);
            this.uiFlete.Name = "uiFlete";
            this.uiFlete.Properties.Caption = "Flete";
            this.uiFlete.Size = new System.Drawing.Size(75, 19);
            this.uiFlete.TabIndex = 0;
            this.uiFlete.CheckedChanged += new System.EventHandler(this.uiFlete_CheckedChanged);
            // 
            // frmProductosCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 638);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelCentro);
            this.Controls.Add(this.panelSup);
            this.KeyPreview = true;
            this.Name = "frmProductosCompra";
            this.Text = "Entrada por Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPuntoVenta_FormClosing);
            this.Load += new System.EventHandler(this.frmPuntoVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPuntoVenta_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.uiDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescPartida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalPartida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFotoProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridProducto)).EndInit();
            this.panelSup.ResumeLayout(false);
            this.panelSup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProductoCompraId)).EndInit();
            this.panelCentro.ResumeLayout(false);
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioUnitario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestosOtros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalOtros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionesTotal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteTotal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCargos)).EndInit();
            this.grCargos.ResumeLayout(false);
            this.grCargos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiOtrosCargosImpuestos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionImpuestos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteImpuestos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catproductospreciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catproveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiOtrosCargosTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionRemision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteRemision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComisionTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFleteTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiComision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFlete.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown uiDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown uiSubTotal;
        private System.Windows.Forms.NumericUpDown uiImpuestos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown uiTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uiCodigoProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox uiDescripcionProd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown uiPorcDescVenta;
        private System.Windows.Forms.RadioButton uiDescPartida;
        private System.Windows.Forms.RadioButton uiDescTodaVenta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown uiPorcDescPartida;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.NumericUpDown uiTotalPartida;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox uiFotoProducto;
        private System.Windows.Forms.DataGridView uiGridProducto;
        private System.Windows.Forms.Panel panelSup;
        private System.Windows.Forms.Panel panelCentro;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiNombreCliente;
        private System.Windows.Forms.TextBox uiProveedorId;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker uiFecha;
        private System.Windows.Forms.Button uiBuscarCliente;
        private System.Windows.Forms.NumericUpDown uiProductoCompraId;
        private System.Windows.Forms.CheckBox uiActivo;
        private System.Windows.Forms.DateTimePicker uiFechaRemision;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox uiRemision;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnActualizarPrecio;
        private System.Windows.Forms.Button uiLimpiar;
        private System.Windows.Forms.CheckBox uiPrecioConIVA;
        private System.Windows.Forms.CheckBox uiGrabada;
        private System.Windows.Forms.CheckBox uiAfectado;
        private System.Windows.Forms.Button uiBuscarFolio;
        private System.Windows.Forms.Button uiCancelarCompra;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button uiImprimir;
        private DevExpress.XtraEditors.GroupControl grCargos;
        private DevExpress.XtraEditors.CheckEdit uiComision;
        private DevExpress.XtraEditors.CheckEdit uiFlete;
        private DevExpress.XtraEditors.CalcEdit uiOtrosCargosTotal;
        private DevExpress.XtraEditors.DateEdit uiComisionFecha;
        private DevExpress.XtraEditors.DateEdit uiFleteFecha;
        private System.Windows.Forms.Label label23;
        private DevExpress.XtraEditors.TextEdit uiComisionRemision;
        private System.Windows.Forms.Label label22;
        private DevExpress.XtraEditors.TextEdit uiFleteRemision;
        private System.Windows.Forms.Label label21;
        private DevExpress.XtraEditors.CalcEdit uiComisionTotal;
        private DevExpress.XtraEditors.CalcEdit uiFleteTotal;
        private DevExpress.XtraEditors.LookUpEdit uiComisionProveedor;
        private System.Windows.Forms.Label label24;
        private DevExpress.XtraEditors.LookUpEdit uiFleteProveedor;
        private System.Windows.Forms.BindingSource catproductospreciosBindingSource;
        private System.Windows.Forms.BindingSource catproveedoresBindingSource;
        private System.Windows.Forms.NumericUpDown uiComisionesTotal2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown uiFleteTotal2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown uiTotalOtros;
        private DevExpress.XtraEditors.CalcEdit uiOtrosCargosImpuestos;
        private DevExpress.XtraEditors.CalcEdit uiComisionImpuestos;
        private DevExpress.XtraEditors.CalcEdit uiFleteImpuestos;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown uiImpuestosOtros;
        private System.Windows.Forms.Label label28;
        private DevExpress.XtraEditors.SpinEdit uiCantidad;
        private DevExpress.XtraEditors.SpinEdit uiPrecioUnitario;
        private System.Windows.Forms.CheckBox uiAgregarIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcImpuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}