using PrestamosApp.Datos;
using PrestamosApp.Entidades;
using SisemaPrestamo.Models;
using System;

namespace SisemaPrestamo.Servicios
{
    public class PrestamoService
    {
        public decimal ObtenerTasaPorMeses(int meses)
        {
            if (meses <= 6) return 0.10m;
            if (meses <= 12) return 0.15m;
            return 0.20m;
        }

        public decimal CalcularInteres(decimal monto, decimal tasa)
        {
            return monto * tasa;
        }

        public decimal CalcularMontoTotal(decimal monto, decimal interes)
        {
            return monto + interes;
        }

        public decimal CalcularCuotaMensual(decimal total, int meses)
        {
            return total / meses;
        }

        public string CrearPrestamo(int clienteId, decimal monto, int meses)
        {
            using (var db = new AppDbContext())
            {
                var cliente = db.Clientes.Find(clienteId);

                if (cliente == null)
                    return "Cliente no existe";

                if (cliente.Sueldo * 4 < monto)
                    return "Monto excede límite permitido";

                if (string.IsNullOrEmpty(cliente.Garantia))
                    return "Cliente sin garantía";

                var tasa = ObtenerTasaPorMeses(meses);
                var interes = CalcularInteres(monto, tasa);
                var total = CalcularMontoTotal(monto, interes);

                var prestamo = new Prestamo
                {
                    ClienteId = clienteId,
                    Monto = monto,
                    Interes = interes,
                    MontoTotal = total,
                    Meses = meses,
                    Fecha = DateTime.Now
                };

                Prestamo prestamo1 = db.Prestamos.Add(prestamo);
                db.SaveChanges();

                return "Préstamo creado correctamente";
            }
        }
    }
}