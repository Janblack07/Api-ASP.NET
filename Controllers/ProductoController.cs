using backendProducto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //inyecto mi contexto de base de datos
        private readonly contextoProducto context;

        public ProductoController(contextoProducto context)
        {
            this.context = context;
        }
        //Metodo POST
        [HttpPost]
        [Route("Crear")]
        //Registro de Productos
        public async Task<IActionResult> CrearProducto(Producto producto) {
        await context.Producto.AddAsync(producto);  //aqui accedo a mi tabla producto de mi base de datos
        await context.SaveChangesAsync();   //guardo los producto en la base de datos

        return Ok(new { message = "El producto se ha ingresado con éxito." });  //retorno todo
        }
        //Metodo GET
        [HttpGet]
        [Route("Ver")]
        //Visualizar de Productos
        public async Task<ActionResult<IEnumerable<Producto>>>VerProducto(){
        var productos = await context.Producto.ToListAsync();//Traigo todo los productos de mi tabla
        return Ok(productos);
        }
        //Metodo GET
        [HttpGet]
        [Route("Buscar")]
        //Buscar un Producto
        public async Task<IActionResult> BuscarProducto(int id)
        {
            
            Producto producto = await context.Producto.FindAsync(id);//Traigo un  producto de mi tabla
            if (producto == null) { 
            return NotFound();
            }
            return Ok(producto);
        }
        //Metodo PUT
        [HttpPut]
        [Route("Modificar")]
        //Modificar un Producto
        public async Task<IActionResult> ModificarProducto(Producto productos, int id)
        {
            var productoExistente = await context.Producto.FindAsync(id);//Traigo un  producto de mi tabla a modificar
            //actualizo todos los campos uno a uno
            productoExistente.Nombre = productos.Nombre;
            productoExistente.Descripcion = productos.Descripcion;
            productoExistente.Precio = productos.Precio;
            await context.SaveChangesAsync();   //Actualizo los producto en la base de datos
            return Ok(new { message = "El producto se ha Modificado con éxito." });  //retorno todo
        }
        //Metodo DELETE
        [HttpDelete]
        [Route("Eliminar")]
        //Eliminar un Producto
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoBorrar = await context.Producto.FindAsync(id);//Traigo un  producto de mi tabla a modificar
            context.Producto.Remove(productoBorrar!);//elimino el producto 
            await context.SaveChangesAsync();   //Actualizo los producto en la base de datos
            return Ok(new { message = "El producto se ha Eliminado con éxito." });  //retorno todo
        }
    }
}
