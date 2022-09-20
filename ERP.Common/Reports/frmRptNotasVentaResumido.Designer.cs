namespace ERP.Common.Reports
{
    partial class frmRptNotasVentaResumido
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
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiCaja = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiDel = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.uiAl = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(87, 17);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(259, 21);
            this.uiSucursal.TabIndex = 0;
            this.uiSucursal.ValueMember = "Clave";
            this.uiSucursal.SelectedIndexChanged += new System.EventHandler(this.uiSucursal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sucursal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Caja";
            // 
            // uiCaja
            // 
            this.uiCaja.DisplayMember = "Descripcion";
            this.uiCaja.FormattingEnabled = true;
            this.uiCaja.Location = new System.Drawing.Point(87, 50);
            this.uiCaja.Name = "uiCaja";
            this.uiCaja.Size = new System.Drawing.Size(259, 21);
            this.uiCaja.TabIndex = 3;
            this.uiCaja.ValueMember = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Del";
            // 
            // uiDel
            // 
            this.uiDel.Location = new System.Drawing.Point(87, 80);
            this.uiDel.Name = "uiDel";
            this.uiDel.Size = new System.Drawing.Size(200, 20);
            this.uiDel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Al";
            // 
            // uiAl
            // 
            this.uiAl.Location = new System.Drawing.Point(87, 109);
            this.uiAl.Name = "uiAl";
            this.uiAl.Size = new System.Drawing.Size(200, 20);
            this.uiAl.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "VER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "ENVIAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmRptNotasVentaResumido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiAl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uiDel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiCaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiSucursal);
            this.Name = "frmRptNotasVentaResumido";
            this.Text = "Notas de Venta Resumido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRptNotasVentaResumido_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiCaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker uiDel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker uiAl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}