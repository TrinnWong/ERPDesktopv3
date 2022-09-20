namespace ERP.Common.PuntoVenta
{
    partial class frmAutorizacion
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
            this.uiNumeroEmpleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiClaveSupervisor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // uiNumeroEmpleado
            // 
            this.uiNumeroEmpleado.Location = new System.Drawing.Point(148, 60);
            this.uiNumeroEmpleado.Name = "uiNumeroEmpleado";
            this.uiNumeroEmpleado.Size = new System.Drawing.Size(156, 20);
            this.uiNumeroEmpleado.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clave de Supervisor";
            // 
            // uiClaveSupervisor
            // 
            this.uiClaveSupervisor.Location = new System.Drawing.Point(148, 86);
            this.uiClaveSupervisor.Name = "uiClaveSupervisor";
            this.uiClaveSupervisor.PasswordChar = '*';
            this.uiClaveSupervisor.Size = new System.Drawing.Size(156, 20);
            this.uiClaveSupervisor.TabIndex = 1;
            this.uiClaveSupervisor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiClaveSupervisor_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "ACEPTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAutorizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiClaveSupervisor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiNumeroEmpleado);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(340, 167);
            this.MinimumSize = new System.Drawing.Size(340, 167);
            this.Name = "frmAutorizacion";
            this.Text = "Clave Supervisor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAutorizacion_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiNumeroEmpleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiClaveSupervisor;
        private System.Windows.Forms.Button button1;
    }
}