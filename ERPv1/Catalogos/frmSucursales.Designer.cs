namespace ERPv1.Catalogos
{
    partial class frmSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSucursales));
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvFamilia = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nClave = new System.Windows.Forms.NumericUpDown();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCPo = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono1 = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumInt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNumExt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiPuerto = new System.Windows.Forms.NumericUpDown();
            this.uiPassword = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.uiCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiSMTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.dgvFamilia);
            this.gbListado.Controls.Add(this.label4);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(50, 335);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(863, 305);
            this.gbListado.TabIndex = 10;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "LISTADO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::ERPv1.Properties.Resources.Search_icon16;
            this.btnBuscar.Location = new System.Drawing.Point(742, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvFamilia
            // 
            this.dgvFamilia.AllowUserToAddRows = false;
            this.dgvFamilia.AllowUserToDeleteRows = false;
            this.dgvFamilia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Sucursal,
            this.Estatus});
            this.dgvFamilia.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvFamilia.Location = new System.Drawing.Point(47, 68);
            this.dgvFamilia.Name = "dgvFamilia";
            this.dgvFamilia.ReadOnly = true;
            this.dgvFamilia.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFamilia.Size = new System.Drawing.Size(764, 226);
            this.dgvFamilia.TabIndex = 5;
            this.dgvFamilia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFamilia_CellContentClick);
            this.dgvFamilia.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFamilia_CellMouseDoubleClick);
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.DataPropertyName = "NombreSucursal";
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(119, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(625, 31);
            this.txtBuscar.TabIndex = 3;
            // 
            // gbBotones
            // 
            this.gbBotones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbBotones.Controls.Add(this.btnLimpiar);
            this.gbBotones.Controls.Add(this.btnEliminar);
            this.gbBotones.Controls.Add(this.btnEditar);
            this.gbBotones.Controls.Add(this.btnAgregar);
            this.gbBotones.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBotones.ForeColor = System.Drawing.SystemColors.Control;
            this.gbBotones.Location = new System.Drawing.Point(50, 259);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(863, 75);
            this.gbBotones.TabIndex = 9;
            this.gbBotones.TabStop = false;
            this.gbBotones.Text = "BOTONES";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Black;
            this.btnLimpiar.Image = global::ERPv1.Properties.Resources.Clear_icon24;
            this.btnLimpiar.Location = new System.Drawing.Point(450, 23);
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
            this.btnEliminar.Location = new System.Drawing.Point(320, 23);
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
            this.btnEditar.Location = new System.Drawing.Point(181, 23);
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
            this.btnAgregar.Location = new System.Drawing.Point(40, 23);
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
            this.gbDatos.Controls.Add(this.tabControl1);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(50, 6);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(863, 262);
            this.gbDatos.TabIndex = 8;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 227);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbEmpresa);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.nClave);
            this.tabPage1.Controls.Add(this.txtNombreFamilia);
            this.tabPage1.Controls.Add(this.chkEstatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 191);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Activo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "EMPRESA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "*CLAVE";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "Nombre";
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(203, 101);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(556, 31);
            this.cmbEmpresa.TabIndex = 8;
            this.cmbEmpresa.ValueMember = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "*NOMBRE DE LA SUCURSAL";
            // 
            // nClave
            // 
            this.nClave.Location = new System.Drawing.Point(27, 43);
            this.nClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nClave.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nClave.Name = "nClave";
            this.nClave.Size = new System.Drawing.Size(131, 31);
            this.nClave.TabIndex = 1;
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(203, 43);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreFamilia.MaxLength = 60;
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(556, 31);
            this.txtNombreFamilia.TabIndex = 2;
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Location = new System.Drawing.Point(34, 111);
            this.chkEstatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(22, 21);
            this.chkEstatus.TabIndex = 3;
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tabPage2.Controls.Add(this.txtCPo);
            this.tabPage2.Controls.Add(this.txtTelefono2);
            this.tabPage2.Controls.Add(this.txtTelefono1);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtPais);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtEstado);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtNumInt);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtCiudad);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtNumExt);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtColonia);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtCalle);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 191);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dirección";
            // 
            // txtCPo
            // 
            this.txtCPo.Location = new System.Drawing.Point(434, 70);
            this.txtCPo.Mask = "00000";
            this.txtCPo.Name = "txtCPo";
            this.txtCPo.Size = new System.Drawing.Size(157, 31);
            this.txtCPo.TabIndex = 35;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Location = new System.Drawing.Point(634, 164);
            this.txtTelefono2.Mask = "(999)000-0000";
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(157, 31);
            this.txtTelefono2.TabIndex = 48;
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Location = new System.Drawing.Point(434, 164);
            this.txtTelefono1.Mask = "(999)000-0000";
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(157, 31);
            this.txtTelefono1.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(633, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 23);
            this.label18.TabIndex = 47;
            this.label18.Text = "TELÉFONO 2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(431, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 23);
            this.label17.TabIndex = 46;
            this.label17.Text = "TELÉFONO 1";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(29, 164);
            this.txtPais.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(356, 31);
            this.txtPais.TabIndex = 39;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 23);
            this.label16.TabIndex = 45;
            this.label16.Text = "PAIS";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(432, 117);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEstado.MaxLength = 15;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(359, 31);
            this.txtEstado.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(431, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 23);
            this.label15.TabIndex = 44;
            this.label15.Text = "ESTADO";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(431, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 23);
            this.label14.TabIndex = 43;
            this.label14.Text = "CÓDIGO POSTAL";
            // 
            // txtNumInt
            // 
            this.txtNumInt.Location = new System.Drawing.Point(235, 71);
            this.txtNumInt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumInt.MaxLength = 20;
            this.txtNumInt.Name = "txtNumInt";
            this.txtNumInt.Size = new System.Drawing.Size(150, 31);
            this.txtNumInt.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(232, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 23);
            this.label13.TabIndex = 42;
            this.label13.Text = "NO. INT";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(29, 117);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(356, 31);
            this.txtCiudad.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 40;
            this.label12.Text = "CIUDAD";
            // 
            // txtNumExt
            // 
            this.txtNumExt.Location = new System.Drawing.Point(27, 70);
            this.txtNumExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumExt.MaxLength = 20;
            this.txtNumExt.Name = "txtNumExt";
            this.txtNumExt.Size = new System.Drawing.Size(150, 31);
            this.txtNumExt.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 23);
            this.label11.TabIndex = 37;
            this.label11.Text = "NO. EXT";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(432, 24);
            this.txtColonia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtColonia.MaxLength = 100;
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(361, 31);
            this.txtColonia.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(431, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.label10.TabIndex = 33;
            this.label10.Text = "COLONIA";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(27, 24);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCalle.MaxLength = 100;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(356, 31);
            this.txtCalle.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 23);
            this.label9.TabIndex = 30;
            this.label9.Text = "CALLE";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uiPuerto);
            this.tabPage3.Controls.Add(this.uiPassword);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.uiCorreo);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.uiSMTP);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(833, 191);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Envío de Correo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiPuerto
            // 
            this.uiPuerto.Location = new System.Drawing.Point(36, 120);
            this.uiPuerto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uiPuerto.Name = "uiPuerto";
            this.uiPuerto.Size = new System.Drawing.Size(120, 31);
            this.uiPuerto.TabIndex = 39;
            // 
            // uiPassword
            // 
            this.uiPassword.Location = new System.Drawing.Point(36, 163);
            this.uiPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPassword.MaxLength = 100;
            this.uiPassword.Name = "uiPassword";
            this.uiPassword.Size = new System.Drawing.Size(356, 31);
            this.uiPassword.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(35, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(151, 23);
            this.label19.TabIndex = 38;
            this.label19.Text = "PASSSWORD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(35, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "PUERTO";
            // 
            // uiCorreo
            // 
            this.uiCorreo.Location = new System.Drawing.Point(36, 75);
            this.uiCorreo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiCorreo.MaxLength = 100;
            this.uiCorreo.Name = "uiCorreo";
            this.uiCorreo.Size = new System.Drawing.Size(356, 31);
            this.uiCorreo.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(35, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 34;
            this.label7.Text = "CORREO";
            // 
            // uiSMTP
            // 
            this.uiSMTP.Location = new System.Drawing.Point(36, 31);
            this.uiSMTP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiSMTP.MaxLength = 100;
            this.uiSMTP.Name = "uiSMTP";
            this.uiSMTP.Size = new System.Drawing.Size(356, 31);
            this.uiSMTP.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(35, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "SMTP";
            // 
            // frmSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(969, 653);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.frmSucursales_Load);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPuerto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvFamilia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.NumericUpDown nClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MaskedTextBox txtCPo;
        private System.Windows.Forms.MaskedTextBox txtTelefono2;
        private System.Windows.Forms.MaskedTextBox txtTelefono1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNumInt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNumExt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox uiPassword;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uiCorreo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox uiSMTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uiPuerto;
    }
}