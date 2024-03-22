using System.ComponentModel.DataAnnotations;

namespace backendProducto.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }


        // Esta propiedad representa la clave externa para la relación con la categoría
        public int CategoriaId { get; set; }

        // Esta propiedad representa la navegación a la categoría
        public Categoria categoria { get; set; }
    }
}
