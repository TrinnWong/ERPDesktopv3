namespace PuntoVenta
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.uiDevoluciones = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uiGastos = new System.Windows.Forms.Button();
            this.uiRetiroEfectivo = new System.Windows.Forms.Button();
            this.uiBuscarTicket = new System.Windows.Forms.Button();
            this.uiCancelaciones = new System.Windows.Forms.Button();
            this.uiReimpresiones = new System.Windows.Forms.Button();
            this.uiNuevaVenta = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.uiMenuImpresoras = new System.Windows.Forms.Button();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.uiApartados = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiDevoluciones
            // 
            this.uiDevoluciones.BackColor = System.Drawing.Color.White;
            this.uiDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("uiDevoluciones.Image")));
            this.uiDevoluciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiDevoluciones.Location = new System.Drawing.Point(627, 0);
            this.uiDevoluciones.Name = "uiDevoluciones";
            this.uiDevoluciones.Size = new System.Drawing.Size(105, 71);
            this.uiDevoluciones.TabIndex = 9;
            this.uiDevoluciones.Text = "DEVOLUCIONES";
            this.uiDevoluciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiDevoluciones.UseVisualStyleBackColor = false;
            this.uiDevoluciones.Click += new System.EventHandler(this.uiDevoluciones_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(938, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 71);
            this.button1.TabIndex = 8;
            this.button1.Text = "CORTE CAJA";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // uiGastos
            // 
            this.uiGastos.BackColor = System.Drawing.Color.White;
            this.uiGastos.Image = ((System.Drawing.Image)(resources.GetObject("uiGastos.Image")));
            this.uiGastos.Location = new System.Drawing.Point(523, 0);
            this.uiGastos.Name = "uiGastos";
            this.uiGastos.Size = new System.Drawing.Size(105, 71);
            this.uiGastos.TabIndex = 7;
            this.uiGastos.Text = "GASTOS";
            this.uiGastos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiGastos.UseVisualStyleBackColor = false;
            this.uiGastos.Click += new System.EventHandler(this.btnGastos_Click);
            // 
            // uiRetiroEfectivo
            // 
            this.uiRetiroEfectivo.BackColor = System.Drawing.Color.White;
            this.uiRetiroEfectivo.Image = ((System.Drawing.Image)(resources.GetObject("uiRetiroEfectivo.Image")));
            this.uiRetiroEfectivo.Location = new System.Drawing.Point(418, 0);
            this.uiRetiroEfectivo.Name = "uiRetiroEfectivo";
            this.uiRetiroEfectivo.Size = new System.Drawing.Size(105, 71);
            this.uiRetiroEfectivo.TabIndex = 5;
            this.uiRetiroEfectivo.Text = "RETIRO EFECTIVO";
            this.uiRetiroEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiRetiroEfectivo.UseVisualStyleBackColor = false;
            this.uiRetiroEfectivo.Click += new System.EventHandler(this.button6_Click);
            // 
            // uiBuscarTicket
            // 
            this.uiBuscarTicket.BackColor = System.Drawing.Color.White;
            this.uiBuscarTicket.Image = ((System.Drawing.Image)(resources.GetObject("uiBuscarTicket.Image")));
            this.uiBuscarTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiBuscarTicket.Location = new System.Drawing.Point(314, 0);
            this.uiBuscarTicket.Name = "uiBuscarTicket";
            this.uiBuscarTicket.Size = new System.Drawing.Size(105, 71);
            this.uiBuscarTicket.TabIndex = 3;
            this.uiBuscarTicket.Text = "BUSCAR TICKET";
            this.uiBuscarTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiBuscarTicket.UseVisualStyleBackColor = false;
            this.uiBuscarTicket.Click += new System.EventHandler(this.button4_Click);
            // 
            // uiCancelaciones
            // 
            this.uiCancelaciones.BackColor = System.Drawing.Color.White;
            this.uiCancelaciones.Image = ((System.Drawing.Image)(resources.GetObject("uiCancelaciones.Image")));
            this.uiCancelaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiCancelaciones.Location = new System.Drawing.Point(210, 0);
            this.uiCancelaciones.Name = "uiCancelaciones";
            this.uiCancelaciones.Size = new System.Drawing.Size(105, 71);
            this.uiCancelaciones.TabIndex = 2;
            this.uiCancelaciones.Text = "CANCELACIONES";
            this.uiCancelaciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiCancelaciones.UseVisualStyleBackColor = false;
            this.uiCancelaciones.Click += new System.EventHandler(this.button3_Click);
            // 
            // uiReimpresiones
            // 
            this.uiReimpresiones.BackColor = System.Drawing.Color.White;
            this.uiReimpresiones.Image = ((System.Drawing.Image)(resources.GetObject("uiReimpresiones.Image")));
            this.uiReimpresiones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiReimpresiones.Location = new System.Drawing.Point(104, 0);
            this.uiReimpresiones.Name = "uiReimpresiones";
            this.uiReimpresiones.Size = new System.Drawing.Size(105, 71);
            this.uiReimpresiones.TabIndex = 1;
            this.uiReimpresiones.Text = "RE-IMPRESIONES";
            this.uiReimpresiones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiReimpresiones.UseVisualStyleBackColor = false;
            this.uiReimpresiones.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiNuevaVenta
            // 
            this.uiNuevaVenta.BackColor = System.Drawing.Color.White;
            this.uiNuevaVenta.Image = ((System.Drawing.Image)(resources.GetObject("uiNuevaVenta.Image")));
            this.uiNuevaVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uiNuevaVenta.Location = new System.Drawing.Point(0, 0);
            this.uiNuevaVenta.Name = "uiNuevaVenta";
            this.uiNuevaVenta.Size = new System.Drawing.Size(105, 71);
            this.uiNuevaVenta.TabIndex = 0;
            this.uiNuevaVenta.Text = "NUEVA VENTA";
            this.uiNuevaVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiNuevaVenta.UseVisualStyleBackColor = false;
            this.uiNuevaVenta.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(1245, 71);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiMenuImpresoras);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnExistencias);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnCerrarSesion);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiApartados);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiDevoluciones);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiGastos);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiRetiroEfectivo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiBuscarTicket);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiCancelaciones);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiReimpresiones);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.uiNuevaVenta);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1305, 72);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1305, 73);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 1);
            this.toolStripContainer1.TopToolStripPanel.MinimumSize = new System.Drawing.Size(0, 1);
            // 
            // uiMenuImpresoras
            // 
            this.uiMenuImpresoras.BackColor = System.Drawing.Color.White;
            this.uiMenuImpresoras.Image = ((System.Drawing.Image)(resources.GetObject("uiMenuImpresoras.Image")));
            this.uiMenuImpresoras.Location = new System.Drawing.Point(1045, 0);
            this.uiMenuImpresoras.Name = "uiMenuImpresoras";
            this.uiMenuImpresoras.Size = new System.Drawing.Size(105, 71);
            this.uiMenuImpresoras.TabIndex = 13;
            this.uiMenuImpresoras.Text = "IMPRESORAS";
            this.uiMenuImpresoras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiMenuImpresoras.UseVisualStyleBackColor = false;
            this.uiMenuImpresoras.Click += new System.EventHandler(this.uiMenuImpresoras_Click);
            // 
            // btnExistencias
            // 
            this.btnExistencias.BackColor = System.Drawing.Color.White;
            this.btnExistencias.Image = ((System.Drawing.Image)(resources.GetObject("btnExistencias.Image")));
            this.btnExistencias.Location = new System.Drawing.Point(834, 0);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(105, 71);
            this.btnExistencias.TabIndex = 12;
            this.btnExistencias.Text = "EXISTENCIAS";
            this.btnExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExistencias.UseVisualStyleBackColor = false;
            this.btnExistencias.Click += new System.EventHandler(this.btnExistencias_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.Location = new System.Drawing.Point(1148, 0);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(105, 71);
            this.btnCerrarSesion.TabIndex = 11;
            this.btnCerrarSesion.Text = "CERRAR SESIÓN";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click_1);
            // 
            // uiApartados
            // 
            this.uiApartados.BackColor = System.Drawing.Color.White;
            this.uiApartados.Image = ((System.Drawing.Image)(resources.GetObject("uiApartados.Image")));
            this.uiApartados.Location = new System.Drawing.Point(731, 0);
            this.uiApartados.Name = "uiApartados";
            this.uiApartados.Size = new System.Drawing.Size(105, 71);
            this.uiApartados.TabIndex = 10;
            this.uiApartados.Text = "APARTADOS";
            this.uiApartados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiApartados.UseVisualStyleBackColor = false;
            this.uiApartados.Click += new System.EventHandler(this.uiApartados_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1305, 579);
            this.Controls.Add(this.toolStripContainer1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "frmMenu";
            this.Text = "Menú";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uiNuevaVenta;
        private System.Windows.Forms.Button uiRetiroEfectivo;
        private System.Windows.Forms.Button uiBuscarTicket;
        private System.Windows.Forms.Button uiCancelaciones;
        private System.Windows.Forms.Button uiReimpresiones;
        private System.Windows.Forms.Button uiGastos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button uiDevoluciones;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button uiApartados;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnExistencias;
        private System.Windows.Forms.Button uiMenuImpresoras;
    }
}

