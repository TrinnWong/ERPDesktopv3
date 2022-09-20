namespace ConexionBD.Forms
{
    partial class FormERP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            this.panelSup = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.AllowDrop = true;
            this.panelSup.Controls.Add(this.button1);
            this.panelSup.Controls.Add(this.uiGuardar);
            this.panelSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSup.Location = new System.Drawing.Point(0, 0);
            this.panelSup.Name = "panelSup";
            this.panelSup.Size = new System.Drawing.Size(653, 36);
            this.panelSup.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "SALIR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(3, 3);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(103, 31);
            this.uiGuardar.TabIndex = 0;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            // 
            // FormERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 419);
            this.Controls.Add(this.panelSup);
            this.Name = "FormERP";
            this.Text = "FormERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormERP_FormClosing);
            this.Load += new System.EventHandler(this.FormERP_Load);
            this.panelSup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelSup;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button uiGuardar;
    }
}