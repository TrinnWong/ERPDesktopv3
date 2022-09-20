namespace PuntoVenta
{
    partial class frmGastosList
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
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.gpFechas = new System.Windows.Forms.GroupBox();
            this.uiFechaFin = new System.Windows.Forms.DateTimePicker();
            this.uiFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpFolio = new System.Windows.Forms.GroupBox();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.uiBuscarFechas = new System.Windows.Forms.RadioButton();
            this.uiBuscarFolio = new System.Windows.Forms.RadioButton();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CentroCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbBotones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpFechas.SuspendLayout();
            this.gpFolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbBotones);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 159);
            this.panel1.TabIndex = 0;
            // 
            // gbBotones
            // 
            this.gbBotones.BackColor = System.Drawing.SystemColors.Control;
            this.gbBotones.Controls.Add(this.btnEliminar);
            this.gbBotones.Controls.Add(this.btnEditar);
            this.gbBotones.Controls.Add(this.btnAgregar);
            this.gbBotones.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbBotones.Location = new System.Drawing.Point(13, 98);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(841, 59);
            this.gbBotones.TabIndex = 17;
            this.gbBotones.TabStop = false;
            this.gbBotones.Text = "BOTONES";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Black;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(271, 23);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(113, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Black;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditar.Location = new System.Drawing.Point(152, 23);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(113, 30);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(33, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 30);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiBuscar);
            this.groupBox1.Controls.Add(this.gpFechas);
            this.groupBox1.Controls.Add(this.gpFolio);
            this.groupBox1.Controls.Add(this.uiBuscarFechas);
            this.groupBox1.Controls.Add(this.uiBuscarFolio);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(719, 42);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(113, 45);
            this.uiBuscar.TabIndex = 10;
            this.uiBuscar.Text = "BUSCAR";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // gpFechas
            // 
            this.gpFechas.Controls.Add(this.uiFechaFin);
            this.gpFechas.Controls.Add(this.uiFechaIni);
            this.gpFechas.Controls.Add(this.label2);
            this.gpFechas.Controls.Add(this.label1);
            this.gpFechas.Location = new System.Drawing.Point(202, 42);
            this.gpFechas.Name = "gpFechas";
            this.gpFechas.Size = new System.Drawing.Size(511, 45);
            this.gpFechas.TabIndex = 9;
            this.gpFechas.TabStop = false;
            this.gpFechas.Text = "Fechas";
            // 
            // uiFechaFin
            // 
            this.uiFechaFin.Location = new System.Drawing.Point(296, 19);
            this.uiFechaFin.Name = "uiFechaFin";
            this.uiFechaFin.Size = new System.Drawing.Size(200, 20);
            this.uiFechaFin.TabIndex = 3;
            // 
            // uiFechaIni
            // 
            this.uiFechaIni.Location = new System.Drawing.Point(54, 19);
            this.uiFechaIni.Name = "uiFechaIni";
            this.uiFechaIni.Size = new System.Drawing.Size(200, 20);
            this.uiFechaIni.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del";
            // 
            // gpFolio
            // 
            this.gpFolio.Controls.Add(this.uiFolio);
            this.gpFolio.Location = new System.Drawing.Point(7, 42);
            this.gpFolio.Name = "gpFolio";
            this.gpFolio.Size = new System.Drawing.Size(189, 45);
            this.gpFolio.TabIndex = 8;
            this.gpFolio.TabStop = false;
            this.gpFolio.Text = "Folio";
            // 
            // uiFolio
            // 
            this.uiFolio.Location = new System.Drawing.Point(36, 19);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(139, 20);
            this.uiFolio.TabIndex = 0;
            // 
            // uiBuscarFechas
            // 
            this.uiBuscarFechas.AutoSize = true;
            this.uiBuscarFechas.Location = new System.Drawing.Point(148, 19);
            this.uiBuscarFechas.Name = "uiBuscarFechas";
            this.uiBuscarFechas.Size = new System.Drawing.Size(115, 17);
            this.uiBuscarFechas.TabIndex = 7;
            this.uiBuscarFechas.Text = "Buscar Por Fechas";
            this.uiBuscarFechas.UseVisualStyleBackColor = true;
            this.uiBuscarFechas.CheckedChanged += new System.EventHandler(this.uiBuscarFechas_CheckedChanged);
            // 
            // uiBuscarFolio
            // 
            this.uiBuscarFolio.AutoSize = true;
            this.uiBuscarFolio.Checked = true;
            this.uiBuscarFolio.Location = new System.Drawing.Point(25, 19);
            this.uiBuscarFolio.Name = "uiBuscarFolio";
            this.uiBuscarFolio.Size = new System.Drawing.Size(102, 17);
            this.uiBuscarFolio.TabIndex = 6;
            this.uiBuscarFolio.TabStop = true;
            this.uiBuscarFolio.Text = "Buscar Por Folio";
            this.uiBuscarFolio.UseVisualStyleBackColor = true;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.CentroCosto,
            this.Concepto,
            this.Observaciones,
            this.Monto});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 159);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(977, 344);
            this.uiGrid.TabIndex = 1;
            this.uiGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.uiGrid_CellMouseDoubleClick);
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "Folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // CentroCosto
            // 
            this.CentroCosto.DataPropertyName = "CentroCosto";
            this.CentroCosto.HeaderText = "Centro Costo";
            this.CentroCosto.Name = "CentroCosto";
            this.CentroCosto.ReadOnly = true;
            this.CentroCosto.Width = 200;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            this.Concepto.Width = 200;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.Width = 300;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // frmGastosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 503);
            this.Controls.Add(this.uiGrid);
            this.Controls.Add(this.panel1);
            this.Name = "frmGastosList";
            this.Text = "Gastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGastosList_FormClosing);
            this.Load += new System.EventHandler(this.frmGastosList_Load);
            this.panel1.ResumeLayout(false);
            this.gbBotones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpFechas.ResumeLayout(false);
            this.gpFechas.PerformLayout();
            this.gpFolio.ResumeLayout(false);
            this.gpFolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiBuscar;
        private System.Windows.Forms.GroupBox gpFechas;
        private System.Windows.Forms.DateTimePicker uiFechaFin;
        private System.Windows.Forms.DateTimePicker uiFechaIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpFolio;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.RadioButton uiBuscarFechas;
        private System.Windows.Forms.RadioButton uiBuscarFolio;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CentroCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
    }
}