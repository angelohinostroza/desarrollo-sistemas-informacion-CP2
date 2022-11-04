using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("ingreso", Schema = "ingreso")]
    [Index("ProveedorIdproveedor", Name = "fk_ingreso_proveedor1_idx")]
    public partial class Ingreso
    {
        public Ingreso()
        {
            DetalleIngreso = new HashSet<DetalleIngreso>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idingreso", TypeName = "int(11)")]
        public int Idingreso { get; set; }
        [Column("proveedor_idproveedor", TypeName = "int(11)")]
        public int ProveedorIdproveedor { get; set; }
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
        [Column("estado")]
        [StringLength(20)]
        public string Estado { get; set; } = null!;

        [ForeignKey("ProveedorIdproveedor")]
        [InverseProperty("Ingreso")]
        public virtual Proveedor ProveedorIdproveedorNavigation { get; set; } = null!;
        [InverseProperty("IngresoIdingresoNavigation")]
        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }
    }
}
