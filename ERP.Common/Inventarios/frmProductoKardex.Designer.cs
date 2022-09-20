namespace ERP.Common.Inventarios
{
    partial class frmProductoKardex
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
            this.button1 = new System.Windows.Forms.Button();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiDescripcionProd = new System.Windows.Forms.TextBox();
            this.uiClaveProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.FechaMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SucursalMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SucOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SucDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolioMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaveProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValCostoUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValCostoPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.uiSucursal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.uiDescripcionProd);
            this.panel1.Controls.Add(this.uiClaveProd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 74);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.Enabled = false;
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(66, 42);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(167, 21);
            this.uiSucursal.TabIndex = 5;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sucursal";
            // 
            // uiDescripcionProd
            // 
            this.uiDescripcionProd.Enabled = false;
            this.uiDescripcionProd.Location = new System.Drawing.Point(366, 43);
            this.uiDescripcionProd.Name = "uiDescripcionProd";
            this.uiDescripcionProd.Size = new System.Drawing.Size(371, 20);
            this.uiDescripcionProd.TabIndex = 3;
            // 
            // uiClaveProd
            // 
            this.uiClaveProd.Location = new System.Drawing.Point(298, 43);
            this.uiClaveProd.Name = "uiClaveProd";
            this.uiClaveProd.Size = new System.Drawing.Size(66, 20);
            this.uiClaveProd.TabIndex = 2;
            this.uiClaveProd.Validating += new System.ComponentModel.CancelEventHandler(this.uiClaveProd_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kardex de Producto";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1261, 325);
            this.panel2.TabIndex = 1;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaMov,
            this.SucursalMov,
            this.SucOrigen,
            this.SucDestino,
            this.FolioMov,
            this.Movimiento,
            this.ClaveProd,
            this.Producto,
            this.CantEntrada,
            this.CantSalida,
            this.Existencia,
            this.CostoUltimaCompra,
            this.CostoPromedio,
            this.ValorMovimiento,
            this.ValCostoUltimaCompra,
            this.ValCostoPromedio,
            this.Comentarios});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1261, 325);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellContentClick);
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // FechaMov
            // 
            this.FechaMov.DataPropertyName = "FechaMov";
            this.FechaMov.HeaderText = "Fecha Mov.";
            this.FechaMov.Name = "FechaMov";
            this.FechaMov.Width = 120;
            // 
            // SucursalMov
            // 
            this.SucursalMov.DataPropertyName = "SucursalMov";
            this.SucursalMov.HeaderText = "Sucursal Mov.";
            this.SucursalMov.Name = "SucursalMov";
            this.SucursalMov.ReadOnly = true;
            this.SucursalMov.Width = 80;
            // 
            // SucOrigen
            // 
            this.SucOrigen.DataPropertyName = "SucursalOrigen";
            this.SucOrigen.HeaderText = "SucOrigen";
            this.SucOrigen.Name = "SucOrigen";
            this.SucOrigen.ReadOnly = true;
            this.SucOrigen.Width = 80;
            // 
            // SucDestino
            // 
            this.SucDestino.DataPropertyName = "SucursalDestino";
            this.SucDestino.HeaderText = "SucDestino";
            this.SucDestino.Name = "SucDestino";
            this.SucDestino.ReadOnly = true;
            this.SucDestino.Width = 80;
            // 
            // FolioMov
            // 
            this.FolioMov.DataPropertyName = "FolioMov";
            this.FolioMov.HeaderText = "Folio Mov.";
            this.FolioMov.Name = "FolioMov";
            this.FolioMov.ReadOnly = true;
            this.FolioMov.Width = 50;
            // 
            // Movimiento
            // 
            this.Movimiento.DataPropertyName = "Movimiento";
            this.Movimiento.HeaderText = "Movimiento";
            this.Movimiento.Name = "Movimiento";
            this.Movimiento.ReadOnly = true;
            // 
            // ClaveProd
            // 
            this.ClaveProd.DataPropertyName = "clave";
            this.ClaveProd.HeaderText = "Clave Prod.";
            this.ClaveProd.Name = "ClaveProd";
            this.ClaveProd.ReadOnly = true;
            this.ClaveProd.Width = 60;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "DescripcionCorta";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 200;
            // 
            // CantEntrada
            // 
            this.CantEntrada.DataPropertyName = "CantidadEntrada";
            this.CantEntrada.HeaderText = "Entrada";
            this.CantEntrada.Name = "CantEntrada";
            this.CantEntrada.ReadOnly = true;
            this.CantEntrada.Width = 80;
            // 
            // CantSalida
            // 
            this.CantSalida.DataPropertyName = "CantidadSalida";
            this.CantSalida.HeaderText = "Salida";
            this.CantSalida.Name = "CantSalida";
            this.CantSalida.ReadOnly = true;
            this.CantSalida.Width = 80;
            // 
            // Existencia
            // 
            this.Existencia.DataPropertyName = "Existencia";
            this.Existencia.HeaderText = "Existencia";
            this.Existencia.Name = "Existencia";
            this.Existencia.ReadOnly = true;
            this.Existencia.Width = 80;
            // 
            // CostoUltimaCompra
            // 
            this.CostoUltimaCompra.DataPropertyName = "CostoUltimaCompra";
            this.CostoUltimaCompra.HeaderText = "Cost. Ult. Compra";
            this.CostoUltimaCompra.Name = "CostoUltimaCompra";
            this.CostoUltimaCompra.ReadOnly = true;
            this.CostoUltimaCompra.Width = 80;
            // 
            // CostoPromedio
            // 
            this.CostoPromedio.DataPropertyName = "CostoPromedio";
            this.CostoPromedio.HeaderText = "Costo Promedio";
            this.CostoPromedio.Name = "CostoPromedio";
            this.CostoPromedio.ReadOnly = true;
            this.CostoPromedio.Visible = false;
            this.CostoPromedio.Width = 80;
            // 
            // ValorMovimiento
            // 
            this.ValorMovimiento.DataPropertyName = "ValorMovimiento";
            this.ValorMovimiento.HeaderText = "Valor Movimiento";
            this.ValorMovimiento.Name = "ValorMovimiento";
            this.ValorMovimiento.ReadOnly = true;
            this.ValorMovimiento.Visible = false;
            // 
            // ValCostoUltimaCompra
            // 
            this.ValCostoUltimaCompra.DataPropertyName = "ValCostoUltimaCompra";
            this.ValCostoUltimaCompra.HeaderText = "Valor Cto. Ult. Compra";
            this.ValCostoUltimaCompra.Name = "ValCostoUltimaCompra";
            this.ValCostoUltimaCompra.ReadOnly = true;
            this.ValCostoUltimaCompra.Visible = false;
            this.ValCostoUltimaCompra.Width = 80;
            // 
            // ValCostoPromedio
            // 
            this.ValCostoPromedio.DataPropertyName = "ValCostoPromedio";
            this.ValCostoPromedio.HeaderText = "Valor Cto. Promedio";
            this.ValCostoPromedio.Name = "ValCostoPromedio";
            this.ValCostoPromedio.ReadOnly = true;
            this.ValCostoPromedio.Visible = false;
            this.ValCostoPromedio.Width = 80;
            // 
            // Comentarios
            // 
            this.Comentarios.DataPropertyName = "Comentarios";
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            // 
            // frmProductoKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 399);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmProductoKardex";
            this.Text = "Kardex Producto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductoKardex_FormClosing);
            this.Load += new System.EventHandler(this.frmProductoKardex_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmProductoKardex_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox uiDescripcionProd;
        private System.Windows.Forms.TextBox uiClaveProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucursalMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaveProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUltimaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValCostoUltimaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValCostoPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
    }
}