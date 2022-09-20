namespace Productos
{
    partial class frmBuscarCompra
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
            this.uiGridClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.uiFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiFechaFin = new System.Windows.Forms.DateTimePicker();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGridClientes
            // 
            this.uiGridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.Proveedor,
            this.Fecha,
            this.Total,
            this.Activo});
            this.uiGridClientes.Location = new System.Drawing.Point(13, 53);
            this.uiGridClientes.Name = "uiGridClientes";
            this.uiGridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiGridClientes.Size = new System.Drawing.Size(915, 224);
            this.uiGridClientes.TabIndex = 2;
            this.uiGridClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridClientes_CellDoubleClick);
            this.uiGridClientes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiGridClientes_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio";
            // 
            // uiFechaInicio
            // 
            this.uiFechaInicio.Location = new System.Drawing.Point(94, 22);
            this.uiFechaInicio.Name = "uiFechaInicio";
            this.uiFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.uiFechaInicio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Fin";
            // 
            // uiFechaFin
            // 
            this.uiFechaFin.Location = new System.Drawing.Point(416, 22);
            this.uiFechaFin.Name = "uiFechaFin";
            this.uiFechaFin.Size = new System.Drawing.Size(200, 20);
            this.uiFechaFin.TabIndex = 3;
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(632, 22);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(145, 23);
            this.uiBuscar.TabIndex = 4;
            this.uiBuscar.Text = "BUSCAR";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "proveedor";
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 450;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            // 
            // frmBuscarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 289);
            this.Controls.Add(this.uiBuscar);
            this.Controls.Add(this.uiFechaFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiFechaInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiGridClientes);
            this.MaximizeBox = false;
            this.Name = "frmBuscarCompra";
            this.Text = "Buscar Compras";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGridClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView uiGridClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker uiFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker uiFechaFin;
        private System.Windows.Forms.Button uiBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
    }
}