namespace ERPv1.Productos
{
    partial class frmProductosGrouplist
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiEliminar = new System.Windows.Forms.Button();
            this.uiAgregar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.uiTextBuscar = new System.Windows.Forms.TextBox();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiEliminar);
            this.groupBox1.Controls.Add(this.uiAgregar);
            this.groupBox1.Location = new System.Drawing.Point(17, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Botones";
            // 
            // uiEliminar
            // 
            this.uiEliminar.Location = new System.Drawing.Point(136, 19);
            this.uiEliminar.Name = "uiEliminar";
            this.uiEliminar.Size = new System.Drawing.Size(111, 33);
            this.uiEliminar.TabIndex = 2;
            this.uiEliminar.Text = "Eliminar";
            this.uiEliminar.UseVisualStyleBackColor = true;
            this.uiEliminar.Click += new System.EventHandler(this.uiEliminar_Click);
            // 
            // uiAgregar
            // 
            this.uiAgregar.Location = new System.Drawing.Point(19, 20);
            this.uiAgregar.Name = "uiAgregar";
            this.uiAgregar.Size = new System.Drawing.Size(111, 33);
            this.uiAgregar.TabIndex = 0;
            this.uiAgregar.Text = "Agregar";
            this.uiAgregar.UseVisualStyleBackColor = true;
            this.uiAgregar.Click += new System.EventHandler(this.uiAgregar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiBuscar);
            this.groupBox2.Controls.Add(this.uiTextBuscar);
            this.groupBox2.Location = new System.Drawing.Point(17, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(855, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(552, 9);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(111, 33);
            this.uiBuscar.TabIndex = 1;
            this.uiBuscar.Text = "Buscar";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // uiTextBuscar
            // 
            this.uiTextBuscar.Location = new System.Drawing.Point(19, 19);
            this.uiTextBuscar.Name = "uiTextBuscar";
            this.uiTextBuscar.Size = new System.Drawing.Size(527, 20);
            this.uiTextBuscar.TabIndex = 0;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Location = new System.Drawing.Point(17, 143);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(930, 352);
            this.uiGrid.TabIndex = 2;
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // frmProductosGrouplist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 507);
            this.Controls.Add(this.uiGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProductosGrouplist";
            this.Text = "Productos Agrupados - Listado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductosGrouplist_FormClosing);
            this.Load += new System.EventHandler(this.frmProductosGrouplist_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiEliminar;
        private System.Windows.Forms.Button uiAgregar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button uiBuscar;
        private System.Windows.Forms.TextBox uiTextBuscar;
        private System.Windows.Forms.DataGridView uiGrid;
    }
}