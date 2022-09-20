namespace PuntoVenta
{
    partial class frmDevoluciones
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.DevolucionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreadoEl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbBotones.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbBotones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 79);
            this.panel1.TabIndex = 0;
            // 
            // gbBotones
            // 
            this.gbBotones.BackColor = System.Drawing.SystemColors.Control;
            this.gbBotones.Controls.Add(this.button1);
            this.gbBotones.Controls.Add(this.btnAgregar);
            this.gbBotones.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBotones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbBotones.Location = new System.Drawing.Point(12, 13);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(841, 59);
            this.gbBotones.TabIndex = 18;
            this.gbBotones.TabStop = false;
            this.gbBotones.Text = "BOTONES";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(152, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Imprimir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 314);
            this.panel2.TabIndex = 1;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevolucionId,
            this.VentaId,
            this.CreadoEl,
            this.Total});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(968, 314);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // DevolucionId
            // 
            this.DevolucionId.DataPropertyName = "DevolucionId";
            this.DevolucionId.HeaderText = "Folio Devolución";
            this.DevolucionId.Name = "DevolucionId";
            this.DevolucionId.ReadOnly = true;
            // 
            // VentaId
            // 
            this.VentaId.DataPropertyName = "VentaId";
            this.VentaId.HeaderText = "Ticket";
            this.VentaId.Name = "VentaId";
            this.VentaId.ReadOnly = true;
            // 
            // CreadoEl
            // 
            this.CreadoEl.DataPropertyName = "CreadoEl";
            this.CreadoEl.HeaderText = "FechaRegistro";
            this.CreadoEl.Name = "CreadoEl";
            this.CreadoEl.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // frmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 393);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDevoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devoluciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDevoluciones_FormClosing);
            this.panel1.ResumeLayout(false);
            this.gbBotones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolucionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreadoEl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button button1;
    }
}