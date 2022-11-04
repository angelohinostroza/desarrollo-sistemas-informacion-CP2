using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("detalle_venta", Schema = "detalle_venta")]
    [Index("ProductoIdproducto", Name = "fk_detalle_venta_producto1_idx")]
    [Index("VentaIdventa", Name = "fk_detalle_venta_venta1_idx")]
    public partial class DetalleVenta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("iddetalle_venta", TypeName = "int(11)")]
        public int IddetalleVenta { get; set; }
        [Column("venta_idventa", TypeName = "int(11)")]
        public int VentaIdventa { get; set; }
        [Column("producto_idproducto", TypeName = "int(11)")]
        public int ProductoIdproducto { get; set; }
        [Column("cantidad", TypeName = "int(11)")]
        public int Cantidad { get; set; }
        [Column("precio_venta")]
        [Precision(11, 2)]
        public decimal PrecioVenta { get; set; }
        [Column("descuento")]
        [Precision(11, 2)]
        public decimal Descuento { get; set; }

        [ForeignKey("ProductoIdproducto")]
        [InverseProperty("DetalleVenta")]
        public virtual Producto ProductoIdproductoNavigation { get; set; } = null!;
        [ForeignKey("VentaIdventa")]
        [InverseProperty("DetalleVenta")]
        public virtual Venta VentaIdventaNavigation { get; set; } = null!;
    }
}
