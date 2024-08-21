
namespace ERPv1.Encriptador
{
    partial class frmEncripta
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
            this.uiEntrada = new System.Windows.Forms.TextBox();
            this.btnEncriptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDesencriptar = new DevExpress.XtraEditors.SimpleButton();
            this.uiSalida = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // uiEntrada
            // 
            this.uiEntrada.Location = new System.Drawing.Point(42, 12);
            this.uiEntrada.Multiline = true;
            this.uiEntrada.Name = "uiEntrada";
            this.uiEntrada.Size = new System.Drawing.Size(527, 116);
            this.uiEntrada.TabIndex = 0;
            // 
            // btnEncriptar
            // 
            this.btnEncriptar.Location = new System.Drawing.Point(42, 134);
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Size = new System.Drawing.Size(172, 23);
            this.btnEncriptar.TabIndex = 1;
            this.btnEncriptar.Text = "Encriptar";
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptar_Click);
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.Location = new System.Drawing.Point(241, 134);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(167, 23);
            this.btnDesencriptar.TabIndex = 2;
            this.btnDesencriptar.Text = "Desencriptar";
            this.btnDesencriptar.Click += new System.EventHandler(this.btnDesencriptar_Click);
            // 
            // uiSalida
            // 
            this.uiSalida.Enabled = false;
            this.uiSalida.Location = new System.Drawing.Point(42, 172);
            this.uiSalida.Multiline = true;
            this.uiSalida.Name = "uiSalida";
            this.uiSalida.Size = new System.Drawing.Size(527, 156);
            this.uiSalida.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(42, 335);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(143, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Copiar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmEncripta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 370);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.uiSalida);
            this.Controls.Add(this.btnDesencriptar);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.uiEntrada);
            this.Name = "frmEncripta";
            this.Text = "Encripta";
            this.Load += new System.EventHandler(this.frmEncripta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiEntrada;
        private DevExpress.XtraEditors.SimpleButton btnEncriptar;
        private DevExpress.XtraEditors.SimpleButton btnDesencriptar;
        private System.Windows.Forms.TextBox uiSalida;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}