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
    public partial class frmAgregarModificar : Form
    {
        public frmAgregarModificar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articulos art = new articulos();
            gestionArticulos gestor = new gestionArticulos();
            try
            {
                art.codigo = txbCodigo.Text;
                art.nombre = txbNombre.Text;
                art.descripcion = txbDesc.Text;
                art.precio = decimal.Parse(txbPrecio.Text);
                art.marca = (marcas)cbMarca.SelectedItem;
                art.categoria = (categorias)cbCategoria.SelectedItem; 
                art.imagenUrl = txbUrlImagen.Text;
                gestor.agregarArticulo(art);
                MessageBox.Show("se ha cargado el articulo correctamente");
                Close();

            }
            catch(Exception)
            {
                MessageBox.Show("algunos de los datos ingresados no es correcto");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarModificar_Load(object sender, EventArgs e)
        {
            gestionCategoria gestorCat = new gestionCategoria();
            gestionMarcas gestorMarca = new gestionMarcas();
            try
            {
                cbCategoria.DataSource = gestorCat.listar();
                cbMarca.DataSource = gestorMarca.listar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
