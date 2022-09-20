namespace ERPv1.Procesos
{
    partial class frmPromocionesExcluision
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
            this.uiNombrePromocion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiNombrePromocion
            // 
            this.uiNombrePromocion.Enabled = false;
            this.uiNombrePromocion.Location = new System.Drawing.Point(125, 7);
            this.uiNombrePromocion.Name = "uiNombrePromocion";
            this.uiNombrePromocion.Size = new System.Drawing.Size(277, 20);
            this.uiNombrePromocion.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Nombre Promoción";
            // 
            // frmPromocionesExcluision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 357);
            this.Controls.Add(this.uiNombrePromocion);
            this.Controls.Add(this.label11);
            this.Name = "frmPromocionesExcluision";
            this.Text = "Promociones - Exclusión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiNombrePromocion;
        private System.Windows.Forms.Label label11;
    }
}