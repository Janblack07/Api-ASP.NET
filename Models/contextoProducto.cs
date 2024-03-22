using Microsoft.EntityFrameworkCore;

namespace backendProducto.Models
{
    public class contextoProducto : DbContext
    {
        public contextoProducto(DbContextOptions<contextoProducto>options): base(options) 
        { 

        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    //Configurar la restricción de unicidad para el campo Nombre
                 modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Nombre).IsUnique();
                 modelBuilder.Entity<Producto>()
                  .Property(p => p.Precio)
                  .HasPrecision(18, 2); // Cambia los números según la precisión y escala que necesites
                                        // Establecer la relación uno a muchos entre Categoría y Producto
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos) // Una categoría tiene muchos productos
                .WithOne(p => p.categoria) // Un producto pertenece a una sola categoría
                .HasForeignKey(p => p.CategoriaId); // Clave foránea en Producto
        }
    }
}
