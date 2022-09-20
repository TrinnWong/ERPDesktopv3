namespace ERPv1.Productos
{
    partial class frmProductosGroupUpd
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
            this.uiClave = new System.Windows.Forms.TextBox();
            this.uiProducto = new System.Windows.Forms.TextBox();
            this.uiBuscarProducto = new System.Windows.Forms.Button();
            this.grDetalle = new System.Windows.Forms.GroupBox();
            this.uiEspecificaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.uiEliminar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uiGridDetalle = new System.Windows.Forms.DataGridView();
            this.uiBuscarProducto2 = new System.Windows.Forms.Button();
            this.uiProducto2 = new System.Windows.Forms.TextBox();
            this.uiClave2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDescCorta = new System.Windows.Forms.TextBox();
            this.uiLiquidacion = new System.Windows.Forms.CheckBox();
            this.panelSup.SuspendLayout();
            this.grDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Size = new System.Drawing.Size(989, 36);
            // 
            // button1
            // 
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Producto Base";
            // 
            // uiClave
            // 
            this.uiClave.Location = new System.Drawing.Point(105, 48);
            this.uiClave.Name = "uiClave";
            this.uiClave.Size = new System.Drawing.Size(100, 20);
            this.uiClave.TabIndex = 3;
            this.uiClave.Validated += new System.EventHandler(this.uiClave_Validated);
            // 
            // uiProducto
            // 
            this.uiProducto.Enabled = false;
            this.uiProducto.Location = new System.Drawing.Point(267, 48);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Size = new System.Drawing.Size(650, 20);
            this.uiProducto.TabIndex = 4;
            // 
            // uiBuscarProducto
            // 
            this.uiBuscarProducto.Location = new System.Drawing.Point(211, 46);
            this.uiBuscarProducto.Name = "uiBuscarProducto";
            this.uiBuscarProducto.Size = new System.Drawing.Size(50, 23);
            this.uiBuscarProducto.TabIndex = 5;
            this.uiBuscarProducto.Text = "...";
            this.uiBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // grDetalle
            // 
            this.grDetalle.Controls.Add(this.uiEspecificaciones);
            this.grDetalle.Controls.Add(this.label3);
            this.grDetalle.Controls.Add(this.button3);
            this.grDetalle.Controls.Add(this.uiEliminar);
            this.grDetalle.Controls.Add(this.button2);
            this.grDetalle.Controls.Add(this.uiGridDetalle);
            this.grDetalle.Controls.Add(this.uiBuscarProducto2);
            this.grDetalle.Controls.Add(this.uiProducto2);
            this.grDetalle.Controls.Add(this.uiClave2);
            this.grDetalle.Controls.Add(this.label2);
            this.grDetalle.Enabled = false;
            this.grDetalle.Location = new System.Drawing.Point(24, 98);
            this.grDetalle.Name = "grDetalle";
            this.grDetalle.Size = new System.Drawing.Size(900, 400);
            this.grDetalle.TabIndex = 6;
            this.grDetalle.TabStop = false;
            this.grDetalle.Text = "Detalle (Guarde un producto base para habilitar esta sección)";
            // 
            // uiEspecificaciones
            // 
            this.uiEspecificaciones.Enabled = false;
            this.uiEspecificaciones.Location = new System.Drawing.Point(99, 284);
            this.uiEspecificaciones.MaxLength = 500;
            this.uiEspecificaciones.Multiline = true;
            this.uiEspecificaciones.Name = "uiEspecificaciones";
            this.uiEspecificaciones.Size = new System.Drawing.Size(500, 100);
            this.uiEspecificaciones.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Especificaciones";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(696, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Masivo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // uiEliminar
            // 
            this.uiEliminar.Location = new System.Drawing.Point(615, 25);
            this.uiEliminar.Name = "uiEliminar";
            this.uiEliminar.Size = new System.Drawing.Size(75, 23);
            this.uiEliminar.TabIndex = 12;
            this.uiEliminar.Text = "Eliminar";
            this.uiEliminar.UseVisualStyleBackColor = true;
            this.uiEliminar.Click += new System.EventHandler(this.uiEliminar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(534, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiGridDetalle
            // 
            this.uiGridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridDetalle.Location = new System.Drawing.Point(35, 72);
            this.uiGridDetalle.Name = "uiGridDetalle";
            this.uiGridDetalle.Size = new System.Drawing.Size(850, 200);
            this.uiGridDetalle.TabIndex = 10;
            // 
            // uiBuscarProducto2
            // 
            this.uiBuscarProducto2.Location = new System.Drawing.Point(212, 27);
            this.uiBuscarProducto2.Name = "uiBuscarProducto2";
            this.uiBuscarProducto2.Size = new System.Drawing.Size(50, 23);
            this.uiBuscarProducto2.TabIndex = 9;
            this.uiBuscarProducto2.Text = "...";
            this.uiBuscarProducto2.UseVisualStyleBackColor = true;
            // 
            // uiProducto2
            // 
            this.uiProducto2.Enabled = false;
            this.uiProducto2.Location = new System.Drawing.Point(268, 29);
            this.uiProducto2.Name = "uiProducto2";
            this.uiProducto2.Size = new System.Drawing.Size(250, 20);
            this.uiProducto2.TabIndex = 8;
            // 
            // uiClave2
            // 
            this.uiClave2.Location = new System.Drawing.Point(106, 29);
            this.uiClave2.Name = "uiClave2";
            this.uiClave2.Size = new System.Drawing.Size(100, 20);
            this.uiClave2.TabIndex = 7;
            this.uiClave2.Validated += new System.EventHandler(this.uiClave2_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Producto Detalle";
            // 
            // uiDescCorta
            // 
            this.uiDescCorta.Enabled = false;
            this.uiDescCorta.Location = new System.Drawing.Point(267, 73);
            this.uiDescCorta.Name = "uiDescCorta";
            this.uiDescCorta.Size = new System.Drawing.Size(500, 20);
            this.uiDescCorta.TabIndex = 7;
            // 
            // uiLiquidacion
            // 
            this.uiLiquidacion.AutoSize = true;
            this.uiLiquidacion.Location = new System.Drawing.Point(837, 76);
            this.uiLiquidacion.Name = "uiLiquidacion";
            this.uiLiquidacion.Size = new System.Drawing.Size(80, 17);
            this.uiLiquidacion.TabIndex = 8;
            this.uiLiquidacion.Text = "Liquidación";
            this.uiLiquidacion.UseVisualStyleBackColor = true;
            // 
            // frmProductosGroupUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 597);
            this.Controls.Add(this.uiLiquidacion);
            this.Controls.Add(this.uiDescCorta);
            this.Controls.Add(this.grDetalle);
            this.Controls.Add(this.uiBuscarProducto);
            this.Controls.Add(this.uiProducto);
            this.Controls.Add(this.uiClave);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmProductosGroupUpd";
            this.Text = "Agrupador de Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductosGroupUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmProductosGroupUpd_Load);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.uiClave, 0);
            this.Controls.SetChildIndex(this.uiProducto, 0);
            this.Controls.SetChildIndex(this.uiBuscarProducto, 0);
            this.Controls.SetChildIndex(this.grDetalle, 0);
            this.Controls.SetChildIndex(this.uiDescCorta, 0);
            this.Controls.SetChildIndex(this.uiLiquidacion, 0);
            this.panelSup.ResumeLayout(false);
            this.grDetalle.ResumeLayout(false);
            this.grDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiClave;
        private System.Windows.Forms.TextBox uiProducto;
        private System.Windows.Forms.Button uiBuscarProducto;
        private System.Windows.Forms.GroupBox grDetalle;
        private System.Windows.Forms.DataGridView uiGridDetalle;
        private System.Windows.Forms.Button uiBuscarProducto2;
        private System.Windows.Forms.TextBox uiProducto2;
        private System.Windows.Forms.TextBox uiClave2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox uiDescCorta;
        private System.Windows.Forms.Button uiEliminar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox uiEspecificaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox uiLiquidacion;
    }
}