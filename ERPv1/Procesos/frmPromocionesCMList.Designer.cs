namespace ERPv1.Procesos
{
    partial class frmPromocionesCMList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromocionesCMList));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.uiLayoutFrm = new DevExpress.XtraLayout.LayoutControl();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.uiGrid = new DevExpress.XtraGrid.GridControl();
            this.docpromocionescmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBtnEditar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPromocionCMId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombrePromocion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVigencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoraVigencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLunes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMartes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiercoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJueves = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViernes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSabado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomingo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldoc_promociones_cm_detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_sucursales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.uiLayoutFrm)).BeginInit();
            this.uiLayoutFrm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docpromocionescmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLayoutFrm
            // 
            this.uiLayoutFrm.Controls.Add(this.uiCancelar);
            this.uiLayoutFrm.Controls.Add(this.uiAgregar);
            this.uiLayoutFrm.Controls.Add(this.uiGrid);
            this.uiLayoutFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayoutFrm.Location = new System.Drawing.Point(0, 0);
            this.uiLayoutFrm.Name = "uiLayoutFrm";
            this.uiLayoutFrm.OptionsView.UseDefaultDragAndDropRendering = false;
            this.uiLayoutFrm.Root = this.layoutControlGroup1;
            this.uiLayoutFrm.Size = new System.Drawing.Size(1054, 450);
            this.uiLayoutFrm.TabIndex = 0;
            this.uiLayoutFrm.Text = "layoutControl1";
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiCancelar.Location = new System.Drawing.Point(530, 18);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(506, 40);
            this.uiCancelar.StyleController = this.uiLayoutFrm;
            this.uiCancelar.TabIndex = 6;
            this.uiCancelar.Text = "Salir";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiAgregar
            // 
            this.uiAgregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiAgregar.ImageOptions.Image")));
            this.uiAgregar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiAgregar.Location = new System.Drawing.Point(18, 18);
            this.uiAgregar.Name = "uiAgregar";
            this.uiAgregar.Size = new System.Drawing.Size(506, 40);
            this.uiAgregar.StyleController = this.uiLayoutFrm;
            this.uiAgregar.TabIndex = 5;
            this.uiAgregar.Text = "Agregar";
            this.uiAgregar.Click += new System.EventHandler(this.uiAgregar_Click);
            // 
            // uiGrid
            // 
            this.uiGrid.DataSource = this.docpromocionescmBindingSource;
            this.uiGrid.Location = new System.Drawing.Point(18, 64);
            this.uiGrid.MainView = this.uiGridView;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBtnEditar});
            this.uiGrid.Size = new System.Drawing.Size(1018, 368);
            this.uiGrid.TabIndex = 4;
            this.uiGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.uiGridView});
            // 
            // docpromocionescmBindingSource
            // 
            this.docpromocionescmBindingSource.DataSource = typeof(ConexionBD.doc_promociones_cm);
            // 
            // uiGridView
            // 
            this.uiGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEdit,
            this.colPromocionCMId,
            this.colNombrePromocion,
            this.colFechaRegistro,
            this.colFechaVigencia,
            this.colHoraVigencia,
            this.colLunes,
            this.colMartes,
            this.colMiercoles,
            this.colJueves,
            this.colViernes,
            this.colSabado,
            this.colDomingo,
            this.colCreadoPor,
            this.colActivo,
            this.colSucursalId,
            this.colcat_usuarios,
            this.coldoc_promociones_cm_detalle,
            this.colcat_sucursales});
            this.uiGridView.GridControl = this.uiGrid;
            this.uiGridView.Name = "uiGridView";
            this.uiGridView.OptionsFind.AlwaysVisible = true;
            this.uiGridView.DoubleClick += new System.EventHandler(this.uiGridView_DoubleClick);
            // 
            // colEdit
            // 
            this.colEdit.ColumnEdit = this.repBtnEditar;
            this.colEdit.Name = "colEdit";
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 0;
            // 
            // repBtnEditar
            // 
            this.repBtnEditar.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repBtnEditar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repBtnEditar.Name = "repBtnEditar";
            this.repBtnEditar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repBtnEditar.Click += new System.EventHandler(this.repBtnEditar_Click);
            // 
            // colPromocionCMId
            // 
            this.colPromocionCMId.Caption = "Clave";
            this.colPromocionCMId.FieldName = "PromocionCMId";
            this.colPromocionCMId.Name = "colPromocionCMId";
            this.colPromocionCMId.Visible = true;
            this.colPromocionCMId.VisibleIndex = 1;
            this.colPromocionCMId.Width = 62;
            // 
            // colNombrePromocion
            // 
            this.colNombrePromocion.Caption = "Promoción";
            this.colNombrePromocion.FieldName = "NombrePromocion";
            this.colNombrePromocion.Name = "colNombrePromocion";
            this.colNombrePromocion.Visible = true;
            this.colNombrePromocion.VisibleIndex = 2;
            this.colNombrePromocion.Width = 62;
            // 
            // colFechaRegistro
            // 
            this.colFechaRegistro.Caption = "F. Registro";
            this.colFechaRegistro.FieldName = "FechaRegistro";
            this.colFechaRegistro.Name = "colFechaRegistro";
            this.colFechaRegistro.Visible = true;
            this.colFechaRegistro.VisibleIndex = 3;
            this.colFechaRegistro.Width = 62;
            // 
            // colFechaVigencia
            // 
            this.colFechaVigencia.Caption = "Vigencia";
            this.colFechaVigencia.FieldName = "FechaVigencia";
            this.colFechaVigencia.Name = "colFechaVigencia";
            this.colFechaVigencia.Visible = true;
            this.colFechaVigencia.VisibleIndex = 4;
            this.colFechaVigencia.Width = 62;
            // 
            // colHoraVigencia
            // 
            this.colHoraVigencia.Caption = "Hora Vigencia";
            this.colHoraVigencia.FieldName = "HoraVigencia";
            this.colHoraVigencia.Name = "colHoraVigencia";
            this.colHoraVigencia.Visible = true;
            this.colHoraVigencia.VisibleIndex = 5;
            this.colHoraVigencia.Width = 87;
            // 
            // colLunes
            // 
            this.colLunes.Caption = "Lun";
            this.colLunes.FieldName = "Lunes";
            this.colLunes.Name = "colLunes";
            this.colLunes.Visible = true;
            this.colLunes.VisibleIndex = 6;
            this.colLunes.Width = 59;
            // 
            // colMartes
            // 
            this.colMartes.Caption = "Mar";
            this.colMartes.FieldName = "Martes";
            this.colMartes.Name = "colMartes";
            this.colMartes.Visible = true;
            this.colMartes.VisibleIndex = 7;
            this.colMartes.Width = 59;
            // 
            // colMiercoles
            // 
            this.colMiercoles.Caption = "Mie";
            this.colMiercoles.FieldName = "Miercoles";
            this.colMiercoles.Name = "colMiercoles";
            this.colMiercoles.Visible = true;
            this.colMiercoles.VisibleIndex = 8;
            this.colMiercoles.Width = 59;
            // 
            // colJueves
            // 
            this.colJueves.Caption = "Jue";
            this.colJueves.FieldName = "Jueves";
            this.colJueves.Name = "colJueves";
            this.colJueves.Visible = true;
            this.colJueves.VisibleIndex = 9;
            this.colJueves.Width = 59;
            // 
            // colViernes
            // 
            this.colViernes.Caption = "Vie";
            this.colViernes.FieldName = "Viernes";
            this.colViernes.Name = "colViernes";
            this.colViernes.Visible = true;
            this.colViernes.VisibleIndex = 10;
            this.colViernes.Width = 59;
            // 
            // colSabado
            // 
            this.colSabado.Caption = "Sab";
            this.colSabado.FieldName = "Sabado";
            this.colSabado.Name = "colSabado";
            this.colSabado.Visible = true;
            this.colSabado.VisibleIndex = 11;
            this.colSabado.Width = 59;
            // 
            // colDomingo
            // 
            this.colDomingo.Caption = "Dom";
            this.colDomingo.FieldName = "Domingo";
            this.colDomingo.Name = "colDomingo";
            this.colDomingo.Visible = true;
            this.colDomingo.VisibleIndex = 12;
            this.colDomingo.Width = 59;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.FieldName = "CreadoPor";
            this.colCreadoPor.Name = "colCreadoPor";
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 13;
            this.colActivo.Width = 59;
            // 
            // colSucursalId
            // 
            this.colSucursalId.FieldName = "SucursalId";
            this.colSucursalId.Name = "colSucursalId";
            // 
            // colcat_usuarios
            // 
            this.colcat_usuarios.FieldName = "cat_usuarios";
            this.colcat_usuarios.Name = "colcat_usuarios";
            this.colcat_usuarios.Width = 59;
            // 
            // coldoc_promociones_cm_detalle
            // 
            this.coldoc_promociones_cm_detalle.FieldName = "doc_promociones_cm_detalle";
            this.coldoc_promociones_cm_detalle.Name = "coldoc_promociones_cm_detalle";
            this.coldoc_promociones_cm_detalle.Width = 59;
            // 
            // colcat_sucursales
            // 
            this.colcat_sucursales.FieldName = "cat_sucursales";
            this.colcat_sucursales.Name = "colcat_sucursales";
            this.colcat_sucursales.Width = 70;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1054, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uiGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1024, 374);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uiAgregar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(512, 46);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uiCancelar;
            this.layoutControlItem3.Location = new System.Drawing.Point(512, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(512, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmPromocionesCMList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 450);
            this.Controls.Add(this.uiLayoutFrm);
            this.Name = "frmPromocionesCMList";
            this.Text = "Promociones por compra mínima";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPromocionesCMList_FormClosing);
            this.Load += new System.EventHandler(this.frmPromocionesCMList_Load);
            this.Enter += new System.EventHandler(this.frmPromocionesCMList_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.uiLayoutFrm)).EndInit();
            this.uiLayoutFrm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docpromocionescmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBtnEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl uiLayoutFrm;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl uiGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView uiGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource docpromocionescmBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPromocionCMId;
        private DevExpress.XtraGrid.Columns.GridColumn colNombrePromocion;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVigencia;
        private DevExpress.XtraGrid.Columns.GridColumn colHoraVigencia;
        private DevExpress.XtraGrid.Columns.GridColumn colLunes;
        private DevExpress.XtraGrid.Columns.GridColumn colMartes;
        private DevExpress.XtraGrid.Columns.GridColumn colMiercoles;
        private DevExpress.XtraGrid.Columns.GridColumn colJueves;
        private DevExpress.XtraGrid.Columns.GridColumn colViernes;
        private DevExpress.XtraGrid.Columns.GridColumn colSabado;
        private DevExpress.XtraGrid.Columns.GridColumn colDomingo;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursalId;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios;
        private DevExpress.XtraGrid.Columns.GridColumn coldoc_promociones_cm_detalle;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_sucursales;
        private DevExpress.XtraEditors.SimpleButton uiAgregar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repBtnEditar;
    }
}