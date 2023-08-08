namespace ERP.Common.PuntoVenta
{
    partial class frmGastos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastos));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSalir1 = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar1 = new DevExpress.XtraEditors.SimpleButton();
            this.uiObservaciones1 = new DevExpress.XtraEditors.MemoEdit();
            this.uiMonto1 = new DevExpress.XtraEditors.SpinEdit();
            this.uiConcepto1 = new DevExpress.XtraEditors.LookUpEdit();
            this.catgastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiCentroCosto1 = new DevExpress.XtraEditors.LookUpEdit();
            this.catcentrocostosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiMontoLabel1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiObservacionesLabel1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiConcepto1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catgastosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCentroCosto1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catcentrocostosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMontoLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservacionesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.uiSalir1);
            this.layoutControl1.Controls.Add(this.uiGuardar1);
            this.layoutControl1.Controls.Add(this.uiObservaciones1);
            this.layoutControl1.Controls.Add(this.uiMonto1);
            this.layoutControl1.Controls.Add(this.uiConcepto1);
            this.layoutControl1.Controls.Add(this.uiCentroCosto1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(573, 280);
            this.layoutControl1.TabIndex = 10;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Registro de Gasto";
            // 
            // uiSalir1
            // 
            this.uiSalir1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiSalir1.ImageOptions.Image")));
            this.uiSalir1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiSalir1.Location = new System.Drawing.Point(279, 230);
            this.uiSalir1.Name = "uiSalir1";
            this.uiSalir1.Size = new System.Drawing.Size(239, 38);
            this.uiSalir1.StyleController = this.layoutControl1;
            this.uiSalir1.TabIndex = 9;
            this.uiSalir1.Text = "Salir";
            this.uiSalir1.Click += new System.EventHandler(this.uiSalir1_Click);
            // 
            // uiGuardar1
            // 
            this.uiGuardar1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar1.ImageOptions.Image")));
            this.uiGuardar1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar1.Location = new System.Drawing.Point(12, 230);
            this.uiGuardar1.Name = "uiGuardar1";
            this.uiGuardar1.Size = new System.Drawing.Size(263, 38);
            this.uiGuardar1.StyleController = this.layoutControl1;
            this.uiGuardar1.TabIndex = 8;
            this.uiGuardar1.Text = "Guardar";
            this.uiGuardar1.Click += new System.EventHandler(this.uiGuardar1_Click);
            // 
            // uiObservaciones1
            // 
            this.uiObservaciones1.Location = new System.Drawing.Point(94, 108);
            this.uiObservaciones1.Name = "uiObservaciones1";
            this.uiObservaciones1.Size = new System.Drawing.Size(467, 118);
            this.uiObservaciones1.StyleController = this.layoutControl1;
            this.uiObservaciones1.TabIndex = 7;
            this.uiObservaciones1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiObservaciones1_KeyDown);
            // 
            // uiMonto1
            // 
            this.uiMonto1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiMonto1.Location = new System.Drawing.Point(94, 84);
            this.uiMonto1.Name = "uiMonto1";
            this.uiMonto1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiMonto1.Size = new System.Drawing.Size(214, 20);
            this.uiMonto1.StyleController = this.layoutControl1;
            this.uiMonto1.TabIndex = 6;
            this.uiMonto1.Click += new System.EventHandler(this.uiMonto1_Click);
            this.uiMonto1.Enter += new System.EventHandler(this.uiMonto1_Enter);
            this.uiMonto1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiMonto1_KeyDown);
            // 
            // uiConcepto1
            // 
            this.uiConcepto1.Location = new System.Drawing.Point(94, 60);
            this.uiConcepto1.Name = "uiConcepto1";
            this.uiConcepto1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiConcepto1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Concepto")});
            this.uiConcepto1.Properties.DataSource = this.catgastosBindingSource;
            this.uiConcepto1.Properties.DisplayMember = "Descripcion";
            this.uiConcepto1.Properties.NullText = "(SELECCIONA UN CONCEPTO)";
            this.uiConcepto1.Properties.ValueMember = "Clave";
            this.uiConcepto1.Size = new System.Drawing.Size(430, 20);
            this.uiConcepto1.StyleController = this.layoutControl1;
            this.uiConcepto1.TabIndex = 5;
            this.uiConcepto1.EditValueChanged += new System.EventHandler(this.uiConcepto1_EditValueChanged);
            // 
            // catgastosBindingSource
            // 
            this.catgastosBindingSource.DataSource = typeof(ConexionBD.cat_gastos);
            // 
            // uiCentroCosto1
            // 
            this.uiCentroCosto1.Location = new System.Drawing.Point(94, 36);
            this.uiCentroCosto1.Name = "uiCentroCosto1";
            this.uiCentroCosto1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCentroCosto1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "CC")});
            this.uiCentroCosto1.Properties.DataSource = this.catcentrocostosBindingSource;
            this.uiCentroCosto1.Properties.DisplayMember = "Descripcion";
            this.uiCentroCosto1.Properties.NullText = "(SELECCIONA UN CENTRO DE COSTOS)";
            this.uiCentroCosto1.Properties.ValueMember = "Clave";
            this.uiCentroCosto1.Size = new System.Drawing.Size(430, 20);
            this.uiCentroCosto1.StyleController = this.layoutControl1;
            this.uiCentroCosto1.TabIndex = 4;
            // 
            // catcentrocostosBindingSource
            // 
            this.catcentrocostosBindingSource.DataSource = typeof(ConexionBD.cat_centro_costos);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.uiMontoLabel1,
            this.uiObservacionesLabel1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem5,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(573, 280);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiCentroCosto1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem1.Text = "Centro de Costo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiConcepto1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem2.Text = "Concepto";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // uiMontoLabel1
            // 
            this.uiMontoLabel1.Control = this.uiMonto1;
            this.uiMontoLabel1.Location = new System.Drawing.Point(0, 72);
            this.uiMontoLabel1.Name = "uiMontoLabel1";
            this.uiMontoLabel1.Size = new System.Drawing.Size(300, 24);
            this.uiMontoLabel1.Text = "Monto";
            this.uiMontoLabel1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // uiObservacionesLabel1
            // 
            this.uiObservacionesLabel1.Control = this.uiObservaciones1;
            this.uiObservacionesLabel1.Location = new System.Drawing.Point(0, 96);
            this.uiObservacionesLabel1.Name = "uiObservacionesLabel1";
            this.uiObservacionesLabel1.Size = new System.Drawing.Size(553, 122);
            this.uiObservacionesLabel1.Text = "Observaciones";
            this.uiObservacionesLabel1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(516, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(37, 48);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(516, 48);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(37, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(300, 72);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(253, 24);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGuardar1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 218);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(267, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiSalir1;
            this.layoutControlItem4.Location = new System.Drawing.Point(267, 218);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(243, 42);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(510, 218);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(43, 42);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.label1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(516, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // frmGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 280);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Gastos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGastos_FormClosing);
            this.Load += new System.EventHandler(this.frmGastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiObservaciones1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMonto1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiConcepto1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catgastosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCentroCosto1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catcentrocostosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMontoLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiObservacionesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton uiSalir1;
        private DevExpress.XtraEditors.SimpleButton uiGuardar1;
        private DevExpress.XtraEditors.MemoEdit uiObservaciones1;
        private DevExpress.XtraEditors.SpinEdit uiMonto1;
        private DevExpress.XtraEditors.LookUpEdit uiConcepto1;
        private DevExpress.XtraEditors.LookUpEdit uiCentroCosto1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem uiMontoLabel1;
        private DevExpress.XtraLayout.LayoutControlItem uiObservacionesLabel1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private System.Windows.Forms.BindingSource catcentrocostosBindingSource;
        private System.Windows.Forms.BindingSource catgastosBindingSource;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}