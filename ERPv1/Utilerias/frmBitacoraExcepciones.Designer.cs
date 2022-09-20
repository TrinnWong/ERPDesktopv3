namespace ERPv1.Utilerias
{
    partial class frmBitacoraExcepciones
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sisbitacoraerroresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSistema = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExStackTrace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colExInnerException = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colExMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcat_usuarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sisbitacoraerroresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sisbitacoraerroresBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemMemoEdit3,
            this.repositoryItemDateEdit1,
            this.repositoryItemMemoExEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1033, 523);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sisbitacoraerroresBindingSource
            // 
            this.sisbitacoraerroresBindingSource.DataSource = typeof(ConexionBD.sis_bitacora_errores);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdError,
            this.colSistema,
            this.colClase,
            this.colExStackTrace,
            this.colExInnerException,
            this.colExMessage,
            this.colCreadoEl,
            this.colCreadoPor,
            this.colcat_usuarios});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.RowHeight = 100;
            // 
            // colIdError
            // 
            this.colIdError.Caption = "Id Excepción";
            this.colIdError.FieldName = "IdError";
            this.colIdError.Name = "colIdError";
            this.colIdError.OptionsColumn.AllowEdit = false;
            this.colIdError.Visible = true;
            this.colIdError.VisibleIndex = 0;
            this.colIdError.Width = 80;
            // 
            // colSistema
            // 
            this.colSistema.FieldName = "Sistema";
            this.colSistema.Name = "colSistema";
            this.colSistema.OptionsColumn.AllowEdit = false;
            this.colSistema.Visible = true;
            this.colSistema.VisibleIndex = 1;
            this.colSistema.Width = 80;
            // 
            // colClase
            // 
            this.colClase.FieldName = "Clase";
            this.colClase.Name = "colClase";
            this.colClase.OptionsColumn.AllowEdit = false;
            this.colClase.Visible = true;
            this.colClase.VisibleIndex = 2;
            this.colClase.Width = 84;
            // 
            // colExStackTrace
            // 
            this.colExStackTrace.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colExStackTrace.FieldName = "ExStackTrace";
            this.colExStackTrace.Name = "colExStackTrace";
            this.colExStackTrace.OptionsColumn.AllowEdit = false;
            this.colExStackTrace.Visible = true;
            this.colExStackTrace.VisibleIndex = 3;
            this.colExStackTrace.Width = 188;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colExInnerException
            // 
            this.colExInnerException.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colExInnerException.FieldName = "ExInnerException";
            this.colExInnerException.Name = "colExInnerException";
            this.colExInnerException.OptionsColumn.AllowEdit = false;
            this.colExInnerException.Visible = true;
            this.colExInnerException.VisibleIndex = 4;
            this.colExInnerException.Width = 188;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colExMessage
            // 
            this.colExMessage.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colExMessage.FieldName = "ExMessage";
            this.colExMessage.Name = "colExMessage";
            this.colExMessage.OptionsColumn.AllowEdit = false;
            this.colExMessage.Visible = true;
            this.colExMessage.VisibleIndex = 5;
            this.colExMessage.Width = 233;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.ColumnEdit = this.repositoryItemDateEdit1;
            this.colCreadoEl.DisplayFormat.FormatString = "dd/mm/yyyy hh:mm tt";
            this.colCreadoEl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreadoEl.FieldName = "CreadoEl";
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.AllowEdit = false;
            this.colCreadoEl.Visible = true;
            this.colCreadoEl.VisibleIndex = 6;
            this.colCreadoEl.Width = 157;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/mm/yyyy hh:mm";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.FieldName = "CreadoPor";
            this.colCreadoPor.Name = "colCreadoPor";
            this.colCreadoPor.OptionsColumn.AllowEdit = false;
            // 
            // colcat_usuarios
            // 
            this.colcat_usuarios.FieldName = "cat_usuarios";
            this.colcat_usuarios.Name = "colcat_usuarios";
            this.colcat_usuarios.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // frmBitacoraExcepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 523);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmBitacoraExcepciones";
            this.Text = "Bitácora de Excepciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBitacoraExcepciones_FormClosing);
            this.Load += new System.EventHandler(this.frmBitacoraExcepciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sisbitacoraerroresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource sisbitacoraerroresBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdError;
        private DevExpress.XtraGrid.Columns.GridColumn colSistema;
        private DevExpress.XtraGrid.Columns.GridColumn colClase;
        private DevExpress.XtraGrid.Columns.GridColumn colExStackTrace;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colExInnerException;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colExMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colcat_usuarios;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
    }
}