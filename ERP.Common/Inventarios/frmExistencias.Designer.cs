namespace ERP.Common.Inventarios
{
    partial class frmExistencias
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
            this.uiSoloExistencia = new System.Windows.Forms.CheckBox();
            this.uiProducto = new System.Windows.Forms.ComboBox();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiSubfamilia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uiFamilia = new System.Windows.Forms.ComboBox();
            this.uiLinea = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subfamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistenciaSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistenciaTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiSoloExistencia);
            this.panel1.Controls.Add(this.uiProducto);
            this.panel1.Controls.Add(this.uiSucursal);
            this.panel1.Controls.Add(this.label10);
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
            // uiSoloExistencia
            // 
            this.uiSoloExistencia.AutoSize = true;
            this.uiSoloExistencia.Checked = true;
            this.uiSoloExistencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiSoloExistencia.Location = new System.Drawing.Point(989, 54);
            this.uiSoloExistencia.Name = "uiSoloExistencia";
            this.uiSoloExistencia.Size = new System.Drawing.Size(167, 17);
            this.uiSoloExistencia.TabIndex = 12;
            this.uiSoloExistencia.Text = "Solo Articulos con Existencias";
            this.uiSoloExistencia.UseVisualStyleBackColor = true;
            // 
            // uiProducto
            // 
            this.uiProducto.DisplayMember = "Descripcion";
            this.uiProducto.FormattingEnabled = true;
            this.uiProducto.Location = new System.Drawing.Point(800, 52);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Size = new System.Drawing.Size(175, 21);
            this.uiProducto.TabIndex = 4;
            this.uiProducto.ValueMember = "ProductoId";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(753, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Producto";
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
            this.panel3.Controls.Add(this.uiGrid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1209, 183);
            this.panel3.TabIndex = 3;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Linea,
            this.Familia,
            this.Subfamilia,
            this.Clave,
            this.Producto,
            this.ExistenciaSuc,
            this.ExistenciaTot});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1209, 183);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellContentDoubleClick);
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // Linea
            // 
            this.Linea.DataPropertyName = "Linea";
            this.Linea.HeaderText = "Línea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            this.Linea.Width = 150;
            // 
            // Familia
            // 
            this.Familia.DataPropertyName = "Familia";
            this.Familia.HeaderText = "Familia";
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            this.Familia.Width = 150;
            // 
            // Subfamilia
            // 
            this.Subfamilia.DataPropertyName = "Subfamilia";
            this.Subfamilia.HeaderText = "Subfamilia";
            this.Subfamilia.Name = "Subfamilia";
            this.Subfamilia.ReadOnly = true;
            this.Subfamilia.Width = 150;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "ClaveProducto";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 200;
            // 
            // ExistenciaSuc
            // 
            this.ExistenciaSuc.DataPropertyName = "ExistenciaSucursal";
            this.ExistenciaSuc.HeaderText = "Existencia Sucursal";
            this.ExistenciaSuc.Name = "ExistenciaSuc";
            this.ExistenciaSuc.ReadOnly = true;
            // 
            // ExistenciaTot
            // 
            this.ExistenciaTot.DataPropertyName = "ExistenciaTotal";
            this.ExistenciaTot.HeaderText = "ExistenciaTotal";
            this.ExistenciaTot.Name = "ExistenciaTot";
            this.ExistenciaTot.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "IMPRIMIR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(315, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "ENVIAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmExistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 419);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmExistencias";
            this.Text = "Existencias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExistencias_FormClosing);
            this.Load += new System.EventHandler(this.frmExistencias_Load);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panelSup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox uiProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox uiSubfamilia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox uiFamilia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uiLinea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subfamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistenciaSuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistenciaTot;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox uiSoloExistencia;
        private System.Windows.Forms.Button button3;
    }
}