using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiVentas.Modelos
{
    [Table("categoria", Schema = "categoria")]
    public class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idcategoria", TypeName = "int(11)")]
        public int Idcategoria { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Column("condicion", TypeName = "tinyint(4)")]
        public sbyte? Condicion { get; set; }

        [InverseProperty("CategoriaIdcategoriaNavigation")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
