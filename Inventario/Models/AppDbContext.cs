using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(b => b.Productos)
                .HasForeignKey(p => p.ProveedorId)
                .HasConstraintName("ForeignKey_Producto_Proveedor");

            modelBuilder.Entity<Detalle>()
                .HasOne(d => d.Factura)
                .WithMany(f => f.Detalles)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("ForeignKey_Detalle_Factura");

            modelBuilder.Entity<Detalle>()
                .HasOne(p => p.Producto)
                .WithMany(f => f.Detalles)
                .HasForeignKey(p => p.ProductoId)
                .HasConstraintName("ForeignKey_Detalle_Producto");

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.ClienteId)
                .HasConstraintName("ForeignKey_Factura_Cliente");
        }
    }
}
