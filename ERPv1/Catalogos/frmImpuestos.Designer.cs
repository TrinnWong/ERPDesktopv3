namespace ERPv1.Catalogos
{
    partial class frmImpuestos
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.uiAgregarImpPVta = new System.Windows.Forms.RadioButton();
            this.uiDesglosarImpPVta = new System.Windows.Forms.RadioButton();
            this.uiDecimales = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.uiCuotaFija = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.uiPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.uiTipoFactor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiClasificacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uiOrden = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.uiAbreviatura = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nClave = new System.Windows.Forms.NumericUpDown();
            this.uiCondigoSAT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDecimales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCuotaFija)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbDatos.Controls.Add(this.uiAgregarImpPVta);
            this.gbDatos.Controls.Add(this.uiDesglosarImpPVta);
            this.gbDatos.Controls.Add(this.uiDecimales);
            this.gbDatos.Controls.Add(this.label10);
            this.gbDatos.Controls.Add(this.uiCuotaFija);
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.uiPorcentaje);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Controls.Add(this.uiTipoFactor);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.uiClasificacion);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.uiOrden);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.uiAbreviatura);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.uiDescripcion);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.nClave);
            this.gbDatos.Controls.Add(this.uiCondigoSAT);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(12, 13);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(863, 208);
            this.gbDatos.TabIndex = 12;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            this.gbDatos.Enter += new System.EventHandler(this.gbDatos_Enter);
            // 
            // uiAgregarImpPVta
            // 
            this.uiAgregarImpPVta.AutoSize = true;
            this.uiAgregarImpPVta.Enabled = false;
            this.uiAgregarImpPVta.Location = new System.Drawing.Point(580, 181);
            this.uiAgregarImpPVta.Name = "uiAgregarImpPVta";
            this.uiAgregarImpPVta.Size = new System.Drawing.Size(255, 20);
            this.uiAgregarImpPVta.TabIndex = 20;
            this.uiAgregarImpPVta.TabStop = true;
            this.uiAgregarImpPVta.Text = "Agregar impuesto al precio venta";
            this.uiAgregarImpPVta.UseVisualStyleBackColor = true;
            this.uiAgregarImpPVta.Visible = false;
            // 
            // uiDesglosarImpPVta
            // 
            this.uiDesglosarImpPVta.AutoSize = true;
            this.uiDesglosarImpPVta.Enabled = false;
            this.uiDesglosarImpPVta.Location = new System.Drawing.Point(580, 147);
            this.uiDesglosarImpPVta.Name = "uiDesglosarImpPVta";
            this.uiDesglosarImpPVta.Size = new System.Drawing.Size(267, 20);
            this.uiDesglosarImpPVta.TabIndex = 19;
            this.uiDesglosarImpPVta.TabStop = true;
            this.uiDesglosarImpPVta.Text = "Desglosar impuesto al precio venta";
            this.uiDesglosarImpPVta.UseVisualStyleBackColor = true;
            this.uiDesglosarImpPVta.Visible = false;
            // 
            // uiDecimales
            // 
            this.uiDecimales.Location = new System.Drawing.Point(344, 166);
            this.uiDecimales.Name = "uiDecimales";
            this.uiDecimales.Size = new System.Drawing.Size(142, 23);
            this.uiDecimales.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "DECIMALES PORC./CUOTA";
            // 
            // uiCuotaFija
            // 
            this.uiCuotaFija.Location = new System.Drawing.Point(173, 166);
            this.uiCuotaFija.Name = "uiCuotaFija";
            this.uiCuotaFija.Size = new System.Drawing.Size(142, 23);
            this.uiCuotaFija.TabIndex = 16;
            this.uiCuotaFija.ValueChanged += new System.EventHandler(this.uiCuotaFija_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "CUOTA FIJA";
            // 
            // uiPorcentaje
            // 
            this.uiPorcentaje.Location = new System.Drawing.Point(9, 166);
            this.uiPorcentaje.Name = "uiPorcentaje";
            this.uiPorcentaje.Size = new System.Drawing.Size(131, 23);
            this.uiPorcentaje.TabIndex = 14;
            this.uiPorcentaje.ValueChanged += new System.EventHandler(this.uiPorcentaje_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "PORCENTAJE %";
            // 
            // uiTipoFactor
            // 
            this.uiTipoFactor.DisplayMember = "NombreFactorSAT";
            this.uiTipoFactor.FormattingEnabled = true;
            this.uiTipoFactor.Location = new System.Drawing.Point(590, 105);
            this.uiTipoFactor.Name = "uiTipoFactor";
            this.uiTipoFactor.Size = new System.Drawing.Size(219, 24);
            this.uiTipoFactor.TabIndex = 12;
            this.uiTipoFactor.ValueMember = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(587, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "*TIPO FACTOR";
            // 
            // uiClasificacion
            // 
            this.uiClasificacion.DisplayMember = "NombreSAT";
            this.uiClasificacion.FormattingEnabled = true;
            this.uiClasificacion.Location = new System.Drawing.Point(341, 105);
            this.uiClasificacion.Name = "uiClasificacion";
            this.uiClasificacion.Size = new System.Drawing.Size(219, 24);
            this.uiClasificacion.TabIndex = 10;
            this.uiClasificacion.ValueMember = "Clave";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "*CLASIFICACIÓN IMPUESTO";
            // 
            // uiOrden
            // 
            this.uiOrden.Location = new System.Drawing.Point(173, 106);
            this.uiOrden.Name = "uiOrden";
            this.uiOrden.Size = new System.Drawing.Size(142, 23);
            this.uiOrden.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "*ORDEN IMPRESIÓN";
            // 
            // uiAbreviatura
            // 
            this.uiAbreviatura.DisplayMember = "AbreviaturaSAT";
            this.uiAbreviatura.FormattingEnabled = true;
            this.uiAbreviatura.Location = new System.Drawing.Point(9, 106);
            this.uiAbreviatura.Name = "uiAbreviatura";
            this.uiAbreviatura.Size = new System.Drawing.Size(131, 24);
            this.uiAbreviatura.TabIndex = 6;
            this.uiAbreviatura.Text = "(Seleccionar)";
            this.uiAbreviatura.ValueMember = "Clave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "*ABREVIATURA SAT";
            // 
            // uiDescripcion
            // 
            this.uiDescripcion.Location = new System.Drawing.Point(340, 45);
            this.uiDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiDescripcion.MaxLength = 60;
            this.uiDescripcion.Name = "uiDescripcion";
            this.uiDescripcion.Size = new System.Drawing.Size(517, 23);
            this.uiDescripcion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "*DESCRIPCIÓN IMPUESTO";
            // 
            // nClave
            // 
            this.nClave.Location = new System.Drawing.Point(9, 46);
            this.nClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nClave.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nClave.Name = "nClave";
            this.nClave.Size = new System.Drawing.Size(131, 23);
            this.nClave.TabIndex = 1;
            // 
            // uiCondigoSAT
            // 
            this.uiCondigoSAT.Location = new System.Drawing.Point(173, 46);
            this.uiCondigoSAT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiCondigoSAT.MaxLength = 60;
            this.uiCondigoSAT.Name = "uiCondigoSAT";
            this.uiCondigoSAT.Size = new System.Drawing.Size(142, 23);
            this.uiCondigoSAT.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "*CÓDIGO SAT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "*CLAVE";
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
            this.gbBotones.Location = new System.Drawing.Point(13, 229);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(863, 75);
            this.gbBotones.TabIndex = 13;
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
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.uiGrid);
            this.gbListado.Controls.Add(this.label11);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(12, 312);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(863, 312);
            this.gbListado.TabIndex = 14;
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
            // uiGrid
            // 
            this.uiGrid.AllowUserToAddRows = false;
            this.uiGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.uiGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.uiGrid.Location = new System.Drawing.Point(22, 68);
            this.uiGrid.MultiSelect = false;
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.uiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiGrid.Size = new System.Drawing.Size(825, 192);
            this.uiGrid.TabIndex = 5;
            this.uiGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellContentClick);
            this.uiGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiGrid_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(119, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(625, 23);
            this.txtBuscar.TabIndex = 3;
            // 
            // frmImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(888, 584);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Name = "frmImpuestos";
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.frmImpuestos_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDecimales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCuotaFija)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.NumericUpDown uiDecimales;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown uiCuotaFija;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown uiPorcentaje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uiTipoFactor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox uiClasificacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uiOrden;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox uiAbreviatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nClave;
        private System.Windows.Forms.TextBox uiCondigoSAT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton uiAgregarImpPVta;
        private System.Windows.Forms.RadioButton uiDesglosarImpPVta;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}