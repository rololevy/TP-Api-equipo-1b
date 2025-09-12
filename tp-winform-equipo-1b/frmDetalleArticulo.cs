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

namespace tp_winform_equipo_1b
{
    public partial class frmDetalleArticulo : Form
    {
        private readonly articulos art;
        public frmDetalleArticulo(articulos articulo)
        {
            InitializeComponent();
            art = articulo;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            txtIdArt.Text = art.idArticulo.ToString();
            txtCodigo.Text = art.codigo;
            txtNombre.Text = art.nombre;
             txtDescripcion.Text = art.descripcion;
            txtPrecio.Text = art.precio.ToString();
            txtMarca.Text = art.marca.descripcion;
            txtCategoria.Text = art.categoria.descripcion;
            imagenManager.cargarImagen(pbArtDetalle, art.imagenUrl);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
