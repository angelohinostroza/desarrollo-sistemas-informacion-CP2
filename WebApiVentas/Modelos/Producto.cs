using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("producto", Schema = "producto")]
    [Index("CategoriaIdcategoria", Name = "fk_producto_categoria_idx")]
    public partial class Producto
    {
        public Producto()
        {
            DetalleIngreso = new HashSet<DetalleIngreso>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idproducto", TypeName = "int(11)")]
        public int Idproducto { get; set; }
        [Column("categoria_idcategoria", TypeName = "int(11)")]
        public int CategoriaIdcategoria { get; set; }
        [Column("codigo")]
        [StringLength(10)]
        public string Codigo { get; set; } = null!;
        [Column("nombre")]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [Column("stock", TypeName = "int(11)")]
        public int? Stock { get; set; }
        [Column("imagen")]
        [StringLength(100)]
        public string? Imagen { get; set; }
        [Column("estado")]
        [StringLength(8)]
        public string? Estado { get; set; }

        [ForeignKey("CategoriaIdcategoria")]
        [InverseProperty("Producto")]
        public virtual Categoria? CategoriaIdcategoriaNavigation { get; set; } = null!;
        [InverseProperty("ProductoIdproductoNavigation")]
        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }
        [InverseProperty("ProductoIdproductoNavigation")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
