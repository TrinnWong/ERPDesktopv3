﻿namespace ERP.Common.Inventarios
{
    partial class frmExistenciasValuoAgrupado
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiRadioTipo = new System.Windows.Forms.RadioButton();
            this.uiRadioTipo1 = new System.Windows.Forms.RadioButton();
            this.uiDescuento = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiProguctoG = new System.Windows.Forms.RadioButton();
            this.uiSubfamiliaG = new System.Windows.Forms.RadioButton();
            this.uiFamiliaG = new System.Windows.Forms.RadioButton();
            this.uiLineaG = new System.Windows.Forms.RadioButton();
            this.uiSoloExistencia = new System.Windows.Forms.CheckBox();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiSubfamilia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uiFamilia = new System.Windows.Forms.ComboBox();
            this.uiLinea = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDescuento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.button3);
            this.panelSup.Controls.Add(this.button2);
            this.panelSup.Size = new System.Drawing.Size(1209, 36);
            this.panelSup.Controls.SetChildIndex(this.uiGuardar, 0);
            this.panelSup.Controls.SetChildIndex(this.button1, 0);
            this.panelSup.Controls.SetChildIndex(this.button2, 0);
            this.panelSup.Controls.SetChildIndex(this.button3, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 2);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(8, 3);
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.uiDescuento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.uiSoloExistencia);
            this.panel1.Controls.Add(this.uiSucursal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.uiSubfamilia);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.uiFamilia);
            this.panel1.Controls.Add(this.uiLinea);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1209, 100);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiRadioTipo);
            this.groupBox2.Controls.Add(this.uiRadioTipo1);
            this.groupBox2.Location = new System.Drawing.Point(731, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 38);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // uiRadioTipo
            // 
            this.uiRadioTipo.AutoSize = true;
            this.uiRadioTipo.Location = new System.Drawing.Point(216, 12);
            this.uiRadioTipo.Name = "uiRadioTipo";
            this.uiRadioTipo.Size = new System.Drawing.Size(168, 17);
            this.uiRadioTipo.TabIndex = 1;
            this.uiRadioTipo.Text = "Costo u. compra/Precio Venta";
            this.uiRadioTipo.UseVisualStyleBackColor = true;
            // 
            // uiRadioTipo1
            // 
            this.uiRadioTipo1.AutoSize = true;
            this.uiRadioTipo1.Checked = true;
            this.uiRadioTipo1.Location = new System.Drawing.Point(29, 12);
            this.uiRadioTipo1.Name = "uiRadioTipo1";
            this.uiRadioTipo1.Size = new System.Drawing.Size(163, 17);
            this.uiRadioTipo1.TabIndex = 0;
            this.uiRadioTipo1.TabStop = true;
            this.uiRadioTipo1.Text = "Costo u. compra/Costo prom.";
            this.uiRadioTipo1.UseVisualStyleBackColor = true;
            // 
            // uiDescuento
            // 
            this.uiDescuento.Location = new System.Drawing.Point(1000, 53);
            this.uiDescuento.Name = "uiDescuento";
            this.uiDescuento.Size = new System.Drawing.Size(120, 20);
            this.uiDescuento.TabIndex = 15;
            this.uiDescuento.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(935, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descuento";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiProguctoG);
            this.groupBox1.Controls.Add(this.uiSubfamiliaG);
            this.groupBox1.Controls.Add(this.uiFamiliaG);
            this.groupBox1.Controls.Add(this.uiLineaG);
            this.groupBox1.Location = new System.Drawing.Point(294, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 40);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mostrar Hasta";
            // 
            // uiProguctoG
            // 
            this.uiProguctoG.AutoSize = true;
            this.uiProguctoG.Location = new System.Drawing.Point(265, 15);
            this.uiProguctoG.Name = "uiProguctoG";
            this.uiProguctoG.Size = new System.Drawing.Size(68, 17);
            this.uiProguctoG.TabIndex = 3;
            this.uiProguctoG.Text = "Producto";
            this.uiProguctoG.UseVisualStyleBackColor = true;
            // 
            // uiSubfamiliaG
            // 
            this.uiSubfamiliaG.AutoSize = true;
            this.uiSubfamiliaG.Location = new System.Drawing.Point(169, 15);
            this.uiSubfamiliaG.Name = "uiSubfamiliaG";
            this.uiSubfamiliaG.Size = new System.Drawing.Size(73, 17);
            this.uiSubfamiliaG.TabIndex = 2;
            this.uiSubfamiliaG.Text = "Subfamilia";
            this.uiSubfamiliaG.UseVisualStyleBackColor = true;
            // 
            // uiFamiliaG
            // 
            this.uiFamiliaG.AutoSize = true;
            this.uiFamiliaG.Location = new System.Drawing.Point(97, 16);
            this.uiFamiliaG.Name = "uiFamiliaG";
            this.uiFamiliaG.Size = new System.Drawing.Size(57, 17);
            this.uiFamiliaG.TabIndex = 1;
            this.uiFamiliaG.Text = "Familia";
            this.uiFamiliaG.UseVisualStyleBackColor = true;
            // 
            // uiLineaG
            // 
            this.uiLineaG.AutoSize = true;
            this.uiLineaG.Checked = true;
            this.uiLineaG.Location = new System.Drawing.Point(33, 16);
            this.uiLineaG.Name = "uiLineaG";
            this.uiLineaG.Size = new System.Drawing.Size(53, 17);
            this.uiLineaG.TabIndex = 0;
            this.uiLineaG.TabStop = true;
            this.uiLineaG.Text = "Línea";
            this.uiLineaG.UseVisualStyleBackColor = true;
            // 
            // uiSoloExistencia
            // 
            this.uiSoloExistencia.AutoSize = true;
            this.uiSoloExistencia.Checked = true;
            this.uiSoloExistencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiSoloExistencia.Location = new System.Drawing.Point(740, 54);
            this.uiSoloExistencia.Name = "uiSoloExistencia";
            this.uiSoloExistencia.Size = new System.Drawing.Size(167, 17);
            this.uiSoloExistencia.TabIndex = 12;
            this.uiSoloExistencia.Text = "Solo Articulos con Existencias";
            this.uiSoloExistencia.UseVisualStyleBackColor = true;
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.Enabled = false;
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(70, 20);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(176, 21);
            this.uiSucursal.TabIndex = 0;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Sucursal";
            // 
            // uiSubfamilia
            // 
            this.uiSubfamilia.DisplayMember = "Descripcion";
            this.uiSubfamilia.FormattingEnabled = true;
            this.uiSubfamilia.Location = new System.Drawing.Point(559, 52);
            this.uiSubfamilia.Name = "uiSubfamilia";
            this.uiSubfamilia.Size = new System.Drawing.Size(175, 21);
            this.uiSubfamilia.TabIndex = 3;
            this.uiSubfamilia.ValueMember = "Clave";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(498, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Subfamilia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Línea";
            // 
            // uiFamilia
            // 
            this.uiFamilia.DisplayMember = "Descripcion";
            this.uiFamilia.FormattingEnabled = true;
            this.uiFamilia.Location = new System.Drawing.Point(307, 52);
            this.uiFamilia.Name = "uiFamilia";
            this.uiFamilia.Size = new System.Drawing.Size(175, 21);
            this.uiFamilia.TabIndex = 2;
            this.uiFamilia.ValueMember = "Clave";
            // 
            // uiLinea
            // 
            this.uiLinea.DisplayMember = "Descripcion";
            this.uiLinea.FormattingEnabled = true;
            this.uiLinea.Location = new System.Drawing.Point(69, 52);
            this.uiLinea.Name = "uiLinea";
            this.uiLinea.Size = new System.Drawing.Size(175, 21);
            this.uiLinea.TabIndex = 1;
            this.uiLinea.ValueMember = "Clave";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Familia";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1209, 100);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1209, 183);
            this.panel3.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "VER EN TICKET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "ENVIAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmExistenciasValuoAgrupado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 419);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmExistenciasValuoAgrupado";
            this.Text = "Existencias Valuo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExistencias_FormClosing);
            this.Load += new System.EventHandler(this.frmExistencias_Load);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panelSup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDescuento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox uiSubfamilia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox uiFamilia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uiLinea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox uiSoloExistencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton uiSubfamiliaG;
        private System.Windows.Forms.RadioButton uiFamiliaG;
        private System.Windows.Forms.RadioButton uiLineaG;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton uiProguctoG;
        private System.Windows.Forms.NumericUpDown uiDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton uiRadioTipo;
        private System.Windows.Forms.RadioButton uiRadioTipo1;
    }
}