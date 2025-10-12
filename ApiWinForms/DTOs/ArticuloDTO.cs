using System.ComponentModel.DataAnnotations;

namespace ApiWinForms.DTOs
{
    // clase DTO para recibir datos de creación
    public class ArticuloDTO
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El ID de marca es obligatorio")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "El ID de categoría es obligatorio")]
        public int IdCategoria { get; set; }

        public string ImagenUrl { get; set; }
    }
}