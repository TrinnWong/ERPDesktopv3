namespace ERP.Common.Catalogos.Restaurante
{
    partial class frmComandasEdit
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
            this.uiLayout = new DevExpress.XtraLayout.LayoutControl();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGenerar = new DevExpress.XtraEditors.SimpleButton();
            this.uiFolioFin = new DevExpress.XtraEditors.SpinEdit();
            this.uiFolioInicio = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.uiLayout)).BeginInit();
            this.uiLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLayout
            // 
            this.uiLayout.Controls.Add(this.uiCancelar);
            this.uiLayout.Controls.Add(this.uiGenerar);
            this.uiLayout.Controls.Add(this.uiFolioFin);
            this.uiLayout.Controls.Add(this.uiFolioInicio);
            this.uiLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayout.Location = new System.Drawing.Point(0, 0);
            this.uiLayout.Name = "uiLayout";
            this.uiLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(560, 202, 650, 400);
            this.uiLayout.OptionsView.UseDefaultDragAndDropRendering = false;
            this.uiLayout.Root = this.layoutControlGroup1;
            this.uiLayout.Size = new System.Drawing.Size(800, 103);
            this.uiLayout.TabIndex = 0;
            this.uiLayout.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(402, 36);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(386, 22);
            this.uiCancelar.StyleController = this.uiLayout;
            this.uiCancelar.TabIndex = 7;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiGenerar
            // 
            this.uiGenerar.Location = new System.Drawing.Point(12, 36);
            this.uiGenerar.Name = "uiGenerar";
            this.uiGenerar.Size = new System.Drawing.Size(386, 22);
            this.uiGenerar.StyleController = this.uiLayout;
            this.uiGenerar.TabIndex = 6;
            this.uiGenerar.Text = "Generar";
            this.uiGenerar.Click += new System.EventHandler(this.uiGenerar_Click);
            // 
            // uiFolioFin
            // 
            this.uiFolioFin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiFolioFin.Location = new System.Drawing.Point(420, 12);
            this.uiFolioFin.Name = "uiFolioFin";
            this.uiFolioFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFolioFin.Size = new System.Drawing.Size(368, 20);
            this.uiFolioFin.StyleController = this.uiLayout;
            this.uiFolioFin.TabIndex = 5;
            // 
            // uiFolioInicio
            // 
            this.uiFolioInicio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiFolioInicio.Location = new System.Drawing.Point(30, 12);
            this.uiFolioInicio.Name = "uiFolioInicio";
            this.uiFolioInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFolioInicio.Size = new System.Drawing.Size(368, 20);
            this.uiFolioInicio.StyleController = this.uiLayout;
            this.uiFolioInicio.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 103);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiFolioInicio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem1.Text = "Del";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(15, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiFolioFin;
            this.layoutControlItem2.Location = new System.Drawing.Point(390, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem2.Text = "Al";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(15, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGenerar;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(390, 59);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiCancelar;
            this.layoutControlItem4.Location = new System.Drawing.Point(390, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(390, 59);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmComandasEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 103);
            this.Controls.Add(this.uiLayout);
            this.Name = "frmComandasEdit";
            this.Text = "Comandas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComandasEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.uiLayout)).EndInit();
            this.uiLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl uiLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton uiGenerar;
        private DevExpress.XtraEditors.SpinEdit uiFolioFin;
        private DevExpress.XtraEditors.SpinEdit uiFolioInicio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}