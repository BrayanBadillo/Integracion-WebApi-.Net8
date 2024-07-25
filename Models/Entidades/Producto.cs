using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Entidades
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [Column("ProductoId")]
        public int Id { get; set; }

        [Column("NombreProducto")]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}