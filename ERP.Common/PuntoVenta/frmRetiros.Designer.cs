namespace ERP.Common.PuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiMonto = new DevExpress.XtraEditors.SpinEdit();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiObservaciones = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            this.label1.Click += new System.EventHandler(this.labelMonto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Observaciones";
            this.label2.Click += new System.EventHandler(this.labelObservaciones_Click);
            // 
            // uiMonto
            // 
            this.uiMonto.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiMonto.Location = new System.Drawing.Point(125, 15);
            this.uiMonto.Name = "uiMonto";
            this.uiMonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiMonto.Size = new System.Drawing.Size(193, 22);
            this.uiMonto.TabIndex = 6;
            this.uiMonto.EditValueChanged += new System.EventHandler(this.uiMonto_EditValueChanged);
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(314, 148);
            this.uiCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(178, 40);
            this.uiCancelar.TabIndex = 11;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.CancelarRetiro_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(130, 148);
            this.uiGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(178, 40);
            this.uiGuardar.TabIndex = 10;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.GuadarRetiros);
            // 
            // uiObservaciones
            // 
            this.uiObservaciones.Location = new System.Drawing.Point(126, 58);
            this.uiObservaciones.Name = "uiObservaciones";
            this.uiObservaciones.Size = new System.Drawing.Size(366, 75);
            this.uiObservaciones.TabIndex = 13;
            this.uiObservaciones.EditValueChanged += new System.EventHandler(this.uiObservaciones_EditValueChanged);
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 201);
            this.Controls.Add(this.uiObservaciones);
            this.Controls.Add(this.uiCancelar);
            this.Controls.Add(this.uiGuardar);
            this.Controls.Add(this.uiMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(545, 248);
            this.MinimumSize = new System.Drawing.Size(545, 248);
            this.Name = "frmRetiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiros";
            this.Load += new System.EventHandler(this.frmRetiros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SpinEdit uiMonto;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraEditors.MemoEdit uiObservaciones;
    }
}