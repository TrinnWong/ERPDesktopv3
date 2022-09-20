namespace ERPv1.Catalogos
{
    partial class frmTipoFactorSAT
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
            this.nClave = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEstatus = new System.Windows.Forms.CheckBox();
            this.txtNombreAlmacen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBotones = new System.Windows.Forms.GroupBox();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.dgvGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).BeginInit();
            this.gbBotones.SuspendLayout();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbDatos.Controls.Add(this.nClave);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.chkEstatus);
            this.gbDatos.Controls.Add(this.txtNombreAlmacen);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.gbDatos.Location = new System.Drawing.Point(22, 13);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDatos.Size = new System.Drawing.Size(863, 127);
            this.gbDatos.TabIndex = 13;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
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
            this.nClave.Size = new System.Drawing.Size(131, 23);
            this.nClave.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "ACTIVO";
            // 
            // chkEstatus
            // 
            this.chkEstatus.AutoSize = true;
            this.chkEstatus.Checked = true;
            this.chkEstatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstatus.Location = new System.Drawing.Point(156, 93);
            this.chkEstatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEstatus.Name = "chkEstatus";
            this.chkEstatus.Size = new System.Drawing.Size(15, 14);
            this.chkEstatus.TabIndex = 3;
            this.chkEstatus.UseVisualStyleBackColor = true;
            // 
            // txtNombreAlmacen
            // 
            this.txtNombreAlmacen.Location = new System.Drawing.Point(216, 52);
            this.txtNombreAlmacen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreAlmacen.MaxLength = 60;
            this.txtNombreAlmacen.Name = "txtNombreAlmacen";
            this.txtNombreAlmacen.Size = new System.Drawing.Size(528, 23);
            this.txtNombreAlmacen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "*NOMBRE TIPO FACTOR SAT";
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
            // gbBotones
            // 
            this.gbBotones.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbBotones.Controls.Add(this.btnLimpiar);
            this.gbBotones.Controls.Add(this.btnEliminar);
            this.gbBotones.Controls.Add(this.btnEditar);
            this.gbBotones.Controls.Add(this.btnAgregar);
            this.gbBotones.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBotones.ForeColor = System.Drawing.SystemColors.Control;
            this.gbBotones.Location = new System.Drawing.Point(22, 148);
            this.gbBotones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Name = "gbBotones";
            this.gbBotones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBotones.Size = new System.Drawing.Size(863, 75);
            this.gbBotones.TabIndex = 14;
            this.gbBotones.TabStop = false;
            this.gbBotones.Text = "BOTONES";
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.btnBuscar);
            this.gbListado.Controls.Add(this.dgvGrid);
            this.gbListado.Controls.Add(this.label4);
            this.gbListado.Controls.Add(this.txtBuscar);
            this.gbListado.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListado.ForeColor = System.Drawing.SystemColors.Control;
            this.gbListado.Location = new System.Drawing.Point(22, 231);
            this.gbListado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Name = "gbListado";
            this.gbListado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbListado.Size = new System.Drawing.Size(863, 312);
            this.gbListado.TabIndex = 15;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "LISTADO";
            // 
            // dgvGrid
            // 
            this.dgvGrid.AllowUserToAddRows = false;
            this.dgvGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvGrid.Location = new System.Drawing.Point(47, 68);
            this.dgvGrid.MultiSelect = false;
            this.dgvGrid.Name = "dgvGrid";
            this.dgvGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrid.Size = new System.Drawing.Size(764, 226);
            this.dgvGrid.TabIndex = 5;
            this.dgvGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrid_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "BUSCAR";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(119, 28);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(625, 23);
            this.txtBuscar.TabIndex = 3;
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
            // frmTipoFactorSAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(909, 543);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbBotones);
            this.Controls.Add(this.gbDatos);
            this.Name = "frmTipoFactorSAT";
            this.Text = "Tipo Factor SAT";
            this.Load += new System.EventHandler(this.frmTipoFactorSAT_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nClave)).EndInit();
            this.gbBotones.ResumeLayout(false);
            this.gbListado.ResumeLayout(false);
            this.gbListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.NumericUpDown nClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEstatus;
        private System.Windows.Forms.TextBox txtNombreAlmacen;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}