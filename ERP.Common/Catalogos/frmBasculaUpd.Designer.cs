namespace ERP.Common.Catalogos
{
    partial class frmBasculaUpd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBasculaUpd));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiActivo = new System.Windows.Forms.CheckBox();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiSerie = new DevExpress.XtraEditors.TextEdit();
            this.uiModelo = new DevExpress.XtraEditors.TextEdit();
            this.uiMarca = new DevExpress.XtraEditors.TextEdit();
            this.uiAlias = new DevExpress.XtraEditors.TextEdit();
            this.uiID = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiModelo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMarca.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.uiActivo);
            this.layoutControl1.Controls.Add(this.uiSucursal);
            this.layoutControl1.Controls.Add(this.uiSerie);
            this.layoutControl1.Controls.Add(this.uiModelo);
            this.layoutControl1.Controls.Add(this.uiMarca);
            this.layoutControl1.Controls.Add(this.uiAlias);
            this.layoutControl1.Controls.Add(this.uiID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(707, 276);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(266, 108);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(257, 38);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 12;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(12, 108);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(250, 38);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 11;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiActivo
            // 
            this.uiActivo.Location = new System.Drawing.Point(12, 84);
            this.uiActivo.Name = "uiActivo";
            this.uiActivo.Size = new System.Drawing.Size(683, 20);
            this.uiActivo.TabIndex = 10;
            this.uiActivo.Text = "Activo";
            this.uiActivo.UseVisualStyleBackColor = true;
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(446, 60);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clave", "Clave"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DataSource = this.catsucursalesBindingSource;
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Selecciona una sucursal)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(249, 20);
            this.uiSucursal.StyleController = this.layoutControl1;
            this.uiSucursal.TabIndex = 9;
            // 
            // catsucursalesBindingSource
            // 
            this.catsucursalesBindingSource.DataSource = typeof(ConexionBD.cat_sucursales);
            // 
            // uiSerie
            // 
            this.uiSerie.Location = new System.Drawing.Point(102, 60);
            this.uiSerie.Name = "uiSerie";
            this.uiSerie.Size = new System.Drawing.Size(250, 20);
            this.uiSerie.StyleController = this.layoutControl1;
            this.uiSerie.TabIndex = 8;
            // 
            // uiModelo
            // 
            this.uiModelo.Location = new System.Drawing.Point(446, 36);
            this.uiModelo.Name = "uiModelo";
            this.uiModelo.Size = new System.Drawing.Size(249, 20);
            this.uiModelo.StyleController = this.layoutControl1;
            this.uiModelo.TabIndex = 7;
            // 
            // uiMarca
            // 
            this.uiMarca.Location = new System.Drawing.Point(102, 36);
            this.uiMarca.Name = "uiMarca";
            this.uiMarca.Size = new System.Drawing.Size(250, 20);
            this.uiMarca.StyleController = this.layoutControl1;
            this.uiMarca.TabIndex = 6;
            // 
            // uiAlias
            // 
            this.uiAlias.Location = new System.Drawing.Point(446, 12);
            this.uiAlias.Name = "uiAlias";
            this.uiAlias.Size = new System.Drawing.Size(249, 20);
            this.uiAlias.StyleController = this.layoutControl1;
            this.uiAlias.TabIndex = 5;
            // 
            // uiID
            // 
            this.uiID.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiID.Enabled = false;
            this.uiID.Location = new System.Drawing.Point(102, 12);
            this.uiID.Name = "uiID";
            this.uiID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiID.Size = new System.Drawing.Size(250, 20);
            this.uiID.StyleController = this.layoutControl1;
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
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(707, 276);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(344, 24);
            this.layoutControlItem1.Text = "ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiAlias;
            this.layoutControlItem2.Location = new System.Drawing.Point(344, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(343, 24);
            this.layoutControlItem2.Text = "Alias";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiMarca;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(344, 24);
            this.layoutControlItem3.Text = "Marca";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiModelo;
            this.layoutControlItem4.Location = new System.Drawing.Point(344, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(343, 24);
            this.layoutControlItem4.Text = "Modelo";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiSerie;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(344, 24);
            this.layoutControlItem5.Text = "Serie";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiSucursal;
            this.layoutControlItem6.Location = new System.Drawing.Point(344, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(343, 24);
            this.layoutControlItem6.Text = "Sucursal Asignada";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(87, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.uiActivo;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(687, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 138);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(687, 118);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.uiGuardar;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(254, 42);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.uiCancelar;
            this.layoutControlItem9.Location = new System.Drawing.Point(254, 96);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(261, 42);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(515, 96);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(172, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmBasculaUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 276);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmBasculaUpd";
            this.Text = "Edición de Basculas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBasculaUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmBasculaUpd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiModelo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMarca.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit uiModelo;
        private DevExpress.XtraEditors.TextEdit uiMarca;
        private DevExpress.XtraEditors.TextEdit uiAlias;
        private DevExpress.XtraEditors.SpinEdit uiID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private System.Windows.Forms.CheckBox uiActivo;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private DevExpress.XtraEditors.TextEdit uiSerie;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
    }
}