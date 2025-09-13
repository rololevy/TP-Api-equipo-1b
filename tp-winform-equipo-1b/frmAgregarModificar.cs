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

        //creo un atributo privado para poder manipular despues
        //este cae al constructor sin parametros
        private articulos articulo = null;
        public frmAgregarModificar()
        {
            InitializeComponent();
        }

        public frmAgregarModificar(articulos art)
        {
            InitializeComponent();
            articulo = art;
            Text = "Modificar Articulo"; //Titulo de la ventana
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
            //articulos art = new articulos();
            gestionArticulos gestor = new gestionArticulos();
            try
            {
<<<<<<< HEAD
                if (articulo == null) //Si es null estoy agregando/creando
                {
                    articulo = new articulos(); //genero la instancia
                }
                    articulo.codigo = txbCodigo.Text;
                    articulo.nombre = txbNombre.Text;
                    articulo.descripcion = txbDesc.Text;
                    articulo.precio = decimal.Parse(txbPrecio.Text);
                    articulo.marca = (marcas)cbMarca.SelectedItem;
                    articulo.categoria = (categorias)cbCategoria.SelectedItem;
                    articulo.imagenUrl = txbUrlImagen.Text;
=======
                art.codigo = txbCodigo.Text;
                art.nombre = txbNombre.Text;
                art.descripcion = txbDesc.Text;
                art.precio = decimal.Parse(txbPrecio.Text);
                art.marca = (marcas)cbMarca.SelectedItem;
                art.categoria = (categorias)cbCategoria.SelectedItem; 
                art.imagenUrl = txbUrlImagen.Text;
                gestor.agregarArticulo(art);
                MessageBox.Show("Se ha cargado el artículo correctamente");
                Close();
>>>>>>> 3842e94dbda8ef1a0d7f9b1996b68be357144a21

                if (articulo.idArticulo != 0) //Estoy modificando
                {
                    gestor.modificar(articulo);
                    MessageBox.Show("Se ha modificado el articulo correctamente");
                }else //Estoy agregando
                {
                    gestor.agregarArticulo(articulo);
                    MessageBox.Show("se ha cargado el articulo correctamente");
                }

                Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Algunos de los datos ingresados no es correcto");
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
                cbMarca.DataSource = gestorMarca.listar();
                cbMarca.ValueMember = "idMarca"; //prop de la clase marca
                cbMarca.DisplayMember = "descripcion"; //prop de la clase marca
                cbCategoria.DataSource = gestorCat.listar();
                cbCategoria.ValueMember = "idCategoria"; //prop de la clase categoria
                cbCategoria.DisplayMember = "descripcion"; //prop de la clase categoria

                if (articulo != null) //el objeto existe, solo modifico
                {
                    txbCodigo.Text = articulo.codigo.ToString();
                    txbNombre.Text = articulo.nombre;
                    txbDesc.Text = articulo.descripcion;
                    txbPrecio.Text = articulo.precio.ToString();
                    txbUrlImagen.Text = articulo.imagenUrl;
                    cbMarca.SelectedValue = articulo.marca.idMarca;
                    cbCategoria.SelectedValue = articulo.categoria.idCategoria;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }
    }
}
