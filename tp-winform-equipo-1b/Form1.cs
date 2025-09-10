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
    public partial class FrmGestionArticulos : Form
    {
        //lista privada para manejar articulos en memoria
        private List<articulos> listaArticulos;
        public FrmGestionArticulos()
        {
            InitializeComponent();
        }

        private void FrmGestionArticulos_Load(object sender, EventArgs e)
        {
            gestionArticulos articulos = new gestionArticulos();
            listaArticulos = articulos.listar();
            dgvArticulos.DataSource = listaArticulos;
            pbArticulos.Load(listaArticulos[0].imagenUrl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            articulos selecionado=(articulos)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(selecionado.imagenUrl);

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbArticulos.Load(imagen);
            }
            catch (Exception)
            {
                pbArticulos.Load("https://demofree.sirv.com/nope-not-here.jpg");
            }
        }
    }
}
