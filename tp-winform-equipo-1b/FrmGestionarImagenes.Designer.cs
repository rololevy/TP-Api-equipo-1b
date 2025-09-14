namespace tp_winform_equipo_1b
{
    partial class FrmGestionarImagenes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lstImagenes;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblCount;

        protected override void Dispose(bool disposing)
        { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lstImagenes = new System.Windows.Forms.ListBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // lblTitulo
            this.lblTitulo.AutoSize = true; this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo"; this.lblTitulo.Size = new System.Drawing.Size(106, 13);
            this.lblTitulo.Text = "Imágenes del artículo";
            // lstImagenes
            this.lstImagenes.FormattingEnabled = true; this.lstImagenes.IntegralHeight = false;
            this.lstImagenes.Location = new System.Drawing.Point(15, 35);
            this.lstImagenes.Name = "lstImagenes"; this.lstImagenes.Size = new System.Drawing.Size(350, 300);
            this.lstImagenes.SelectedIndexChanged += new System.EventHandler(this.lstImagenes_SelectedIndexChanged);
            // picPreview
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(385, 35);
            this.picPreview.Name = "picPreview"; this.picPreview.Size = new System.Drawing.Size(380, 300);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; this.picPreview.TabStop = false;
            // txtUrl
            this.txtUrl.Location = new System.Drawing.Point(15, 345); this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(350, 20);
            // btnAgregar
            this.btnAgregar.Location = new System.Drawing.Point(371, 343);
            this.btnAgregar.Name = "btnAgregar"; this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.Text = "Agregar"; this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(452, 343);
            this.btnEliminar.Name = "btnEliminar"; this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.Text = "Eliminar"; this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(690, 343);
            this.btnCerrar.Name = "btnCerrar"; this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.Text = "Cerrar"; this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // lblCount
            this.lblCount.AutoSize = true; this.lblCount.Location = new System.Drawing.Point(742, 9);
            this.lblCount.Name = "lblCount"; this.lblCount.Size = new System.Drawing.Size(23, 13); this.lblCount.Text = "0/0";
            // FrmGestionarImagenes
            this.ClientSize = new System.Drawing.Size(780, 380);
            this.Controls.Add(this.lblCount); this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar); this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtUrl); this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lstImagenes); this.Controls.Add(this.lblTitulo);
            this.Name = "FrmGestionarImagenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionar Imágenes";
            this.Load += new System.EventHandler(this.FrmGestionarImagenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
