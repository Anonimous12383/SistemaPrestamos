using PrestamosApp.Entidades;
using System.Data.Entity;

namespace PrestamosApp.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ConexionPrestamos")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<FondoEmpresa> FondosEmpresa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamos");
            modelBuilder.Entity<Pago>().ToTable("Pagos");
            modelBuilder.Entity<FondoEmpresa>().ToTable("FondoEmpresa");

            base.OnModelCreating(modelBuilder);
        }
    }
}