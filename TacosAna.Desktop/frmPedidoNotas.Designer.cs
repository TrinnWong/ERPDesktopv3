namespace TacosAna.Desktop
{
    partial class frmPedidoNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoNotas));
            this.uiNotas = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // uiNotas
            // 
            this.uiNotas.Location = new System.Drawing.Point(12, 12);
            this.uiNotas.Name = "uiNotas";
            this.uiNotas.Properties.MaxLength = 250;
            this.uiNotas.Size = new System.Drawing.Size(439, 108);
            this.uiNotas.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(12, 127);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(439, 36);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Guardar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmPedidoNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 173);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.uiNotas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidoNotas";
            this.Text = "Notas de la Venta";
            this.Load += new System.EventHandler(this.frmPedidoNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit uiNotas;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}