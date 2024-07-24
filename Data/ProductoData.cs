using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entidades;

namespace Data
{
    public static class ProductoData
    {
        public static List<Producto> GetProductos = new List<Producto>{
            new(){ Id = 1, Nombre = "Producto 1", Categoria = "Computadoras", Marca = "Hp", Precio = 2000, Costo = 1200},
            new(){ Id = 2, Nombre = "Producto 2", Categoria = "Computadoras", Marca = "Windows", Precio = 3000, Costo = 1300},
            new(){ Id = 3, Nombre = "Producto 3", Categoria = "Computadoras", Marca = "Hp", Precio = 4000, Costo = 1400},
            new(){ Id = 4, Nombre = "Producto 4", Categoria = "Computadoras", Marca = "Hp", Precio = 5000, Costo = 1500}
        };
    }
}