using System.Collections.Generic;

namespace ApiWinForms.Models
{
    // clase modelo para respuesta completa
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public int IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public List<string> Imagenes { get; set; }

        public Articulo()
        {
            Imagenes = new List<string>();
        }
    }
}