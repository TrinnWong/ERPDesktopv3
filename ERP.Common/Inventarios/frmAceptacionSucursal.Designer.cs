namespace ERP.Common.Inventarios
{
    partial class frmAceptacionSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAceptacionSucursal));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.aceptacionSucursalGrdModelBindingSource = new System.Windows.Forms.BindingSource();
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmovimientoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmovimientoDetalleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproductoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidadMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidadReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmovimientoDetalleAjusteId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uiTraspasos = new DevExpress.XtraEditors.LookUpEdit();
            this.docinvmovimientoBindingSource = new System.Windows.Forms.BindingSource();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aceptacionSucursalGrdModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTraspasos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinvmovimientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.uiCancelar);
            this.layoutControl1.Controls.Add(this.uiGuardar);
            this.layoutControl1.Controls.Add(this.uiGrid);
            this.layoutControl1.Controls.Add(this.uiTraspasos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(294, 392);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(295, 40);
            this.uiCancelar.StyleController = this.layoutControl1;
            this.uiCancelar.TabIndex = 7;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(18, 392);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(270, 40);
            this.uiGuardar.StyleController = this.layoutControl1;
            this.uiGuardar.TabIndex = 6;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.aceptacionSucursalGrdModelBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 50);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(764, 336);
            this.uiGrid.TabIndex = 5;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // aceptacionSucursalGrdModelBindingSource
            // 
            this.aceptacionSucursalGrdModelBindingSource.DataSource = typeof(ERP.Models.Inventario.AceptacionSucursalGrdModel);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colmovimientoId,
            this.colmovimientoDetalleId,
            this.colproductoId,
            this.colproducto,
            this.colcantidadMovimiento,
            this.colcantidadReal,
            this.colmovimientoDetalleAjusteId});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.AllowEdit = false;
            // 
            // colmovimientoId
            // 
            this.colmovimientoId.FieldName = "movimientoId";
            this.colmovimientoId.Name = "colmovimientoId";
            this.colmovimientoId.OptionsColumn.AllowEdit = false;
            // 
            // colmovimientoDetalleId
            // 
            this.colmovimientoDetalleId.FieldName = "movimientoDetalleId";
            this.colmovimientoDetalleId.Name = "colmovimientoDetalleId";
            this.colmovimientoDetalleId.OptionsColumn.AllowEdit = false;
            // 
            // colproductoId
            // 
            this.colproductoId.FieldName = "productoId";
            this.colproductoId.Name = "colproductoId";
            this.colproductoId.OptionsColumn.AllowEdit = false;
            // 
            // colproducto
            // 
            this.colproducto.Caption = "Producto";
            this.colproducto.FieldName = "producto";
            this.colproducto.Name = "colproducto";
            this.colproducto.OptionsColumn.AllowEdit = false;
            this.colproducto.Visible = true;
            this.colproducto.VisibleIndex = 0;
            // 
            // colcantidadMovimiento
            // 
            this.colcantidadMovimiento.Caption = "Cantidad Movimiento";
            this.colcantidadMovimiento.FieldName = "cantidadMovimiento";
            this.colcantidadMovimiento.Name = "colcantidadMovimiento";
            this.colcantidadMovimiento.OptionsColumn.AllowEdit = false;
            this.colcantidadMovimiento.Visible = true;
            this.colcantidadMovimiento.VisibleIndex = 1;
            // 
            // colcantidadReal
            // 
            this.colcantidadReal.Caption = "Cantidad Real";
            this.colcantidadReal.FieldName = "cantidadReal";
            this.colcantidadReal.Name = "colcantidadReal";
            this.colcantidadReal.Visible = true;
            this.colcantidadReal.VisibleIndex = 2;
            // 
            // colmovimientoDetalleAjusteId
            // 
            this.colmovimientoDetalleAjusteId.FieldName = "movimientoDetalleAjusteId";
            this.colmovimientoDetalleAjusteId.Name = "colmovimientoDetalleAjusteId";
            this.colmovimientoDetalleAjusteId.OptionsColumn.AllowEdit = false;
            // 
            // uiTraspasos
            // 
            this.uiTraspasos.Location = new System.Drawing.Point(191, 18);
            this.uiTraspasos.Name = "uiTraspasos";
            this.uiTraspasos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTraspasos.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MovimientoId", "Movimiento"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FechaMovimiento", "Fecha")});
            this.uiTraspasos.Properties.DataSource = this.docinvmovimientoBindingSource;
            this.uiTraspasos.Properties.DisplayMember = "MovimientoId";
            this.uiTraspasos.Properties.NullText = "(Selecciona un Traspaso)";
            this.uiTraspasos.Properties.ValueMember = "MovimientoId";
            this.uiTraspasos.Size = new System.Drawing.Size(591, 26);
            this.uiTraspasos.StyleController = this.layoutControl1;
            this.uiTraspasos.TabIndex = 4;
            this.uiTraspasos.EditValueChanged += new System.EventHandler(this.uiTraspasos_EditValueChanged);
            // 
            // docinvmovimientoBindingSource
            // 
            this.docinvmovimientoBindingSource.DataSource = typeof(ConexionBD.doc_inv_movimiento);
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
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiTraspasos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 32);
            this.layoutControlItem1.Text = "1. Selecciona el traspaso a verificar";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(170, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(577, 374);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(193, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiGrid;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(770, 342);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiGuardar;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 374);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(276, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uiCancelar;
            this.layoutControlItem4.Location = new System.Drawing.Point(276, 374);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(301, 46);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmAceptacionSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmAceptacionSucursal";
            this.Text = "Aceptación Sucursal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAceptacionSucursal_FormClosing);
            this.Load += new System.EventHandler(this.frmAceptacionSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aceptacionSucursalGrdModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTraspasos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docinvmovimientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit uiTraspasos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource docinvmovimientoBindingSource;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private System.Windows.Forms.BindingSource aceptacionSucursalGrdModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colmovimientoId;
        private DevExpress.XtraGrid.Columns.GridColumn colmovimientoDetalleId;
        private DevExpress.XtraGrid.Columns.GridColumn colproductoId;
        private DevExpress.XtraGrid.Columns.GridColumn colproducto;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidadMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidadReal;
        private DevExpress.XtraGrid.Columns.GridColumn colmovimientoDetalleAjusteId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}