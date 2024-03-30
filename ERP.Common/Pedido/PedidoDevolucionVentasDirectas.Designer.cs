
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
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
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label3);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.label2);
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1065, 558);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1041, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "Registra las devoluciones ingresando la  cantidad en Devolución Tortilla y Devolu" +
    "ción Masa";
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.pedidoDevolucionVentaDirectaMasaTortillaBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(12, 122);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1041, 424);
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
            this.coldevolucionMasa});
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
            this.colventaId.Visible = true;
            this.colventaId.VisibleIndex = 0;
            // 
            // colfolio
            // 
            this.colfolio.Caption = "Folio";
            this.colfolio.FieldName = "folio";
            this.colfolio.Name = "colfolio";
            this.colfolio.Visible = true;
            this.colfolio.VisibleIndex = 1;
            // 
            // colclienteId
            // 
            this.colclienteId.FieldName = "clienteId";
            this.colclienteId.Name = "colclienteId";
            // 
            // colcliente
            // 
            this.colcliente.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcliente.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colcliente.AppearanceCell.Options.UseFont = true;
            this.colcliente.AppearanceCell.Options.UseForeColor = true;
            this.colcliente.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcliente.AppearanceHeader.Options.UseFont = true;
            this.colcliente.Caption = "Cliente";
            this.colcliente.FieldName = "cliente";
            this.colcliente.Name = "colcliente";
            this.colcliente.Visible = true;
            this.colcliente.VisibleIndex = 1;
            // 
            // colfecha
            // 
            this.colfecha.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colfecha.AppearanceCell.Options.UseFont = true;
            this.colfecha.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colfecha.AppearanceHeader.Options.UseFont = true;
            this.colfecha.Caption = "Fecha Venta";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 2;
            // 
            // colprecioTortilla
            // 
            this.colprecioTortilla.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioTortilla.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colprecioTortilla.AppearanceCell.Options.UseFont = true;
            this.colprecioTortilla.AppearanceCell.Options.UseForeColor = true;
            this.colprecioTortilla.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioTortilla.AppearanceHeader.Options.UseFont = true;
            this.colprecioTortilla.Caption = "Precio Tortilla";
            this.colprecioTortilla.DisplayFormat.FormatString = "c2";
            this.colprecioTortilla.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colprecioTortilla.FieldName = "precioTortilla";
            this.colprecioTortilla.Name = "colprecioTortilla";
            this.colprecioTortilla.Visible = true;
            this.colprecioTortilla.VisibleIndex = 4;
            // 
            // coldevolucionTortilla
            // 
            this.coldevolucionTortilla.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionTortilla.AppearanceCell.Options.UseFont = true;
            this.coldevolucionTortilla.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionTortilla.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionTortilla.AppearanceHeader.Options.UseFont = true;
            this.coldevolucionTortilla.AppearanceHeader.Options.UseForeColor = true;
            this.coldevolucionTortilla.Caption = "Devolución Tortilla";
            this.coldevolucionTortilla.FieldName = "devolucionTortilla";
            this.coldevolucionTortilla.Name = "coldevolucionTortilla";
            this.coldevolucionTortilla.Visible = true;
            this.coldevolucionTortilla.VisibleIndex = 3;
            // 
            // colprecioMasa
            // 
            this.colprecioMasa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioMasa.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.colprecioMasa.AppearanceCell.Options.UseFont = true;
            this.colprecioMasa.AppearanceCell.Options.UseForeColor = true;
            this.colprecioMasa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colprecioMasa.AppearanceHeader.Options.UseFont = true;
            this.colprecioMasa.Caption = "Precio Masa";
            this.colprecioMasa.DisplayFormat.FormatString = "c2";
            this.colprecioMasa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colprecioMasa.FieldName = "precioMasa";
            this.colprecioMasa.Name = "colprecioMasa";
            this.colprecioMasa.Visible = true;
            this.colprecioMasa.VisibleIndex = 6;
            // 
            // coldevolucionMasa
            // 
            this.coldevolucionMasa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionMasa.AppearanceCell.Options.UseFont = true;
            this.coldevolucionMasa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldevolucionMasa.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.coldevolucionMasa.AppearanceHeader.Options.UseFont = true;
            this.coldevolucionMasa.AppearanceHeader.Options.UseForeColor = true;
            this.coldevolucionMasa.Caption = "Devolución Masa";
            this.coldevolucionMasa.FieldName = "devolucionMasa";
            this.coldevolucionMasa.Name = "coldevolucionMasa";
            this.coldevolucionMasa.Visible = true;
            this.coldevolucionMasa.VisibleIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1041, 38);
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
            this.label1.Size = new System.Drawing.Size(1041, 27);
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
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1065, 558);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.label1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1045, 31);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.label2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1045, 42);
            this.layoutControlItem2.Text = "Aquí se registran devoluciones de pedidos de masa y tortilla que se hayan generad" +
    "o directa. Solo aparecerán en este listado ventas de clientes del día actual y d" +
    "e un día anterior";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGrid;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1045, 428);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.label3;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1045, 37);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // PedidoDevolucionVentasDirectas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 558);
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
    }
}