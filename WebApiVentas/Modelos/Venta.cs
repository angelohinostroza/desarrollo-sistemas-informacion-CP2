using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("venta", Schema = "venta")]
    [Index("ClienteIdcliente", Name = "fk_venta_cliente1_idx")]
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idventa", TypeName = "int(11)")]
        public int Idventa { get; set; }
        [Column("cliente_idcliente", TypeName = "int(11)")]
        public int ClienteIdcliente { get; set; }
        [Column("tipo_comprobante")]
        [StringLength(20)]
        public string TipoComprobante { get; set; } = null!;
        [Column("num_comprobante")]
        [StringLength(10)]
        public string NumComprobante { get; set; } = null!;
        [Column("fecha_hora", TypeName = "datetime")]
        public DateTime FechaHora { get; set; }
        [Column("igv")]
        [Precision(4, 2)]
        public decimal Igv { get; set; }
        [Column("total_venta")]
        [Precision(11, 2)]
        public decimal TotalVenta { get; set; }
        [Column("estado")]
        [StringLength(20)]
        public string Estado { get; set; } = null!;

        [ForeignKey("ClienteIdcliente")]
        [InverseProperty("Venta")]
        public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;
        [InverseProperty("VentaIdventaNavigation")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
