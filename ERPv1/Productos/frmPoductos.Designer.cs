namespace ERPv1.Productos
{
    partial class frmPoductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPoductos));
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvAltaPersonal = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtDescCorta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcProducto = new System.Windows.Forms.TabControl();
            this.tpGenerales = new System.Windows.Forms.TabPage();
            this.uiProduccion = new DevExpress.XtraEditors.SimpleButton();
            this.uiClonar = new System.Windows.Forms.Button();
            this.nProductoId = new System.Windows.Forms.NumericUpDown();
            this.chkSeriado = new System.Windows.Forms.CheckBox();
            this.chkProdVtaBascula = new System.Windows.Forms.CheckBox();
            this.chkProdParaVenta = new System.Windows.Forms.CheckBox();
            this.chkMateriaPrima = new System.Windows.Forms.CheckBox();
            this.chkInventariable = new System.Windows.Forms.CheckBox();
            this.chkProductoTerminado = new System.Windows.Forms.CheckBox();
            this.chkEstatusProducto = new System.Windows.Forms.CheckBox();
            this.cmbVendidoPor = new System.Windows.Forms.ComboBox();
            this.nDescEmp = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.nConXCaja = new System.Windows.Forms.NumericUpDown();
            this.nDecimales = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbInvetariadoPor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEliminarFoto = new System.Windows.Forms.LinkLabel();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tpPrecioImp = new System.Windows.Forms.TabPage();
            this.gpPRecios = new System.Windows.Forms.GroupBox();
            this.uiPrecios = new System.Windows.Forms.DataGridView();
            this.IdProductoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpCalcularprecioVta = new System.Windows.Forms.GroupBox();
            this.uiUsarEstablecer = new System.Windows.Forms.RadioButton();
            this.uiUsarIncPesos = new System.Windows.Forms.RadioButton();
            this.uiUsarIncUtilidad = new System.Windows.Forms.RadioButton();
            this.btnAplicarPrecioVta = new System.Windows.Forms.Button();
            this.uiPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.uiEstablecerPrecio = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.uiIncUtilidadPesos = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.uiIncUtilidadPorc = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.gpPrecioUltCompra = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.uiCtoSinIVA = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.uiImpuestos = new System.Windows.Forms.NumericUpDown();
            this.uiCtoNeto = new System.Windows.Forms.NumericUpDown();
            this.tpImpuestos = new System.Windows.Forms.TabPage();
            this.btnAgregarImpuesto = new System.Windows.Forms.Button();
            this.uiImpuestoCMB = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.uiProductosImpuesto = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tpExistencias = new System.Windows.Forms.TabPage();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.uiMaximo = new System.Windows.Forms.NumericUpDown();
            this.uiMinimo = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.uiValuadoCostoProm = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.uiValuadoUtimaCom = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.uiCostoPromedio = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.uiCostoUCompra = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.uiExistencia = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.tpFamilia = new System.Windows.Forms.TabPage();
            this.uiFechaCad = new System.Windows.Forms.DateTimePicker();
            this.uiLote = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.uiLocalizacion = new System.Windows.Forms.ComboBox();
            this.uiAnden = new System.Windows.Forms.ComboBox();
            this.uiAlmacen = new System.Windows.Forms.ComboBox();
            this.uiLinea = new System.Windows.Forms.ComboBox();
            this.uiSubfamilia = new System.Windows.Forms.ComboBox();
            this.uiFamilia = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tpAdiconal = new System.Windows.Forms.TabPage();
            this.uiSobrePedido = new System.Windows.Forms.CheckBox();
            this.uiEspecificaciones = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.uiColor2 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.uiColor = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.uiTalla = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tpFotos = new System.Windows.Forms.TabPage();
            this.uiImagenPrincipal = new System.Windows.Forms.Button();
            this.uiImagenDetalle = new System.Windows.Forms.PictureBox();
            this.label41 = new System.Windows.Forms.Label();
            this.uiGridImagenes = new System.Windows.Forms.DataGridView();
            this.uiPath = new System.Windows.Forms.TextBox();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltaPersonal)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.tcProducto.SuspendLayout();
            this.tpGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nProductoId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDescEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConXCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.tpPrecioImp.SuspendLayout();
            this.gpPRecios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecios)).BeginInit();
            this.gpCalcularprecioVta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiEstablecerPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiIncUtilidadPesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiIncUtilidadPorc)).BeginInit();
            this.gpPrecioUltCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCtoSinIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCtoNeto)).BeginInit();
            this.tpImpuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProductosImpuesto)).BeginInit();
            this.tpExistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiValuadoCostoProm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiValuadoUtimaCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCostoPromedio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCostoUCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiExistencia)).BeginInit();
            this.tpFamilia.SuspendLayout();
            this.tpAdiconal.SuspendLayout();
            this.tpFotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImagenDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridImagenes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.dgvAltaPersonal);
            this.gbListado.Controls.Add(this.label4);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(12, 409);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(1040, 244);
            this.gbListado.TabIndex = 16;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "LISTADO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::ERPv1.Properties.Resources.Search_icon16;
            this.btnBuscar.Location = new System.Drawing.Point(742, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvAltaPersonal
            // 
            this.dgvAltaPersonal.AllowUserToAddRows = false;
            this.dgvAltaPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAltaPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAltaPersonal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAltaPersonal.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAltaPersonal.Location = new System.Drawing.Point(21, 44);
            this.dgvAltaPersonal.Name = "dgvAltaPersonal";
            this.dgvAltaPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAltaPersonal.Size = new System.Drawing.Size(1006, 190);
            this.dgvAltaPersonal.TabIndex = 5;
            this.dgvAltaPersonal.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAltaPersonal_CellMouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(119, 17);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(625, 22);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // gbBotones
            // 
            this.gbBotones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbBotones.Controls.Add(this.btnLimpiar);
            this.gbBotones.Controls.Add(this.btnEliminar);
            this.gbBotones.Controls.Add(this.btnEditar);
            this.gbBotones.Controls.Add(this.btnAgregar);
            this.gbBotones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBotones.ForeColor = System.Drawing.SystemColors.Control;
            this.gbBotones.Location = new System.Drawing.Point(12, 340);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(1040, 70);
            this.gbBotones.TabIndex = 15;
            this.gbBotones.TabStop = false;
            this.gbBotones.Text = "BOTONES";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Black;
            this.btnLimpiar.Image = global::ERPv1.Properties.Resources.Clear_icon24;
            this.btnLimpiar.Location = new System.Drawing.Point(450, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(113, 41);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = global::ERPv1.Properties.Resources.Actions_button_cancel_icon24;
            this.btnEliminar.Location = new System.Drawing.Point(320, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(113, 41);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Black;
            this.btnEditar.Image = global::ERPv1.Properties.Resources.edit_icon24;
            this.btnEditar.Location = new System.Drawing.Point(181, 20);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(113, 41);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar Guardar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Black;
            this.btnAgregar.Image = global::ERPv1.Properties.Resources.Button_Add_icon24;
            this.btnAgregar.Location = new System.Drawing.Point(40, 21);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 41);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbDatos.Controls.Add(this.txtDescCorta);
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.txtNomProducto);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtClave);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.tcProducto);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(12, 4);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(1040, 349);
            this.gbDatos.TabIndex = 14;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // txtDescCorta
            // 
            this.txtDescCorta.Location = new System.Drawing.Point(556, 42);
            this.txtDescCorta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescCorta.MaxLength = 150;
            this.txtDescCorta.Name = "txtDescCorta";
            this.txtDescCorta.Size = new System.Drawing.Size(172, 22);
            this.txtDescCorta.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(554, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "*DESCRIPCIÓN CORTA";
            // 
            // txtNomProducto
            // 
            this.txtNomProducto.Location = new System.Drawing.Point(191, 41);
            this.txtNomProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNomProducto.MaxLength = 150;
            this.txtNomProducto.Name = "txtNomProducto";
            this.txtNomProducto.Size = new System.Drawing.Size(358, 22);
            this.txtNomProducto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "*DESCRIPCIÓN DEL PRODUCTO";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(10, 40);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtClave.MaxLength = 30;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(172, 22);
            this.txtClave.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "*CLAVE/COD. BARRAS";
            // 
            // tcProducto
            // 
            this.tcProducto.Controls.Add(this.tpGenerales);
            this.tcProducto.Controls.Add(this.tpPrecioImp);
            this.tcProducto.Controls.Add(this.tpImpuestos);
            this.tcProducto.Controls.Add(this.tpExistencias);
            this.tcProducto.Controls.Add(this.tpFamilia);
            this.tcProducto.Controls.Add(this.tpAdiconal);
            this.tcProducto.Controls.Add(this.tpFotos);
            this.tcProducto.Location = new System.Drawing.Point(6, 70);
            this.tcProducto.Name = "tcProducto";
            this.tcProducto.SelectedIndex = 0;
            this.tcProducto.Size = new System.Drawing.Size(1021, 267);
            this.tcProducto.TabIndex = 6;
            // 
            // tpGenerales
            // 
            this.tpGenerales.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpGenerales.Controls.Add(this.uiProduccion);
            this.tpGenerales.Controls.Add(this.uiClonar);
            this.tpGenerales.Controls.Add(this.nProductoId);
            this.tpGenerales.Controls.Add(this.chkSeriado);
            this.tpGenerales.Controls.Add(this.chkProdVtaBascula);
            this.tpGenerales.Controls.Add(this.chkProdParaVenta);
            this.tpGenerales.Controls.Add(this.chkMateriaPrima);
            this.tpGenerales.Controls.Add(this.chkInventariable);
            this.tpGenerales.Controls.Add(this.chkProductoTerminado);
            this.tpGenerales.Controls.Add(this.chkEstatusProducto);
            this.tpGenerales.Controls.Add(this.cmbVendidoPor);
            this.tpGenerales.Controls.Add(this.nDescEmp);
            this.tpGenerales.Controls.Add(this.label14);
            this.tpGenerales.Controls.Add(this.nConXCaja);
            this.tpGenerales.Controls.Add(this.nDecimales);
            this.tpGenerales.Controls.Add(this.label8);
            this.tpGenerales.Controls.Add(this.label13);
            this.tpGenerales.Controls.Add(this.cmbInvetariadoPor);
            this.tpGenerales.Controls.Add(this.label12);
            this.tpGenerales.Controls.Add(this.cmbMarca);
            this.tpGenerales.Controls.Add(this.label11);
            this.tpGenerales.Controls.Add(this.cmbUnidadMedida);
            this.tpGenerales.Controls.Add(this.label7);
            this.tpGenerales.Controls.Add(this.lblEliminarFoto);
            this.tpGenerales.Controls.Add(this.pbFoto);
            this.tpGenerales.Controls.Add(this.label3);
            this.tpGenerales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tpGenerales.Location = new System.Drawing.Point(4, 25);
            this.tpGenerales.Name = "tpGenerales";
            this.tpGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenerales.Size = new System.Drawing.Size(1013, 238);
            this.tpGenerales.TabIndex = 0;
            this.tpGenerales.Text = "GENERALES";
            this.tpGenerales.Click += new System.EventHandler(this.tpGenerales_Click);
            // 
            // uiProduccion
            // 
            this.uiProduccion.Location = new System.Drawing.Point(903, 61);
            this.uiProduccion.Name = "uiProduccion";
            this.uiProduccion.Size = new System.Drawing.Size(104, 23);
            this.uiProduccion.TabIndex = 43;
            this.uiProduccion.Text = "PRODUCCIÓN";
            this.uiProduccion.Click += new System.EventHandler(this.uiProduccion_Click);
            // 
            // uiClonar
            // 
            this.uiClonar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiClonar.Location = new System.Drawing.Point(903, 29);
            this.uiClonar.Name = "uiClonar";
            this.uiClonar.Size = new System.Drawing.Size(104, 25);
            this.uiClonar.TabIndex = 42;
            this.uiClonar.Text = "CLONAR";
            this.uiClonar.UseVisualStyleBackColor = true;
            this.uiClonar.Click += new System.EventHandler(this.uiClonar_Click);
            // 
            // nProductoId
            // 
            this.nProductoId.Location = new System.Drawing.Point(456, 185);
            this.nProductoId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nProductoId.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nProductoId.Name = "nProductoId";
            this.nProductoId.Size = new System.Drawing.Size(97, 22);
            this.nProductoId.TabIndex = 41;
            this.nProductoId.Visible = false;
            // 
            // chkSeriado
            // 
            this.chkSeriado.AutoSize = true;
            this.chkSeriado.Location = new System.Drawing.Point(624, 198);
            this.chkSeriado.Name = "chkSeriado";
            this.chkSeriado.Size = new System.Drawing.Size(148, 20);
            this.chkSeriado.TabIndex = 14;
            this.chkSeriado.Text = "Producto Seriado";
            this.chkSeriado.UseVisualStyleBackColor = true;
            // 
            // chkProdVtaBascula
            // 
            this.chkProdVtaBascula.AutoSize = true;
            this.chkProdVtaBascula.Location = new System.Drawing.Point(624, 180);
            this.chkProdVtaBascula.Name = "chkProdVtaBascula";
            this.chkProdVtaBascula.Size = new System.Drawing.Size(171, 20);
            this.chkProdVtaBascula.TabIndex = 13;
            this.chkProdVtaBascula.Text = "Proucto Vta. Bascula";
            this.chkProdVtaBascula.UseVisualStyleBackColor = true;
            this.chkProdVtaBascula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkProdVtaBascula_KeyPress);
            // 
            // chkProdParaVenta
            // 
            this.chkProdParaVenta.AutoSize = true;
            this.chkProdParaVenta.Checked = true;
            this.chkProdParaVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProdParaVenta.Location = new System.Drawing.Point(624, 161);
            this.chkProdParaVenta.Name = "chkProdParaVenta";
            this.chkProdParaVenta.Size = new System.Drawing.Size(169, 20);
            this.chkProdParaVenta.TabIndex = 12;
            this.chkProdParaVenta.Text = "Producto para Venta";
            this.chkProdParaVenta.UseVisualStyleBackColor = true;
            this.chkProdParaVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkProdParaVenta_KeyPress);
            // 
            // chkMateriaPrima
            // 
            this.chkMateriaPrima.AutoSize = true;
            this.chkMateriaPrima.Location = new System.Drawing.Point(624, 144);
            this.chkMateriaPrima.Name = "chkMateriaPrima";
            this.chkMateriaPrima.Size = new System.Drawing.Size(123, 20);
            this.chkMateriaPrima.TabIndex = 11;
            this.chkMateriaPrima.Text = "Materia Prima";
            this.chkMateriaPrima.UseVisualStyleBackColor = true;
            this.chkMateriaPrima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkMateriaPrima_KeyPress);
            // 
            // chkInventariable
            // 
            this.chkInventariable.AutoSize = true;
            this.chkInventariable.Checked = true;
            this.chkInventariable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInventariable.Location = new System.Drawing.Point(624, 125);
            this.chkInventariable.Name = "chkInventariable";
            this.chkInventariable.Size = new System.Drawing.Size(117, 20);
            this.chkInventariable.TabIndex = 10;
            this.chkInventariable.Text = "Inventariable";
            this.chkInventariable.UseVisualStyleBackColor = true;
            this.chkInventariable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkInventariable_KeyPress);
            // 
            // chkProductoTerminado
            // 
            this.chkProductoTerminado.AutoSize = true;
            this.chkProductoTerminado.Checked = true;
            this.chkProductoTerminado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProductoTerminado.Location = new System.Drawing.Point(624, 108);
            this.chkProductoTerminado.Name = "chkProductoTerminado";
            this.chkProductoTerminado.Size = new System.Drawing.Size(168, 20);
            this.chkProductoTerminado.TabIndex = 9;
            this.chkProductoTerminado.Text = "Producto Terminado";
            this.chkProductoTerminado.UseVisualStyleBackColor = true;
            this.chkProductoTerminado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkProductoTerminado_KeyPress);
            // 
            // chkEstatusProducto
            // 
            this.chkEstatusProducto.AutoSize = true;
            this.chkEstatusProducto.Checked = true;
            this.chkEstatusProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatusProducto.Location = new System.Drawing.Point(624, 89);
            this.chkEstatusProducto.Name = "chkEstatusProducto";
            this.chkEstatusProducto.Size = new System.Drawing.Size(70, 20);
            this.chkEstatusProducto.TabIndex = 8;
            this.chkEstatusProducto.Text = "Activo";
            this.chkEstatusProducto.UseVisualStyleBackColor = true;
            this.chkEstatusProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkEstatusProducto_KeyPress);
            // 
            // cmbVendidoPor
            // 
            this.cmbVendidoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendidoPor.FormattingEnabled = true;
            this.cmbVendidoPor.Location = new System.Drawing.Point(440, 89);
            this.cmbVendidoPor.Name = "cmbVendidoPor";
            this.cmbVendidoPor.Size = new System.Drawing.Size(171, 24);
            this.cmbVendidoPor.TabIndex = 4;
            this.cmbVendidoPor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbVendidoPor_KeyPress);
            // 
            // nDescEmp
            // 
            this.nDescEmp.DecimalPlaces = 2;
            this.nDescEmp.Location = new System.Drawing.Point(253, 149);
            this.nDescEmp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nDescEmp.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nDescEmp.Name = "nDescEmp";
            this.nDescEmp.Size = new System.Drawing.Size(170, 22);
            this.nDescEmp.TabIndex = 5;
            this.nDescEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nDescEmp_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(253, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 16);
            this.label14.TabIndex = 31;
            this.label14.Text = "% DESC. EMPLEADOS";
            // 
            // nConXCaja
            // 
            this.nConXCaja.Location = new System.Drawing.Point(440, 149);
            this.nConXCaja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nConXCaja.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nConXCaja.Name = "nConXCaja";
            this.nConXCaja.Size = new System.Drawing.Size(170, 22);
            this.nConXCaja.TabIndex = 6;
            this.nConXCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nConXCaja_KeyPress);
            // 
            // nDecimales
            // 
            this.nDecimales.Location = new System.Drawing.Point(624, 31);
            this.nDecimales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nDecimales.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nDecimales.Name = "nDecimales";
            this.nDecimales.Size = new System.Drawing.Size(97, 22);
            this.nDecimales.TabIndex = 2;
            this.nDecimales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nDecimales_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "SE VENDE POR";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(437, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(175, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "CONTENIDO POR CAJA";
            // 
            // cmbInvetariadoPor
            // 
            this.cmbInvetariadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvetariadoPor.FormattingEnabled = true;
            this.cmbInvetariadoPor.Location = new System.Drawing.Point(251, 90);
            this.cmbInvetariadoPor.Name = "cmbInvetariadoPor";
            this.cmbInvetariadoPor.Size = new System.Drawing.Size(171, 24);
            this.cmbInvetariadoPor.TabIndex = 3;
            this.cmbInvetariadoPor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInvetariadoPor_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(624, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "DECIMALES";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(440, 30);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(171, 24);
            this.cmbMarca.TabIndex = 1;
            this.cmbMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMarca_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "*MARCA";
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(253, 31);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(171, 24);
            this.cmbUnidadMedida.TabIndex = 0;
            this.cmbUnidadMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUnidadMedida_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "INVENTARIADO POR";
            // 
            // lblEliminarFoto
            // 
            this.lblEliminarFoto.AutoSize = true;
            this.lblEliminarFoto.LinkColor = System.Drawing.Color.White;
            this.lblEliminarFoto.Location = new System.Drawing.Point(248, 185);
            this.lblEliminarFoto.Name = "lblEliminarFoto";
            this.lblEliminarFoto.Size = new System.Drawing.Size(59, 32);
            this.lblEliminarFoto.TabIndex = 7;
            this.lblEliminarFoto.TabStop = true;
            this.lblEliminarFoto.Text = "Quitar\r\nImagen";
            this.lblEliminarFoto.Click += new System.EventHandler(this.lblEliminarFoto_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pbFoto.BackgroundImage = global::ERPv1.Properties.Resources.Search_good_icon72x72;
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFoto.ErrorImage = global::ERPv1.Properties.Resources.Search_good_icon72x72;
            this.pbFoto.InitialImage = global::ERPv1.Properties.Resources.personal_information_icon28x128;
            this.pbFoto.Location = new System.Drawing.Point(10, 9);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(222, 218);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 10;
            this.pbFoto.TabStop = false;
            this.pbFoto.Click += new System.EventHandler(this.pbFoto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "UNIDAD DE MEDIDA";
            // 
            // tpPrecioImp
            // 
            this.tpPrecioImp.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpPrecioImp.Controls.Add(this.gpPRecios);
            this.tpPrecioImp.Controls.Add(this.gpCalcularprecioVta);
            this.tpPrecioImp.Controls.Add(this.gpPrecioUltCompra);
            this.tpPrecioImp.Location = new System.Drawing.Point(4, 25);
            this.tpPrecioImp.Name = "tpPrecioImp";
            this.tpPrecioImp.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrecioImp.Size = new System.Drawing.Size(1013, 238);
            this.tpPrecioImp.TabIndex = 1;
            this.tpPrecioImp.Text = "PRECIO/IMP";
            // 
            // gpPRecios
            // 
            this.gpPRecios.Controls.Add(this.uiPrecios);
            this.gpPRecios.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpPRecios.Location = new System.Drawing.Point(450, 8);
            this.gpPRecios.Name = "gpPRecios";
            this.gpPRecios.Size = new System.Drawing.Size(555, 234);
            this.gpPRecios.TabIndex = 10;
            this.gpPRecios.TabStop = false;
            this.gpPRecios.Text = "Precios";
            // 
            // uiPrecios
            // 
            this.uiPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiPrecios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProductoPrecio,
            this.IdPrecio,
            this.Descripcion,
            this.PorcDescuento,
            this.MontoDescuento,
            this.Precio});
            this.uiPrecios.Location = new System.Drawing.Point(6, 19);
            this.uiPrecios.Name = "uiPrecios";
            this.uiPrecios.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.uiPrecios.Size = new System.Drawing.Size(534, 209);
            this.uiPrecios.TabIndex = 0;
            this.uiPrecios.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.uiPrecios_CellBeginEdit);
            this.uiPrecios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiPrecios_CellEndEdit);
            this.uiPrecios.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiPrecios_RowValidated);
            this.uiPrecios.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.uiPrecios_RowValidating);
            // 
            // IdProductoPrecio
            // 
            this.IdProductoPrecio.DataPropertyName = "IdProductoPrecio";
            this.IdProductoPrecio.HeaderText = "IdProductoPrecio";
            this.IdProductoPrecio.MinimumWidth = 2;
            this.IdProductoPrecio.Name = "IdProductoPrecio";
            this.IdProductoPrecio.ReadOnly = true;
            this.IdProductoPrecio.Width = 2;
            // 
            // IdPrecio
            // 
            this.IdPrecio.DataPropertyName = "IdPrecio";
            this.IdPrecio.HeaderText = "IdPrecio";
            this.IdPrecio.MinimumWidth = 2;
            this.IdPrecio.Name = "IdPrecio";
            this.IdPrecio.ReadOnly = true;
            this.IdPrecio.Width = 2;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // PorcDescuento
            // 
            this.PorcDescuento.DataPropertyName = "PorcDescuento";
            this.PorcDescuento.HeaderText = "%";
            this.PorcDescuento.Name = "PorcDescuento";
            this.PorcDescuento.Width = 80;
            // 
            // MontoDescuento
            // 
            this.MontoDescuento.DataPropertyName = "MontoDescuento";
            this.MontoDescuento.HeaderText = "Descuento $";
            this.MontoDescuento.Name = "MontoDescuento";
            this.MontoDescuento.ReadOnly = true;
            this.MontoDescuento.Width = 80;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 80;
            // 
            // gpCalcularprecioVta
            // 
            this.gpCalcularprecioVta.Controls.Add(this.uiUsarEstablecer);
            this.gpCalcularprecioVta.Controls.Add(this.uiUsarIncPesos);
            this.gpCalcularprecioVta.Controls.Add(this.uiUsarIncUtilidad);
            this.gpCalcularprecioVta.Controls.Add(this.btnAplicarPrecioVta);
            this.gpCalcularprecioVta.Controls.Add(this.uiPrecioVenta);
            this.gpCalcularprecioVta.Controls.Add(this.label33);
            this.gpCalcularprecioVta.Controls.Add(this.uiEstablecerPrecio);
            this.gpCalcularprecioVta.Controls.Add(this.label32);
            this.gpCalcularprecioVta.Controls.Add(this.uiIncUtilidadPesos);
            this.gpCalcularprecioVta.Controls.Add(this.label31);
            this.gpCalcularprecioVta.Controls.Add(this.uiIncUtilidadPorc);
            this.gpCalcularprecioVta.Controls.Add(this.label5);
            this.gpCalcularprecioVta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpCalcularprecioVta.Location = new System.Drawing.Point(181, 6);
            this.gpCalcularprecioVta.Name = "gpCalcularprecioVta";
            this.gpCalcularprecioVta.Size = new System.Drawing.Size(252, 236);
            this.gpCalcularprecioVta.TabIndex = 8;
            this.gpCalcularprecioVta.TabStop = false;
            this.gpCalcularprecioVta.Text = "Calcular Nuevo Precio Vta";
            // 
            // uiUsarEstablecer
            // 
            this.uiUsarEstablecer.AutoSize = true;
            this.uiUsarEstablecer.Location = new System.Drawing.Point(120, 128);
            this.uiUsarEstablecer.Name = "uiUsarEstablecer";
            this.uiUsarEstablecer.Size = new System.Drawing.Size(14, 13);
            this.uiUsarEstablecer.TabIndex = 17;
            this.uiUsarEstablecer.UseVisualStyleBackColor = true;
            this.uiUsarEstablecer.CheckedChanged += new System.EventHandler(this.uiUsarEstablecer_CheckedChanged);
            // 
            // uiUsarIncPesos
            // 
            this.uiUsarIncPesos.AutoSize = true;
            this.uiUsarIncPesos.Location = new System.Drawing.Point(120, 86);
            this.uiUsarIncPesos.Name = "uiUsarIncPesos";
            this.uiUsarIncPesos.Size = new System.Drawing.Size(14, 13);
            this.uiUsarIncPesos.TabIndex = 16;
            this.uiUsarIncPesos.UseVisualStyleBackColor = true;
            this.uiUsarIncPesos.CheckedChanged += new System.EventHandler(this.uiUsarIncPesos_CheckedChanged);
            // 
            // uiUsarIncUtilidad
            // 
            this.uiUsarIncUtilidad.AutoSize = true;
            this.uiUsarIncUtilidad.Checked = true;
            this.uiUsarIncUtilidad.Location = new System.Drawing.Point(120, 39);
            this.uiUsarIncUtilidad.Name = "uiUsarIncUtilidad";
            this.uiUsarIncUtilidad.Size = new System.Drawing.Size(14, 13);
            this.uiUsarIncUtilidad.TabIndex = 15;
            this.uiUsarIncUtilidad.TabStop = true;
            this.uiUsarIncUtilidad.UseVisualStyleBackColor = true;
            this.uiUsarIncUtilidad.CheckedChanged += new System.EventHandler(this.uiUsarIncUtilidad_CheckedChanged);
            // 
            // btnAplicarPrecioVta
            // 
            this.btnAplicarPrecioVta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAplicarPrecioVta.Location = new System.Drawing.Point(120, 154);
            this.btnAplicarPrecioVta.Name = "btnAplicarPrecioVta";
            this.btnAplicarPrecioVta.Size = new System.Drawing.Size(126, 42);
            this.btnAplicarPrecioVta.TabIndex = 4;
            this.btnAplicarPrecioVta.Text = "Aplicar Precio Venta";
            this.btnAplicarPrecioVta.UseVisualStyleBackColor = true;
            this.btnAplicarPrecioVta.Click += new System.EventHandler(this.btnAplicarPrecioVta_Click);
            // 
            // uiPrecioVenta
            // 
            this.uiPrecioVenta.DecimalPlaces = 2;
            this.uiPrecioVenta.Enabled = false;
            this.uiPrecioVenta.Location = new System.Drawing.Point(10, 173);
            this.uiPrecioVenta.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiPrecioVenta.Name = "uiPrecioVenta";
            this.uiPrecioVenta.Size = new System.Drawing.Size(94, 22);
            this.uiPrecioVenta.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 154);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(97, 16);
            this.label33.TabIndex = 14;
            this.label33.Text = "Precio Venta";
            // 
            // uiEstablecerPrecio
            // 
            this.uiEstablecerPrecio.DecimalPlaces = 2;
            this.uiEstablecerPrecio.Enabled = false;
            this.uiEstablecerPrecio.Location = new System.Drawing.Point(9, 128);
            this.uiEstablecerPrecio.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiEstablecerPrecio.Name = "uiEstablecerPrecio";
            this.uiEstablecerPrecio.Size = new System.Drawing.Size(94, 22);
            this.uiEstablecerPrecio.TabIndex = 2;
            this.uiEstablecerPrecio.ValueChanged += new System.EventHandler(this.uiEstablecerPrecio_ValueChanged);
            this.uiEstablecerPrecio.Validating += new System.ComponentModel.CancelEventHandler(this.uiEstablecerPrecio_Validating);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 109);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(132, 16);
            this.label32.TabIndex = 12;
            this.label32.Text = "Establecer Precio";
            // 
            // uiIncUtilidadPesos
            // 
            this.uiIncUtilidadPesos.DecimalPlaces = 2;
            this.uiIncUtilidadPesos.Enabled = false;
            this.uiIncUtilidadPesos.Location = new System.Drawing.Point(9, 83);
            this.uiIncUtilidadPesos.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiIncUtilidadPesos.Name = "uiIncUtilidadPesos";
            this.uiIncUtilidadPesos.Size = new System.Drawing.Size(94, 22);
            this.uiIncUtilidadPesos.TabIndex = 1;
            this.uiIncUtilidadPesos.ValueChanged += new System.EventHandler(this.uiIncUtilidadPesos_ValueChanged);
            this.uiIncUtilidadPesos.Validating += new System.ComponentModel.CancelEventHandler(this.uiIncUtilidadPesos_Validating);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(216, 16);
            this.label31.TabIndex = 10;
            this.label31.Text = "Incrementar utilidad en pesos ";
            // 
            // uiIncUtilidadPorc
            // 
            this.uiIncUtilidadPorc.DecimalPlaces = 2;
            this.uiIncUtilidadPorc.Location = new System.Drawing.Point(10, 38);
            this.uiIncUtilidadPorc.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiIncUtilidadPorc.Name = "uiIncUtilidadPorc";
            this.uiIncUtilidadPorc.Size = new System.Drawing.Size(94, 22);
            this.uiIncUtilidadPorc.TabIndex = 0;
            this.uiIncUtilidadPorc.ValueChanged += new System.EventHandler(this.uiIncUtilidadPorc_ValueChanged);
            this.uiIncUtilidadPorc.Validating += new System.ComponentModel.CancelEventHandler(this.uiIncUtilidadPorc_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "%Incremento Utilidad";
            // 
            // gpPrecioUltCompra
            // 
            this.gpPrecioUltCompra.Controls.Add(this.label6);
            this.gpPrecioUltCompra.Controls.Add(this.label30);
            this.gpPrecioUltCompra.Controls.Add(this.uiCtoSinIVA);
            this.gpPrecioUltCompra.Controls.Add(this.label10);
            this.gpPrecioUltCompra.Controls.Add(this.uiImpuestos);
            this.gpPrecioUltCompra.Controls.Add(this.uiCtoNeto);
            this.gpPrecioUltCompra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpPrecioUltCompra.Location = new System.Drawing.Point(6, 6);
            this.gpPrecioUltCompra.Name = "gpPrecioUltCompra";
            this.gpPrecioUltCompra.Size = new System.Drawing.Size(166, 236);
            this.gpPrecioUltCompra.TabIndex = 7;
            this.gpPrecioUltCompra.TabStop = false;
            this.gpPrecioUltCompra.Text = "Precio Ult. Compra";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Cto. sin IVA";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 109);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 16);
            this.label30.TabIndex = 6;
            this.label30.Text = "Cto. Neto";
            // 
            // uiCtoSinIVA
            // 
            this.uiCtoSinIVA.DecimalPlaces = 2;
            this.uiCtoSinIVA.Enabled = false;
            this.uiCtoSinIVA.Location = new System.Drawing.Point(9, 38);
            this.uiCtoSinIVA.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiCtoSinIVA.Name = "uiCtoSinIVA";
            this.uiCtoSinIVA.Size = new System.Drawing.Size(94, 22);
            this.uiCtoSinIVA.TabIndex = 0;
            this.uiCtoSinIVA.ValueChanged += new System.EventHandler(this.uiCtoSinIVA_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Impuestos";
            // 
            // uiImpuestos
            // 
            this.uiImpuestos.DecimalPlaces = 2;
            this.uiImpuestos.Enabled = false;
            this.uiImpuestos.Location = new System.Drawing.Point(9, 83);
            this.uiImpuestos.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiImpuestos.Name = "uiImpuestos";
            this.uiImpuestos.Size = new System.Drawing.Size(94, 22);
            this.uiImpuestos.TabIndex = 1;
            // 
            // uiCtoNeto
            // 
            this.uiCtoNeto.DecimalPlaces = 2;
            this.uiCtoNeto.Enabled = false;
            this.uiCtoNeto.Location = new System.Drawing.Point(9, 128);
            this.uiCtoNeto.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.uiCtoNeto.Name = "uiCtoNeto";
            this.uiCtoNeto.Size = new System.Drawing.Size(94, 22);
            this.uiCtoNeto.TabIndex = 2;
            // 
            // tpImpuestos
            // 
            this.tpImpuestos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpImpuestos.Controls.Add(this.btnAgregarImpuesto);
            this.tpImpuestos.Controls.Add(this.uiImpuestoCMB);
            this.tpImpuestos.Controls.Add(this.label34);
            this.tpImpuestos.Controls.Add(this.uiProductosImpuesto);
            this.tpImpuestos.Location = new System.Drawing.Point(4, 25);
            this.tpImpuestos.Name = "tpImpuestos";
            this.tpImpuestos.Padding = new System.Windows.Forms.Padding(3);
            this.tpImpuestos.Size = new System.Drawing.Size(1013, 238);
            this.tpImpuestos.TabIndex = 4;
            this.tpImpuestos.Text = "IMPUESTOS";
            // 
            // btnAgregarImpuesto
            // 
            this.btnAgregarImpuesto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarImpuesto.Location = new System.Drawing.Point(469, 16);
            this.btnAgregarImpuesto.Name = "btnAgregarImpuesto";
            this.btnAgregarImpuesto.Size = new System.Drawing.Size(75, 28);
            this.btnAgregarImpuesto.TabIndex = 3;
            this.btnAgregarImpuesto.Text = "Agregar";
            this.btnAgregarImpuesto.UseVisualStyleBackColor = true;
            this.btnAgregarImpuesto.Click += new System.EventHandler(this.btnAgregarImpuesto_Click);
            // 
            // uiImpuestoCMB
            // 
            this.uiImpuestoCMB.DisplayMember = "Descripcion";
            this.uiImpuestoCMB.FormattingEnabled = true;
            this.uiImpuestoCMB.Location = new System.Drawing.Point(109, 16);
            this.uiImpuestoCMB.Name = "uiImpuestoCMB";
            this.uiImpuestoCMB.Size = new System.Drawing.Size(354, 24);
            this.uiImpuestoCMB.TabIndex = 2;
            this.uiImpuestoCMB.ValueMember = "cLAVE";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(27, 19);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(71, 16);
            this.label34.TabIndex = 1;
            this.label34.Text = "Impuesto";
            // 
            // uiProductosImpuesto
            // 
            this.uiProductosImpuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiProductosImpuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DescripcionImpuesto,
            this.Porcentaje,
            this.Delete});
            this.uiProductosImpuesto.Location = new System.Drawing.Point(30, 46);
            this.uiProductosImpuesto.Name = "uiProductosImpuesto";
            this.uiProductosImpuesto.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.uiProductosImpuesto.Size = new System.Drawing.Size(537, 180);
            this.uiProductosImpuesto.TabIndex = 0;
            this.uiProductosImpuesto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiProductosImpuesto_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // DescripcionImpuesto
            // 
            this.DescripcionImpuesto.DataPropertyName = "DescripcionImpuesto";
            this.DescripcionImpuesto.HeaderText = "Descripción";
            this.DescripcionImpuesto.Name = "DescripcionImpuesto";
            this.DescripcionImpuesto.ReadOnly = true;
            this.DescripcionImpuesto.Width = 150;
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "Porcentaje";
            this.Porcentaje.HeaderText = "%";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Eliminar";
            this.Delete.HeaderText = "Eliminar";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Eliminar";
            // 
            // tpExistencias
            // 
            this.tpExistencias.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpExistencias.Controls.Add(this.uiSucursal);
            this.tpExistencias.Controls.Add(this.label35);
            this.tpExistencias.Controls.Add(this.uiMaximo);
            this.tpExistencias.Controls.Add(this.uiMinimo);
            this.tpExistencias.Controls.Add(this.label21);
            this.tpExistencias.Controls.Add(this.label20);
            this.tpExistencias.Controls.Add(this.uiValuadoCostoProm);
            this.tpExistencias.Controls.Add(this.label19);
            this.tpExistencias.Controls.Add(this.uiValuadoUtimaCom);
            this.tpExistencias.Controls.Add(this.label18);
            this.tpExistencias.Controls.Add(this.uiCostoPromedio);
            this.tpExistencias.Controls.Add(this.label17);
            this.tpExistencias.Controls.Add(this.uiCostoUCompra);
            this.tpExistencias.Controls.Add(this.label16);
            this.tpExistencias.Controls.Add(this.uiExistencia);
            this.tpExistencias.Controls.Add(this.label15);
            this.tpExistencias.Location = new System.Drawing.Point(4, 25);
            this.tpExistencias.Name = "tpExistencias";
            this.tpExistencias.Padding = new System.Windows.Forms.Padding(3);
            this.tpExistencias.Size = new System.Drawing.Size(1013, 238);
            this.tpExistencias.TabIndex = 2;
            this.tpExistencias.Text = "EXISTENCIAS";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(163, 4);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(416, 24);
            this.uiSucursal.TabIndex = 15;
            this.uiSucursal.ValueMember = "Clave";
            this.uiSucursal.SelectedValueChanged += new System.EventHandler(this.uiSucursal_SelectedValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label35.Location = new System.Drawing.Point(87, 9);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(68, 16);
            this.label35.TabIndex = 14;
            this.label35.Text = "Sucursal";
            // 
            // uiMaximo
            // 
            this.uiMaximo.Location = new System.Drawing.Point(595, 130);
            this.uiMaximo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiMaximo.Name = "uiMaximo";
            this.uiMaximo.Size = new System.Drawing.Size(120, 22);
            this.uiMaximo.TabIndex = 6;
            // 
            // uiMinimo
            // 
            this.uiMinimo.Location = new System.Drawing.Point(164, 130);
            this.uiMinimo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiMinimo.Name = "uiMinimo";
            this.uiMinimo.Size = new System.Drawing.Size(120, 22);
            this.uiMinimo.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label21.Location = new System.Drawing.Point(517, 132);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 16);
            this.label21.TabIndex = 12;
            this.label21.Text = "Máximo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label20.Location = new System.Drawing.Point(76, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 16);
            this.label20.TabIndex = 10;
            this.label20.Text = "Mínimo";
            // 
            // uiValuadoCostoProm
            // 
            this.uiValuadoCostoProm.DecimalPlaces = 2;
            this.uiValuadoCostoProm.Enabled = false;
            this.uiValuadoCostoProm.Location = new System.Drawing.Point(595, 68);
            this.uiValuadoCostoProm.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiValuadoCostoProm.Name = "uiValuadoCostoProm";
            this.uiValuadoCostoProm.Size = new System.Drawing.Size(120, 22);
            this.uiValuadoCostoProm.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label19.Location = new System.Drawing.Point(355, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(181, 16);
            this.label19.TabIndex = 6;
            this.label19.Text = "Valuado Costo Promedio";
            // 
            // uiValuadoUtimaCom
            // 
            this.uiValuadoUtimaCom.DecimalPlaces = 2;
            this.uiValuadoUtimaCom.Enabled = false;
            this.uiValuadoUtimaCom.Location = new System.Drawing.Point(595, 36);
            this.uiValuadoUtimaCom.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiValuadoUtimaCom.Name = "uiValuadoUtimaCom";
            this.uiValuadoUtimaCom.Size = new System.Drawing.Size(120, 22);
            this.uiValuadoUtimaCom.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(355, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(224, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Valuado a Costo última compra";
            // 
            // uiCostoPromedio
            // 
            this.uiCostoPromedio.DecimalPlaces = 2;
            this.uiCostoPromedio.Enabled = false;
            this.uiCostoPromedio.Location = new System.Drawing.Point(164, 101);
            this.uiCostoPromedio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiCostoPromedio.Name = "uiCostoPromedio";
            this.uiCostoPromedio.Size = new System.Drawing.Size(120, 22);
            this.uiCostoPromedio.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label17.Location = new System.Drawing.Point(20, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 16);
            this.label17.TabIndex = 8;
            this.label17.Text = "Costo Promedio";
            // 
            // uiCostoUCompra
            // 
            this.uiCostoUCompra.DecimalPlaces = 2;
            this.uiCostoUCompra.Enabled = false;
            this.uiCostoUCompra.Location = new System.Drawing.Point(164, 68);
            this.uiCostoUCompra.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiCostoUCompra.Name = "uiCostoUCompra";
            this.uiCostoUCompra.Size = new System.Drawing.Size(120, 22);
            this.uiCostoUCompra.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(20, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 16);
            this.label16.TabIndex = 4;
            this.label16.Text = "Costo U. Compra";
            // 
            // uiExistencia
            // 
            this.uiExistencia.DecimalPlaces = 2;
            this.uiExistencia.Enabled = false;
            this.uiExistencia.Location = new System.Drawing.Point(164, 34);
            this.uiExistencia.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiExistencia.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.uiExistencia.Name = "uiExistencia";
            this.uiExistencia.Size = new System.Drawing.Size(120, 22);
            this.uiExistencia.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(20, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Existencia Teórica";
            // 
            // tpFamilia
            // 
            this.tpFamilia.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpFamilia.Controls.Add(this.uiFechaCad);
            this.tpFamilia.Controls.Add(this.uiLote);
            this.tpFamilia.Controls.Add(this.label29);
            this.tpFamilia.Controls.Add(this.label28);
            this.tpFamilia.Controls.Add(this.uiLocalizacion);
            this.tpFamilia.Controls.Add(this.uiAnden);
            this.tpFamilia.Controls.Add(this.uiAlmacen);
            this.tpFamilia.Controls.Add(this.uiLinea);
            this.tpFamilia.Controls.Add(this.uiSubfamilia);
            this.tpFamilia.Controls.Add(this.uiFamilia);
            this.tpFamilia.Controls.Add(this.label27);
            this.tpFamilia.Controls.Add(this.label26);
            this.tpFamilia.Controls.Add(this.label25);
            this.tpFamilia.Controls.Add(this.label24);
            this.tpFamilia.Controls.Add(this.label23);
            this.tpFamilia.Controls.Add(this.label22);
            this.tpFamilia.Location = new System.Drawing.Point(4, 25);
            this.tpFamilia.Name = "tpFamilia";
            this.tpFamilia.Padding = new System.Windows.Forms.Padding(3);
            this.tpFamilia.Size = new System.Drawing.Size(1013, 238);
            this.tpFamilia.TabIndex = 3;
            this.tpFamilia.Text = "FAMILIA/UBICACION";
            // 
            // uiFechaCad
            // 
            this.uiFechaCad.Location = new System.Drawing.Point(574, 16);
            this.uiFechaCad.Name = "uiFechaCad";
            this.uiFechaCad.Size = new System.Drawing.Size(200, 22);
            this.uiFechaCad.TabIndex = 6;
            // 
            // uiLote
            // 
            this.uiLote.DisplayMember = "Descripcion";
            this.uiLote.FormattingEnabled = true;
            this.uiLote.Location = new System.Drawing.Point(574, 42);
            this.uiLote.Name = "uiLote";
            this.uiLote.Size = new System.Drawing.Size(235, 24);
            this.uiLote.TabIndex = 7;
            this.uiLote.ValueMember = "Clave";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(525, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 16);
            this.label29.TabIndex = 14;
            this.label29.Text = "Lote";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(418, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(152, 16);
            this.label28.TabIndex = 12;
            this.label28.Text = "Fecha de Caducidad";
            // 
            // uiLocalizacion
            // 
            this.uiLocalizacion.FormattingEnabled = true;
            this.uiLocalizacion.Location = new System.Drawing.Point(139, 172);
            this.uiLocalizacion.Name = "uiLocalizacion";
            this.uiLocalizacion.Size = new System.Drawing.Size(235, 24);
            this.uiLocalizacion.TabIndex = 5;
            // 
            // uiAnden
            // 
            this.uiAnden.DisplayMember = "Descripcion";
            this.uiAnden.FormattingEnabled = true;
            this.uiAnden.Location = new System.Drawing.Point(140, 142);
            this.uiAnden.Name = "uiAnden";
            this.uiAnden.Size = new System.Drawing.Size(235, 24);
            this.uiAnden.TabIndex = 4;
            this.uiAnden.ValueMember = "Clave";
            // 
            // uiAlmacen
            // 
            this.uiAlmacen.DisplayMember = "Descripcion";
            this.uiAlmacen.FormattingEnabled = true;
            this.uiAlmacen.Location = new System.Drawing.Point(139, 112);
            this.uiAlmacen.Name = "uiAlmacen";
            this.uiAlmacen.Size = new System.Drawing.Size(235, 24);
            this.uiAlmacen.TabIndex = 3;
            this.uiAlmacen.ValueMember = "Clave";
            // 
            // uiLinea
            // 
            this.uiLinea.FormattingEnabled = true;
            this.uiLinea.Location = new System.Drawing.Point(139, 80);
            this.uiLinea.Name = "uiLinea";
            this.uiLinea.Size = new System.Drawing.Size(235, 24);
            this.uiLinea.TabIndex = 2;
            // 
            // uiSubfamilia
            // 
            this.uiSubfamilia.FormattingEnabled = true;
            this.uiSubfamilia.Location = new System.Drawing.Point(139, 47);
            this.uiSubfamilia.Name = "uiSubfamilia";
            this.uiSubfamilia.Size = new System.Drawing.Size(235, 24);
            this.uiSubfamilia.TabIndex = 1;
            // 
            // uiFamilia
            // 
            this.uiFamilia.FormattingEnabled = true;
            this.uiFamilia.Location = new System.Drawing.Point(140, 17);
            this.uiFamilia.Name = "uiFamilia";
            this.uiFamilia.Size = new System.Drawing.Size(235, 24);
            this.uiFamilia.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(40, 175);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 16);
            this.label27.TabIndex = 10;
            this.label27.Text = "Localización";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(82, 145);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 16);
            this.label26.TabIndex = 8;
            this.label26.Text = "Andén";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(66, 115);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 16);
            this.label25.TabIndex = 6;
            this.label25.Text = "Almacén";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(86, 83);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 16);
            this.label24.TabIndex = 4;
            this.label24.Text = "Línea";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(50, 47);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 16);
            this.label23.TabIndex = 2;
            this.label23.Text = "Subfamilia";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(71, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 16);
            this.label22.TabIndex = 0;
            this.label22.Text = "Familia";
            // 
            // tpAdiconal
            // 
            this.tpAdiconal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpAdiconal.Controls.Add(this.uiSobrePedido);
            this.tpAdiconal.Controls.Add(this.uiEspecificaciones);
            this.tpAdiconal.Controls.Add(this.label39);
            this.tpAdiconal.Controls.Add(this.uiColor2);
            this.tpAdiconal.Controls.Add(this.label38);
            this.tpAdiconal.Controls.Add(this.uiColor);
            this.tpAdiconal.Controls.Add(this.label37);
            this.tpAdiconal.Controls.Add(this.uiTalla);
            this.tpAdiconal.Controls.Add(this.label36);
            this.tpAdiconal.Location = new System.Drawing.Point(4, 25);
            this.tpAdiconal.Name = "tpAdiconal";
            this.tpAdiconal.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdiconal.Size = new System.Drawing.Size(1013, 238);
            this.tpAdiconal.TabIndex = 5;
            this.tpAdiconal.Text = "ADICIONALES";
            // 
            // uiSobrePedido
            // 
            this.uiSobrePedido.AutoSize = true;
            this.uiSobrePedido.Location = new System.Drawing.Point(602, 14);
            this.uiSobrePedido.Name = "uiSobrePedido";
            this.uiSobrePedido.Size = new System.Drawing.Size(123, 20);
            this.uiSobrePedido.TabIndex = 25;
            this.uiSobrePedido.Text = "Sobre Pedido";
            this.uiSobrePedido.UseVisualStyleBackColor = true;
            // 
            // uiEspecificaciones
            // 
            this.uiEspecificaciones.Location = new System.Drawing.Point(180, 101);
            this.uiEspecificaciones.Multiline = true;
            this.uiEspecificaciones.Name = "uiEspecificaciones";
            this.uiEspecificaciones.Size = new System.Drawing.Size(827, 113);
            this.uiEspecificaciones.TabIndex = 24;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(20, 105);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(151, 16);
            this.label39.TabIndex = 23;
            this.label39.Text = "ESPECIFICACIONES";
            // 
            // uiColor2
            // 
            this.uiColor2.Location = new System.Drawing.Point(180, 72);
            this.uiColor2.MaxLength = 10;
            this.uiColor2.Name = "uiColor2";
            this.uiColor2.Size = new System.Drawing.Size(256, 22);
            this.uiColor2.TabIndex = 22;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(10, 74);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(162, 16);
            this.label38.TabIndex = 21;
            this.label38.Text = "COLOR SECUNDARIO";
            // 
            // uiColor
            // 
            this.uiColor.Location = new System.Drawing.Point(180, 43);
            this.uiColor.MaxLength = 10;
            this.uiColor.Name = "uiColor";
            this.uiColor.Size = new System.Drawing.Size(256, 22);
            this.uiColor.TabIndex = 20;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(117, 45);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(59, 16);
            this.label37.TabIndex = 19;
            this.label37.Text = "COLOR";
            // 
            // uiTalla
            // 
            this.uiTalla.Location = new System.Drawing.Point(180, 15);
            this.uiTalla.MaxLength = 5;
            this.uiTalla.Name = "uiTalla";
            this.uiTalla.Size = new System.Drawing.Size(100, 22);
            this.uiTalla.TabIndex = 18;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(117, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(54, 16);
            this.label36.TabIndex = 17;
            this.label36.Text = "TALLA";
            // 
            // tpFotos
            // 
            this.tpFotos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpFotos.Controls.Add(this.uiImagenPrincipal);
            this.tpFotos.Controls.Add(this.uiImagenDetalle);
            this.tpFotos.Controls.Add(this.label41);
            this.tpFotos.Controls.Add(this.uiGridImagenes);
            this.tpFotos.Controls.Add(this.uiPath);
            this.tpFotos.Controls.Add(this.btnBuscarArchivo);
            this.tpFotos.Controls.Add(this.label40);
            this.tpFotos.Location = new System.Drawing.Point(4, 25);
            this.tpFotos.Name = "tpFotos";
            this.tpFotos.Padding = new System.Windows.Forms.Padding(3);
            this.tpFotos.Size = new System.Drawing.Size(1013, 238);
            this.tpFotos.TabIndex = 6;
            this.tpFotos.Text = "FOTOS";
            // 
            // uiImagenPrincipal
            // 
            this.uiImagenPrincipal.ForeColor = System.Drawing.SystemColors.MenuText;
            this.uiImagenPrincipal.Location = new System.Drawing.Point(495, 207);
            this.uiImagenPrincipal.Name = "uiImagenPrincipal";
            this.uiImagenPrincipal.Size = new System.Drawing.Size(170, 25);
            this.uiImagenPrincipal.TabIndex = 13;
            this.uiImagenPrincipal.Text = "HACER PRINCIPAL";
            this.uiImagenPrincipal.UseVisualStyleBackColor = true;
            this.uiImagenPrincipal.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiImagenDetalle
            // 
            this.uiImagenDetalle.Location = new System.Drawing.Point(509, 49);
            this.uiImagenDetalle.Name = "uiImagenDetalle";
            this.uiImagenDetalle.Size = new System.Drawing.Size(144, 154);
            this.uiImagenDetalle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiImagenDetalle.TabIndex = 12;
            this.uiImagenDetalle.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(17, 34);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(213, 16);
            this.label41.TabIndex = 11;
            this.label41.Text = "*Doble click para vista previa";
            // 
            // uiGridImagenes
            // 
            this.uiGridImagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridImagenes.Location = new System.Drawing.Point(17, 53);
            this.uiGridImagenes.Name = "uiGridImagenes";
            this.uiGridImagenes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.uiGridImagenes.Size = new System.Drawing.Size(486, 150);
            this.uiGridImagenes.TabIndex = 10;
            this.uiGridImagenes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridImagenes_CellContentDoubleClick);
            this.uiGridImagenes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridImagenes_CellDoubleClick);
            // 
            // uiPath
            // 
            this.uiPath.Enabled = false;
            this.uiPath.Location = new System.Drawing.Point(260, 11);
            this.uiPath.Name = "uiPath";
            this.uiPath.Size = new System.Drawing.Size(410, 22);
            this.uiPath.TabIndex = 9;
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(165, 11);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(95, 23);
            this.btnBuscarArchivo.TabIndex = 8;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(14, 14);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(158, 16);
            this.label40.TabIndex = 7;
            this.label40.Text = "Selecciona el archivo";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmPoductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1058, 654);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPoductos";
            this.Text = "Poductos";
            this.Load += new System.EventHandler(this.frmPoductos_Load);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltaPersonal)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.tcProducto.ResumeLayout(false);
            this.tpGenerales.ResumeLayout(false);
            this.tpGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nProductoId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDescEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConXCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.tpPrecioImp.ResumeLayout(false);
            this.gpPRecios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecios)).EndInit();
            this.gpCalcularprecioVta.ResumeLayout(false);
            this.gpCalcularprecioVta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiEstablecerPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiIncUtilidadPesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiIncUtilidadPorc)).EndInit();
            this.gpPrecioUltCompra.ResumeLayout(false);
            this.gpPrecioUltCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCtoSinIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImpuestos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCtoNeto)).EndInit();
            this.tpImpuestos.ResumeLayout(false);
            this.tpImpuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiProductosImpuesto)).EndInit();
            this.tpExistencias.ResumeLayout(false);
            this.tpExistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiValuadoCostoProm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiValuadoUtimaCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCostoPromedio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCostoUCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiExistencia)).EndInit();
            this.tpFamilia.ResumeLayout(false);
            this.tpFamilia.PerformLayout();
            this.tpAdiconal.ResumeLayout(false);
            this.tpAdiconal.PerformLayout();
            this.tpFotos.ResumeLayout(false);
            this.tpFotos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImagenDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridImagenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvAltaPersonal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TabControl tcProducto;
        private System.Windows.Forms.TabPage tpGenerales;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lblEliminarFoto;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.TabPage tpPrecioImp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbInvetariadoPor;
        private System.Windows.Forms.NumericUpDown nConXCaja;
        private System.Windows.Forms.NumericUpDown nDecimales;
        private System.Windows.Forms.NumericUpDown nDescEmp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbVendidoPor;
        private System.Windows.Forms.CheckBox chkProdVtaBascula;
        private System.Windows.Forms.CheckBox chkProdParaVenta;
        private System.Windows.Forms.CheckBox chkMateriaPrima;
        private System.Windows.Forms.CheckBox chkInventariable;
        private System.Windows.Forms.CheckBox chkProductoTerminado;
        private System.Windows.Forms.CheckBox chkEstatusProducto;
        private System.Windows.Forms.CheckBox chkSeriado;
        private System.Windows.Forms.NumericUpDown nProductoId;
        private System.Windows.Forms.TabPage tpExistencias;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown uiValuadoCostoProm;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown uiValuadoUtimaCom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown uiCostoPromedio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown uiCostoUCompra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown uiExistencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tpFamilia;
        private System.Windows.Forms.ComboBox uiLote;
        
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox uiLocalizacion;
        private System.Windows.Forms.ComboBox uiAnden;
        private System.Windows.Forms.ComboBox uiAlmacen;
        private System.Windows.Forms.ComboBox uiLinea;
        private System.Windows.Forms.ComboBox uiSubfamilia;
        private System.Windows.Forms.ComboBox uiFamilia;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uiMaximo;
        private System.Windows.Forms.NumericUpDown uiMinimo;
        private System.Windows.Forms.DateTimePicker uiFechaCad;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uiCtoNeto;
        private System.Windows.Forms.NumericUpDown uiImpuestos;
        private System.Windows.Forms.NumericUpDown uiCtoSinIVA;
        private System.Windows.Forms.GroupBox gpCalcularprecioVta;
        private System.Windows.Forms.NumericUpDown uiEstablecerPrecio;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.NumericUpDown uiIncUtilidadPesos;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown uiIncUtilidadPorc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpPrecioUltCompra;
        private System.Windows.Forms.NumericUpDown uiPrecioVenta;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnAplicarPrecioVta;
        private System.Windows.Forms.GroupBox gpPRecios;
        private System.Windows.Forms.DataGridView uiPrecios;
        private System.Windows.Forms.TabPage tpImpuestos;
        private System.Windows.Forms.DataGridView uiProductosImpuesto;
        private System.Windows.Forms.ComboBox uiImpuestoCMB;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnAgregarImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.TextBox txtDescCorta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton uiUsarEstablecer;
        private System.Windows.Forms.RadioButton uiUsarIncPesos;
        private System.Windows.Forms.RadioButton uiUsarIncUtilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProductoPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.TabPage tpAdiconal;
        private System.Windows.Forms.TextBox uiEspecificaciones;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox uiColor2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox uiColor;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox uiTalla;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabPage tpFotos;
        private System.Windows.Forms.TextBox uiPath;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox uiSobrePedido;
        private System.Windows.Forms.DataGridView uiGridImagenes;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.PictureBox uiImagenDetalle;
        private System.Windows.Forms.Button uiImagenPrincipal;
        private System.Windows.Forms.Button uiClonar;
        private DevExpress.XtraEditors.SimpleButton uiProduccion;
    }
}