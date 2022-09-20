namespace PuntoVenta
{
    partial class frmCancelarTicket
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
            this.uiTicket = new System.Windows.Forms.Label();
            this.uiMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancelar Ticket";
            // 
            // uiTicket
            // 
            this.uiTicket.AutoSize = true;
            this.uiTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTicket.Location = new System.Drawing.Point(115, 35);
            this.uiTicket.Name = "uiTicket";
            this.uiTicket.Size = new System.Drawing.Size(53, 20);
            this.uiTicket.TabIndex = 1;
            this.uiTicket.Text = "NV26";
            this.uiTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiMotivo
            // 
            this.uiMotivo.Location = new System.Drawing.Point(12, 90);
            this.uiMotivo.MaxLength = 150;
            this.uiMotivo.Multiline = true;
            this.uiMotivo.Name = "uiMotivo";
            this.uiMotivo.Size = new System.Drawing.Size(331, 141);
            this.uiMotivo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese el motivo de cancelación";
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(12, 238);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(331, 41);
            this.uiCancelar.TabIndex = 4;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // frmCancelarTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 299);
            this.Controls.Add(this.uiCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiMotivo);
            this.Controls.Add(this.uiTicket);
            this.Controls.Add(this.label1);
            this.Name = "frmCancelarTicket";
            this.Text = "Cancelación de Ticket";
            this.Load += new System.EventHandler(this.frmCancelarTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uiTicket;
        private System.Windows.Forms.TextBox uiMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiCancelar;
    }
}