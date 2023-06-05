
namespace ERP.Common.Dialogos
{
    partial class frmRetiroAutomatico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiroAutomatico));
            this.uiOk = new DevExpress.XtraEditors.SimpleButton();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.uiMontoRetiro = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMontoRetiro.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // uiOk
            // 
            this.uiOk.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.uiOk.Appearance.Options.UseFont = true;
            this.uiOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiOk.ImageOptions.Image")));
            this.uiOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiOk.Location = new System.Drawing.Point(50, 149);
            this.uiOk.Name = "uiOk";
            this.uiOk.Size = new System.Drawing.Size(325, 39);
            this.uiOk.TabIndex = 0;
            this.uiOk.Text = "REALIZAR RETIRO";
            this.uiOk.Click += new System.EventHandler(this.uiOk_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.uiCancelar.Appearance.Options.UseFont = true;
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(381, 149);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(283, 39);
            this.uiCancelar.TabIndex = 1;
            this.uiCancelar.Text = "MAS ADELANTE";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(27, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(666, 33);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Es necesario realizar un retiro por la cantidad de:";
            // 
            // uiMontoRetiro
            // 
            this.uiMontoRetiro.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiMontoRetiro.Location = new System.Drawing.Point(172, 70);
            this.uiMontoRetiro.Name = "uiMontoRetiro";
            this.uiMontoRetiro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiMontoRetiro.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.uiMontoRetiro.Properties.Appearance.Options.UseFont = true;
            this.uiMontoRetiro.Properties.Appearance.Options.UseForeColor = true;
            this.uiMontoRetiro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiMontoRetiro.Properties.DisplayFormat.FormatString = "c2";
            this.uiMontoRetiro.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiMontoRetiro.Properties.ReadOnly = true;
            this.uiMontoRetiro.Size = new System.Drawing.Size(298, 46);
            this.uiMontoRetiro.TabIndex = 3;
            // 
            // frmRetiroAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 206);
            this.Controls.Add(this.uiMontoRetiro);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.uiCancelar);
            this.Controls.Add(this.uiOk);
            this.Name = "frmRetiroAutomatico";
            this.Text = "Realizar Retiro";
            this.Load += new System.EventHandler(this.frmRetiroAutomatico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiMontoRetiro.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton uiOk;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CalcEdit uiMontoRetiro;
    }
}