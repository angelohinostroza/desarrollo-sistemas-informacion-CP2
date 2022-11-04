using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiVentas.Modelos
{
    public partial class dbventasDbContext : DbContext
    {
        public dbventasDbContext()
        {
        }

        public dbventasDbContext(DbContextOptions<dbventasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<DetalleIngreso> DetalleIngreso { get; set; } = null!;
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingreso { get; set; } = null!;
        public virtual DbSet<Producto> Producto { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedor { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            optionsBuilder.EnableSensitiveDataLogging();
            string conneccion = configurationFile.GetConnectionString("dbventas");
            optionsBuilder.UseMySql(conneccion, ServerVersion.AutoDetect(conneccion));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<DetalleIngreso>(entity =>
            {
                entity.HasKey(e => e.IddetalleIngreso)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.IngresoIdingresoNavigation)
                    .WithMany(p => p.DetalleIngreso)
                    .HasForeignKey(d => d.IngresoIdingreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_ingreso_ingreso1");

                entity.HasOne(d => d.ProductoIdproductoNavigation)
                    .WithMany(p => p.DetalleIngreso)
                    .HasForeignKey(d => d.ProductoIdproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_ingreso_producto1");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IddetalleVenta)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.ProductoIdproductoNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProductoIdproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_venta_producto1");

                entity.HasOne(d => d.VentaIdventaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaIdventa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_venta_venta1");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.Idingreso)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.ProveedorIdproveedorNavigation)
                    .WithMany(p => p.Ingreso)
                    .HasForeignKey(d => d.ProveedorIdproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ingreso_proveedor1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.CategoriaIdcategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaIdcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_categoria");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("PRIMARY");

                entity.HasOne(d => d.ClienteIdclienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteIdcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_cliente1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
