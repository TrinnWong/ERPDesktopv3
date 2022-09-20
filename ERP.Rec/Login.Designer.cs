namespace ERP.Rec
{
    partial class Login
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
            this.uiUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiCaja = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario Cajero";
            // 
            // uiUsuario
            // 
            this.uiUsuario.Location = new System.Drawing.Point(107, 53);
            this.uiUsuario.Name = "uiUsuario";
            this.uiUsuario.Size = new System.Drawing.Size(169, 21);
            this.uiUsuario.TabIndex = 0;
            this.uiUsuario.Validated += new System.EventHandler(this.uiUsuario_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // uiPassword
            // 
            this.uiPassword.Location = new System.Drawing.Point(107, 81);
            this.uiPassword.Name = "uiPassword";
            this.uiPassword.PasswordChar = '*';
            this.uiPassword.Size = new System.Drawing.Size(169, 21);
            this.uiPassword.TabIndex = 1;
            this.uiPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiPassword_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Caja";
            // 
            // uiCaja
            // 
            this.uiCaja.DisplayMember = "Descripcion";
            this.uiCaja.FormattingEnabled = true;
            this.uiCaja.Location = new System.Drawing.Point(107, 134);
            this.uiCaja.Name = "uiCaja";
            this.uiCaja.Size = new System.Drawing.Size(169, 21);
            this.uiCaja.TabIndex = 3;
            this.uiCaja.ValueMember = "Clave";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "INGRESAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "SALIR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sucursal";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(107, 107);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(169, 21);
            this.uiSucursal.TabIndex = 2;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 220);
            this.Controls.Add(this.uiSucursal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiCaja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiUsuario);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(344, 276);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(338, 259);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox uiCaja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox uiSucursal;
    }
}