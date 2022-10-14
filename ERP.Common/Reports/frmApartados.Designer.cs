namespace ERP.Common.Reports
{
    partial class frmApartados
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
            this.label3 = new System.Windows.Forms.Label();
            this.uiDel = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.uiAl = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.uiCliente = new System.Windows.Forms.ComboBox();
            this.uiSoloVencido = new System.Windows.Forms.CheckBox();
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
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sucursal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Del";
            // 
            // uiDel
            // 
            this.uiDel.Location = new System.Drawing.Point(87, 71);
            this.uiDel.Name = "uiDel";
            this.uiDel.Size = new System.Drawing.Size(200, 20);
            this.uiDel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Al";
            // 
            // uiAl
            // 
            this.uiAl.Location = new System.Drawing.Point(87, 100);
            this.uiAl.Name = "uiAl";
            this.uiAl.Size = new System.Drawing.Size(200, 20);
            this.uiAl.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "VER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente";
            // 
            // uiCliente
            // 
            this.uiCliente.DisplayMember = "Nombre";
            this.uiCliente.FormattingEnabled = true;
            this.uiCliente.Location = new System.Drawing.Point(87, 45);
            this.uiCliente.Name = "uiCliente";
            this.uiCliente.Size = new System.Drawing.Size(450, 21);
            this.uiCliente.TabIndex = 10;
            this.uiCliente.ValueMember = "ClienteId";
            // 
            // uiSoloVencido
            // 
            this.uiSoloVencido.AutoSize = true;
            this.uiSoloVencido.Location = new System.Drawing.Point(312, 87);
            this.uiSoloVencido.Name = "uiSoloVencido";
            this.uiSoloVencido.Size = new System.Drawing.Size(107, 19);
            this.uiSoloVencido.TabIndex = 11;
            this.uiSoloVencido.Text = "Solo Vencidos";
            this.uiSoloVencido.UseVisualStyleBackColor = true;
            this.uiSoloVencido.CheckedChanged += new System.EventHandler(this.uiSoloVencido_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "ENVIAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmApartados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 194);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiSoloVencido);
            this.Controls.Add(this.uiCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiAl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uiDel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiSucursal);
            this.Name = "frmApartados";
            this.Text = "Apartados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRptCorteCajaResumido_FormClosing);
            this.Load += new System.EventHandler(this.frmApartados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker uiDel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker uiAl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiCliente;
        private System.Windows.Forms.CheckBox uiSoloVencido;
        private System.Windows.Forms.Button button2;
    }
}