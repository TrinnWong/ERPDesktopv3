namespace ERP.Common.Pedido
{
    partial class frmPedidoDevolucionReparto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidoDevolucionReparto));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiTotal = new DevExpress.XtraEditors.SpinEdit();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiContinuar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar1 = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadFinalReparto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiRepCantidadFinalReparto = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadCobroReparto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uiGuardar = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiRepCantidadFinalReparto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiTotal);
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiContinuar);
            this.layoutControl1.Controls.Add(this.uiGuardar1);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1014, 440);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiTotal
            // 
            this.uiTotal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiTotal.Location = new System.Drawing.Point(767, 346);
            this.uiTotal.Name = "uiTotal";
            this.uiTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotal.Properties.Appearance.Options.UseFont = true;
            this.uiTotal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTotal.Properties.DisplayFormat.FormatString = "c2";
            this.uiTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiTotal.Properties.ReadOnly = true;
            this.uiTotal.Size = new System.Drawing.Size(229, 30);
            this.uiTotal.StyleController = this.layoutControl1;
            this.uiTotal.TabIndex = 8;
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(652, 382);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(344, 40);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 7;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiContinuar
            // 
            this.uiContinuar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiContinuar.ImageOptions.Image")));
            this.uiContinuar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiContinuar.Location = new System.Drawing.Point(331, 382);
            this.uiContinuar.Name = "uiContinuar";
            this.uiContinuar.Size = new System.Drawing.Size(315, 40);
            this.uiContinuar.StyleController = this.layoutControl1;
            this.uiContinuar.TabIndex = 6;
            this.uiContinuar.Text = "CONTINUAR SIN DEVOLUCIÓN";
            this.uiContinuar.Click += new System.EventHandler(this.uiContinuar_Click);
            // 
            // uiGuardar1
            // 
            this.uiGuardar1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar1.ImageOptions.Image")));
            this.uiGuardar1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar1.Location = new System.Drawing.Point(18, 382);
            this.uiGuardar1.Name = "uiGuardar1";
            this.uiGuardar1.Size = new System.Drawing.Size(307, 40);
            this.uiGuardar1.StyleController = this.layoutControl1;
            this.uiGuardar1.TabIndex = 5;
            this.uiGuardar1.Text = "GUARDAR";
            this.uiGuardar1.Click += new System.EventHandler(this.uiGuardar1_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.Location = new System.Drawing.Point(18, 53);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.uiRepCantidadFinalReparto});
            this.uiGrid.Size = new System.Drawing.Size(978, 287);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClave,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecio,
            this.colCantidadFinalReparto,
            this.colTotal,
            this.colCantidadCobroReparto});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsView.ShowGroupPanel = false;
            this.uiGridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.uiGridView_CustomRowCellEdit);
            // 
            // colClave
            // 
            this.colClave.Caption = "Clave";
            this.colClave.FieldName = "clave";
            this.colClave.Name = "colClave";
            this.colClave.OptionsColumn.ReadOnly = true;
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescripcion.AppearanceCell.Options.UseFont = true;
            this.colDescripcion.Caption = "Descrición";
            this.colDescripcion.FieldName = "descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad Orig.";
            this.colCantidad.FieldName = "cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.OptionsColumn.ReadOnly = true;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            // 
            // colPrecio
            // 
            this.colPrecio.Caption = "Precio";
            this.colPrecio.DisplayFormat.FormatString = "c2";
            this.colPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio.FieldName = "precioUnitario";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.OptionsColumn.ReadOnly = true;
            this.colPrecio.Visible = true;
            this.colPrecio.VisibleIndex = 3;
            // 
            // colCantidadFinalReparto
            // 
            this.colCantidadFinalReparto.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCantidadFinalReparto.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colCantidadFinalReparto.AppearanceCell.Options.UseFont = true;
            this.colCantidadFinalReparto.AppearanceCell.Options.UseForeColor = true;
            this.colCantidadFinalReparto.Caption = "Cantidad Devolución";
            this.colCantidadFinalReparto.ColumnEdit = this.uiRepCantidadFinalReparto;
            this.colCantidadFinalReparto.DisplayFormat.FormatString = "n2";
            this.colCantidadFinalReparto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantidadFinalReparto.FieldName = "cantidadFinalReparto";
            this.colCantidadFinalReparto.Name = "colCantidadFinalReparto";
            this.colCantidadFinalReparto.Visible = true;
            this.colCantidadFinalReparto.VisibleIndex = 6;
            this.colCantidadFinalReparto.Width = 125;
            // 
            // uiRepCantidadFinalReparto
            // 
            this.uiRepCantidadFinalReparto.AutoHeight = false;
            this.uiRepCantidadFinalReparto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiRepCantidadFinalReparto.DisplayFormat.FormatString = "n2";
            this.uiRepCantidadFinalReparto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiRepCantidadFinalReparto.EditFormat.FormatString = "n2";
            this.uiRepCantidadFinalReparto.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiRepCantidadFinalReparto.Name = "uiRepCantidadFinalReparto";
            this.uiRepCantidadFinalReparto.Enter += new System.EventHandler(this.uiRepCantidadFinalReparto_Enter);
            this.uiRepCantidadFinalReparto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uiRepCantidadFinalReparto_MouseUp);
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal.AppearanceCell.Options.UseFont = true;
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 4;
            // 
            // colCantidadCobroReparto
            // 
            this.colCantidadCobroReparto.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCantidadCobroReparto.AppearanceCell.Options.UseFont = true;
            this.colCantidadCobroReparto.Caption = "Cantidad Cobro";
            this.colCantidadCobroReparto.FieldName = "cantidadCobroReparto";
            this.colCantidadCobroReparto.Name = "colCantidadCobroReparto";
            this.colCantidadCobroReparto.OptionsColumn.ReadOnly = true;
            this.colCantidadCobroReparto.Visible = true;
            this.colCantidadCobroReparto.VisibleIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.uiGuardar,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.simpleLabelItem1,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.simpleLabelItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1014, 440);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(984, 293);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // uiGuardar
            // 
            this.uiGuardar.Control = this.uiGuardar1;
            this.uiGuardar.Location = new System.Drawing.Point(0, 364);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(313, 46);
            this.uiGuardar.TextSize = new System.Drawing.Size(0, 0);
            this.uiGuardar.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiContinuar;
            this.layoutControlItem2.Location = new System.Drawing.Point(313, 364);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(321, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiCancelar;
            this.layoutControlItem3.Location = new System.Drawing.Point(634, 364);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(350, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(984, 35);
            this.simpleLabelItem1.Text = "Registro Cantidades Finales Reparto";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(431, 29);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiTotal;
            this.layoutControlItem4.Location = new System.Drawing.Point(749, 328);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(235, 36);
            this.layoutControlItem4.Text = "Total";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 328);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(204, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem2.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem2.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.simpleLabelItem2.Location = new System.Drawing.Point(204, 328);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(545, 36);
            this.simpleLabelItem2.Text = "Total";
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(431, 24);
            // 
            // frmPedidoDevolucionReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 440);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPedidoDevolucionReparto";
            this.Text = "Reparto Devolución";
            this.Load += new System.EventHandler(this.frmPedidoDevolucionReparto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiRepCantidadFinalReparto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadFinalReparto;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit uiRepCantidadFinalReparto;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.SimpleButton uiGuardar1;
        private DevExpress.XtraLayout.LayoutControlItem uiGuardar;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiContinuar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraEditors.SpinEdit uiTotal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadCobroReparto;
    }
}