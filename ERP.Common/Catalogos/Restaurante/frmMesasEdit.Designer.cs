namespace ERP.Common.Catalogos.Restaurante
{
    partial class frmMesasEdit
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
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiActivo = new DevExpress.XtraEditors.CheckEdit();
            this.uiDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.uiNombre = new DevExpress.XtraEditors.TextEdit();
            this.uiID = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.uiLayout)).BeginInit();
            this.uiLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLayout
            // 
            this.uiLayout.Controls.Add(this.uiCancelar);
            this.uiLayout.Controls.Add(this.uiGuardar);
            this.uiLayout.Controls.Add(this.uiActivo);
            this.uiLayout.Controls.Add(this.uiDescripcion);
            this.uiLayout.Controls.Add(this.uiNombre);
            this.uiLayout.Controls.Add(this.uiID);
            this.uiLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayout.Location = new System.Drawing.Point(0, 0);
            this.uiLayout.Name = "uiLayout";
            this.uiLayout.OptionsView.UseDefaultDragAndDropRendering = false;
            this.uiLayout.Root = this.layoutControlGroup1;
            this.uiLayout.Size = new System.Drawing.Size(800, 450);
            this.uiLayout.TabIndex = 0;
            this.uiLayout.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(402, 416);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(386, 22);
            this.uiCancelar.StyleController = this.uiLayout;
            this.uiCancelar.TabIndex = 9;
            this.uiCancelar.Text = "Cancelar";
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(12, 416);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(386, 22);
            this.uiGuardar.StyleController = this.uiLayout;
            this.uiGuardar.TabIndex = 8;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiActivo
            // 
            this.uiActivo.Location = new System.Drawing.Point(12, 393);
            this.uiActivo.Name = "uiActivo";
            this.uiActivo.Properties.Caption = "Activo";
            this.uiActivo.Size = new System.Drawing.Size(776, 19);
            this.uiActivo.StyleController = this.uiLayout;
            this.uiActivo.TabIndex = 7;
            // 
            // uiDescripcion
            // 
            this.uiDescripcion.Location = new System.Drawing.Point(80, 60);
            this.uiDescripcion.Name = "uiDescripcion";
            this.uiDescripcion.Properties.LinesCount = 3;
            this.uiDescripcion.Size = new System.Drawing.Size(708, 329);
            this.uiDescripcion.StyleController = this.uiLayout;
            this.uiDescripcion.TabIndex = 6;
            // 
            // uiNombre
            // 
            this.uiNombre.Location = new System.Drawing.Point(80, 36);
            this.uiNombre.Name = "uiNombre";
            this.uiNombre.Size = new System.Drawing.Size(708, 20);
            this.uiNombre.StyleController = this.uiLayout;
            this.uiNombre.TabIndex = 5;
            // 
            // uiID
            // 
            this.uiID.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiID.Enabled = false;
            this.uiID.Location = new System.Drawing.Point(80, 12);
            this.uiID.Name = "uiID";
            this.uiID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiID.Size = new System.Drawing.Size(708, 20);
            this.uiID.StyleController = this.uiLayout;
            this.uiID.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItem1.Text = "ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiNombre;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 24);
            this.layoutControlItem2.Text = "Nombre Mesa";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiDescripcion;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(780, 333);
            this.layoutControlItem3.Text = "Descripción";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiActivo;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 381);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(780, 23);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiGuardar;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 404);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(390, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiCancelar;
            this.layoutControlItem6.Location = new System.Drawing.Point(390, 404);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(390, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmMesasEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiLayout);
            this.Name = "frmMesasEdit";
            this.Text = "Editando Mesas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMesasEdit_FormClosing);
            this.Load += new System.EventHandler(this.frmMesasEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiLayout)).EndInit();
            this.uiLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl uiLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit uiID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit uiNombre;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit uiDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraEditors.CheckEdit uiActivo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}