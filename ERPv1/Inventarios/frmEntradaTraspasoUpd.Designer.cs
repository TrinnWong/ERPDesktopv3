namespace ERPv1.Inventarios
{
    partial class frmEntradaTraspasoUpd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.uiPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.uiCancelado = new System.Windows.Forms.CheckBox();
            this.uiFechaCancelacion = new System.Windows.Forms.DateTimePicker();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.uiCargadoInv = new System.Windows.Forms.CheckBox();
            this.uiGuardado = new System.Windows.Forms.CheckBox();
            this.uiSucursalOrigen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiCantidad = new DevExpress.XtraEditors.SpinEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.uiAgregar = new System.Windows.Forms.Button();
            this.uiDescProducto = new System.Windows.Forms.TextBox();
            this.uiClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSucursalDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiAutorizar = new System.Windows.Forms.Button();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.uiImprimir = new System.Windows.Forms.Button();
            this.btnMovimiento = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioUnitario)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.uiImprimir);
            this.panelSup.Controls.Add(this.uiCancelar);
            this.panelSup.Controls.Add(this.uiAutorizar);
            this.panelSup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelSup.Size = new System.Drawing.Size(1491, 44);
            this.panelSup.Controls.SetChildIndex(this.uiGuardar, 0);
            this.panelSup.Controls.SetChildIndex(this.button1, 0);
            this.panelSup.Controls.SetChildIndex(this.uiAutorizar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiCancelar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiImprimir, 0);
            // 
            // button1
            // 
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMovimiento);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.uiPrecioUnitario);
            this.panel1.Controls.Add(this.uiCancelado);
            this.panel1.Controls.Add(this.uiFechaCancelacion);
            this.panel1.Controls.Add(this.lblPrecio);
            this.panel1.Controls.Add(this.uiCargadoInv);
            this.panel1.Controls.Add(this.uiGuardado);
            this.panel1.Controls.Add(this.uiSucursalOrigen);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblTituloForm);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.uiSucursalDestino);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.uiFecha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.uiFolio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1491, 135);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(28, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(67, 18);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "lblTitulo";
            // 
            // uiPrecioUnitario
            // 
            this.uiPrecioUnitario.DecimalPlaces = 2;
            this.uiPrecioUnitario.Enabled = false;
            this.uiPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiPrecioUnitario.Location = new System.Drawing.Point(1208, -9);
            this.uiPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiPrecioUnitario.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiPrecioUnitario.Name = "uiPrecioUnitario";
            this.uiPrecioUnitario.Size = new System.Drawing.Size(128, 26);
            this.uiPrecioUnitario.TabIndex = 22;
            this.uiPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uiCancelado
            // 
            this.uiCancelado.AutoSize = true;
            this.uiCancelado.Enabled = false;
            this.uiCancelado.Location = new System.Drawing.Point(1071, 98);
            this.uiCancelado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiCancelado.Name = "uiCancelado";
            this.uiCancelado.Size = new System.Drawing.Size(97, 21);
            this.uiCancelado.TabIndex = 12;
            this.uiCancelado.Text = "Cancelado";
            this.uiCancelado.UseVisualStyleBackColor = true;
            // 
            // uiFechaCancelacion
            // 
            this.uiFechaCancelacion.Enabled = false;
            this.uiFechaCancelacion.Location = new System.Drawing.Point(1208, 98);
            this.uiFechaCancelacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiFechaCancelacion.Name = "uiFechaCancelacion";
            this.uiFechaCancelacion.Size = new System.Drawing.Size(265, 22);
            this.uiFechaCancelacion.TabIndex = 13;
            this.uiFechaCancelacion.Visible = false;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Enabled = false;
            this.lblPrecio.Location = new System.Drawing.Point(1151, 7);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(48, 17);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio";
            // 
            // uiCargadoInv
            // 
            this.uiCargadoInv.AutoSize = true;
            this.uiCargadoInv.Enabled = false;
            this.uiCargadoInv.Location = new System.Drawing.Point(833, 98);
            this.uiCargadoInv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiCargadoInv.Name = "uiCargadoInv";
            this.uiCargadoInv.Size = new System.Drawing.Size(118, 21);
            this.uiCargadoInv.TabIndex = 11;
            this.uiCargadoInv.Text = "Cargado a Inv";
            this.uiCargadoInv.UseVisualStyleBackColor = true;
            // 
            // uiGuardado
            // 
            this.uiGuardado.AutoSize = true;
            this.uiGuardado.Enabled = false;
            this.uiGuardado.Location = new System.Drawing.Point(965, 98);
            this.uiGuardado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiGuardado.Name = "uiGuardado";
            this.uiGuardado.Size = new System.Drawing.Size(94, 21);
            this.uiGuardado.TabIndex = 10;
            this.uiGuardado.Text = "Guardado";
            this.uiGuardado.UseVisualStyleBackColor = true;
            // 
            // uiSucursalOrigen
            // 
            this.uiSucursalOrigen.DisplayMember = "NombreSucursal";
            this.uiSucursalOrigen.FormattingEnabled = true;
            this.uiSucursalOrigen.Location = new System.Drawing.Point(633, 32);
            this.uiSucursalOrigen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiSucursalOrigen.Name = "uiSucursalOrigen";
            this.uiSucursalOrigen.Size = new System.Drawing.Size(265, 24);
            this.uiSucursalOrigen.TabIndex = 2;
            this.uiSucursalOrigen.ValueMember = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(571, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Origen";
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.Location = new System.Drawing.Point(16, 4);
            this.lblTituloForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(0, 25);
            this.lblTituloForm.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiCantidad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.uiAgregar);
            this.groupBox1.Controls.Add(this.uiDescProducto);
            this.groupBox1.Controls.Add(this.uiClave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(805, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captura";
            // 
            // uiCantidad
            // 
            this.uiCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiCantidad.Location = new System.Drawing.Point(468, 21);
            this.uiCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiCantidad.Name = "uiCantidad";
            this.uiCantidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCantidad.Properties.DisplayFormat.FormatString = "n4";
            this.uiCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Properties.EditFormat.FormatString = "n4";
            this.uiCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Size = new System.Drawing.Size(133, 22);
            this.uiCantidad.TabIndex = 1;
            this.uiCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiCantidad_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Cantidad";
            // 
            // uiAgregar
            // 
            this.uiAgregar.Location = new System.Drawing.Point(628, 18);
            this.uiAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiAgregar.Name = "uiAgregar";
            this.uiAgregar.Size = new System.Drawing.Size(129, 38);
            this.uiAgregar.TabIndex = 3;
            this.uiAgregar.Text = "AGREGAR";
            this.uiAgregar.UseVisualStyleBackColor = true;
            this.uiAgregar.Click += new System.EventHandler(this.uiAgregar_Click);
            // 
            // uiDescProducto
            // 
            this.uiDescProducto.Enabled = false;
            this.uiDescProducto.Location = new System.Drawing.Point(169, 16);
            this.uiDescProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiDescProducto.Name = "uiDescProducto";
            this.uiDescProducto.Size = new System.Drawing.Size(199, 22);
            this.uiDescProducto.TabIndex = 1;
            // 
            // uiClave
            // 
            this.uiClave.Location = new System.Drawing.Point(68, 16);
            this.uiClave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiClave.Name = "uiClave";
            this.uiClave.Size = new System.Drawing.Size(92, 22);
            this.uiClave.TabIndex = 0;
            this.uiClave.Validating += new System.ComponentModel.CancelEventHandler(this.uiClave_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Clave";
            // 
            // uiSucursalDestino
            // 
            this.uiSucursalDestino.DisplayMember = "NombreSucursal";
            this.uiSucursalDestino.FormattingEnabled = true;
            this.uiSucursalDestino.Location = new System.Drawing.Point(991, 32);
            this.uiSucursalDestino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiSucursalDestino.Name = "uiSucursalDestino";
            this.uiSucursalDestino.Size = new System.Drawing.Size(265, 24);
            this.uiSucursalDestino.TabIndex = 3;
            this.uiSucursalDestino.ValueMember = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(928, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destino";
            // 
            // uiFecha
            // 
            this.uiFecha.Location = new System.Drawing.Point(279, 32);
            this.uiFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Size = new System.Drawing.Size(265, 22);
            this.uiFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // uiFolio
            // 
            this.uiFolio.Enabled = false;
            this.uiFolio.Location = new System.Drawing.Point(75, 32);
            this.uiFolio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(132, 22);
            this.uiFolio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1491, 296);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 234);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1491, 62);
            this.panel3.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 15);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "[F3-Buscar Producto]";
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partida,
            this.Clave,
            this.Descripcion,
            this.Unidad,
            this.Cantidad,
            this.Precio});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RowHeadersWidth = 51;
            this.uiGrid.Size = new System.Drawing.Size(1491, 296);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellContentClick);
            this.uiGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiGrid_KeyDown);
            // 
            // Partida
            // 
            this.Partida.DataPropertyName = "partida";
            this.Partida.HeaderText = "#";
            this.Partida.MinimumWidth = 6;
            this.Partida.Name = "Partida";
            this.Partida.ReadOnly = true;
            this.Partida.Width = 125;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.MinimumWidth = 6;
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidadMov";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 125;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "precioCompra";
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Visible = false;
            this.Precio.Width = 125;
            // 
            // uiAutorizar
            // 
            this.uiAutorizar.Location = new System.Drawing.Point(283, 4);
            this.uiAutorizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiAutorizar.Name = "uiAutorizar";
            this.uiAutorizar.Size = new System.Drawing.Size(136, 38);
            this.uiAutorizar.TabIndex = 2;
            this.uiAutorizar.Text = "AUTORIZAR";
            this.uiAutorizar.UseVisualStyleBackColor = true;
            this.uiAutorizar.Click += new System.EventHandler(this.uiAutorizar_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(420, 4);
            this.uiCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(136, 38);
            this.uiCancelar.TabIndex = 3;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiImprimir
            // 
            this.uiImprimir.Location = new System.Drawing.Point(557, 4);
            this.uiImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uiImprimir.Name = "uiImprimir";
            this.uiImprimir.Size = new System.Drawing.Size(136, 38);
            this.uiImprimir.TabIndex = 4;
            this.uiImprimir.Text = "IMPRIMIR";
            this.uiImprimir.UseVisualStyleBackColor = true;
            this.uiImprimir.Click += new System.EventHandler(this.uiImprimir_Click);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Location = new System.Drawing.Point(1260, 33);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(140, 23);
            this.btnMovimiento.TabIndex = 23;
            this.btnMovimiento.Text = "Exstencias";
            this.btnMovimiento.UseVisualStyleBackColor = true;
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // frmEntradaTraspasoUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 475);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmEntradaTraspasoUpd";
            this.Text = "Salida Traspaso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalidaTraspasoUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmSalidaTraspasoUpd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntradaTraspasoUpd_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEntradaTraspasoUpd_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntradaTraspasoUpd_KeyUp);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panelSup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioUnitario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiAutorizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox uiSucursalDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker uiFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiAgregar;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox uiDescProducto;
        private System.Windows.Forms.TextBox uiClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.ComboBox uiSucursalOrigen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox uiCargadoInv;
        private System.Windows.Forms.CheckBox uiGuardado;
        private System.Windows.Forms.Button uiCancelar;
        private System.Windows.Forms.DateTimePicker uiFechaCancelacion;
        private System.Windows.Forms.CheckBox uiCancelado;
        private System.Windows.Forms.Button uiImprimir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uiPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private DevExpress.XtraEditors.SpinEdit uiCantidad;
        private System.Windows.Forms.Button btnMovimiento;
    }
}