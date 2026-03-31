using PrestamosApp.Datos;
using PrestamosApp.Entidades;
using System;

namespace PrestamosApp.Services
{
    public class PrestamoService
    {
        public decimal ObtenerTasaPorMeses(int meses)
        {
            if (meses <= 12)
                return 10m;
            else if (meses <= 24)
                return 12m;
            else
                return 15m;
        }

        public decimal CalcularInteres(decimal capital, decimal tasaAnual)
        {
            return Math.Round(capital * (tasaAnual / 100m), 2);
        }

        public decimal CalcularMontoTotal(decimal capital, decimal interes)
        {
            return Math.Round(capital + interes, 2);
        }

        public decimal CalcularCuotaMensual(decimal montoTotal, int plazoMeses)
        {
            return Math.Round(montoTotal / plazoMeses, 2);
        }

        public string CrearPrestamo(int clienteId, decimal capital, int plazoMeses)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var cliente = db.Clientes.Find(clienteId);

                    if (cliente == null)
                        return "Cliente no encontrado.";

                    if (string.IsNullOrWhiteSpace(cliente.Garantia))
                        return "Cliente sin garantía.";

                    decimal tasa = ObtenerTasaPorMeses(plazoMeses);
                    decimal interes = CalcularInteres(capital, tasa);
                    decimal montoTotal = CalcularMontoTotal(capital, interes);
                    decimal cuota = CalcularCuotaMensual(montoTotal, plazoMeses);

                    var prestamo = new Prestamo
                    {
                        ClienteId = clienteId,
                        Capital = capital,
                        PlazoMeses = plazoMeses,
                        TasaAnual = tasa,
                        Cuota = cuota,
                        FechaInicio = DateTime.Now,
                        Estado = "ACTIVO",
                        SaldoPendiente = montoTotal
                    };

                    db.Prestamos.Add(prestamo);
                    db.SaveChanges();

                    return "Préstamo creado correctamente.";
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                return "Error al crear préstamo:\n\n" + mensaje;
            }
        }
    }
}