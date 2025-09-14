using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using servicios;

namespace tp_winform_equipo_1b
{
    public partial class FrmGestionarImagenes : Form
    {
        private readonly int _idArticulo;
        private readonly string _nombreArticulo;
        private List<imagen> _imagenes = new List<imagen>();

        public FrmGestionarImagenes(int idArticulo, string nombreArticulo)
        {
            InitializeComponent();
            _idArticulo = idArticulo;
            _nombreArticulo = nombreArticulo;
        }

        private void FrmGestionarImagenes_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Imágenes de: {_nombreArticulo} (Id {_idArticulo})";
            CargarImagenes();
        }

        private void CargarImagenes()
        {
            _imagenes = new gestionImagenes().listarPorArticulo(_idArticulo);
            lstImagenes.DataSource = null;
            lstImagenes.DataSource = _imagenes;
            lstImagenes.DisplayMember = "Url";
            if (_imagenes.Count > 0) lstImagenes.SelectedIndex = 0;
            MostrarSeleccion();
        }

        private void MostrarSeleccion()
        {
            if (lstImagenes.SelectedItem is imagen img && !string.IsNullOrWhiteSpace(img.Url))
            {
                try { picPreview.LoadAsync(img.Url); }
                catch { picPreview.Image = null; }
            }
            else picPreview.Image = null;

            btnEliminar.Enabled = lstImagenes.SelectedItem is imagen;
            lblCount.Text = $"{(lstImagenes.SelectedIndex + 1 <= 0 ? 0 : lstImagenes.SelectedIndex + 1)}/{_imagenes.Count}";
        }

        private void lstImagenes_SelectedIndexChanged(object sender, EventArgs e) => MostrarSeleccion();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var url = txtUrl.Text?.Trim();
            if (string.IsNullOrWhiteSpace(url) ||
                !Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show("Ingresá una URL válida (http/https).");
                return;
            }

            new gestionImagenes().agregar(_idArticulo, url);
            txtUrl.Clear();
            CargarImagenes();
            var pos = _imagenes.FindIndex(i => i.Url == url);
            if (pos >= 0) lstImagenes.SelectedIndex = pos;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstImagenes.SelectedItem is imagen img &&
                MessageBox.Show("¿Eliminar la imagen seleccionada?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new gestionImagenes().eliminar(img.Id);
                CargarImagenes();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}