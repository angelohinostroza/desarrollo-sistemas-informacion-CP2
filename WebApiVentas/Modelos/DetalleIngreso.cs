using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("detalle_ingreso", Schema = "detalle_ingreso")]
    [Index("IngresoIdingreso", Name = "fk_detalle_ingreso_ingreso1_idx")]
    [Index("ProductoIdproducto", Name = "fk_detalle_ingreso_producto1_idx")]
    public partial class DetalleIngreso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("iddetalle_ingreso", TypeName = "int(11)")]
        public int IddetalleIngreso { get; set; }
        [Column("ingreso_idingreso", TypeName = "int(11)")]
        public int IngresoIdingreso { get; set; }
        [Column("producto_idproducto", TypeName = "int(11)")]
        public int ProductoIdproducto { get; set; }
        [Column("cantidad", TypeName = "int(11)")]
        public int Cantidad { get; set; }
        [Column("precio_compra")]
        [Precision(11, 2)]
        public decimal PrecioCompra { get; set; }
        [Column("precio_venta")]
        [Precision(11, 2)]
        public decimal PrecioVenta { get; set; }

        [ForeignKey("IngresoIdingreso")]
        [InverseProperty("DetalleIngreso")]
        public virtual Ingreso IngresoIdingresoNavigation { get; set; } = null!;
        [ForeignKey("ProductoIdproducto")]
        [InverseProperty("DetalleIngreso")]
        public virtual Producto ProductoIdproductoNavigation { get; set; } = null!;
    }
}
