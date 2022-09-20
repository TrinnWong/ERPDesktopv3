namespace ERPv1.Catalogos
{
    partial class frmCajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajas));
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.uiSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.catsucursalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uiTipoCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.cattiposcajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtUbicación = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nClave = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.txtNombreCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.catcajasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTipoCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cattiposcajasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catcajasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.dgvCaja);
            this.gbListado.Controls.Add(this.label4);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(50, 308);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(989, 312);
            this.gbListado.TabIndex = 16;
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
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaja.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCaja.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvCaja.Location = new System.Drawing.Point(47, 68);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaja.Size = new System.Drawing.Size(764, 226);
            this.dgvCaja.TabIndex = 5;
            this.dgvCaja.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCaja_CellMouseDoubleClick);
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
            this.gbBotones.Location = new System.Drawing.Point(50, 210);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(989, 75);
            this.gbBotones.TabIndex = 15;
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
            this.gbDatos.Controls.Add(this.uiSucursal);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.uiTipoCaja);
            this.gbDatos.Controls.Add(this.txtUbicación);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.nClave);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.chkEstatus);
            this.gbDatos.Controls.Add(this.txtNombreCaja);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(50, 13);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(989, 178);
            this.gbDatos.TabIndex = 14;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // uiSucursal
            // 
            this.uiSucursal.Location = new System.Drawing.Point(568, 135);
            this.uiSucursal.Name = "uiSucursal";
            this.uiSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiSucursal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreSucursal", "Sucursal")});
            this.uiSucursal.Properties.DataSource = this.catsucursalesBindingSource;
            this.uiSucursal.Properties.DisplayMember = "NombreSucursal";
            this.uiSucursal.Properties.NullText = "(Seleccione una sucursal)";
            this.uiSucursal.Properties.ValueMember = "Clave";
            this.uiSucursal.Size = new System.Drawing.Size(403, 26);
            this.uiSucursal.TabIndex = 11;
            // 
            // catsucursalesBindingSource
            // 
            this.catsucursalesBindingSource.DataSource = typeof(ConexionBD.cat_sucursales);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "SUCURSAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "*TIPO CAJA";
            // 
            // uiTipoCaja
            // 
            this.uiTipoCaja.Location = new System.Drawing.Point(217, 130);
            this.uiTipoCaja.Name = "uiTipoCaja";
            this.uiTipoCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiTipoCaja.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Tipo")});
            this.uiTipoCaja.Properties.DataSource = this.cattiposcajasBindingSource;
            this.uiTipoCaja.Properties.DisplayMember = "Nombre";
            this.uiTipoCaja.Properties.NullText = "(Selecciona un Tipo)";
            this.uiTipoCaja.Properties.ValueMember = "TipoCajaId";
            this.uiTipoCaja.Size = new System.Drawing.Size(306, 26);
            this.uiTipoCaja.TabIndex = 8;
            // 
            // cattiposcajasBindingSource
            // 
            this.cattiposcajasBindingSource.DataSource = typeof(ConexionBD.cat_tipos_cajas);
            // 
            // txtUbicación
            // 
            this.txtUbicación.Location = new System.Drawing.Point(568, 51);
            this.txtUbicación.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUbicación.MaxLength = 60;
            this.txtUbicación.Name = "txtUbicación";
            this.txtUbicación.Size = new System.Drawing.Size(403, 31);
            this.txtUbicación.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(574, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "UBICACIÓN";
            // 
            // nClave
            // 
            this.nClave.Location = new System.Drawing.Point(40, 52);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "CAJA ACTIVA";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Location = new System.Drawing.Point(98, 148);
            this.chkEstatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(22, 21);
            this.chkEstatus.TabIndex = 3;
            this.chkEstatus.UseVisualStyleBackColor = true;
            this.chkEstatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkEstatus_KeyPress);
            // 
            // txtNombreCaja
            // 
            this.txtNombreCaja.Location = new System.Drawing.Point(216, 52);
            this.txtNombreCaja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreCaja.MaxLength = 60;
            this.txtNombreCaja.Name = "txtNombreCaja";
            this.txtNombreCaja.Size = new System.Drawing.Size(307, 31);
            this.txtNombreCaja.TabIndex = 2;
            this.txtNombreCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCaja_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "*NOMBRE CAJA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "*CLAVE";
            // 
            // catcajasBindingSource
            // 
            this.catcajasBindingSource.DataSource = typeof(ConexionBD.cat_cajas);
            // 
            // frmCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1051, 657);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.frmCajas_Load);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSucursal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catsucursalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTipoCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cattiposcajasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catcajasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtUbicación;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.TextBox txtNombreCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit uiTipoCaja;
        private System.Windows.Forms.BindingSource cattiposcajasBindingSource;
        private DevExpress.XtraEditors.LookUpEdit uiSucursal;
        private System.Windows.Forms.BindingSource catcajasBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource catsucursalesBindingSource;
    }
}