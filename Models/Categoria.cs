using System.ComponentModel.DataAnnotations;

namespace backendProducto.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; } = null!;
        // Esta propiedad representa la relación uno a muchos con los productos
        public List<Producto> Productos { get; set; }

    }
}
