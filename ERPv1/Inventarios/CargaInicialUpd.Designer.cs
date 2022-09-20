namespace ERPv1.Inventarios
{
    partial class CargaInicialUpd
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
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventarioFisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.uiVerListado = new System.Windows.Forms.CheckBox();
            this.uiSubFamilia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiFamilia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiAutorizar = new System.Windows.Forms.Button();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.uiCancelarInv = new System.Windows.Forms.Button();
            this.panelSup.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.uiCancelarInv);
            this.panelSup.Controls.Add(this.uiCancelar);
            this.panelSup.Controls.Add(this.uiAutorizar);
            this.panelSup.Size = new System.Drawing.Size(765, 36);
            this.panelSup.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSup_Paint);
            this.panelSup.Controls.SetChildIndex(this.uiGuardar, 0);
            this.panelSup.Controls.SetChildIndex(this.button1, 0);
            this.panelSup.Controls.SetChildIndex(this.uiAutorizar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiCancelar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiCancelarInv, 0);
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
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.uiGrid);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 383);
            this.panel1.TabIndex = 1;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductoId,
            this.Clave,
            this.Descripcion,
            this.CostoPromedio,
            this.UltCosto,
            this.InventarioFisico,
            this.Inv});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 100);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(765, 233);
            this.uiGrid.TabIndex = 2;
            this.uiGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.uiGrid_CellBeginEdit);
            this.uiGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellEndEdit);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "CargaInventarioId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 5;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Width = 5;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // CostoPromedio
            // 
            this.CostoPromedio.DataPropertyName = "costoPromedio";
            this.CostoPromedio.HeaderText = "Costo Promedio";
            this.CostoPromedio.Name = "CostoPromedio";
            // 
            // UltCosto
            // 
            this.UltCosto.DataPropertyName = "ultimoCosto";
            this.UltCosto.HeaderText = "Ult. Costo";
            this.UltCosto.Name = "UltCosto";
            // 
            // InventarioFisico
            // 
            this.InventarioFisico.DataPropertyName = "inventarioFisico";
            this.InventarioFisico.HeaderText = "Inv. Físico";
            this.InventarioFisico.Name = "InventarioFisico";
            // 
            // Inv
            // 
            this.Inv.DataPropertyName = "tieneCargaInicial";
            this.Inv.HeaderText = "Afecta Inv.";
            this.Inv.Name = "Inv";
            this.Inv.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.uiSucursal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.uiVerListado);
            this.panel3.Controls.Add(this.uiSubFamilia);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.uiFamilia);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 100);
            this.panel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Carga Inicial de Inventario";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.Enabled = false;
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(59, 34);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(170, 21);
            this.uiSucursal.TabIndex = 0;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sucursal";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "BUSCAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiVerListado
            // 
            this.uiVerListado.AutoSize = true;
            this.uiVerListado.Location = new System.Drawing.Point(400, 61);
            this.uiVerListado.Name = "uiVerListado";
            this.uiVerListado.Size = new System.Drawing.Size(119, 17);
            this.uiVerListado.TabIndex = 4;
            this.uiVerListado.Text = "Ver Listado General";
            this.uiVerListado.UseVisualStyleBackColor = true;
            // 
            // uiSubFamilia
            // 
            this.uiSubFamilia.DisplayMember = "Descripcion";
            this.uiSubFamilia.FormattingEnabled = true;
            this.uiSubFamilia.Location = new System.Drawing.Point(260, 59);
            this.uiSubFamilia.Name = "uiSubFamilia";
            this.uiSubFamilia.Size = new System.Drawing.Size(121, 21);
            this.uiSubFamilia.TabIndex = 2;
            this.uiSubFamilia.ValueMember = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SubFamilia";
            // 
            // uiFamilia
            // 
            this.uiFamilia.DisplayMember = "Descripcion";
            this.uiFamilia.FormattingEnabled = true;
            this.uiFamilia.Location = new System.Drawing.Point(58, 59);
            this.uiFamilia.Name = "uiFamilia";
            this.uiFamilia.Size = new System.Drawing.Size(121, 21);
            this.uiFamilia.TabIndex = 1;
            this.uiFamilia.ValueMember = "Clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Familia";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 50);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // uiAutorizar
            // 
            this.uiAutorizar.Location = new System.Drawing.Point(211, 3);
            this.uiAutorizar.Name = "uiAutorizar";
            this.uiAutorizar.Size = new System.Drawing.Size(102, 31);
            this.uiAutorizar.TabIndex = 2;
            this.uiAutorizar.Text = "AFECTAR INV.";
            this.uiAutorizar.UseVisualStyleBackColor = true;
            this.uiAutorizar.Click += new System.EventHandler(this.button3_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(315, 3);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(102, 31);
            this.uiCancelar.TabIndex = 3;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiCancelarInv
            // 
            this.uiCancelarInv.Location = new System.Drawing.Point(418, 3);
            this.uiCancelarInv.Name = "uiCancelarInv";
            this.uiCancelarInv.Size = new System.Drawing.Size(102, 31);
            this.uiCancelarInv.TabIndex = 4;
            this.uiCancelarInv.Text = "CANCELAR INV.";
            this.uiCancelarInv.UseVisualStyleBackColor = true;
            this.uiCancelarInv.Click += new System.EventHandler(this.uiCancelarInv_Click);
            // 
            // CargaInicialUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 419);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CargaInicialUpd";
            this.Text = "CargaInicialUpd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CargaInicialUpd_FormClosing);
            this.Load += new System.EventHandler(this.CargaInicialUpd_Load);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panelSup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox uiVerListado;
        private System.Windows.Forms.ComboBox uiSubFamilia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uiAutorizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventarioFisico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Inv;
        private System.Windows.Forms.Button uiCancelar;
        private System.Windows.Forms.Button uiCancelarInv;
        private System.Windows.Forms.Label label4;
    }
}