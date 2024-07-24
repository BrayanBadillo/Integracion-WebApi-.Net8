using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProducts()
        {
            return ProductoData.GetProductos
            .Select(p => new ProductoDto
            {
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Marca = p.Marca,
                Precio = p.Precio,
                Costo = p.Costo
            }).ToList();
        }
    }
}