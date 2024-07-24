using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ProductoDto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
    }
}