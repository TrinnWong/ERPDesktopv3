
namespace ERP.Common.Pedido
{
    partial class PedidoDevolucionVentasDirectas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoDevolucionVentasDirectas));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.label4 = new System.Windows.Forms.Label();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colventaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfolio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colclienteId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecioTortilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldevolucionTortilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecioMasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldevolucionMasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label4);
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.label3);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.label2);
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1211, 558);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(340, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 38);
            this.label4.TabIndex = 10;
            this.label4.Text = "Al guardar solo se aplicarán los cambios en las ventas con devolución capturada";
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(946, 508);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(253, 38);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 9;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(668, 508);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(274, 38);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 8;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1187, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Registra las devoluciones ingresando la  cantidad en Devolución Tortilla y Devolu" +
    "ción Masa";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(12, 112);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1187, 392);
            this.uiGrid.TabIndex = 6;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // pedidoDevolucionVentaDirectaMasaTortillaBindingSource
            // 
            this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource.DataSource = typeof(ERP.Models.Pedidos.PedidoDevolucionVentaDirectaMasaTortilla);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colventaId,
            this.colfolio,
            this.colclienteId,
            this.colcliente,
            this.colfecha,
            this.colprecioTortilla,
            this.coldevolucionTortilla,
            this.colprecioMasa,
            this.coldevolucionMasa,
            this.gridColumn1,
            this.gridColumn2});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.GroupCount = 1;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colfolio, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colventaId
            // 
            this.colventaId.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colventaId.AppearanceCell.Options.UseFont = true;
            this.colventaId.Caption = "ID";
            this.colventaId.FieldName = "ventaId";
            this.colventaId.Name = "colventaId";
            this.colventaId.OptionsColumn.AllowEdit = false;
            this.colventaId.Visible = true;
            this.colventaId.VisibleIndex = 0;
            // 
            // colfolio
            // 
            this.colfolio.Caption = "Folio";
            this.colfolio.FieldName = "folio";
            this.colfolio.Name = "colfolio";
            this.colfolio.OptionsColumn.AllowEdit = false;
            this.colfolio.Visible = true;
            this.colfolio.VisibleIndex = 1;
            // 
            // colclienteId
            // 
            this.colclienteId.FieldName = "clienteId";
            this.colclienteId.Name = "colclienteId";
            this.colclienteId.OptionsColumn.AllowEdit = false;
            // 
            // colcliente
            // 
            this.colcliente.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcliente.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colcliente.AppearanceCell.Options.UseFont = true;
            this.colcliente.AppearanceCell.Options.UseForeColor = true;
            this.colcliente.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcliente.AppearanceHeader.Options.UseFont = true;
            this.colcliente.Caption = "Cliente";
            this.colcliente.FieldName = "cliente";
            this.colcliente.Name = "colcliente";
            this.colcliente.OptionsColumn.AllowEdit = false;
            this.colcliente.Visible = true;
            this.colcliente.VisibleIndex = 1;
            // 
            // colfecha
            // 
            this.colfecha.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colfecha.AppearanceCell.Options.UseFont = true;
            this.colfecha.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colfecha.AppearanceHeader.Options.UseFont = true;
            this.colfecha.Caption = "Fecha Venta";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.OptionsColumn.AllowEdit = false;
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 2;
            // 
            // colprecioTortilla
            // 
            this.colprecioTortilla.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioTortilla.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colprecioTortilla.AppearanceCell.Options.UseFont = true;
            this.colprecioTortilla.AppearanceCell.Options.UseForeColor = true;
            this.colprecioTortilla.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioTortilla.AppearanceHeader.Options.UseFont = true;
            this.colprecioTortilla.Caption = "Precio Tortilla";
            this.colprecioTortilla.DisplayFormat.FormatString = "c2";
            this.colprecioTortilla.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colprecioTortilla.FieldName = "precioTortilla";
            this.colprecioTortilla.Name = "colprecioTortilla";
            this.colprecioTortilla.OptionsColumn.AllowEdit = false;
            this.colprecioTortilla.Visible = true;
            this.colprecioTortilla.VisibleIndex = 5;
            // 
            // coldevolucionTortilla
            // 
            this.coldevolucionTortilla.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionTortilla.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionTortilla.AppearanceCell.Options.UseFont = true;
            this.coldevolucionTortilla.AppearanceCell.Options.UseForeColor = true;
            this.coldevolucionTortilla.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionTortilla.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionTortilla.AppearanceHeader.Options.UseFont = true;
            this.coldevolucionTortilla.AppearanceHeader.Options.UseForeColor = true;
            this.coldevolucionTortilla.Caption = "Devolución Tortilla";
            this.coldevolucionTortilla.FieldName = "devolucionTortilla";
            this.coldevolucionTortilla.Name = "coldevolucionTortilla";
            this.coldevolucionTortilla.Visible = true;
            this.coldevolucionTortilla.VisibleIndex = 4;
            // 
            // colprecioMasa
            // 
            this.colprecioMasa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioMasa.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colprecioMasa.AppearanceCell.Options.UseFont = true;
            this.colprecioMasa.AppearanceCell.Options.UseForeColor = true;
            this.colprecioMasa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioMasa.AppearanceHeader.Options.UseFont = true;
            this.colprecioMasa.Caption = "Precio Masa";
            this.colprecioMasa.DisplayFormat.FormatString = "c2";
            this.colprecioMasa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colprecioMasa.FieldName = "precioMasa";
            this.colprecioMasa.Name = "colprecioMasa";
            this.colprecioMasa.OptionsColumn.AllowEdit = false;
            this.colprecioMasa.Visible = true;
            this.colprecioMasa.VisibleIndex = 8;
            // 
            // coldevolucionMasa
            // 
            this.coldevolucionMasa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionMasa.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionMasa.AppearanceCell.Options.UseFont = true;
            this.coldevolucionMasa.AppearanceCell.Options.UseForeColor = true;
            this.coldevolucionMasa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionMasa.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionMasa.AppearanceHeader.Options.UseFont = true;
            this.coldevolucionMasa.AppearanceHeader.Options.UseForeColor = true;
            this.coldevolucionMasa.Caption = "Devolución Masa";
            this.coldevolucionMasa.FieldName = "devolucionMasa";
            this.coldevolucionMasa.Name = "coldevolucionMasa";
            this.coldevolucionMasa.Visible = true;
            this.coldevolucionMasa.VisibleIndex = 7;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Cantidad masa vendida";
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "cantidadVentaMasa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Cantidad tortilla vendida";
            this.gridColumn2.DisplayFormat.FormatString = "n2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "cantidadVentaTortilla";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1187, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aquí se registran devoluciones de pedidos de masa y tortilla que se hayan generad" +
    "o de manera directa. Solo aparecerán en este listado ventas de clientes del día " +
    "actual y de un día anterior";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1187, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Registro de devoluciones masa y tortila para ventas directas a clientes";
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
            this.emptySpaceItem1,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1211, 558);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.label1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1191, 29);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.label2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1191, 38);
            this.layoutControlItem2.Text = "Aquí se registran devoluciones de pedidos de masa y tortilla que se hayan generad" +
    "o directa. Solo aparecerán en este listado ventas de clientes del día actual y d" +
    "e un día anterior";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1191, 396);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.label3;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1191, 33);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiGuardar;
            this.layoutControlItem5.Location = new System.Drawing.Point(656, 496);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(278, 42);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiCancelar;
            this.layoutControlItem6.Location = new System.Drawing.Point(934, 496);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(257, 42);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 496);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(328, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.label4;
            this.layoutControlItem7.Location = new System.Drawing.Point(328, 496);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(328, 42);
            this.layoutControlItem7.Text = "Al guardar, solo se aplicarán los cambios sobre las ventas que tenga devolución c" +
    "apturada";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // PedidoDevolucionVentasDirectas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 558);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PedidoDevolucionVentasDirectas";
            this.Text = "Registro de devoluciones masa y tortilla para ventas directas a clientes";
            this.Load += new System.EventHandler(this.PedidoDevolucionVentasDirectas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource pedidoDevolucionVentaDirectaMasaTortillaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colventaId;
        private DevExpress.XtraGrid.Columns.GridColumn colfolio;
        private DevExpress.XtraGrid.Columns.GridColumn colclienteId;
        private DevExpress.XtraGrid.Columns.GridColumn colcliente;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn coldevolucionTortilla;
        private DevExpress.XtraGrid.Columns.GridColumn coldevolucionMasa;
        private DevExpress.XtraGrid.Columns.GridColumn colprecioTortilla;
        private DevExpress.XtraGrid.Columns.GridColumn colprecioMasa;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}