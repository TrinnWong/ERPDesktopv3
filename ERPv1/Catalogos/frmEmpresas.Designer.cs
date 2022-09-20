namespace ERPv1.Catalogos
{
    partial class frmEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresas));
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvEmpresa = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.tcDatos = new System.Windows.Forms.TabControl();
            this.tpGenerales = new System.Windows.Forms.TabPage();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRegimenFiscal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nClave = new System.Windows.Forms.NumericUpDown();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.tpDireccion = new System.Windows.Forms.TabPage();
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
            this.tpLogo = new System.Windows.Forms.TabPage();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.tcDatos.SuspendLayout();
            this.tpGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).BeginInit();
            this.tpDireccion.SuspendLayout();
            this.tpLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.dgvEmpresa);
            this.gbListado.Controls.Add(this.label4);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(64, 445);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(863, 312);
            this.gbListado.TabIndex = 10;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "LISTADO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::ERPv1.Properties.Resources.Search_icon16;
            this.btnBuscar.Location = new System.Drawing.Point(742, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvEmpresa
            // 
            this.dgvEmpresa.AllowUserToAddRows = false;
            this.dgvEmpresa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmpresa.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvEmpresa.Location = new System.Drawing.Point(47, 68);
            this.dgvEmpresa.Name = "dgvEmpresa";
            this.dgvEmpresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpresa.Size = new System.Drawing.Size(764, 216);
            this.dgvEmpresa.TabIndex = 5;
            this.dgvEmpresa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresa_CellDoubleClick);
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
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
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
            this.gbBotones.Location = new System.Drawing.Point(64, 347);
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
            this.btnAgregar.Location = new System.Drawing.Point(40, 24);
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
            this.gbDatos.Controls.Add(this.tcDatos);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(64, 21);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(863, 304);
            this.gbDatos.TabIndex = 8;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // tcDatos
            // 
            this.tcDatos.Controls.Add(this.tpGenerales);
            this.tcDatos.Controls.Add(this.tpDireccion);
            this.tcDatos.Controls.Add(this.tpLogo);
            this.tcDatos.Location = new System.Drawing.Point(17, 22);
            this.tcDatos.Name = "tcDatos";
            this.tcDatos.SelectedIndex = 0;
            this.tcDatos.Size = new System.Drawing.Size(830, 266);
            this.tcDatos.TabIndex = 6;
            // 
            // tpGenerales
            // 
            this.tpGenerales.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpGenerales.Controls.Add(this.txtCorreoElectronico);
            this.tpGenerales.Controls.Add(this.label8);
            this.tpGenerales.Controls.Add(this.txtRegimenFiscal);
            this.tpGenerales.Controls.Add(this.label7);
            this.tpGenerales.Controls.Add(this.txtNombreComercial);
            this.tpGenerales.Controls.Add(this.label6);
            this.tpGenerales.Controls.Add(this.txtRFC);
            this.tpGenerales.Controls.Add(this.label5);
            this.tpGenerales.Controls.Add(this.nClave);
            this.tpGenerales.Controls.Add(this.txtNombreEmpresa);
            this.tpGenerales.Controls.Add(this.label1);
            this.tpGenerales.Controls.Add(this.label2);
            this.tpGenerales.Controls.Add(this.label3);
            this.tpGenerales.Controls.Add(this.chkEstatus);
            this.tpGenerales.Location = new System.Drawing.Point(4, 32);
            this.tpGenerales.Name = "tpGenerales";
            this.tpGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenerales.Size = new System.Drawing.Size(822, 230);
            this.tpGenerales.TabIndex = 0;
            this.tpGenerales.Text = "GENERALES";
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(508, 167);
            this.txtCorreoElectronico.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCorreoElectronico.MaxLength = 60;
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(262, 31);
            this.txtCorreoElectronico.TabIndex = 7;
            this.txtCorreoElectronico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorreoElectronico_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(274, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "CORREO ELECTRÓNICO";
            // 
            // txtRegimenFiscal
            // 
            this.txtRegimenFiscal.Location = new System.Drawing.Point(218, 169);
            this.txtRegimenFiscal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegimenFiscal.MaxLength = 100;
            this.txtRegimenFiscal.Name = "txtRegimenFiscal";
            this.txtRegimenFiscal.Size = new System.Drawing.Size(262, 31);
            this.txtRegimenFiscal.TabIndex = 6;
            this.txtRegimenFiscal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegimenFiscal_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "REGIMÉN FISCAL";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(218, 103);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreComercial.MaxLength = 100;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(552, 31);
            this.txtNombreComercial.TabIndex = 4;
            this.txtNombreComercial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreComercial_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "*NOMBRE COMERCIAL";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(26, 103);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRFC.MaxLength = 15;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(175, 31);
            this.txtRFC.TabIndex = 3;
            this.txtRFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRFC_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "*RFC";
            // 
            // nClave
            // 
            this.nClave.Location = new System.Drawing.Point(26, 38);
            this.nClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nClave.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nClave.Name = "nClave";
            this.nClave.Size = new System.Drawing.Size(131, 31);
            this.nClave.TabIndex = 1;
            this.nClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nClave_KeyPress);
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(218, 38);
            this.txtNombreEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreEmpresa.MaxLength = 100;
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(552, 31);
            this.txtNombreEmpresa.TabIndex = 2;
            this.txtNombreEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEmpresa_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "*CLAVE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "*NOMBRE DE LA EMPRESA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "EMPRESA ACTIVA";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Location = new System.Drawing.Point(84, 172);
            this.chkEstatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(22, 21);
            this.chkEstatus.TabIndex = 5;
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // tpDireccion
            // 
            this.tpDireccion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tpDireccion.Controls.Add(this.txtCPo);
            this.tpDireccion.Controls.Add(this.txtTelefono2);
            this.tpDireccion.Controls.Add(this.txtTelefono1);
            this.tpDireccion.Controls.Add(this.label18);
            this.tpDireccion.Controls.Add(this.label17);
            this.tpDireccion.Controls.Add(this.txtPais);
            this.tpDireccion.Controls.Add(this.label16);
            this.tpDireccion.Controls.Add(this.txtEstado);
            this.tpDireccion.Controls.Add(this.label15);
            this.tpDireccion.Controls.Add(this.label14);
            this.tpDireccion.Controls.Add(this.txtNumInt);
            this.tpDireccion.Controls.Add(this.label13);
            this.tpDireccion.Controls.Add(this.txtCiudad);
            this.tpDireccion.Controls.Add(this.label12);
            this.tpDireccion.Controls.Add(this.txtNumExt);
            this.tpDireccion.Controls.Add(this.label11);
            this.tpDireccion.Controls.Add(this.txtColonia);
            this.tpDireccion.Controls.Add(this.label10);
            this.tpDireccion.Controls.Add(this.txtCalle);
            this.tpDireccion.Controls.Add(this.label9);
            this.tpDireccion.Location = new System.Drawing.Point(4, 32);
            this.tpDireccion.Name = "tpDireccion";
            this.tpDireccion.Padding = new System.Windows.Forms.Padding(3);
            this.tpDireccion.Size = new System.Drawing.Size(822, 230);
            this.tpDireccion.TabIndex = 1;
            this.tpDireccion.Text = "DIRECCIÓN";
            // 
            // txtCPo
            // 
            this.txtCPo.Location = new System.Drawing.Point(431, 86);
            this.txtCPo.Mask = "00000";
            this.txtCPo.Name = "txtCPo";
            this.txtCPo.Size = new System.Drawing.Size(157, 31);
            this.txtCPo.TabIndex = 12;
            this.txtCPo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPo_KeyPress);
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Location = new System.Drawing.Point(633, 202);
            this.txtTelefono2.Mask = "(999)000-0000";
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(157, 31);
            this.txtTelefono2.TabIndex = 28;
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Location = new System.Drawing.Point(431, 202);
            this.txtTelefono1.Mask = "(999)000-0000";
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(157, 31);
            this.txtTelefono1.TabIndex = 16;
            this.txtTelefono1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono1_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(630, 179);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 23);
            this.label18.TabIndex = 27;
            this.label18.Text = "TELÉFONO 2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(433, 179);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 23);
            this.label17.TabIndex = 25;
            this.label17.Text = "TELÉFONO 1";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(26, 202);
            this.txtPais.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPais.MaxLength = 15;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(356, 31);
            this.txtPais.TabIndex = 15;
            this.txtPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPais_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 179);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 23);
            this.label16.TabIndex = 23;
            this.label16.Text = "PAIS";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(431, 143);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEstado.MaxLength = 15;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(359, 31);
            this.txtEstado.TabIndex = 14;
            this.txtEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstado_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(428, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 23);
            this.label15.TabIndex = 21;
            this.label15.Text = "ESTADO";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(428, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 23);
            this.label14.TabIndex = 19;
            this.label14.Text = "CÓDIGO POSTAL";
            // 
            // txtNumInt
            // 
            this.txtNumInt.Location = new System.Drawing.Point(232, 87);
            this.txtNumInt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumInt.MaxLength = 20;
            this.txtNumInt.Name = "txtNumInt";
            this.txtNumInt.Size = new System.Drawing.Size(150, 31);
            this.txtNumInt.TabIndex = 11;
            this.txtNumInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumInt_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(229, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 23);
            this.label13.TabIndex = 17;
            this.label13.Text = "NO. INT";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(24, 143);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCiudad.MaxLength = 15;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(356, 31);
            this.txtCiudad.TabIndex = 13;
            this.txtCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCiudad_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 15;
            this.label12.Text = "CIUDAD";
            // 
            // txtNumExt
            // 
            this.txtNumExt.Location = new System.Drawing.Point(24, 90);
            this.txtNumExt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumExt.MaxLength = 20;
            this.txtNumExt.Name = "txtNumExt";
            this.txtNumExt.Size = new System.Drawing.Size(150, 31);
            this.txtNumExt.TabIndex = 10;
            this.txtNumExt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumExt_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 23);
            this.label11.TabIndex = 13;
            this.label11.Text = "NO. EXT";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(429, 35);
            this.txtColonia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtColonia.MaxLength = 100;
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(361, 31);
            this.txtColonia.TabIndex = 9;
            this.txtColonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColonia_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "COLONIA";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(24, 35);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCalle.MaxLength = 100;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(356, 31);
            this.txtCalle.TabIndex = 8;
            this.txtCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalle_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "CALLE";
            // 
            // tpLogo
            // 
            this.tpLogo.Controls.Add(this.pbFoto);
            this.tpLogo.Location = new System.Drawing.Point(4, 32);
            this.tpLogo.Name = "tpLogo";
            this.tpLogo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogo.Size = new System.Drawing.Size(822, 230);
            this.tpLogo.TabIndex = 2;
            this.tpLogo.Text = "LOGO";
            this.tpLogo.UseVisualStyleBackColor = true;
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pbFoto.BackgroundImage = global::ERPv1.Properties.Resources.Search_good_icon72x72;
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFoto.ErrorImage = global::ERPv1.Properties.Resources.Search_good_icon72x72;
            this.pbFoto.InitialImage = global::ERPv1.Properties.Resources.personal_information_icon28x128;
            this.pbFoto.Location = new System.Drawing.Point(19, 6);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(222, 218);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 11;
            this.pbFoto.TabStop = false;
            this.pbFoto.Click += new System.EventHandler(this.pbFoto_Click);
            // 
            // frmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1000, 741);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.frmEmpresas_Load);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.tcDatos.ResumeLayout(false);
            this.tpGenerales.ResumeLayout(false);
            this.tpGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).EndInit();
            this.tpDireccion.ResumeLayout(false);
            this.tpDireccion.PerformLayout();
            this.tpLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvEmpresa;
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
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcDatos;
        private System.Windows.Forms.TabPage tpGenerales;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRegimenFiscal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tpDireccion;
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
        private System.Windows.Forms.MaskedTextBox txtCPo;
        private System.Windows.Forms.MaskedTextBox txtTelefono2;
        private System.Windows.Forms.MaskedTextBox txtTelefono1;
        private System.Windows.Forms.TabPage tpLogo;
        private System.Windows.Forms.PictureBox pbFoto;
    }
}