namespace ERP.Common.PuntoVenta
{
    partial class frmRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros));
            this.uiMonto = new DevExpress.XtraEditors.SpinEdit();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // uiMonto
            // 
            this.uiMonto.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiMonto.Location = new System.Drawing.Point(109, 44);
            this.uiMonto.Name = "uiMonto";
            this.uiMonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiMonto.Size = new System.Drawing.Size(285, 22);
            this.uiMonto.StyleController = this.layoutControl1;
            this.uiMonto.TabIndex = 6;
            this.uiMonto.EditValueChanged += new System.EventHandler(this.uiMonto_EditValueChanged);
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(255, 210);
            this.uiCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(230, 40);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 11;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.CancelarRetiro_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(16, 210);
            this.uiGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(233, 40);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 10;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.GuadarRetiros);
            // 
            // uiObservaciones
            // 
            this.uiObservaciones.Location = new System.Drawing.Point(109, 72);
            this.uiObservaciones.Name = "uiObservaciones";
            this.uiObservaciones.Size = new System.Drawing.Size(535, 132);
            this.uiObservaciones.StyleController = this.layoutControl1;
            this.uiObservaciones.TabIndex = 13;
            this.uiObservaciones.EditValueChanged += new System.EventHandler(this.uiObservaciones_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiObservaciones);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.uiMonto);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(660, 266);
            this.layoutControl1.TabIndex = 14;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(660, 266);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiMonto;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(384, 28);
            this.layoutControlItem1.Text = "Cantidad Retiro";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(475, 194);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(159, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiObservaciones;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(634, 138);
            this.layoutControlItem2.Text = "Observaciones";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGuardar;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 194);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(239, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiCancelar;
            this.layoutControlItem4.Location = new System.Drawing.Point(239, 194);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(236, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(221, 22);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Ingresa la cantidad a retirar";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(634, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(384, 28);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(250, 28);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 266);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 248);
            this.Name = "frmRetiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiros";
            this.Load += new System.EventHandler(this.frmRetiros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SpinEdit uiMonto;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraEditors.MemoEdit uiObservaciones;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}