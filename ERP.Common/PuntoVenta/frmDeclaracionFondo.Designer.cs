namespace ERP.Common.PuntoVenta
{
    partial class frmDeclaracionFondo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiTerminar = new System.Windows.Forms.Button();
            this.uiTotal2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiTotal1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uiContinuar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiGrid2 = new System.Windows.Forms.DataGridView();
            this.clave2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiGrid1 = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "DECLARACIÓN DE FONDO";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 10);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uiTerminar);
            this.panel3.Controls.Add(this.uiTotal2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.uiTotal1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.uiContinuar);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1147, 449);
            this.panel3.TabIndex = 2;
            // 
            // uiTerminar
            // 
            this.uiTerminar.Enabled = false;
            this.uiTerminar.Location = new System.Drawing.Point(588, 390);
            this.uiTerminar.Name = "uiTerminar";
            this.uiTerminar.Size = new System.Drawing.Size(552, 50);
            this.uiTerminar.TabIndex = 7;
            this.uiTerminar.Text = "FINALIZAR";
            this.uiTerminar.UseVisualStyleBackColor = true;
            this.uiTerminar.Click += new System.EventHandler(this.uiTerminar_Click);
            // 
            // uiTotal2
            // 
            this.uiTotal2.DecimalPlaces = 2;
            this.uiTotal2.Enabled = false;
            this.uiTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal2.Location = new System.Drawing.Point(998, 362);
            this.uiTotal2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiTotal2.Name = "uiTotal2";
            this.uiTotal2.Size = new System.Drawing.Size(139, 30);
            this.uiTotal2.TabIndex = 6;
            this.uiTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(950, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TOTAL";
            // 
            // uiTotal1
            // 
            this.uiTotal1.DecimalPlaces = 2;
            this.uiTotal1.Enabled = false;
            this.uiTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal1.Location = new System.Drawing.Point(431, 362);
            this.uiTotal1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiTotal1.Name = "uiTotal1";
            this.uiTotal1.Size = new System.Drawing.Size(139, 30);
            this.uiTotal1.TabIndex = 4;
            this.uiTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "TOTAL";
            // 
            // uiContinuar
            // 
            this.uiContinuar.Location = new System.Drawing.Point(18, 390);
            this.uiContinuar.Name = "uiContinuar";
            this.uiContinuar.Size = new System.Drawing.Size(552, 50);
            this.uiContinuar.TabIndex = 2;
            this.uiContinuar.Text = "CONTINAR CON LA CONFIRMACIÓN";
            this.uiContinuar.UseVisualStyleBackColor = true;
            this.uiContinuar.Click += new System.EventHandler(this.uiContinuar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiGrid2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(579, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 346);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONFIRMACIÓN";
            // 
            // uiGrid2
            // 
            this.uiGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clave2,
            this.descripcion2,
            this.valor2,
            this.cantidad2,
            this.total2});
            this.uiGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid2.Location = new System.Drawing.Point(3, 16);
            this.uiGrid2.Name = "uiGrid2";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGrid2.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uiGrid2.Size = new System.Drawing.Size(555, 327);
            this.uiGrid2.TabIndex = 1;
            this.uiGrid2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid2_CellContentClick);
            this.uiGrid2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid2_CellEndEdit);
            // 
            // clave2
            // 
            this.clave2.DataPropertyName = "clave";
            this.clave2.HeaderText = "Clave";
            this.clave2.Name = "clave2";
            this.clave2.ReadOnly = true;
            this.clave2.Width = 50;
            // 
            // descripcion2
            // 
            this.descripcion2.DataPropertyName = "descripcion";
            this.descripcion2.HeaderText = "Denominación";
            this.descripcion2.Name = "descripcion2";
            this.descripcion2.ReadOnly = true;
            this.descripcion2.Visible = false;
            this.descripcion2.Width = 200;
            // 
            // valor2
            // 
            this.valor2.DataPropertyName = "valor";
            this.valor2.HeaderText = "Valor";
            this.valor2.Name = "valor2";
            this.valor2.ReadOnly = true;
            // 
            // cantidad2
            // 
            this.cantidad2.DataPropertyName = "cantidad";
            this.cantidad2.HeaderText = "Cantidad";
            this.cantidad2.Name = "cantidad2";
            // 
            // total2
            // 
            this.total2.DataPropertyName = "total";
            this.total2.HeaderText = "Total";
            this.total2.Name = "total2";
            this.total2.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiGrid1);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAPTURA DE DENOMINACIONES";
            // 
            // uiGrid1
            // 
            this.uiGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Denominacion,
            this.Valor,
            this.Cantidad,
            this.Total});
            this.uiGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid1.Location = new System.Drawing.Point(3, 16);
            this.uiGrid1.Name = "uiGrid1";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGrid1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.uiGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uiGrid1.Size = new System.Drawing.Size(555, 327);
            this.uiGrid1.TabIndex = 0;
            this.uiGrid1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid1_CellEndEdit);
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.Width = 50;
            // 
            // Denominacion
            // 
            this.Denominacion.DataPropertyName = "Descripcion";
            this.Denominacion.HeaderText = "Denominación";
            this.Denominacion.Name = "Denominacion";
            this.Denominacion.Visible = false;
            this.Denominacion.Width = 200;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // frmDeclaracionFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 504);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDeclaracionFondo";
            this.Text = "Declaración de Fondo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDeclaracionFondo_FormClosing);
            this.Load += new System.EventHandler(this.frmDeclaracionFondo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView uiGrid1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiGrid2;
        private System.Windows.Forms.Button uiContinuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.NumericUpDown uiTotal1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uiTerminar;
        private System.Windows.Forms.NumericUpDown uiTotal2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad2;
        private System.Windows.Forms.DataGridViewTextBoxColumn total2;
    }
}