namespace PuntoVenta
{
    partial class frmBuscarTicket
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
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio Ticket";
            // 
            // uiFolio
            // 
            this.uiFolio.Location = new System.Drawing.Point(90, 24);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(302, 20);
            this.uiFolio.TabIndex = 1;
            this.uiFolio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiFolio_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(302, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmBuscarTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiFolio);
            this.Controls.Add(this.label1);
            this.Name = "frmBuscarTicket";
            this.Text = "Buscar Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.Button button1;
    }
}