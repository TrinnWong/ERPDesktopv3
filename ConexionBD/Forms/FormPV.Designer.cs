﻿namespace ConexionBD.Forms
{
    partial class FormPV
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.uiSalir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiSalir);
            this.panel1.Controls.Add(this.uiGuardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(991, 346);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 346);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(991, 100);
            this.panel3.TabIndex = 2;
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(3, 3);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(149, 56);
            this.uiGuardar.TabIndex = 1;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            // 
            // uiSalir
            // 
            this.uiSalir.Location = new System.Drawing.Point(155, 3);
            this.uiSalir.Name = "uiSalir";
            this.uiSalir.Size = new System.Drawing.Size(149, 56);
            this.uiSalir.TabIndex = 0;
            this.uiSalir.Text = "SALIR";
            this.uiSalir.UseVisualStyleBackColor = true;
            // 
            // FormPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 446);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormPV";
            this.Text = "FormPV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button uiGuardar;
        private System.Windows.Forms.Button uiSalir;
    }
}