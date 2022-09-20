namespace ERPv1.Inventarios
{
    partial class frmEntradaDirectaUpd
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
            this.uiPrecioCompra = new System.Windows.Forms.Panel();
            this.uiCancelado = new System.Windows.Forms.CheckBox();
            this.uiFechaCancelacion = new System.Windows.Forms.DateTimePicker();
            this.uiCargadoInv = new System.Windows.Forms.CheckBox();
            this.uiGuardado = new System.Windows.Forms.CheckBox();
            this.uiSucursalOrigen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiCantidad = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.uiAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uiDescProducto = new System.Windows.Forms.TextBox();
            this.uiClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.uiFolio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.uiGrid = new System.Windows.Forms.DataGridView();
            this.Partida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiAutorizar = new System.Windows.Forms.Button();
            this.uiCancelar = new System.Windows.Forms.Button();
            this.uiImprimir = new System.Windows.Forms.Button();
            this.uiPrecioCompra1 = new DevExpress.XtraEditors.SpinEdit();
            this.panelSup.SuspendLayout();
            this.uiPrecioCompra.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioCompra1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.uiImprimir);
            this.panelSup.Controls.Add(this.uiCancelar);
            this.panelSup.Controls.Add(this.uiAutorizar);
            this.panelSup.Size = new System.Drawing.Size(1312, 36);
            this.panelSup.Controls.SetChildIndex(this.uiGuardar, 0);
            this.panelSup.Controls.SetChildIndex(this.button1, 0);
            this.panelSup.Controls.SetChildIndex(this.uiAutorizar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiCancelar, 0);
            this.panelSup.Controls.SetChildIndex(this.uiImprimir, 0);
            // 
            // button1
            // 
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiGuardar
            // 
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiPrecioCompra
            // 
            this.uiPrecioCompra.Controls.Add(this.uiCancelado);
            this.uiPrecioCompra.Controls.Add(this.uiFechaCancelacion);
            this.uiPrecioCompra.Controls.Add(this.uiCargadoInv);
            this.uiPrecioCompra.Controls.Add(this.uiGuardado);
            this.uiPrecioCompra.Controls.Add(this.uiSucursalOrigen);
            this.uiPrecioCompra.Controls.Add(this.label7);
            this.uiPrecioCompra.Controls.Add(this.lblTituloForm);
            this.uiPrecioCompra.Controls.Add(this.groupBox1);
            this.uiPrecioCompra.Controls.Add(this.uiFecha);
            this.uiPrecioCompra.Controls.Add(this.label2);
            this.uiPrecioCompra.Controls.Add(this.uiFolio);
            this.uiPrecioCompra.Controls.Add(this.label1);
            this.uiPrecioCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPrecioCompra.Location = new System.Drawing.Point(0, 36);
            this.uiPrecioCompra.Name = "uiPrecioCompra";
            this.uiPrecioCompra.Size = new System.Drawing.Size(1312, 110);
            this.uiPrecioCompra.TabIndex = 1;
            // 
            // uiCancelado
            // 
            this.uiCancelado.AutoSize = true;
            this.uiCancelado.Enabled = false;
            this.uiCancelado.Location = new System.Drawing.Point(973, 29);
            this.uiCancelado.Name = "uiCancelado";
            this.uiCancelado.Size = new System.Drawing.Size(84, 21);
            this.uiCancelado.TabIndex = 12;
            this.uiCancelado.Text = "Cancelado";
            this.uiCancelado.UseVisualStyleBackColor = true;
            // 
            // uiFechaCancelacion
            // 
            this.uiFechaCancelacion.Enabled = false;
            this.uiFechaCancelacion.Location = new System.Drawing.Point(769, 66);
            this.uiFechaCancelacion.Name = "uiFechaCancelacion";
            this.uiFechaCancelacion.Size = new System.Drawing.Size(200, 20);
            this.uiFechaCancelacion.TabIndex = 13;
            this.uiFechaCancelacion.Visible = false;
            // 
            // uiCargadoInv
            // 
            this.uiCargadoInv.AutoSize = true;
            this.uiCargadoInv.Enabled = false;
            this.uiCargadoInv.Location = new System.Drawing.Point(867, 29);
            this.uiCargadoInv.Name = "uiCargadoInv";
            this.uiCargadoInv.Size = new System.Drawing.Size(100, 21);
            this.uiCargadoInv.TabIndex = 11;
            this.uiCargadoInv.Text = "Cargado a Inv";
            this.uiCargadoInv.UseVisualStyleBackColor = true;
            // 
            // uiGuardado
            // 
            this.uiGuardado.AutoSize = true;
            this.uiGuardado.Enabled = false;
            this.uiGuardado.Location = new System.Drawing.Point(769, 29);
            this.uiGuardado.Name = "uiGuardado";
            this.uiGuardado.Size = new System.Drawing.Size(80, 21);
            this.uiGuardado.TabIndex = 10;
            this.uiGuardado.Text = "Guardado";
            this.uiGuardado.UseVisualStyleBackColor = true;
            // 
            // uiSucursalOrigen
            // 
            this.uiSucursalOrigen.DisplayMember = "NombreSucursal";
            this.uiSucursalOrigen.Enabled = false;
            this.uiSucursalOrigen.FormattingEnabled = true;
            this.uiSucursalOrigen.Location = new System.Drawing.Point(475, 26);
            this.uiSucursalOrigen.Name = "uiSucursalOrigen";
            this.uiSucursalOrigen.Size = new System.Drawing.Size(200, 21);
            this.uiSucursalOrigen.TabIndex = 2;
            this.uiSucursalOrigen.ValueMember = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Sucursal";
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.Location = new System.Drawing.Point(12, 3);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(193, 29);
            this.lblTituloForm.TabIndex = 7;
            this.lblTituloForm.Text = "Entrada Directa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiPrecioCompra1);
            this.groupBox1.Controls.Add(this.uiCantidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.uiAgregar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.uiDescProducto);
            this.groupBox1.Controls.Add(this.uiClave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Captura";
            // 
            // uiCantidad
            // 
            this.uiCantidad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiCantidad.Location = new System.Drawing.Point(346, 12);
            this.uiCantidad.Name = "uiCantidad";
            this.uiCantidad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiCantidad.Properties.DisplayFormat.FormatString = "n4";
            this.uiCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Properties.EditFormat.FormatString = "n4";
            this.uiCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiCantidad.Size = new System.Drawing.Size(100, 26);
            this.uiCantidad.TabIndex = 2;
            this.uiCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiCantidad_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Precio";
            // 
            // uiAgregar
            // 
            this.uiAgregar.Location = new System.Drawing.Point(587, 9);
            this.uiAgregar.Name = "uiAgregar";
            this.uiAgregar.Size = new System.Drawing.Size(50, 31);
            this.uiAgregar.TabIndex = 4;
            this.uiAgregar.Text = "+";
            this.uiAgregar.UseVisualStyleBackColor = true;
            this.uiAgregar.Click += new System.EventHandler(this.uiAgregar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad";
            // 
            // uiDescProducto
            // 
            this.uiDescProducto.Enabled = false;
            this.uiDescProducto.Location = new System.Drawing.Point(127, 13);
            this.uiDescProducto.Name = "uiDescProducto";
            this.uiDescProducto.Size = new System.Drawing.Size(150, 20);
            this.uiDescProducto.TabIndex = 1;
            // 
            // uiClave
            // 
            this.uiClave.Location = new System.Drawing.Point(51, 13);
            this.uiClave.Name = "uiClave";
            this.uiClave.Size = new System.Drawing.Size(70, 20);
            this.uiClave.TabIndex = 0;
            this.uiClave.Validating += new System.ComponentModel.CancelEventHandler(this.uiClave_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Clave";
            // 
            // uiFecha
            // 
            this.uiFecha.Location = new System.Drawing.Point(209, 26);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Size = new System.Drawing.Size(200, 20);
            this.uiFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // uiFolio
            // 
            this.uiFolio.Enabled = false;
            this.uiFolio.Location = new System.Drawing.Point(56, 26);
            this.uiFolio.Name = "uiFolio";
            this.uiFolio.Size = new System.Drawing.Size(100, 20);
            this.uiFolio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.uiGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 347);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1312, 50);
            this.panel3.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "[F3-Buscar Producto]";
            // 
            // uiGrid
            // 
            this.uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Partida,
            this.Clave,
            this.Descripcion,
            this.Unidad,
            this.Cantidad,
            this.PrecioCompra});
            this.uiGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGrid.Location = new System.Drawing.Point(0, 0);
            this.uiGrid.Name = "uiGrid";
            this.uiGrid.Size = new System.Drawing.Size(1312, 347);
            this.uiGrid.TabIndex = 0;
            this.uiGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiGrid_KeyDown);
            // 
            // Partida
            // 
            this.Partida.DataPropertyName = "partida";
            this.Partida.HeaderText = "#";
            this.Partida.Name = "Partida";
            this.Partida.ReadOnly = true;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "clave";
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidadMov";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.DataPropertyName = "precioUnitario";
            this.PrecioCompra.HeaderText = "PrecioCompra";
            this.PrecioCompra.Name = "PrecioCompra";
            // 
            // uiAutorizar
            // 
            this.uiAutorizar.Location = new System.Drawing.Point(212, 3);
            this.uiAutorizar.Name = "uiAutorizar";
            this.uiAutorizar.Size = new System.Drawing.Size(102, 31);
            this.uiAutorizar.TabIndex = 2;
            this.uiAutorizar.Text = "AUTORIZAR";
            this.uiAutorizar.UseVisualStyleBackColor = true;
            this.uiAutorizar.Click += new System.EventHandler(this.uiAutorizar_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.Location = new System.Drawing.Point(315, 3);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(102, 31);
            this.uiCancelar.TabIndex = 3;
            this.uiCancelar.Text = "CANCELAR";
            this.uiCancelar.UseVisualStyleBackColor = true;
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiImprimir
            // 
            this.uiImprimir.Location = new System.Drawing.Point(418, 3);
            this.uiImprimir.Name = "uiImprimir";
            this.uiImprimir.Size = new System.Drawing.Size(102, 31);
            this.uiImprimir.TabIndex = 4;
            this.uiImprimir.Text = "IMPRIMIR";
            this.uiImprimir.UseVisualStyleBackColor = true;
            this.uiImprimir.Click += new System.EventHandler(this.uiImprimir_Click);
            // 
            // uiPrecioCompra1
            // 
            this.uiPrecioCompra1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uiPrecioCompra1.Location = new System.Drawing.Point(497, 13);
            this.uiPrecioCompra1.Name = "uiPrecioCompra1";
            this.uiPrecioCompra1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiPrecioCompra1.Properties.DisplayFormat.FormatString = "c2";
            this.uiPrecioCompra1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiPrecioCompra1.Properties.EditFormat.FormatString = "c2";
            this.uiPrecioCompra1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.uiPrecioCompra1.Size = new System.Drawing.Size(85, 26);
            this.uiPrecioCompra1.TabIndex = 3;
            // 
            // frmEntradaDirectaUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.uiPrecioCompra);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmEntradaDirectaUpd";
            this.Text = "Salida Traspaso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalidaTraspasoUpd_FormClosing);
            this.Load += new System.EventHandler(this.frmSalidaTraspasoUpd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntradaDirectaUpd_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntradaDirectaUpd_KeyUp);
            this.Controls.SetChildIndex(this.panelSup, 0);
            this.Controls.SetChildIndex(this.uiPrecioCompra, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panelSup.ResumeLayout(false);
            this.uiPrecioCompra.ResumeLayout(false);
            this.uiPrecioCompra.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCantidad.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPrecioCompra1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiAutorizar;
        private System.Windows.Forms.Panel uiPrecioCompra;
        private System.Windows.Forms.DateTimePicker uiFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiFolio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView uiGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button uiAgregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiDescProducto;
        private System.Windows.Forms.TextBox uiClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.ComboBox uiSucursalOrigen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox uiCargadoInv;
        private System.Windows.Forms.CheckBox uiGuardado;
        private System.Windows.Forms.Button uiCancelar;
        private System.Windows.Forms.DateTimePicker uiFechaCancelacion;
        private System.Windows.Forms.CheckBox uiCancelado;
        private System.Windows.Forms.Button uiImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.SpinEdit uiCantidad;
        private DevExpress.XtraEditors.SpinEdit uiPrecioCompra1;
    }
}