namespace ERP.Common.Procesos
{
    partial class frmImpProductoReimpresion
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
            this.uiReimprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Location = new System.Drawing.Point(12, 41);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1035, 411);
            this.uiGrid.TabIndex = 0;
            // 
            // uiReimprimir
            // 
            this.uiReimprimir.Location = new System.Drawing.Point(12, 3);
            this.uiReimprimir.Name = "uiReimprimir";
            this.uiReimprimir.Size = new System.Drawing.Size(228, 35);
            this.uiReimprimir.TabIndex = 1;
            this.uiReimprimir.Text = "REIMPRIMIR";
            this.uiReimprimir.UseVisualStyleBackColor = true;
            this.uiReimprimir.Click += new System.EventHandler(this.uiReimprimir_Click);
            // 
            // frmImpProductoReimpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 476);
            this.Controls.Add(this.uiReimprimir);
            this.Controls.Add(this.uiGrid);
            this.Name = "frmImpProductoReimpresion";
            this.Text = "frmImpProductoReimpresion";
            this.Load += new System.EventHandler(this.frmImpProductoReimpresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Button uiReimprimir;
    }
}