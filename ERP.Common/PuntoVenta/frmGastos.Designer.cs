namespace ERP.Common.PuntoVenta
{
    partial class frmGastos
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiCentroCosto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiConcepto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiMonto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.uiObservaciones = new System.Windows.Forms.TextBox();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.uiCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Centro de Costo";
            // 
            // uiCentroCosto
            // 
            this.uiCentroCosto.DisplayMember = "Descripcion";
            this.uiCentroCosto.FormattingEnabled = true;
            this.uiCentroCosto.Location = new System.Drawing.Point(122, 13);
            this.uiCentroCosto.Name = "uiCentroCosto";
            this.uiCentroCosto.Size = new System.Drawing.Size(299, 21);
            this.uiCentroCosto.TabIndex = 1;
            this.uiCentroCosto.ValueMember = "Clave";
            this.uiCentroCosto.SelectedValueChanged += new System.EventHandler(this.uiCentroCosto_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Concepto";
            // 
            // uiConcepto
            // 
            this.uiConcepto.DisplayMember = "Descripcion";
            this.uiConcepto.FormattingEnabled = true;
            this.uiConcepto.Location = new System.Drawing.Point(122, 44);
            this.uiConcepto.Name = "uiConcepto";
            this.uiConcepto.Size = new System.Drawing.Size(299, 21);
            this.uiConcepto.TabIndex = 3;
            this.uiConcepto.ValueMember = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // uiMonto
            // 
            this.uiMonto.DecimalPlaces = 2;
            this.uiMonto.Location = new System.Drawing.Point(123, 72);
            this.uiMonto.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiMonto.Name = "uiMonto";
            this.uiMonto.Size = new System.Drawing.Size(120, 20);
            this.uiMonto.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Observaciones";
            // 
            // uiObservaciones
            // 
            this.uiObservaciones.Location = new System.Drawing.Point(123, 105);
            this.uiObservaciones.Multiline = true;
            this.uiObservaciones.Name = "uiObservaciones";
            this.uiObservaciones.Size = new System.Drawing.Size(298, 73);
            this.uiObservaciones.TabIndex = 7;
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(123, 184);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(120, 23);
            this.uiGuardar.TabIndex = 8;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            this.uiGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(249, 184);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(120, 23);
            this.uiCancelar.TabIndex = 9;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 207);
            this.Controls.Add(this.uiCancelar);
            this.Controls.Add(this.uiGuardar);
            this.Controls.Add(this.uiObservaciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uiMonto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiConcepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiCentroCosto);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(450, 254);
            this.MinimumSize = new System.Drawing.Size(450, 254);
            this.Name = "frmGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Gastos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGastos_FormClosing);
            this.Load += new System.EventHandler(this.frmGastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uiCentroCosto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiConcepto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uiMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiObservaciones;
        private System.Windows.Forms.Button uiGuardar;
        private System.Windows.Forms.Button uiCancelar;
    }
}