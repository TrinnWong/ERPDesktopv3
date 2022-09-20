namespace PuntoVenta
{
    partial class frmCorteCaja
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uiSalir = new System.Windows.Forms.Button();
            this.uiReimprimir = new System.Windows.Forms.Button();
            this.uiGenerar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.uiAl = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiDel = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.uiSalir);
            this.panel1.Controls.Add(this.uiReimprimir);
            this.panel1.Controls.Add(this.uiGenerar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 105);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "CORTE PARCIAL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "VOLVER A ENVIAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiSalir
            // 
            this.uiSalir.Location = new System.Drawing.Point(583, 6);
            this.uiSalir.Name = "uiSalir";
            this.uiSalir.Size = new System.Drawing.Size(118, 32);
            this.uiSalir.TabIndex = 3;
            this.uiSalir.Text = "SALIR";
            this.uiSalir.UseVisualStyleBackColor = true;
            this.uiSalir.Click += new System.EventHandler(this.uiSalir_Click);
            // 
            // uiReimprimir
            // 
            this.uiReimprimir.Location = new System.Drawing.Point(216, 4);
            this.uiReimprimir.Name = "uiReimprimir";
            this.uiReimprimir.Size = new System.Drawing.Size(118, 32);
            this.uiReimprimir.TabIndex = 2;
            this.uiReimprimir.Text = "REIMPRIMIR";
            this.uiReimprimir.UseVisualStyleBackColor = true;
            this.uiReimprimir.Click += new System.EventHandler(this.uiReimprimir_Click);
            // 
            // uiGenerar
            // 
            this.uiGenerar.Location = new System.Drawing.Point(13, 4);
            this.uiGenerar.Name = "uiGenerar";
            this.uiGenerar.Size = new System.Drawing.Size(197, 32);
            this.uiGenerar.TabIndex = 1;
            this.uiGenerar.Text = "GENERAR CORTE DE CAJA";
            this.uiGenerar.UseVisualStyleBackColor = true;
            this.uiGenerar.Click += new System.EventHandler(this.uiGenerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiBuscar);
            this.groupBox1.Controls.Add(this.uiAl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.uiDel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(493, 19);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(118, 32);
            this.uiBuscar.TabIndex = 4;
            this.uiBuscar.Text = "BUSCAR";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // uiAl
            // 
            this.uiAl.Location = new System.Drawing.Point(287, 24);
            this.uiAl.Name = "uiAl";
            this.uiAl.Size = new System.Drawing.Size(200, 20);
            this.uiAl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Al";
            // 
            // uiDel
            // 
            this.uiDel.Location = new System.Drawing.Point(47, 24);
            this.uiDel.Name = "uiDel";
            this.uiDel.Size = new System.Drawing.Size(200, 20);
            this.uiDel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 260);
            this.panel2.TabIndex = 1;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FechaHora,
            this.Total});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(891, 260);
            this.uiGrid.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "CorteCajaId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // FechaHora
            // 
            this.FechaHora.DataPropertyName = "CreadoEl";
            this.FechaHora.HeaderText = "Fecha y Hora";
            this.FechaHora.Name = "FechaHora";
            this.FechaHora.ReadOnly = true;
            this.FechaHora.Width = 300;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalCorte";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 300;
            // 
            // frmCorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 365);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCorteCaja";
            this.Text = "Cortes de Caja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCorteCaja_FormClosing);
            this.Load += new System.EventHandler(this.frmCorteCaja_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button uiSalir;
        private System.Windows.Forms.Button uiReimprimir;
        private System.Windows.Forms.Button uiGenerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiBuscar;
        private System.Windows.Forms.DateTimePicker uiAl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker uiDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}