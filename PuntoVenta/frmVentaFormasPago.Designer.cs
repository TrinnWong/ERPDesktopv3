namespace PuntoVenta
{
    partial class frmVentaFormasPago
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
            this.uiGridFormasPago = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitoVerificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiFaltantelbl = new System.Windows.Forms.Label();
            this.uiFaltante = new System.Windows.Forms.NumericUpDown();
            this.uiTotalVenta = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.uiCambio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTotalRecibido = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPagar = new System.Windows.Forms.Button();
            this.uiGriVales = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarVale = new System.Windows.Forms.Button();
            this.uiFolioVale = new System.Windows.Forms.TextBox();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFaltante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalRecibido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGriVales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGridFormasPago
            // 
            this.uiGridFormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridFormasPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FormaPago,
            this.Cantidad,
            this.digitoVerificador});
            this.uiGridFormasPago.Location = new System.Drawing.Point(12, 12);
            this.uiGridFormasPago.MultiSelect = false;
            this.uiGridFormasPago.Name = "uiGridFormasPago";
            this.uiGridFormasPago.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGridFormasPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uiGridFormasPago.Size = new System.Drawing.Size(946, 206);
            this.uiGridFormasPago.TabIndex = 0;
            this.uiGridFormasPago.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.uiGridFormasPago_CellBeginEdit);
            this.uiGridFormasPago.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridFormasPago_CellEndEdit);
            this.uiGridFormasPago.CausesValidationChanged += new System.EventHandler(this.uiGridFormasPago_CausesValidationChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // FormaPago
            // 
            this.FormaPago.DataPropertyName = "Descripcion";
            this.FormaPago.HeaderText = "Forma de Pago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            this.FormaPago.Width = 500;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 200;
            // 
            // digitoVerificador
            // 
            this.digitoVerificador.DataPropertyName = "digitoVerificador";
            this.digitoVerificador.HeaderText = "Digito Verificador";
            this.digitoVerificador.Name = "digitoVerificador";
            // 
            // uiFaltantelbl
            // 
            this.uiFaltantelbl.AutoSize = true;
            this.uiFaltantelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFaltantelbl.ForeColor = System.Drawing.Color.Red;
            this.uiFaltantelbl.Location = new System.Drawing.Point(634, 257);
            this.uiFaltantelbl.Name = "uiFaltantelbl";
            this.uiFaltantelbl.Size = new System.Drawing.Size(76, 24);
            this.uiFaltantelbl.TabIndex = 1;
            this.uiFaltantelbl.Text = "Faltante";
            // 
            // uiFaltante
            // 
            this.uiFaltante.DecimalPlaces = 2;
            this.uiFaltante.Enabled = false;
            this.uiFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFaltante.ForeColor = System.Drawing.Color.Red;
            this.uiFaltante.Location = new System.Drawing.Point(716, 257);
            this.uiFaltante.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiFaltante.Name = "uiFaltante";
            this.uiFaltante.Size = new System.Drawing.Size(140, 29);
            this.uiFaltante.TabIndex = 2;
            this.uiFaltante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uiTotalVenta
            // 
            this.uiTotalVenta.DecimalPlaces = 2;
            this.uiTotalVenta.Enabled = false;
            this.uiTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalVenta.Location = new System.Drawing.Point(716, 296);
            this.uiTotalVenta.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiTotalVenta.Name = "uiTotalVenta";
            this.uiTotalVenta.Size = new System.Drawing.Size(140, 29);
            this.uiTotalVenta.TabIndex = 4;
            this.uiTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(602, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Venta";
            // 
            // uiCambio
            // 
            this.uiCambio.DecimalPlaces = 2;
            this.uiCambio.Enabled = false;
            this.uiCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCambio.ForeColor = System.Drawing.Color.Green;
            this.uiCambio.Location = new System.Drawing.Point(716, 331);
            this.uiCambio.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiCambio.Name = "uiCambio";
            this.uiCambio.Size = new System.Drawing.Size(140, 29);
            this.uiCambio.TabIndex = 6;
            this.uiCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(634, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cambio";
            // 
            // uiTotalRecibido
            // 
            this.uiTotalRecibido.DecimalPlaces = 2;
            this.uiTotalRecibido.Enabled = false;
            this.uiTotalRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalRecibido.Location = new System.Drawing.Point(716, 222);
            this.uiTotalRecibido.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiTotalRecibido.Name = "uiTotalRecibido";
            this.uiTotalRecibido.Size = new System.Drawing.Size(140, 29);
            this.uiTotalRecibido.TabIndex = 8;
            this.uiTotalRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(576, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Recibido";
            // 
            // uiPagar
            // 
            this.uiPagar.Location = new System.Drawing.Point(649, 379);
            this.uiPagar.Name = "uiPagar";
            this.uiPagar.Size = new System.Drawing.Size(309, 47);
            this.uiPagar.TabIndex = 10;
            this.uiPagar.Text = "PAGAR";
            this.uiPagar.UseVisualStyleBackColor = true;
            this.uiPagar.Click += new System.EventHandler(this.uiPagar_Click);
            // 
            // uiGriVales
            // 
            this.uiGriVales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGriVales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Folio,
            this.Vencimiento,
            this.Monto});
            this.uiGriVales.Location = new System.Drawing.Point(20, 46);
            this.uiGriVales.Name = "uiGriVales";
            this.uiGriVales.Size = new System.Drawing.Size(516, 141);
            this.uiGriVales.TabIndex = 11;
            this.uiGriVales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGriVales_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiGriVales);
            this.groupBox1.Controls.Add(this.btnAgregarVale);
            this.groupBox1.Controls.Add(this.uiFolioVale);
            this.groupBox1.Location = new System.Drawing.Point(12, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 189);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VALES";
            // 
            // btnAgregarVale
            // 
            this.btnAgregarVale.Location = new System.Drawing.Point(203, 13);
            this.btnAgregarVale.Name = "btnAgregarVale";
            this.btnAgregarVale.Size = new System.Drawing.Size(244, 30);
            this.btnAgregarVale.TabIndex = 13;
            this.btnAgregarVale.Text = "AGREGAR VALE";
            this.btnAgregarVale.UseVisualStyleBackColor = true;
            this.btnAgregarVale.Click += new System.EventHandler(this.btnAgregarVale_Click);
            // 
            // uiFolioVale
            // 
            this.uiFolioVale.Location = new System.Drawing.Point(20, 20);
            this.uiFolioVale.Name = "uiFolioVale";
            this.uiFolioVale.Size = new System.Drawing.Size(166, 20);
            this.uiFolioVale.TabIndex = 12;
            // 
            // Eliminar
            // 
            this.Eliminar.DataPropertyName = "eliminar";
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "folioVale";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.Width = 80;
            // 
            // Vencimiento
            // 
            this.Vencimiento.DataPropertyName = "fechaVencimiento";
            this.Vencimiento.HeaderText = "Vencimiento";
            this.Vencimiento.Name = "Vencimiento";
            this.Vencimiento.ReadOnly = true;
            this.Vencimiento.Width = 150;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // frmVentaFormasPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uiPagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiTotalRecibido);
            this.Controls.Add(this.uiCambio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiTotalVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiFaltante);
            this.Controls.Add(this.uiFaltantelbl);
            this.Controls.Add(this.uiGridFormasPago);
            this.Name = "frmVentaFormasPago";
            this.Text = "Formas de Pago";
            this.Load += new System.EventHandler(this.frmVentaFormasPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridFormasPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFaltante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotalRecibido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGriVales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiGridFormasPago;
        private System.Windows.Forms.Label uiFaltantelbl;
        private System.Windows.Forms.NumericUpDown uiFaltante;
        private System.Windows.Forms.NumericUpDown uiTotalVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uiCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uiTotalRecibido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uiPagar;
        private System.Windows.Forms.DataGridView uiGriVales;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregarVale;
        private System.Windows.Forms.TextBox uiFolioVale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitoVerificador;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
    }
}