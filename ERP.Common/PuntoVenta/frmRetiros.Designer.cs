﻿namespace ERP.Common.PuntoVenta
{
    partial class frmRetiros
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
            this.uiMonto = new System.Windows.Forms.NumericUpDown();
            this.uiObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // uiMonto
            // 
            this.uiMonto.DecimalPlaces = 2;
            this.uiMonto.Enabled = false;
            this.uiMonto.Location = new System.Drawing.Point(94, 13);
            this.uiMonto.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiMonto.Name = "uiMonto";
            this.uiMonto.Size = new System.Drawing.Size(120, 20);
            this.uiMonto.TabIndex = 1;
            // 
            // uiObservaciones
            // 
            this.uiObservaciones.Location = new System.Drawing.Point(94, 41);
            this.uiObservaciones.Multiline = true;
            this.uiObservaciones.Name = "uiObservaciones";
            this.uiObservaciones.Size = new System.Drawing.Size(276, 82);
            this.uiObservaciones.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observaciones";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "REGISTRAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 154);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiObservaciones);
            this.Controls.Add(this.uiMonto);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(413, 210);
            this.MinimumSize = new System.Drawing.Size(413, 210);
            this.Name = "frmRetiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiros";
            this.Load += new System.EventHandler(this.frmRetiros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown uiMonto;
        private System.Windows.Forms.TextBox uiObservaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}