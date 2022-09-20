namespace ERP.Common.Procesos
{
    partial class frmCorteCajaPrevioList
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
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.uiGenerar = new System.Windows.Forms.Button();
            this.uiReimprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Location = new System.Drawing.Point(12, 51);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(846, 357);
            this.uiGrid.TabIndex = 0;
            // 
            // uiGenerar
            // 
            this.uiGenerar.Location = new System.Drawing.Point(12, 12);
            this.uiGenerar.Name = "uiGenerar";
            this.uiGenerar.Size = new System.Drawing.Size(202, 33);
            this.uiGenerar.TabIndex = 1;
            this.uiGenerar.Text = "GENERAR CORTE PARCIAL";
            this.uiGenerar.UseVisualStyleBackColor = true;
            this.uiGenerar.Click += new System.EventHandler(this.uiGenerar_Click);
            // 
            // uiReimprimir
            // 
            this.uiReimprimir.Location = new System.Drawing.Point(220, 12);
            this.uiReimprimir.Name = "uiReimprimir";
            this.uiReimprimir.Size = new System.Drawing.Size(202, 33);
            this.uiReimprimir.TabIndex = 2;
            this.uiReimprimir.Text = "REIMPRIMIR";
            this.uiReimprimir.UseVisualStyleBackColor = true;
            this.uiReimprimir.Click += new System.EventHandler(this.uiReimprimir_Click);
            // 
            // frmCorteCajaPrevioList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 445);
            this.Controls.Add(this.uiReimprimir);
            this.Controls.Add(this.uiGenerar);
            this.Controls.Add(this.uiGrid);
            this.Name = "frmCorteCajaPrevioList";
            this.Text = "Corte de Caja Parcial";
            this.Load += new System.EventHandler(this.frmCorteCajaPrevioList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Button uiGenerar;
        private System.Windows.Forms.Button uiReimprimir;
    }
}