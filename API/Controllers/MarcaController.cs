using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetMarcas()
        {
            var listMarcas = await dbContext.Marcas.ToListAsync();
            return Ok(listMarcas);
        }
    }
}