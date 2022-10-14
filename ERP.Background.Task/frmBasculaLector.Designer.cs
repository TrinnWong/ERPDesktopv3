namespace ERP.Background.Task
{
    partial class frmBasculaLector
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiPausarActivar = new System.Windows.Forms.Button();
            this.uiPeso = new System.Windows.Forms.NumericUpDown();
            this.TXThdid = new DevExpress.XtraEditors.TextEdit();
            this.uiMemo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXThdid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMemo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiPausarActivar
            // 
            this.uiPausarActivar.Location = new System.Drawing.Point(369, 25);
            this.uiPausarActivar.Name = "uiPausarActivar";
            this.uiPausarActivar.Size = new System.Drawing.Size(121, 23);
            this.uiPausarActivar.TabIndex = 1;
            this.uiPausarActivar.Text = "Pausar/Activar";
            this.uiPausarActivar.UseVisualStyleBackColor = true;
            this.uiPausarActivar.Click += new System.EventHandler(this.uiPausarActivar_Click);
            // 
            // uiPeso
            // 
            this.uiPeso.DecimalPlaces = 2;
            this.uiPeso.Location = new System.Drawing.Point(75, 25);
            this.uiPeso.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiPeso.Name = "uiPeso";
            this.uiPeso.Size = new System.Drawing.Size(120, 20);
            this.uiPeso.TabIndex = 2;
            // 
            // TXThdid
            // 
            this.TXThdid.Location = new System.Drawing.Point(75, 51);
            this.TXThdid.Name = "TXThdid";
            this.TXThdid.Size = new System.Drawing.Size(438, 22);
            this.TXThdid.TabIndex = 3;
            // 
            // uiMemo
            // 
            this.uiMemo.Location = new System.Drawing.Point(75, 80);
            this.uiMemo.Name = "uiMemo";
            this.uiMemo.Size = new System.Drawing.Size(438, 96);
            this.uiMemo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 200);
            this.Controls.Add(this.uiMemo);
            this.Controls.Add(this.TXThdid);
            this.Controls.Add(this.uiPeso);
            this.Controls.Add(this.uiPausarActivar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Lector de Báscula";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.uiPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXThdid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMemo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button uiPausarActivar;
        private System.Windows.Forms.NumericUpDown uiPeso;
        private DevExpress.XtraEditors.TextEdit TXThdid;
        private DevExpress.XtraEditors.MemoEdit uiMemo;
    }
}

