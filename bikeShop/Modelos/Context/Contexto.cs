using bikeShop.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShop.Modelos.Context
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleOrden>()
                .HasKey(t => new { t.correlativo, t.Id_Orden});
        }

        public DbSet<Orden> Orden { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
