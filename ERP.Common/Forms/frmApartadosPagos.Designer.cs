namespace ERP.Common.Forms
{
    partial class frmApartadosPagos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiGridPagos = new System.Windows.Forms.DataGridView();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DigitoVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFolio = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.uiAgregarPago = new System.Windows.Forms.Button();
            this.uiImportePago = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.uiCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiTotal = new System.Windows.Forms.Label();
            this.uiSaldo = new System.Windows.Forms.Label();
            this.uiPagar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolio)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImportePago)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiGridPagos);
            this.groupBox1.Location = new System.Drawing.Point(15, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagos";
            // 
            // uiGridPagos
            // 
            this.uiGridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Importe,
            this.FormaPago,
            this.DigitoVer,
            this.FechaPago});
            this.uiGridPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGridPagos.Location = new System.Drawing.Point(3, 16);
            this.uiGridPagos.Name = "uiGridPagos";
            this.uiGridPagos.Size = new System.Drawing.Size(650, 193);
            this.uiGridPagos.TabIndex = 0;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 200;
            // 
            // FormaPago
            // 
            this.FormaPago.DataPropertyName = "formaPago";
            this.FormaPago.HeaderText = "Forma de Pago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            this.FormaPago.Visible = false;
            this.FormaPago.Width = 200;
            // 
            // DigitoVer
            // 
            this.DigitoVer.DataPropertyName = "digitoVer";
            this.DigitoVer.HeaderText = "Digito Ver.";
            this.DigitoVer.Name = "DigitoVer";
            this.DigitoVer.Visible = false;
            this.DigitoVer.Width = 80;
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPago";
            this.FechaPago.HeaderText = "Fecha Pago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            this.FechaPago.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pagos de Apartados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folio";
            // 
            // uiFolio
            // 
            this.uiFolio.Enabled = false;
            this.uiFolio.Location = new System.Drawing.Point(51, 31);
            this.uiFolio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(84, 20);
            this.uiFolio.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Apartado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiPagar);
            this.groupBox2.Controls.Add(this.uiFechaPago);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.uiAgregarPago);
            this.groupBox2.Controls.Add(this.uiImportePago);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(16, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Captura";
            // 
            // uiFechaPago
            // 
            this.uiFechaPago.Enabled = false;
            this.uiFechaPago.Location = new System.Drawing.Point(103, 19);
            this.uiFechaPago.Name = "uiFechaPago";
            this.uiFechaPago.Size = new System.Drawing.Size(200, 20);
            this.uiFechaPago.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha de Pago";
            // 
            // uiAgregarPago
            // 
            this.uiAgregarPago.Location = new System.Drawing.Point(19, 45);
            this.uiAgregarPago.Name = "uiAgregarPago";
            this.uiAgregarPago.Size = new System.Drawing.Size(284, 33);
            this.uiAgregarPago.TabIndex = 9;
            this.uiAgregarPago.Text = "1. FORMAS PAGO";
            this.uiAgregarPago.UseVisualStyleBackColor = true;
            this.uiAgregarPago.Click += new System.EventHandler(this.uiAgregarPago_Click);
            // 
            // uiImportePago
            // 
            this.uiImportePago.DecimalPlaces = 2;
            this.uiImportePago.Enabled = false;
            this.uiImportePago.Location = new System.Drawing.Point(408, 19);
            this.uiImportePago.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiImportePago.Name = "uiImportePago";
            this.uiImportePago.Size = new System.Drawing.Size(84, 20);
            this.uiImportePago.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Importe a Pagar";
            // 
            // uiCliente
            // 
            this.uiCliente.Enabled = false;
            this.uiCliente.Location = new System.Drawing.Point(230, 33);
            this.uiCliente.Name = "uiCliente";
            this.uiCliente.Size = new System.Drawing.Size(439, 20);
            this.uiCliente.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Saldo";
            // 
            // uiTotal
            // 
            this.uiTotal.AutoSize = true;
            this.uiTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal.Location = new System.Drawing.Point(435, 368);
            this.uiTotal.Name = "uiTotal";
            this.uiTotal.Size = new System.Drawing.Size(100, 15);
            this.uiTotal.TabIndex = 13;
            this.uiTotal.Text = "Total Apartado";
            // 
            // uiSaldo
            // 
            this.uiSaldo.AutoSize = true;
            this.uiSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSaldo.Location = new System.Drawing.Point(571, 368);
            this.uiSaldo.Name = "uiSaldo";
            this.uiSaldo.Size = new System.Drawing.Size(100, 15);
            this.uiSaldo.TabIndex = 14;
            this.uiSaldo.Text = "Total Apartado";
            // 
            // uiPagar
            // 
            this.uiPagar.Location = new System.Drawing.Point(309, 45);
            this.uiPagar.Name = "uiPagar";
            this.uiPagar.Size = new System.Drawing.Size(334, 33);
            this.uiPagar.TabIndex = 15;
            this.uiPagar.Text = "2. AGREGAR PAGO";
            this.uiPagar.UseVisualStyleBackColor = true;
            this.uiPagar.Click += new System.EventHandler(this.uiPagar_Click);
            // 
            // frmApartadosPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 459);
            this.Controls.Add(this.uiSaldo);
            this.Controls.Add(this.uiTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uiCliente);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiFolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmApartadosPagos";
            this.Text = "Apartados Pagos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmApartadosPagos_FormClosing);
            this.Load += new System.EventHandler(this.frmApartadosPagos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImportePago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView uiGridPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uiFolio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker uiFechaPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uiAgregarPago;
        private System.Windows.Forms.NumericUpDown uiImportePago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label uiTotal;
        private System.Windows.Forms.Label uiSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn DigitoVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.Button uiPagar;
    }
}