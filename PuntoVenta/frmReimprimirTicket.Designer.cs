namespace PuntoVenta
{
    partial class frmReimprimirTicket
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
            this.uiBuscarFolio = new System.Windows.Forms.RadioButton();
            this.uiBuscarFechas = new System.Windows.Forms.RadioButton();
            this.gpFolio = new System.Windows.Forms.GroupBox();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.gpFechas = new System.Windows.Forms.GroupBox();
            this.uiFechaFin = new System.Windows.Forms.DateTimePicker();
            this.uiFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTicket = new System.Windows.Forms.DataGridView();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.gpFolio.SuspendLayout();
            this.gpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // uiBuscarFolio
            // 
            this.uiBuscarFolio.AutoSize = true;
            this.uiBuscarFolio.Checked = true;
            this.uiBuscarFolio.Location = new System.Drawing.Point(30, 12);
            this.uiBuscarFolio.Name = "uiBuscarFolio";
            this.uiBuscarFolio.Size = new System.Drawing.Size(102, 17);
            this.uiBuscarFolio.TabIndex = 0;
            this.uiBuscarFolio.TabStop = true;
            this.uiBuscarFolio.Text = "Buscar Por Folio";
            this.uiBuscarFolio.UseVisualStyleBackColor = true;
            // 
            // uiBuscarFechas
            // 
            this.uiBuscarFechas.AutoSize = true;
            this.uiBuscarFechas.Location = new System.Drawing.Point(153, 12);
            this.uiBuscarFechas.Name = "uiBuscarFechas";
            this.uiBuscarFechas.Size = new System.Drawing.Size(115, 17);
            this.uiBuscarFechas.TabIndex = 1;
            this.uiBuscarFechas.Text = "Buscar Por Fechas";
            this.uiBuscarFechas.UseVisualStyleBackColor = true;
            this.uiBuscarFechas.CheckedChanged += new System.EventHandler(this.uiBuscarFechas_CheckedChanged);
            // 
            // gpFolio
            // 
            this.gpFolio.Controls.Add(this.uiFolio);
            this.gpFolio.Location = new System.Drawing.Point(12, 35);
            this.gpFolio.Name = "gpFolio";
            this.gpFolio.Size = new System.Drawing.Size(189, 45);
            this.gpFolio.TabIndex = 2;
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
            // gpFechas
            // 
            this.gpFechas.Controls.Add(this.uiFechaFin);
            this.gpFechas.Controls.Add(this.uiFechaIni);
            this.gpFechas.Controls.Add(this.label2);
            this.gpFechas.Controls.Add(this.label1);
            this.gpFechas.Location = new System.Drawing.Point(207, 35);
            this.gpFechas.Name = "gpFechas";
            this.gpFechas.Size = new System.Drawing.Size(511, 45);
            this.gpFechas.TabIndex = 3;
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
            // uiTicket
            // 
            this.uiTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.Fecha,
            this.Descuento,
            this.Subtotal,
            this.Impuestos,
            this.Total,
            this.Estatus});
            this.uiTicket.Location = new System.Drawing.Point(13, 86);
            this.uiTicket.Name = "uiTicket";
            this.uiTicket.Size = new System.Drawing.Size(824, 294);
            this.uiTicket.TabIndex = 4;
            this.uiTicket.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiTicket_CellDoubleClick);
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "descuento";
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "subtotal";
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // Impuestos
            // 
            this.Impuestos.DataPropertyName = "impuestos";
            this.Impuestos.HeaderText = "Impuestos";
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(724, 35);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(113, 45);
            this.uiBuscar.TabIndex = 5;
            this.uiBuscar.Text = "BUSCAR";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // frmReimprimirTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 392);
            this.Controls.Add(this.uiBuscar);
            this.Controls.Add(this.uiTicket);
            this.Controls.Add(this.gpFechas);
            this.Controls.Add(this.gpFolio);
            this.Controls.Add(this.uiBuscarFechas);
            this.Controls.Add(this.uiBuscarFolio);
            this.Name = "frmReimprimirTicket";
            this.Text = "Reimprimir Ticket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReimprimirTicket_FormClosing);
            this.Load += new System.EventHandler(this.frmReimprimirTicket_Load);
            this.gpFolio.ResumeLayout(false);
            this.gpFolio.PerformLayout();
            this.gpFechas.ResumeLayout(false);
            this.gpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton uiBuscarFolio;
        private System.Windows.Forms.RadioButton uiBuscarFechas;
        private System.Windows.Forms.GroupBox gpFolio;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.GroupBox gpFechas;
        private System.Windows.Forms.DateTimePicker uiFechaFin;
        private System.Windows.Forms.DateTimePicker uiFechaIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiTicket;
        private System.Windows.Forms.Button uiBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
    }
}