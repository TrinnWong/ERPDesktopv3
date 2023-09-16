namespace TacosAna.Desktop
{
    partial class frmBuscarTicket
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarTicket));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.uiBuscarFolio = new System.Windows.Forms.RadioButton();
            this.uiBuscarFechas = new System.Windows.Forms.RadioButton();
            this.gpFolio = new System.Windows.Forms.GroupBox();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.gpFechas = new System.Windows.Forms.GroupBox();
            this.uiFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.uiFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiBuscar = new System.Windows.Forms.Button();
            this.uiTicket = new DevExpress.XtraGrid.GridControl();
            this.uigvTicket = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repVer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiReimprimir = new System.Windows.Forms.RadioButton();
            this.uiVerVenta = new System.Windows.Forms.RadioButton();
            this.gpFolio.SuspendLayout();
            this.gpFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uigvTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBuscarFolio
            // 
            this.uiBuscarFolio.AutoSize = true;
            this.uiBuscarFolio.Checked = true;
            this.uiBuscarFolio.Location = new System.Drawing.Point(16, 22);
            this.uiBuscarFolio.Name = "uiBuscarFolio";
            this.uiBuscarFolio.Size = new System.Drawing.Size(102, 17);
            this.uiBuscarFolio.TabIndex = 0;
            this.uiBuscarFolio.TabStop = true;
            this.uiBuscarFolio.Text = "Buscar Por Folio";
            this.uiBuscarFolio.UseVisualStyleBackColor = true;
            // 
            // uiBuscarFechas
            // 
            this.uiBuscarFechas.AutoSize = true;
            this.uiBuscarFechas.Location = new System.Drawing.Point(139, 22);
            this.uiBuscarFechas.Name = "uiBuscarFechas";
            this.uiBuscarFechas.Size = new System.Drawing.Size(115, 17);
            this.uiBuscarFechas.TabIndex = 1;
            this.uiBuscarFechas.Text = "Buscar Por Fechas";
            this.uiBuscarFechas.UseVisualStyleBackColor = true;
            this.uiBuscarFechas.CheckedChanged += new System.EventHandler(this.uiBuscarFechas_CheckedChanged);
            // 
            // gpFolio
            // 
            this.gpFolio.Controls.Add(this.uiFolio);
            this.gpFolio.Location = new System.Drawing.Point(12, 66);
            this.gpFolio.Name = "gpFolio";
            this.gpFolio.Size = new System.Drawing.Size(264, 55);
            this.gpFolio.TabIndex = 2;
            this.gpFolio.TabStop = false;
            this.gpFolio.Text = "Folio";
            // 
            // uiFolio
            // 
            this.uiFolio.Location = new System.Drawing.Point(36, 19);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(218, 20);
            this.uiFolio.TabIndex = 0;
            // 
            // gpFechas
            // 
            this.gpFechas.Controls.Add(this.uiFechaFin);
            this.gpFechas.Controls.Add(this.uiFechaIni);
            this.gpFechas.Controls.Add(this.label2);
            this.gpFechas.Controls.Add(this.label1);
            this.gpFechas.Location = new System.Drawing.Point(282, 66);
            this.gpFechas.Name = "gpFechas";
            this.gpFechas.Size = new System.Drawing.Size(388, 55);
            this.gpFechas.TabIndex = 3;
            this.gpFechas.TabStop = false;
            this.gpFechas.Text = "Fechas";
            // 
            // uiFechaFin
            // 
            this.uiFechaFin.EditValue = null;
            this.uiFechaFin.Enabled = false;
            this.uiFechaFin.Location = new System.Drawing.Point(238, 19);
            this.uiFechaFin.Name = "uiFechaFin";
            this.uiFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaFin.Size = new System.Drawing.Size(134, 20);
            this.uiFechaFin.TabIndex = 3;
            // 
            // uiFechaIni
            // 
            this.uiFechaIni.EditValue = null;
            this.uiFechaIni.Enabled = false;
            this.uiFechaIni.Location = new System.Drawing.Point(54, 18);
            this.uiFechaIni.Name = "uiFechaIni";
            this.uiFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFechaIni.Size = new System.Drawing.Size(156, 20);
            this.uiFechaIni.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del";
            // 
            // uiBuscar
            // 
            this.uiBuscar.Location = new System.Drawing.Point(686, 72);
            this.uiBuscar.Name = "uiBuscar";
            this.uiBuscar.Size = new System.Drawing.Size(113, 45);
            this.uiBuscar.TabIndex = 5;
            this.uiBuscar.Text = "BUSCAR";
            this.uiBuscar.UseVisualStyleBackColor = true;
            this.uiBuscar.Click += new System.EventHandler(this.uiBuscar_Click);
            // 
            // uiTicket
            // 
            this.uiTicket.Location = new System.Drawing.Point(12, 127);
            this.uiTicket.MainView = this.uigvTicket;
            this.uiTicket.Name = "uiTicket";
            this.uiTicket.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repVer,
            this.repositoryItemCheckEdit1});
            this.uiTicket.Size = new System.Drawing.Size(828, 253);
            this.uiTicket.TabIndex = 6;
            this.uiTicket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uigvTicket});
            // 
            // uigvTicket
            // 
            this.uigvTicket.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.uigvTicket.GridControl = this.uiTicket;
            this.uigvTicket.Name = "uigvTicket";
            this.uigvTicket.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Folio";
            this.gridColumn1.FieldName = "folio";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 107;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descuento";
            this.gridColumn3.DisplayFormat.FormatString = "c2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "descuento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 107;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Subtotal";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "subtotal";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 107;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Impuestos";
            this.gridColumn5.DisplayFormat.FormatString = "c2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "impuestos";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 107;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "total";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 107;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estatus";
            this.gridColumn7.FieldName = "Estatus";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 113;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "#";
            this.gridColumn8.ColumnEdit = this.repVer;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 55;
            // 
            // repVer
            // 
            this.repVer.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repVer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repVer.Name = "repVer";
            this.repVer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repVer.Click += new System.EventHandler(this.repVer_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "ventaId";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Facturar";
            this.gridColumn10.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn10.FieldName = "facturar";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiBuscarFolio);
            this.groupBox1.Controls.Add(this.uiBuscarFechas);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 60);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Filtros";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiReimprimir);
            this.groupBox2.Controls.Add(this.uiVerVenta);
            this.groupBox2.Location = new System.Drawing.Point(296, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acción";
            // 
            // uiReimprimir
            // 
            this.uiReimprimir.AutoSize = true;
            this.uiReimprimir.Location = new System.Drawing.Point(111, 20);
            this.uiReimprimir.Name = "uiReimprimir";
            this.uiReimprimir.Size = new System.Drawing.Size(73, 17);
            this.uiReimprimir.TabIndex = 1;
            this.uiReimprimir.TabStop = true;
            this.uiReimprimir.Text = "Reimprimir";
            this.uiReimprimir.UseVisualStyleBackColor = true;
            // 
            // uiVerVenta
            // 
            this.uiVerVenta.AutoSize = true;
            this.uiVerVenta.Checked = true;
            this.uiVerVenta.Location = new System.Drawing.Point(14, 20);
            this.uiVerVenta.Name = "uiVerVenta";
            this.uiVerVenta.Size = new System.Drawing.Size(72, 17);
            this.uiVerVenta.TabIndex = 0;
            this.uiVerVenta.TabStop = true;
            this.uiVerVenta.Text = "Ver Venta";
            this.uiVerVenta.UseVisualStyleBackColor = true;
            // 
            // frmBuscarTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uiTicket);
            this.Controls.Add(this.uiBuscar);
            this.Controls.Add(this.gpFechas);
            this.Controls.Add(this.gpFolio);
            this.Name = "frmBuscarTicket";
            this.Text = "Reimprimir Ticket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReimprimirTicket_FormClosing);
            this.Load += new System.EventHandler(this.frmReimprimirTicket_Load);
            this.gpFolio.ResumeLayout(false);
            this.gpFolio.PerformLayout();
            this.gpFechas.ResumeLayout(false);
            this.gpFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uigvTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton uiBuscarFolio;
        private System.Windows.Forms.RadioButton uiBuscarFechas;
        private System.Windows.Forms.GroupBox gpFolio;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.GroupBox gpFechas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uiBuscar;
        private DevExpress.XtraEditors.DateEdit uiFechaFin;
        private DevExpress.XtraEditors.DateEdit uiFechaIni;
        private DevExpress.XtraGrid.GridControl uiTicket;
        private DevExpress.XtraGrid.Views.Grid.GridView uigvTicket;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repVer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton uiReimprimir;
        private System.Windows.Forms.RadioButton uiVerVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}