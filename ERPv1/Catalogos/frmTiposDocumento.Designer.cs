namespace ERPv1.Catalogos
{
    partial class frmTiposDocumento
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
            this.uiAbreviatura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiClave = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiReqClaveSup = new System.Windows.Forms.CheckBox();
            this.uiDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uiFolioInicial = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.uiIntegrarCorte = new System.Windows.Forms.CheckBox();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioInicial)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbDatos.Controls.Add(this.uiIntegrarCorte);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.uiFolioInicial);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.uiAbreviatura);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.uiClave);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.uiReqClaveSup);
            this.gbDatos.Controls.Add(this.uiDescripcion);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(12, 13);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(1121, 91);
            this.gbDatos.TabIndex = 15;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // uiAbreviatura
            // 
            this.uiAbreviatura.Location = new System.Drawing.Point(520, 51);
            this.uiAbreviatura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiAbreviatura.MaxLength = 3;
            this.uiAbreviatura.Name = "uiAbreviatura";
            this.uiAbreviatura.Size = new System.Drawing.Size(96, 23);
            this.uiAbreviatura.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "*ABREVIATURA";
            // 
            // uiClave
            // 
            this.uiClave.Location = new System.Drawing.Point(40, 52);
            this.uiClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiClave.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.uiClave.Name = "uiClave";
            this.uiClave.Size = new System.Drawing.Size(131, 23);
            this.uiClave.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(788, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "REQUIERE CLAVE SUPERVISOR";
            // 
            // uiReqClaveSup
            // 
            this.uiReqClaveSup.AutoSize = true;
            this.uiReqClaveSup.Location = new System.Drawing.Point(1055, 31);
            this.uiReqClaveSup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiReqClaveSup.Name = "uiReqClaveSup";
            this.uiReqClaveSup.Size = new System.Drawing.Size(15, 14);
            this.uiReqClaveSup.TabIndex = 3;
            this.uiReqClaveSup.UseVisualStyleBackColor = true;
            // 
            // uiDescripcion
            // 
            this.uiDescripcion.Location = new System.Drawing.Point(181, 52);
            this.uiDescripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiDescripcion.MaxLength = 60;
            this.uiDescripcion.Name = "uiDescripcion";
            this.uiDescripcion.Size = new System.Drawing.Size(334, 23);
            this.uiDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "*DESCRIPCIÓN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "*CLAVE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(642, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "FOLIO INICIAL";
            // 
            // uiFolioInicial
            // 
            this.uiFolioInicial.Location = new System.Drawing.Point(645, 52);
            this.uiFolioInicial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiFolioInicial.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.uiFolioInicial.Name = "uiFolioInicial";
            this.uiFolioInicial.Size = new System.Drawing.Size(118, 23);
            this.uiFolioInicial.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(788, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "INTEGRAR AL CORTE DE CAJA";
            // 
            // uiIntegrarCorte
            // 
            this.uiIntegrarCorte.AutoSize = true;
            this.uiIntegrarCorte.Location = new System.Drawing.Point(1055, 56);
            this.uiIntegrarCorte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiIntegrarCorte.Name = "uiIntegrarCorte";
            this.uiIntegrarCorte.Size = new System.Drawing.Size(15, 14);
            this.uiIntegrarCorte.TabIndex = 11;
            this.uiIntegrarCorte.UseVisualStyleBackColor = true;
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
            this.gbBotones.Location = new System.Drawing.Point(12, 112);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(1121, 75);
            this.gbBotones.TabIndex = 16;
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
            this.gbListado.Controls.Add(this.dgvGrid);
            this.gbListado.Controls.Add(this.label7);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(12, 195);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(1121, 285);
            this.gbListado.TabIndex = 17;
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
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvGrid.Location = new System.Drawing.Point(18, 68);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrid.Size = new System.Drawing.Size(1082, 198);
            this.dgvGrid.TabIndex = 5;
            this.dgvGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrid_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(119, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(625, 23);
            this.txtBuscar.TabIndex = 3;
            // 
            // frmTiposDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1156, 495);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Name = "frmTiposDocumento";
            this.Text = "Tipos de Documento";
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFolioInicial)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.CheckBox uiIntegrarCorte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uiFolioInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uiAbreviatura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown uiClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox uiReqClaveSup;
        private System.Windows.Forms.TextBox uiDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbBotones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}