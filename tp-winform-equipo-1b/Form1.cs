using System;
using System.Collections.Generic;
using System.Windows.Forms;
using dominio;
using servicios;

namespace tp_winform_equipo_1b
{
    public partial class FrmGestionArticulos : Form
    {
        // Lista privada para manejar artículos en memoria
        private List<articulos> listaArticulos = new List<articulos>();

        public FrmGestionArticulos()
        {
            InitializeComponent();
        }

        // CARGA INICIAL
        private void FrmGestionArticulos_Load(object sender, EventArgs e)
        {
            var svc = new gestionArticulos();
            listaArticulos = svc.listar();

            dgvArticulos.AutoGenerateColumns = true;
            dgvArticulos.DataSource = listaArticulos;

            // Ocultar la columna imagen si existe
            if (dgvArticulos.Columns["imagenUrl"] != null)
                dgvArticulos.Columns["imagenUrl"].Visible = false;

            // Opciones del combo (por si faltan)
            if (cbFiltrar.Items.Count == 0)
                cbFiltrar.Items.AddRange(new object[] { "ID articulo", "Nombre Articulo", "Marca", "Categoria", "Codigo" });
            if (cbFiltrar.SelectedIndex < 0)
                cbFiltrar.SelectedIndex = 0;

            // Sólo números cuando filtra por ID
            this.TxbFiltrar.KeyPress += TxbFiltrar_KeyPress;
        }

        // FILTRO EN MEMORIA usando findAll
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            string opcion = cbFiltrar.SelectedItem == null ? "ID articulo" : cbFiltrar.SelectedItem.ToString();
            string texto = (TxbFiltrar.Text ?? "").Trim();

            // Punto de partida: toda la lista
            var lista = new List<articulos>(listaArticulos);

            if (string.IsNullOrEmpty(texto))
            {
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = lista;
                if (dgvArticulos.Columns["imagenUrl"] != null)
                    dgvArticulos.Columns["imagenUrl"].Visible = false;
                return;
            }

            if (opcion.Equals("ID articulo", StringComparison.OrdinalIgnoreCase))
            {
                int id;
                if (int.TryParse(texto, out id))
                    lista = lista.FindAll(a => a.idArticulo == id);
                else
                    lista = new List<articulos>(); // si escriben letras
            }
            else if (opcion.StartsWith("Nombre", StringComparison.OrdinalIgnoreCase))
            {
                lista = lista.FindAll(a => !string.IsNullOrEmpty(a.nombre) &&
                                           a.nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if (opcion.Equals("Marca", StringComparison.OrdinalIgnoreCase))
            {
                lista = lista.FindAll(a => a.marca != null &&
                                           !string.IsNullOrEmpty(a.marca.descripcion) &&
                                           a.marca.descripcion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if (opcion.Equals("Categoria", StringComparison.OrdinalIgnoreCase))
            {
                lista = lista.FindAll(a => a.categoria != null &&
                                           !string.IsNullOrEmpty(a.categoria.descripcion) &&
                                           a.categoria.descripcion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            else if (opcion.Equals("Codigo", StringComparison.OrdinalIgnoreCase))
            {
                lista = lista.FindAll(a => !string.IsNullOrEmpty(a.codigo) &&
                                           a.codigo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = lista;
            if (dgvArticulos.Columns["imagenUrl"] != null)
                dgvArticulos.Columns["imagenUrl"].Visible = false;
        }

        private void TxbFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltrar.SelectedItem != null &&
                cbFiltrar.SelectedItem.ToString().Equals("ID articulo", StringComparison.OrdinalIgnoreCase))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seleccionado = (articulos)dgvArticulos.Rows[e.RowIndex].DataBoundItem;
                var detalle = new frmDetalleArticulo(seleccionado);
                detalle.ShowDialog(this);
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            // Por ahora no hacemos nada.
        }


        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
    }
}
