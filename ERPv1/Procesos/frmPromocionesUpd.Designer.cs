namespace ERPv1.Procesos
{
    partial class frmPromocionesUpd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiDomingo = new System.Windows.Forms.CheckBox();
            this.uiSabado = new System.Windows.Forms.CheckBox();
            this.uiViernes = new System.Windows.Forms.CheckBox();
            this.uiJueves = new System.Windows.Forms.CheckBox();
            this.uiMiercoles = new System.Windows.Forms.CheckBox();
            this.uiMartes = new System.Windows.Forms.CheckBox();
            this.uiLunes = new System.Windows.Forms.CheckBox();
            this.uiNombrePromocion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.uiActivo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarExcepcion = new System.Windows.Forms.Button();
            this.uiClaveProducto = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.uiProducto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uiSubfamilia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uiFamilia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uiLinea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiSucursal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grVig = new System.Windows.Forms.GroupBox();
            this.uiTimeFin = new System.Windows.Forms.DateTimePicker();
            this.uiTimeIni = new System.Windows.Forms.DateTimePicker();
            this.uiFechaVigenciaFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.uiFechaVigenciaIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.uiPorcDescuento = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiID = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.uiGridExcepcion = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiGridDetalle = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subfamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.uiGuardar = new System.Windows.Forms.Button();
            this.uiPermanente = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grVig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridExcepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridDetalle)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiPermanente);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.uiNombrePromocion);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.uiActivo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.uiSucursal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.grVig);
            this.panel1.Controls.Add(this.uiPorcDescuento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.uiFechaRegistro);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uiID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 237);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiDomingo);
            this.groupBox2.Controls.Add(this.uiSabado);
            this.groupBox2.Controls.Add(this.uiViernes);
            this.groupBox2.Controls.Add(this.uiJueves);
            this.groupBox2.Controls.Add(this.uiMiercoles);
            this.groupBox2.Controls.Add(this.uiMartes);
            this.groupBox2.Controls.Add(this.uiLunes);
            this.groupBox2.Location = new System.Drawing.Point(12, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1053, 44);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Días de la semana";
            // 
            // uiDomingo
            // 
            this.uiDomingo.AutoSize = true;
            this.uiDomingo.Location = new System.Drawing.Point(427, 19);
            this.uiDomingo.Name = "uiDomingo";
            this.uiDomingo.Size = new System.Drawing.Size(68, 17);
            this.uiDomingo.TabIndex = 6;
            this.uiDomingo.Text = "Domingo";
            this.uiDomingo.UseVisualStyleBackColor = true;
            // 
            // uiSabado
            // 
            this.uiSabado.AutoSize = true;
            this.uiSabado.Location = new System.Drawing.Point(358, 19);
            this.uiSabado.Name = "uiSabado";
            this.uiSabado.Size = new System.Drawing.Size(63, 17);
            this.uiSabado.TabIndex = 5;
            this.uiSabado.Text = "Sabado";
            this.uiSabado.UseVisualStyleBackColor = true;
            // 
            // uiViernes
            // 
            this.uiViernes.AutoSize = true;
            this.uiViernes.Location = new System.Drawing.Point(291, 21);
            this.uiViernes.Name = "uiViernes";
            this.uiViernes.Size = new System.Drawing.Size(61, 17);
            this.uiViernes.TabIndex = 4;
            this.uiViernes.Text = "Viernes";
            this.uiViernes.UseVisualStyleBackColor = true;
            // 
            // uiJueves
            // 
            this.uiJueves.AutoSize = true;
            this.uiJueves.Location = new System.Drawing.Point(225, 21);
            this.uiJueves.Name = "uiJueves";
            this.uiJueves.Size = new System.Drawing.Size(60, 17);
            this.uiJueves.TabIndex = 3;
            this.uiJueves.Text = "Jueves";
            this.uiJueves.UseVisualStyleBackColor = true;
            // 
            // uiMiercoles
            // 
            this.uiMiercoles.AutoSize = true;
            this.uiMiercoles.Location = new System.Drawing.Point(148, 21);
            this.uiMiercoles.Name = "uiMiercoles";
            this.uiMiercoles.Size = new System.Drawing.Size(71, 17);
            this.uiMiercoles.TabIndex = 2;
            this.uiMiercoles.Text = "Miercoles";
            this.uiMiercoles.UseVisualStyleBackColor = true;
            // 
            // uiMartes
            // 
            this.uiMartes.AutoSize = true;
            this.uiMartes.Location = new System.Drawing.Point(84, 21);
            this.uiMartes.Name = "uiMartes";
            this.uiMartes.Size = new System.Drawing.Size(58, 17);
            this.uiMartes.TabIndex = 1;
            this.uiMartes.Text = "Martes";
            this.uiMartes.UseVisualStyleBackColor = true;
            // 
            // uiLunes
            // 
            this.uiLunes.AutoSize = true;
            this.uiLunes.Location = new System.Drawing.Point(23, 21);
            this.uiLunes.Name = "uiLunes";
            this.uiLunes.Size = new System.Drawing.Size(55, 17);
            this.uiLunes.TabIndex = 0;
            this.uiLunes.Text = "Lunes";
            this.uiLunes.UseVisualStyleBackColor = true;
            // 
            // uiNombrePromocion
            // 
            this.uiNombrePromocion.Location = new System.Drawing.Point(473, 20);
            this.uiNombrePromocion.Name = "uiNombrePromocion";
            this.uiNombrePromocion.Size = new System.Drawing.Size(277, 20);
            this.uiNombrePromocion.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(372, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Nombre Promoción";
            // 
            // uiActivo
            // 
            this.uiActivo.AutoSize = true;
            this.uiActivo.Location = new System.Drawing.Point(1003, 83);
            this.uiActivo.Name = "uiActivo";
            this.uiActivo.Size = new System.Drawing.Size(56, 17);
            this.uiActivo.TabIndex = 10;
            this.uiActivo.Text = "Activo";
            this.uiActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarExcepcion);
            this.groupBox1.Controls.Add(this.uiClaveProducto);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.uiProducto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.uiSubfamilia);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.uiFamilia);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.uiLinea);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1208, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captura";
            // 
            // btnAgregarExcepcion
            // 
            this.btnAgregarExcepcion.Enabled = false;
            this.btnAgregarExcepcion.Location = new System.Drawing.Point(279, 47);
            this.btnAgregarExcepcion.Name = "btnAgregarExcepcion";
            this.btnAgregarExcepcion.Size = new System.Drawing.Size(175, 25);
            this.btnAgregarExcepcion.TabIndex = 8;
            this.btnAgregarExcepcion.Text = "EXCEPCIÓN";
            this.btnAgregarExcepcion.UseVisualStyleBackColor = true;
            this.btnAgregarExcepcion.Click += new System.EventHandler(this.btnAgregarExcepcion_Click);
            // 
            // uiClaveProducto
            // 
            this.uiClaveProducto.Location = new System.Drawing.Point(754, 21);
            this.uiClaveProducto.Name = "uiClaveProducto";
            this.uiClaveProducto.Size = new System.Drawing.Size(71, 20);
            this.uiClaveProducto.TabIndex = 7;
            this.uiClaveProducto.Validating += new System.ComponentModel.CancelEventHandler(this.uiClaveProducto_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(49, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(175, 25);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "PROMOCIÓN";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // uiProducto
            // 
            this.uiProducto.DisplayMember = "Descripcion";
            this.uiProducto.FormattingEnabled = true;
            this.uiProducto.Location = new System.Drawing.Point(829, 21);
            this.uiProducto.Name = "uiProducto";
            this.uiProducto.Size = new System.Drawing.Size(175, 21);
            this.uiProducto.TabIndex = 5;
            this.uiProducto.ValueMember = "ProductoId";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(706, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Producto";
            // 
            // uiSubfamilia
            // 
            this.uiSubfamilia.DisplayMember = "Descripcion";
            this.uiSubfamilia.FormattingEnabled = true;
            this.uiSubfamilia.Location = new System.Drawing.Point(525, 20);
            this.uiSubfamilia.Name = "uiSubfamilia";
            this.uiSubfamilia.Size = new System.Drawing.Size(175, 21);
            this.uiSubfamilia.TabIndex = 4;
            this.uiSubfamilia.ValueMember = "Clave";
            this.uiSubfamilia.SelectedValueChanged += new System.EventHandler(this.uiSubfamilia_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(464, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Subfamilia";
            // 
            // uiFamilia
            // 
            this.uiFamilia.DisplayMember = "Descripcion";
            this.uiFamilia.FormattingEnabled = true;
            this.uiFamilia.Location = new System.Drawing.Point(279, 20);
            this.uiFamilia.Name = "uiFamilia";
            this.uiFamilia.Size = new System.Drawing.Size(175, 21);
            this.uiFamilia.TabIndex = 3;
            this.uiFamilia.ValueMember = "Clave";
            this.uiFamilia.SelectedValueChanged += new System.EventHandler(this.uiFamilia_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Familia";
            // 
            // uiLinea
            // 
            this.uiLinea.DisplayMember = "Descripcion";
            this.uiLinea.FormattingEnabled = true;
            this.uiLinea.Location = new System.Drawing.Point(49, 20);
            this.uiLinea.Name = "uiLinea";
            this.uiLinea.Size = new System.Drawing.Size(175, 21);
            this.uiLinea.TabIndex = 1;
            this.uiLinea.ValueMember = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Línea";
            // 
            // uiSucursal
            // 
            this.uiSucursal.DisplayMember = "NombreSucursal";
            this.uiSucursal.FormattingEnabled = true;
            this.uiSucursal.Location = new System.Drawing.Point(189, 19);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Size = new System.Drawing.Size(176, 21);
            this.uiSucursal.TabIndex = 8;
            this.uiSucursal.ValueMember = "Clave";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sucursal";
            // 
            // grVig
            // 
            this.grVig.Controls.Add(this.uiTimeFin);
            this.grVig.Controls.Add(this.uiTimeIni);
            this.grVig.Controls.Add(this.uiFechaVigenciaFin);
            this.grVig.Controls.Add(this.label5);
            this.grVig.Controls.Add(this.uiFechaVigenciaIni);
            this.grVig.Controls.Add(this.label4);
            this.grVig.Location = new System.Drawing.Point(29, 45);
            this.grVig.Name = "grVig";
            this.grVig.Size = new System.Drawing.Size(839, 54);
            this.grVig.TabIndex = 6;
            this.grVig.TabStop = false;
            this.grVig.Text = "Vigencia";
            // 
            // uiTimeFin
            // 
            this.uiTimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uiTimeFin.Location = new System.Drawing.Point(693, 18);
            this.uiTimeFin.Name = "uiTimeFin";
            this.uiTimeFin.Size = new System.Drawing.Size(113, 20);
            this.uiTimeFin.TabIndex = 8;
            // 
            // uiTimeIni
            // 
            this.uiTimeIni.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uiTimeIni.Location = new System.Drawing.Point(279, 19);
            this.uiTimeIni.Name = "uiTimeIni";
            this.uiTimeIni.Size = new System.Drawing.Size(112, 20);
            this.uiTimeIni.TabIndex = 7;
            // 
            // uiFechaVigenciaFin
            // 
            this.uiFechaVigenciaFin.Location = new System.Drawing.Point(463, 18);
            this.uiFechaVigenciaFin.Name = "uiFechaVigenciaFin";
            this.uiFechaVigenciaFin.Size = new System.Drawing.Size(224, 20);
            this.uiFechaVigenciaFin.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Al";
            // 
            // uiFechaVigenciaIni
            // 
            this.uiFechaVigenciaIni.Location = new System.Drawing.Point(49, 19);
            this.uiFechaVigenciaIni.Name = "uiFechaVigenciaIni";
            this.uiFechaVigenciaIni.Size = new System.Drawing.Size(224, 20);
            this.uiFechaVigenciaIni.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Del";
            // 
            // uiPorcDescuento
            // 
            this.uiPorcDescuento.DecimalPlaces = 2;
            this.uiPorcDescuento.Location = new System.Drawing.Point(982, 57);
            this.uiPorcDescuento.Name = "uiPorcDescuento";
            this.uiPorcDescuento.Size = new System.Drawing.Size(83, 20);
            this.uiPorcDescuento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(883, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Porcentaje Desc %";
            // 
            // uiFechaRegistro
            // 
            this.uiFechaRegistro.Enabled = false;
            this.uiFechaRegistro.Location = new System.Drawing.Point(841, 20);
            this.uiFechaRegistro.Name = "uiFechaRegistro";
            this.uiFechaRegistro.Size = new System.Drawing.Size(224, 20);
            this.uiFechaRegistro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Registro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // uiID
            // 
            this.uiID.Enabled = false;
            this.uiID.Location = new System.Drawing.Point(50, 18);
            this.uiID.Name = "uiID";
            this.uiID.Size = new System.Drawing.Size(79, 20);
            this.uiID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.uiGridExcepcion);
            this.panel2.Controls.Add(this.uiGridDetalle);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1248, 416);
            this.panel2.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(3, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "EXCEPCIONES";
            // 
            // uiGridExcepcion
            // 
            this.uiGridExcepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridExcepcion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.ID2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.uiGridExcepcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiGridExcepcion.Location = new System.Drawing.Point(0, 234);
            this.uiGridExcepcion.Name = "uiGridExcepcion";
            this.uiGridExcepcion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            this.uiGridExcepcion.Size = new System.Drawing.Size(1248, 118);
            this.uiGridExcepcion.TabIndex = 2;
            this.uiGridExcepcion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridExcepcion_CellContentClick);
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewButtonColumn1.HeaderText = "Eliminar";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Eliminar";
            // 
            // ID2
            // 
            this.ID2.DataPropertyName = "PromocionExcepcionId";
            this.ID2.HeaderText = "ID";
            this.ID2.Name = "ID2";
            this.ID2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Linea";
            this.dataGridViewTextBoxColumn2.HeaderText = "Línea";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Familia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Familia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Subfamilia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Subfamilia";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Producto";
            this.dataGridViewTextBoxColumn5.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 400;
            // 
            // uiGridDetalle
            // 
            this.uiGridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGridDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.ID,
            this.Linea,
            this.Familia,
            this.Subfamilia,
            this.Producto});
            this.uiGridDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGridDetalle.Location = new System.Drawing.Point(0, 0);
            this.uiGridDetalle.Name = "uiGridDetalle";
            this.uiGridDetalle.Size = new System.Drawing.Size(1248, 129);
            this.uiGridDetalle.TabIndex = 1;
            this.uiGridDetalle.DataSourceChanged += new System.EventHandler(this.uiGridDetalle_DataSourceChanged);
            this.uiGridDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGridDetalle_CellContentClick);
            // 
            // Eliminar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle2;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Eliminar";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "PromocionDetalleId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.DataPropertyName = "Linea";
            this.Linea.HeaderText = "Línea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            this.Linea.Width = 200;
            // 
            // Familia
            // 
            this.Familia.DataPropertyName = "Familia";
            this.Familia.HeaderText = "Familia";
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            this.Familia.Width = 200;
            // 
            // Subfamilia
            // 
            this.Subfamilia.DataPropertyName = "Subfamilia";
            this.Subfamilia.HeaderText = "Subfamilia";
            this.Subfamilia.Name = "Subfamilia";
            this.Subfamilia.ReadOnly = true;
            this.Subfamilia.Width = 200;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 400;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.uiGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1248, 64);
            this.panel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1071, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "SALIR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Location = new System.Drawing.Point(887, 6);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(178, 48);
            this.uiGuardar.TabIndex = 0;
            this.uiGuardar.Text = "GUARDAR";
            this.uiGuardar.UseVisualStyleBackColor = true;
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiPermanente
            // 
            this.uiPermanente.AutoSize = true;
            this.uiPermanente.Location = new System.Drawing.Point(887, 82);
            this.uiPermanente.Name = "uiPermanente";
            this.uiPermanente.Size = new System.Drawing.Size(83, 17);
            this.uiPermanente.TabIndex = 14;
            this.uiPermanente.Text = "Permanente";
            this.uiPermanente.UseVisualStyleBackColor = true;
            // 
            // frmPromocionesUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPromocionesUpd";
            this.Text = "Promociones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPromocionesUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmPromocionesUpd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grVig.ResumeLayout(false);
            this.grVig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiID)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridExcepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGridDetalle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown uiID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox uiProducto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox uiSubfamilia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox uiFamilia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uiLinea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uiSucursal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grVig;
        private System.Windows.Forms.DateTimePicker uiFechaVigenciaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker uiFechaVigenciaIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown uiPorcDescuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker uiFechaRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView uiGridDetalle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button uiGuardar;
        private System.Windows.Forms.CheckBox uiActivo;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subfamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DateTimePicker uiTimeFin;
        private System.Windows.Forms.DateTimePicker uiTimeIni;
        private System.Windows.Forms.TextBox uiNombrePromocion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox uiDomingo;
        private System.Windows.Forms.CheckBox uiSabado;
        private System.Windows.Forms.CheckBox uiViernes;
        private System.Windows.Forms.CheckBox uiJueves;
        private System.Windows.Forms.CheckBox uiMiercoles;
        private System.Windows.Forms.CheckBox uiMartes;
        private System.Windows.Forms.CheckBox uiLunes;
        private System.Windows.Forms.TextBox uiClaveProducto;
        private System.Windows.Forms.DataGridView uiGridExcepcion;
        private System.Windows.Forms.Button btnAgregarExcepcion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.CheckBox uiPermanente;
    }
}