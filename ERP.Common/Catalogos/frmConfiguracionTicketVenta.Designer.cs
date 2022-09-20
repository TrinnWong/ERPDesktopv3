namespace ERP.Common.Catalogos
{
    partial class frmConfiguracionTicketVenta
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
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.uiTextoPie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiTextoCabcecera2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTextoCabecera1 = new System.Windows.Forms.TextBox();
            this.uiID = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sucursal";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(82, 13);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(281, 21);
            this.uiSucursal.TabIndex = 1;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiSerie);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.uiGuardar);
            this.groupBox1.Controls.Add(this.uiCancelar);
            this.groupBox1.Controls.Add(this.uiTextoPie);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.uiTextoCabcecera2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.uiTextoCabecera1);
            this.groupBox1.Location = new System.Drawing.Point(31, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 448);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captura";
            // 
            // uiSerie
            // 
            this.uiSerie.Location = new System.Drawing.Point(147, 37);
            this.uiSerie.MaxLength = 5;
            this.uiSerie.Name = "uiSerie";
            this.uiSerie.Size = new System.Drawing.Size(100, 20);
            this.uiSerie.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Serie";
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(350, 376);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(130, 47);
            this.uiGuardar.TabIndex = 7;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(486, 376);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(130, 47);
            this.uiCancelar.TabIndex = 6;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiTextoPie
            // 
            this.uiTextoPie.Location = new System.Drawing.Point(147, 275);
            this.uiTextoPie.MaxLength = 250;
            this.uiTextoPie.Multiline = true;
            this.uiTextoPie.Name = "uiTextoPie";
            this.uiTextoPie.Size = new System.Drawing.Size(468, 78);
            this.uiTextoPie.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Texto en Pie de Ticket";
            // 
            // uiTextoCabcecera2
            // 
            this.uiTextoCabcecera2.Location = new System.Drawing.Point(147, 173);
            this.uiTextoCabcecera2.MaxLength = 250;
            this.uiTextoCabcecera2.Multiline = true;
            this.uiTextoCabcecera2.Name = "uiTextoCabcecera2";
            this.uiTextoCabcecera2.Size = new System.Drawing.Size(468, 82);
            this.uiTextoCabcecera2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Texto 2 en Cabecera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texto 1 en Cabecera";
            // 
            // uiTextoCabecera1
            // 
            this.uiTextoCabecera1.Location = new System.Drawing.Point(147, 80);
            this.uiTextoCabecera1.MaxLength = 250;
            this.uiTextoCabecera1.Multiline = true;
            this.uiTextoCabecera1.Name = "uiTextoCabecera1";
            this.uiTextoCabecera1.Size = new System.Drawing.Size(468, 84);
            this.uiTextoCabecera1.TabIndex = 0;
            // 
            // uiID
            // 
            this.uiID.Location = new System.Drawing.Point(588, 13);
            this.uiID.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.uiID.Name = "uiID";
            this.uiID.Size = new System.Drawing.Size(120, 20);
            this.uiID.TabIndex = 4;
            this.uiID.Visible = false;
            // 
            // frmConfiguracionTicketVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 520);
            this.Controls.Add(this.uiID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiSucursal);
            this.Controls.Add(this.label1);
            this.Name = "frmConfiguracionTicketVenta";
            this.Text = "Configuración Ticket de Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguracionTicketVenta_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguracionTicketVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiGuardar;
        private System.Windows.Forms.Button uiCancelar;
        private System.Windows.Forms.TextBox uiTextoPie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiTextoCabcecera2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiTextoCabecera1;
        private System.Windows.Forms.NumericUpDown uiID;
        private System.Windows.Forms.TextBox uiSerie;
        private System.Windows.Forms.Label label5;
    }
}