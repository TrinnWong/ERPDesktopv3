namespace PuntoVenta
{
    partial class frmDevolucionesUpd
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
            this.label7 = new System.Windows.Forms.Label();
            this.uiFechaTicket = new System.Windows.Forms.DateTimePicker();
            this.uiTipoDevolucion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uiFolioDevolucion = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiFolioTocket = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.uiTotalDevolucion = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioDevolucion)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalDevolucion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.uiFechaTicket);
            this.panel1.Controls.Add(this.uiTipoDevolucion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.uiFolioDevolucion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.uiFecha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.uiFolioTocket);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 92);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha Ticket";
            // 
            // uiFechaTicket
            // 
            this.uiFechaTicket.Enabled = false;
            this.uiFechaTicket.Location = new System.Drawing.Point(337, 61);
            this.uiFechaTicket.Name = "uiFechaTicket";
            this.uiFechaTicket.Size = new System.Drawing.Size(200, 20);
            this.uiFechaTicket.TabIndex = 9;
            // 
            // uiTipoDevolucion
            // 
            this.uiTipoDevolucion.DisplayMember = "Descripcion";
            this.uiTipoDevolucion.FormattingEnabled = true;
            this.uiTipoDevolucion.Location = new System.Drawing.Point(636, 35);
            this.uiTipoDevolucion.Name = "uiTipoDevolucion";
            this.uiTipoDevolucion.Size = new System.Drawing.Size(207, 21);
            this.uiTipoDevolucion.TabIndex = 8;
            this.uiTipoDevolucion.ValueMember = "TipoDevolucionId";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tipo Devolución";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "DEVOLUCIONES";
            // 
            // uiFolioDevolucion
            // 
            this.uiFolioDevolucion.Enabled = false;
            this.uiFolioDevolucion.Location = new System.Drawing.Point(104, 38);
            this.uiFolioDevolucion.Name = "uiFolioDevolucion";
            this.uiFolioDevolucion.Size = new System.Drawing.Size(137, 20);
            this.uiFolioDevolucion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Folio Devolución";
            // 
            // uiFecha
            // 
            this.uiFecha.Enabled = false;
            this.uiFecha.Location = new System.Drawing.Point(337, 34);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Size = new System.Drawing.Size(200, 20);
            this.uiFecha.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Dev.";
            // 
            // uiFolioTocket
            // 
            this.uiFolioTocket.Location = new System.Drawing.Point(104, 64);
            this.uiFolioTocket.Name = "uiFolioTocket";
            this.uiFolioTocket.Size = new System.Drawing.Size(137, 20);
            this.uiFolioTocket.TabIndex = 1;
            this.uiFolioTocket.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiFolioTocket_KeyUp);
            this.uiFolioTocket.Validating += new System.ComponentModel.CancelEventHandler(this.uiFolioTocket_Validating);
            this.uiFolioTocket.Validated += new System.EventHandler(this.uiFolioTocket_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio Ticket";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 363);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiCancelar);
            this.panel3.Controls.Add(this.uiGuardar);
            this.panel3.Controls.Add(this.uiTotalDevolucion);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1129, 100);
            this.panel3.TabIndex = 1;
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(689, 18);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(168, 49);
            this.uiCancelar.TabIndex = 3;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(515, 18);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(168, 49);
            this.uiGuardar.TabIndex = 2;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiTotalDevolucion
            // 
            this.uiTotalDevolucion.DecimalPlaces = 2;
            this.uiTotalDevolucion.Enabled = false;
            this.uiTotalDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalDevolucion.Location = new System.Drawing.Point(365, 18);
            this.uiTotalDevolucion.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiTotalDevolucion.Name = "uiTotalDevolucion";
            this.uiTotalDevolucion.Size = new System.Drawing.Size(110, 26);
            this.uiTotalDevolucion.TabIndex = 1;
            this.uiTotalDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(216, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Devolución  $";
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductoId,
            this.Producto,
            this.PrecioUnitario,
            this.CantidadTicket,
            this.Cantidad,
            this.Total,
            this.Seleccionar});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1129, 363);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellContentClick);
            this.uiGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellEndEdit);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "DevolucionDetId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 300;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.DataPropertyName = "precioUnitario";
            this.PrecioUnitario.HeaderText = "PrecioUnitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            // 
            // CantidadTicket
            // 
            this.CantidadTicket.DataPropertyName = "cantidadTicket";
            this.CantidadTicket.HeaderText = "Cantidad Ticket";
            this.CantidadTicket.Name = "CantidadTicket";
            this.CantidadTicket.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad Devolución";
            this.Cantidad.Name = "Cantidad";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.DataPropertyName = "Seleccionar";
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // frmDevolucionesUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 455);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDevolucionesUpd";
            this.Text = "Devoluciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDevolucionesUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmDevolucionesUpd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioDevolucion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalDevolucion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker uiFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiFolioTocket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uiFolioDevolucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown uiTotalDevolucion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uiCancelar;
        private System.Windows.Forms.Button uiGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.ComboBox uiTipoDevolucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker uiFechaTicket;
    }
}