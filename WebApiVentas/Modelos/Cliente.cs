using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("cliente", Schema = "cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idcliente", TypeName = "int(11)")]
        public int Idcliente { get; set; }
        [Column("tipo_persona")]
        [StringLength(10)]
        public string TipoPersona { get; set; } = null!;
        [Column("nombre")]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;
        [Column("tipo_documento")]
        [StringLength(20)]
        public string TipoDocumento { get; set; } = null!;
        [Column("num_documento")]
        [StringLength(15)]
        public string NumDocumento { get; set; } = null!;
        [Column("direccion")]
        [StringLength(100)]
        public string? Direccion { get; set; }
        [Column("distrito")]
        [StringLength(45)]
        public string? Distrito { get; set; }
        [Column("departamento")]
        [StringLength(45)]
        public string? Departamento { get; set; }
        [Column("email")]
        [StringLength(45)]
        public string? Email { get; set; }
        [Column("telefono")]
        [StringLength(9)]
        public string? Telefono { get; set; }
        [Column("estado")]
        [StringLength(8)]
        public string? Estado { get; set; }

        [InverseProperty("ClienteIdclienteNavigation")]
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
