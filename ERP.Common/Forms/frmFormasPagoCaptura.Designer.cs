namespace ERP.Common.Forms
{
    partial class frmFormasPagoCaptura
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
            this.uiFormasPago = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DigitoVerificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiereDigitoVerificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.uiTotal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // uiFormasPago
            // 
            this.uiFormasPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiFormasPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FormaPago,
            this.Cantidad,
            this.DigitoVerificador,
            this.requiereDigitoVerificador});
            this.uiFormasPago.Location = new System.Drawing.Point(12, 12);
            this.uiFormasPago.Name = "uiFormasPago";
            this.uiFormasPago.Size = new System.Drawing.Size(644, 227);
            this.uiFormasPago.TabIndex = 0;
            this.uiFormasPago.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiFormasPago_CellEndEdit);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // FormaPago
            // 
            this.FormaPago.DataPropertyName = "descripcion";
            this.FormaPago.HeaderText = "Forma de Pago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.ReadOnly = true;
            this.FormaPago.Width = 300;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // DigitoVerificador
            // 
            this.DigitoVerificador.DataPropertyName = "digitoVerificador";
            this.DigitoVerificador.HeaderText = "DigitoVerificador";
            this.DigitoVerificador.Name = "DigitoVerificador";
            // 
            // requiereDigitoVerificador
            // 
            this.requiereDigitoVerificador.DataPropertyName = "requiereDigito";
            this.requiereDigitoVerificador.HeaderText = "requiereDigitoVerificador";
            this.requiereDigitoVerificador.Name = "requiereDigitoVerificador";
            this.requiereDigitoVerificador.ReadOnly = true;
            this.requiereDigitoVerificador.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(644, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "ACEPTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiTotal
            // 
            this.uiTotal.DecimalPlaces = 2;
            this.uiTotal.Enabled = false;
            this.uiTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal.Location = new System.Drawing.Point(411, 245);
            this.uiTotal.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiTotal.Name = "uiTotal";
            this.uiTotal.Size = new System.Drawing.Size(94, 22);
            this.uiTotal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total";
            // 
            // frmFormasPagoCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiFormasPago);
            this.Name = "frmFormasPagoCaptura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de Pago";
            this.Load += new System.EventHandler(this.frmFormasPagoCaptura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiFormasPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uiFormasPago;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown uiTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DigitoVerificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiereDigitoVerificador;
    }
}