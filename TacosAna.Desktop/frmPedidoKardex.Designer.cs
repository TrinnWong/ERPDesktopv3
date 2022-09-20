namespace TacosAna.Desktop
{
    partial class frmPedidoKardex
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
            this.uiSaldo = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiPagos = new DevExpress.XtraGrid.GridControl();
            this.docpagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPagos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPagoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiNotas = new DevExpress.XtraEditors.MemoEdit();
            this.uiHoraProg = new DevExpress.XtraEditors.TimeEdit();
            this.uiFechaProg = new DevExpress.XtraEditors.DateEdit();
            this.uiClienteClave = new DevExpress.XtraEditors.TextEdit();
            this.uiFechaReg = new DevExpress.XtraEditors.DateEdit();
            this.uiPedido = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSaldo.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docpagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHoraProg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaProg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaProg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiClienteClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaReg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaReg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiSaldo);
            this.layoutControl1.Controls.Add(this.groupBox1);
            this.layoutControl1.Controls.Add(this.uiNotas);
            this.layoutControl1.Controls.Add(this.uiHoraProg);
            this.layoutControl1.Controls.Add(this.uiFechaProg);
            this.layoutControl1.Controls.Add(this.uiClienteClave);
            this.layoutControl1.Controls.Add(this.uiFechaReg);
            this.layoutControl1.Controls.Add(this.uiPedido);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(487, 245);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiSaldo
            // 
            this.uiSaldo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiSaldo.Location = new System.Drawing.Point(367, 211);
            this.uiSaldo.Name = "uiSaldo";
            this.uiSaldo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uiSaldo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.uiSaldo.Properties.Appearance.Options.UseFont = true;
            this.uiSaldo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSaldo.Properties.DisplayFormat.FormatString = "c2";
            this.uiSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiSaldo.Properties.ReadOnly = true;
            this.uiSaldo.Size = new System.Drawing.Size(108, 22);
            this.uiSaldo.StyleController = this.layoutControl1;
            this.uiSaldo.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiPagos);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 102);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagos";
            // 
            // uiPagos
            // 
            this.uiPagos.DataSource = this.docpagosBindingSource;
            this.uiPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPagos.Location = new System.Drawing.Point(3, 17);
            this.uiPagos.MainView = this.gvPagos;
            this.uiPagos.Name = "uiPagos";
            this.uiPagos.Size = new System.Drawing.Size(457, 82);
            this.uiPagos.TabIndex = 0;
            this.uiPagos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPagos});
            this.uiPagos.Click += new System.EventHandler(this.uiPagos_Click);
            // 
            // docpagosBindingSource
            // 
            this.docpagosBindingSource.DataSource = typeof(ConexionBD.doc_pagos);
            // 
            // gvPagos
            // 
            this.gvPagos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPagoId,
            this.colFechaPago,
            this.colMonto});
            this.gvPagos.GridControl = this.uiPagos;
            this.gvPagos.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Monto", this.colMonto, "(Monto: SUM={0:c2})")});
            this.gvPagos.Name = "gvPagos";
            this.gvPagos.OptionsView.ShowFooter = true;
            this.gvPagos.OptionsView.ShowGroupPanel = false;
            // 
            // colPagoId
            // 
            this.colPagoId.Caption = "ID";
            this.colPagoId.FieldName = "PagoId";
            this.colPagoId.Name = "colPagoId";
            this.colPagoId.OptionsColumn.ReadOnly = true;
            this.colPagoId.Visible = true;
            this.colPagoId.VisibleIndex = 0;
            this.colPagoId.Width = 73;
            // 
            // colFechaPago
            // 
            this.colFechaPago.Caption = "Fecha";
            this.colFechaPago.FieldName = "FechaPago";
            this.colFechaPago.Name = "colFechaPago";
            this.colFechaPago.OptionsColumn.ReadOnly = true;
            this.colFechaPago.Visible = true;
            this.colFechaPago.VisibleIndex = 2;
            this.colFechaPago.Width = 204;
            // 
            // colMonto
            // 
            this.colMonto.DisplayFormat.FormatString = "c2";
            this.colMonto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonto.FieldName = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.OptionsColumn.ReadOnly = true;
            this.colMonto.Visible = true;
            this.colMonto.VisibleIndex = 1;
            this.colMonto.Width = 204;
            // 
            // uiNotas
            // 
            this.uiNotas.Location = new System.Drawing.Point(105, 84);
            this.uiNotas.Name = "uiNotas";
            this.uiNotas.Properties.ReadOnly = true;
            this.uiNotas.Size = new System.Drawing.Size(370, 17);
            this.uiNotas.StyleController = this.layoutControl1;
            this.uiNotas.TabIndex = 9;
            this.uiNotas.EditValueChanged += new System.EventHandler(this.memoEdit1_EditValueChanged);
            // 
            // uiHoraProg
            // 
            this.uiHoraProg.EditValue = new System.DateTime(2021, 1, 21, 0, 0, 0, 0);
            this.uiHoraProg.Location = new System.Drawing.Point(338, 60);
            this.uiHoraProg.Name = "uiHoraProg";
            this.uiHoraProg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiHoraProg.Properties.Mask.EditMask = "t";
            this.uiHoraProg.Properties.ReadOnly = true;
            this.uiHoraProg.Size = new System.Drawing.Size(137, 20);
            this.uiHoraProg.StyleController = this.layoutControl1;
            this.uiHoraProg.TabIndex = 8;
            this.uiHoraProg.EditValueChanged += new System.EventHandler(this.uiHoraProg_EditValueChanged);
            // 
            // uiFechaProg
            // 
            this.uiFechaProg.EditValue = null;
            this.uiFechaProg.Location = new System.Drawing.Point(105, 60);
            this.uiFechaProg.Name = "uiFechaProg";
            this.uiFechaProg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaProg.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaProg.Properties.ReadOnly = true;
            this.uiFechaProg.Size = new System.Drawing.Size(136, 20);
            this.uiFechaProg.StyleController = this.layoutControl1;
            this.uiFechaProg.TabIndex = 7;
            this.uiFechaProg.EditValueChanged += new System.EventHandler(this.uiFechaProg_EditValueChanged);
            // 
            // uiClienteClave
            // 
            this.uiClienteClave.Location = new System.Drawing.Point(105, 36);
            this.uiClienteClave.Name = "uiClienteClave";
            this.uiClienteClave.Properties.ReadOnly = true;
            this.uiClienteClave.Size = new System.Drawing.Size(370, 20);
            this.uiClienteClave.StyleController = this.layoutControl1;
            this.uiClienteClave.TabIndex = 6;
            this.uiClienteClave.EditValueChanged += new System.EventHandler(this.uiClienteClave_EditValueChanged);
            // 
            // uiFechaReg
            // 
            this.uiFechaReg.EditValue = null;
            this.uiFechaReg.Location = new System.Drawing.Point(306, 12);
            this.uiFechaReg.Name = "uiFechaReg";
            this.uiFechaReg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaReg.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaReg.Properties.ReadOnly = true;
            this.uiFechaReg.Size = new System.Drawing.Size(169, 20);
            this.uiFechaReg.StyleController = this.layoutControl1;
            this.uiFechaReg.TabIndex = 5;
            this.uiFechaReg.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // uiPedido
            // 
            this.uiPedido.Location = new System.Drawing.Point(105, 12);
            this.uiPedido.Name = "uiPedido";
            this.uiPedido.Properties.ReadOnly = true;
            this.uiPedido.Size = new System.Drawing.Size(104, 20);
            this.uiPedido.StyleController = this.layoutControl1;
            this.uiPedido.TabIndex = 4;
            this.uiPedido.EditValueChanged += new System.EventHandler(this.uiPedido_EditValueChanged);
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
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(487, 245);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiPedido;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(201, 24);
            this.layoutControlItem1.Text = "Pedido";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiFechaReg;
            this.layoutControlItem2.Location = new System.Drawing.Point(201, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(266, 24);
            this.layoutControlItem2.Text = "Fecha Registro";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiClienteClave;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem3.Text = "Cliente";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiFechaProg;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem4.Text = "Fecha Programada";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uiHoraProg;
            this.layoutControlItem5.Location = new System.Drawing.Point(233, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(234, 24);
            this.layoutControlItem5.Text = "Hora Programada";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.uiNotas;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(467, 21);
            this.layoutControlItem6.Text = "Notas";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.groupBox1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(467, 106);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.uiSaldo;
            this.layoutControlItem8.Location = new System.Drawing.Point(262, 199);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(205, 26);
            this.layoutControlItem8.Text = "Saldo";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(90, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 230);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(262, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPedidoKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 245);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPedidoKardex";
            this.Text = "Pedido - Resumen";
            this.Load += new System.EventHandler(this.frmPedidoKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSaldo.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docpagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHoraProg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaProg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaProg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiClienteClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaReg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaReg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit uiPedido;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit uiFechaReg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit uiClienteClave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.MemoEdit uiNotas;
        private DevExpress.XtraEditors.TimeEdit uiHoraProg;
        private DevExpress.XtraEditors.DateEdit uiFechaProg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl uiPagos;
        private System.Windows.Forms.BindingSource docpagosBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPagos;
        private DevExpress.XtraGrid.Columns.GridColumn colPagoId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SpinEdit uiSaldo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}