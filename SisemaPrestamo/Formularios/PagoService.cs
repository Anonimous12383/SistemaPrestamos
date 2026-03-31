using PrestamosApp.Datos;
using PrestamosApp.Entidades;
using System;
using System.Linq;

namespace PrestamosApp.Services
{
    public class PagoService
    {
        public string RegistrarPago(int prestamoId, bool fuePagado)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var prestamo = db.Prestamos.FirstOrDefault(p => p.PrestamoId == prestamoId);

                    if (prestamo == null)
                        return "Préstamo no encontrado.";

                    if (prestamo.Estado == "FINALIZADO")
                        return "Este préstamo ya está finalizado.";

                    int cuotasRegistradas = db.Pagos.Count(p => p.PrestamoId == prestamoId);
                    int numeroCuota = cuotasRegistradas + 1;

                    if (numeroCuota > prestamo.PlazoMeses)
                        return "Ya no hay más cuotas pendientes para este préstamo.";

                    decimal montoAnterior = prestamo.SaldoPendiente;
                    decimal cuota = prestamo.Cuota;

                    decimal interesPagado = Math.Round(
                        (prestamo.Capital * (prestamo.TasaAnual / 100m)) / prestamo.PlazoMeses,
                        2
                    );

                    decimal capitalPagado = Math.Round(cuota - interesPagado, 2);
                    decimal mora = 0m;

                    if (!fuePagado)
                    {
                        mora = Math.Round(cuota * 0.10m, 2);
                    }

                    decimal nuevoMontoDeuda = Math.Round(montoAnterior - capitalPagado + mora, 2);

                    if (nuevoMontoDeuda < 0)
                        nuevoMontoDeuda = 0;

                    int mesesRestantes = prestamo.PlazoMeses - numeroCuota;
                    if (mesesRestantes < 0)
                        mesesRestantes = 0;

                    decimal totalInteresesAcumulados = db.Pagos
                        .Where(p => p.PrestamoId == prestamoId)
                        .Sum(p => (decimal?)p.InteresPagado) ?? 0m;

                    totalInteresesAcumulados += interesPagado;

                    var pago = new Pago
                    {
                        PrestamoId = prestamoId,
                        NumeroCuota = numeroCuota,
                        FechaPago = DateTime.Now,
                        MontoAnterior = montoAnterior,
                        InteresPagado = interesPagado,
                        CapitalPagado = capitalPagado,
                        Cuota = cuota,
                        Mora = mora,
                        NuevoMontoDeuda = nuevoMontoDeuda,
                        MesesRestantes = mesesRestantes,
                        TotalInteresesAcumulados = totalInteresesAcumulados,
                        TasaPrestamo = prestamo.TasaAnual,
                        FuePagado = fuePagado
                    };

                    db.Pagos.Add(pago);

                    prestamo.SaldoPendiente = nuevoMontoDeuda;

                    if (numeroCuota >= prestamo.PlazoMeses || nuevoMontoDeuda <= 0)
                    {
                        prestamo.Estado = "FINALIZADO";
                        prestamo.SaldoPendiente = 0;
                    }

                    db.SaveChanges();

                    return "Pago registrado correctamente.";
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

                if (ex.InnerException != null)
                    mensaje += "\n\nINNER: " + ex.InnerException.Message;

                if (ex.InnerException?.InnerException != null)
                    mensaje += "\n\nSQL: " + ex.InnerException.InnerException.Message;

                return "Error al registrar pago:\n\n" + mensaje;
            }
        }
    }
}