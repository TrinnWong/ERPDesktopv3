namespace ERP.Common.Forms
{
    partial class frmApartadosListCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.uiCliente = new System.Windows.Forms.TextBox();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.uiSoloConSaldo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // uiCliente
            // 
            this.uiCliente.Enabled = false;
            this.uiCliente.Location = new System.Drawing.Point(75, 10);
            this.uiCliente.Name = "uiCliente";
            this.uiCliente.Size = new System.Drawing.Size(477, 20);
            this.uiCliente.TabIndex = 1;
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Location = new System.Drawing.Point(12, 47);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(844, 311);
            this.uiGrid.TabIndex = 2;
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // uiSoloConSaldo
            // 
            this.uiSoloConSaldo.AutoSize = true;
            this.uiSoloConSaldo.Checked = true;
            this.uiSoloConSaldo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiSoloConSaldo.Location = new System.Drawing.Point(567, 12);
            this.uiSoloConSaldo.Name = "uiSoloConSaldo";
            this.uiSoloConSaldo.Size = new System.Drawing.Size(96, 17);
            this.uiSoloConSaldo.TabIndex = 7;
            this.uiSoloConSaldo.Text = "Solo con saldo";
            this.uiSoloConSaldo.UseVisualStyleBackColor = true;
            this.uiSoloConSaldo.CheckedChanged += new System.EventHandler(this.uiSoloConSaldo_CheckedChanged);
            // 
            // frmApartadosListCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 370);
            this.Controls.Add(this.uiSoloConSaldo);
            this.Controls.Add(this.uiGrid);
            this.Controls.Add(this.uiCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmApartadosListCliente";
            this.Text = "Apartados por Cliente";
            this.Load += new System.EventHandler(this.frmApartadosListCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiCliente;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.CheckBox uiSoloConSaldo;
    }
}