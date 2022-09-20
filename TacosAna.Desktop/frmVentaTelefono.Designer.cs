namespace TacosAna.Desktop
{
    partial class frmVentaTelefono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentaTelefono));
            this.uiTelefono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.uiNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.uiGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.uiCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.uiFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.uiHora = new DevExpress.XtraEditors.TimeEdit();
            this.uiTitulo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.uiNotas = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTelefono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTelefono
            // 
            this.uiTelefono.Location = new System.Drawing.Point(101, 52);
            this.uiTelefono.Name = "uiTelefono";
            this.uiTelefono.Properties.Mask.EditMask = "(999)-000-0000";
            this.uiTelefono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.uiTelefono.Properties.Mask.SaveLiteral = false;
            this.uiTelefono.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.uiTelefono.Size = new System.Drawing.Size(147, 20);
            this.uiTelefono.TabIndex = 0;
            this.uiTelefono.EditValueChanged += new System.EventHandler(this.uiTelefono_EditValueChanged);
            this.uiTelefono.Leave += new System.EventHandler(this.uiTelefono_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Teléfono";
            // 
            // uiNombre
            // 
            this.uiNombre.Location = new System.Drawing.Point(101, 91);
            this.uiNombre.Name = "uiNombre";
            this.uiNombre.Properties.MaxLength = 500;
            this.uiNombre.Size = new System.Drawing.Size(427, 20);
            this.uiNombre.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Nombre";
            // 
            // uiGuardar
            // 
            this.uiGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiGuardar.ImageOptions.Image")));
            this.uiGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.uiGuardar.Location = new System.Drawing.Point(103, 341);
            this.uiGuardar.Name = "uiGuardar";
            this.uiGuardar.Size = new System.Drawing.Size(133, 43);
            this.uiGuardar.TabIndex = 8;
            this.uiGuardar.Text = "Guardar";
            this.uiGuardar.Click += new System.EventHandler(this.uiGuardar_Click);
            // 
            // uiCancelar
            // 
            this.uiCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelar.ImageOptions.Image")));
            this.uiCancelar.Location = new System.Drawing.Point(265, 341);
            this.uiCancelar.Name = "uiCancelar";
            this.uiCancelar.Size = new System.Drawing.Size(144, 43);
            this.uiCancelar.TabIndex = 9;
            this.uiCancelar.Text = "Cancelar";
            this.uiCancelar.Click += new System.EventHandler(this.uiCancelar_Click);
            // 
            // uiFecha
            // 
            this.uiFecha.EditValue = null;
            this.uiFecha.Location = new System.Drawing.Point(101, 129);
            this.uiFecha.Name = "uiFecha";
            this.uiFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiFecha.Size = new System.Drawing.Size(147, 20);
            this.uiFecha.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 132);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Fecha Prog.";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(304, 132);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Hora Prog.";
            // 
            // uiHora
            // 
            this.uiHora.EditValue = new System.DateTime(2021, 1, 5, 10, 0, 0, 0);
            this.uiHora.Location = new System.Drawing.Point(381, 129);
            this.uiHora.Name = "uiHora";
            this.uiHora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.uiHora.Size = new System.Drawing.Size(147, 20);
            this.uiHora.TabIndex = 7;
            // 
            // uiTitulo
            // 
            this.uiTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTitulo.Appearance.Options.UseFont = true;
            this.uiTitulo.Location = new System.Drawing.Point(39, 12);
            this.uiTitulo.Name = "uiTitulo";
            this.uiTitulo.Size = new System.Drawing.Size(85, 16);
            this.uiTitulo.TabIndex = 10;
            this.uiTitulo.Text = "labelControl5";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(48, 173);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Notas";
            // 
            // uiNotas
            // 
            this.uiNotas.Location = new System.Drawing.Point(101, 172);
            this.uiNotas.Name = "uiNotas";
            this.uiNotas.Properties.MaxLength = 250;
            this.uiNotas.Size = new System.Drawing.Size(427, 86);
            this.uiNotas.TabIndex = 12;
            // 
            // frmVentaTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 396);
            this.Controls.Add(this.uiNotas);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.uiTitulo);
            this.Controls.Add(this.uiCancelar);
            this.Controls.Add(this.uiGuardar);
            this.Controls.Add(this.uiHora);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.uiFecha);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.uiNombre);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.uiTelefono);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVentaTelefono";
            this.Text = "Venta por Teléfono";
            this.Load += new System.EventHandler(this.frmVentaTelefono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiTelefono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNotas.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit uiTelefono;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit uiNombre;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton uiGuardar;
        private DevExpress.XtraEditors.SimpleButton uiCancelar;
        private DevExpress.XtraEditors.DateEdit uiFecha;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TimeEdit uiHora;
        private DevExpress.XtraEditors.LabelControl uiTitulo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit uiNotas;
    }
}