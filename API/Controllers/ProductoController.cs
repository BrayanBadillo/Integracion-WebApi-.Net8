using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            return Ok(await dbContext.Productos
                        .Include(c => c.Categoria)
                        .Include(m => m.Marca)
                        .Select(p => new ProductoDto
                        {
                            Nombre = p.Nombre,
                            Categoria = p.Categoria.Nombre,
                            Marca = p.Marca.Nombre,
                            Precio = p.Precio,
                            Costo = p.Costo
                        }).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductoById(int id)
        {

            if (id == 0)
                return BadRequest($"El id {id} no existe en nuestros Registros");

            var producto = await dbContext.Productos
                            .Include(c => c.Categoria)
                            .Include(m => m.Marca)
                            .Where(p => p.Id == id)
                            .Select(p => new ProductoDto
                            {
                                Nombre = p.Nombre,
                                Categoria = p.Categoria.Nombre,
                                Marca = p.Marca.Nombre,
                                Precio = p.Precio,
                                Costo = p.Costo
                            }).FirstOrDefaultAsync();

            if (producto is null)
                return NotFound($"El id {id} no existe en nuestros Registros");

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {

            try
            {
                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();

                return CreatedAtAction("GetProductoById", new { id = producto.Id }, producto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, Producto producto)
        {

            if (id != producto.Id)
                return BadRequest($"Los id son diferentes: {id} es diferente a {producto.Id}");

            var productoActual = await dbContext.Productos.FindAsync(id);

            if (productoActual is null)
                return NotFound("Producto no encontrado en la base de datos");

            productoActual.Nombre = producto.Nombre;
            productoActual.CategoriaId = producto.CategoriaId;
            producto.MarcaId = producto.MarcaId;
            productoActual.Precio = producto.Precio;
            productoActual.Costo = producto.Costo;

            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {

            if (id == 0)
                return BadRequest($"El id {id} no existe en nuestros Registros");

            var productoActual = await dbContext.Productos.FindAsync(id);

            if (productoActual is null)
                return NotFound("Producto no encontrado en la base de datos");

            dbContext.Productos.Remove(productoActual);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}