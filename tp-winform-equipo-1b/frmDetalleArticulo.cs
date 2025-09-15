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
    
    public partial class frmDetalleArticulo : Form
    {
        private List<imagen> img;
        private int indice = 0;
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
            img = new gestionImagenes().listarPorArticulo(art.idArticulo);

            txtIdArt.Text = art.idArticulo.ToString();
            txtCodigo.Text = art.codigo;
            txtNombre.Text = art.nombre;
             txtDescripcion.Text = art.descripcion;
            txtPrecio.Text = art.precio.ToString();
            txtMarca.Text = art.marca.descripcion;
            txtCategoria.Text = art.categoria.descripcion;
            if (img.Count > 0)
            { 
                indice = 0;
                imagenManager.cargarImagen(pbArtDetalle, img[indice].Url);
            }
            
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (img == null || img.Count == 0) return;

            indice--;
            if (indice < 0)
                indice = img.Count - 1;//vuelve a la ultima

            imagenManager.cargarImagen(pbArtDetalle, img[indice].Url);

            

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (img == null || img.Count == 0) return;

            indice++;
            if (indice >= img.Count)
                indice = 0;// volvemos a la primer imagen

            imagenManager.cargarImagen(pbArtDetalle, img[indice].Url);
            

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
