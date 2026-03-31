using System.Data.Entity;
using PrestamosApp.Entidades;

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
    }
}