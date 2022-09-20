namespace ERP.Common.Forms
{
    partial class frmApartadosUpd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApartadosUpd));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiAgregarAnticipo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.uiAnticipo = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiBuscarCliente = new System.Windows.Forms.Button();
            this.uiAgregarProducto = new System.Windows.Forms.Button();
            this.uiCantidad = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.uiProductoDesc = new System.Windows.Forms.TextBox();
            this.uiProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uiClienteNombre = new System.Windows.Forms.TextBox();
            this.uiCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiSaldo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.uiTotal = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPagos = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAnticipo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.uiPagos);
            this.panelSup.Size = new System.Drawing.Size(1264, 36);
            this.panelSup.Controls.SetChildIndex(this.uiGuardar, 0);
            this.panelSup.Controls.SetChildIndex(this.button1, 0);
            this.panelSup.Controls.SetChildIndex(this.uiPagos, 0);
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
            this.panel1.Controls.Add(this.uiAgregarAnticipo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.uiAnticipo);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.uiFecha);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uiFolio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 150);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // uiAgregarAnticipo
            // 
            this.uiAgregarAnticipo.Location = new System.Drawing.Point(822, 91);
            this.uiAgregarAnticipo.Name = "uiAgregarAnticipo";
            this.uiAgregarAnticipo.Size = new System.Drawing.Size(200, 40);
            this.uiAgregarAnticipo.TabIndex = 9;
            this.uiAgregarAnticipo.Text = "AGREGAR ANTICIPO";
            this.uiAgregarAnticipo.UseVisualStyleBackColor = true;
            this.uiAgregarAnticipo.Click += new System.EventHandler(this.uiAgregarAnticipo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(630, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Anticipo de";
            // 
            // uiAnticipo
            // 
            this.uiAnticipo.DecimalPlaces = 2;
            this.uiAnticipo.Enabled = false;
            this.uiAnticipo.Location = new System.Drawing.Point(696, 100);
            this.uiAnticipo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiAnticipo.Name = "uiAnticipo";
            this.uiAnticipo.Size = new System.Drawing.Size(120, 20);
            this.uiAnticipo.TabIndex = 7;
            this.uiAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiBuscarCliente);
            this.groupBox2.Controls.Add(this.uiAgregarProducto);
            this.groupBox2.Controls.Add(this.uiCantidad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.uiProductoDesc);
            this.groupBox2.Controls.Add(this.uiProducto);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(24, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 50);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Captura";
            // 
            // uiBuscarCliente
            // 
            this.uiBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiBuscarCliente.BackgroundImage")));
            this.uiBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiBuscarCliente.Location = new System.Drawing.Point(132, 14);
            this.uiBuscarCliente.Name = "uiBuscarCliente";
            this.uiBuscarCliente.Size = new System.Drawing.Size(34, 34);
            this.uiBuscarCliente.TabIndex = 41;
            this.uiBuscarCliente.UseVisualStyleBackColor = true;
            this.uiBuscarCliente.Click += new System.EventHandler(this.uiBuscarCliente_Click);
            // 
            // uiAgregarProducto
            // 
            this.uiAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAgregarProducto.Location = new System.Drawing.Point(495, 11);
            this.uiAgregarProducto.Name = "uiAgregarProducto";
            this.uiAgregarProducto.Size = new System.Drawing.Size(90, 35);
            this.uiAgregarProducto.TabIndex = 2;
            this.uiAgregarProducto.Text = "+";
            this.uiAgregarProducto.UseVisualStyleBackColor = true;
            this.uiAgregarProducto.Click += new System.EventHandler(this.uiAgregarProducto_Click);
            // 
            // uiCantidad
            // 
            this.uiCantidad.Location = new System.Drawing.Point(429, 23);
            this.uiCantidad.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiCantidad.Name = "uiCantidad";
            this.uiCantidad.Size = new System.Drawing.Size(60, 20);
            this.uiCantidad.TabIndex = 1;
            this.uiCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiCantidad_KeyUp);
            this.uiCantidad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiCantidad_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cantidad";
            // 
            // uiProductoDesc
            // 
            this.uiProductoDesc.Enabled = false;
            this.uiProductoDesc.Location = new System.Drawing.Point(170, 22);
            this.uiProductoDesc.Name = "uiProductoDesc";
            this.uiProductoDesc.Size = new System.Drawing.Size(200, 20);
            this.uiProductoDesc.TabIndex = 2;
            // 
            // uiProducto
            // 
            this.uiProducto.Location = new System.Drawing.Point(62, 22);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Size = new System.Drawing.Size(70, 20);
            this.uiProducto.TabIndex = 0;
            this.uiProducto.Validating += new System.ComponentModel.CancelEventHandler(this.uiProducto_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Producto";
            // 
            // uiFecha
            // 
            this.uiFecha.Enabled = false;
            this.uiFecha.Location = new System.Drawing.Point(205, 41);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Size = new System.Drawing.Size(200, 20);
            this.uiFecha.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.uiClienteNombre);
            this.groupBox1.Controls.Add(this.uiCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(421, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(377, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 34);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(416, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiClienteNombre
            // 
            this.uiClienteNombre.Enabled = false;
            this.uiClienteNombre.Location = new System.Drawing.Point(121, 26);
            this.uiClienteNombre.Name = "uiClienteNombre";
            this.uiClienteNombre.Size = new System.Drawing.Size(250, 20);
            this.uiClienteNombre.TabIndex = 2;
            // 
            // uiCliente
            // 
            this.uiCliente.Location = new System.Drawing.Point(59, 26);
            this.uiCliente.Name = "uiCliente";
            this.uiCliente.Size = new System.Drawing.Size(60, 20);
            this.uiCliente.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apartados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio";
            // 
            // uiFolio
            // 
            this.uiFolio.Enabled = false;
            this.uiFolio.Location = new System.Drawing.Point(56, 41);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(100, 20);
            this.uiFolio.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 278);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiSaldo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.uiTotal);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 218);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 60);
            this.panel3.TabIndex = 1;
            // 
            // uiSaldo
            // 
            this.uiSaldo.DecimalPlaces = 2;
            this.uiSaldo.Enabled = false;
            this.uiSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSaldo.Location = new System.Drawing.Point(739, 12);
            this.uiSaldo.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiSaldo.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.uiSaldo.Name = "uiSaldo";
            this.uiSaldo.Size = new System.Drawing.Size(120, 26);
            this.uiSaldo.TabIndex = 1;
            this.uiSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(678, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Saldo";
            // 
            // uiTotal
            // 
            this.uiTotal.DecimalPlaces = 2;
            this.uiTotal.Enabled = false;
            this.uiTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal.Location = new System.Drawing.Point(542, 10);
            this.uiTotal.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiTotal.Name = "uiTotal";
            this.uiTotal.Size = new System.Drawing.Size(120, 26);
            this.uiTotal.TabIndex = 0;
            this.uiTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(403, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Apartado";
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partida,
            this.ID,
            this.Clave,
            this.Producto,
            this.Cantidad,
            this.Precio,
            this.PorcentajeDescuento,
            this.Total});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1264, 278);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellEndEdit);
            this.uiGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.uiGrid_CellValidating);
            this.uiGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiGrid_KeyDown);
            // 
            // partida
            // 
            this.partida.DataPropertyName = "partida";
            this.partida.HeaderText = "";
            this.partida.Name = "partida";
            this.partida.ReadOnly = true;
            this.partida.Width = 5;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "productoId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "descripcion";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 400;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "precioUnitario";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // PorcentajeDescuento
            // 
            this.PorcentajeDescuento.DataPropertyName = "porcDescuento";
            this.PorcentajeDescuento.HeaderText = "% Desc.";
            this.PorcentajeDescuento.Name = "PorcentajeDescuento";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // uiPagos
            // 
            this.uiPagos.Location = new System.Drawing.Point(211, 3);
            this.uiPagos.Name = "uiPagos";
            this.uiPagos.Size = new System.Drawing.Size(102, 31);
            this.uiPagos.TabIndex = 2;
            this.uiPagos.Text = "VER PAGOS";
            this.uiPagos.UseVisualStyleBackColor = true;
            this.uiPagos.Click += new System.EventHandler(this.uiPagos_Click);
            // 
            // frmApartadosUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmApartadosUpd";
            this.Text = "Apartados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmApartadosUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmApartadosUpd_Load);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panelSup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiAnticipo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.DateTimePicker uiFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox uiClienteNombre;
        private System.Windows.Forms.TextBox uiCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button uiAgregarProducto;
        private System.Windows.Forms.NumericUpDown uiCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox uiProductoDesc;
        private System.Windows.Forms.TextBox uiProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button uiBuscarCliente;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown uiAnticipo;
        private System.Windows.Forms.Button uiPagos;
        private System.Windows.Forms.NumericUpDown uiSaldo;
        private System.Windows.Forms.NumericUpDown uiTotal;
        private System.Windows.Forms.Button uiAgregarAnticipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}