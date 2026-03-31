using System;
using System.Collections.Generic;
using System.Linq;
using PrestamosApp.Calculations;
using PrestamosApp.Datos;
using PrestamosApp.DTOs;


namespace PrestamosApp.Services
{
    public class ReporteService
    {
        public ReporteClienteDto ObtenerDetalleCliente(int clienteId)
        {
            using (var db = new AppDbContext())
            {
                var cliente = db.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);

                if (cliente == null)
                    return null;

                var prestamo = db.Prestamos
                    .Where(p => p.ClienteId == clienteId)
                    .OrderByDescending(p => p.FechaInicio)
                    .FirstOrDefault();

                int moras = db.Pagos.Count(p => p.Prestamo.ClienteId == clienteId && p.Mora > 0);

                decimal montoPrestado = 0m;
                decimal interesGenerado = 0m;
                decimal montoTotal = 0m;
                int meses = 0;

                if (prestamo != null)
                {
                    montoPrestado = prestamo.Capital;
                    interesGenerado = Math.Round(prestamo.Capital * (prestamo.TasaAnual / 100m), 2);
                    montoTotal = Math.Round(prestamo.Capital + interesGenerado, 2);
                    meses = prestamo.PlazoMeses;
                }

                return new ReporteClienteDto
                {
                    ClienteId = cliente.ClienteId,
                    NombreCompleto = cliente.NombreCompleto,
                    Correo = cliente.Correo,
                    Telefono = cliente.Telefono,
                    Direccion = cliente.Direccion,
                    Garantia = cliente.Garantia,
                    Sueldo = cliente.SueldoMensual,
                    EsMoroso = moras >= 3,
                    MontoPrestado = montoPrestado,
                    InteresGenerado = interesGenerado,
                    MontoTotal = montoTotal,
                    Meses = meses
                };
            }
        }

        public ReporteFinancieroDto ObtenerResumenFinanciero()
        {
            using (var db = new AppDbContext())
            {
                var prestamos = db.Prestamos.ToList();

                decimal totalPrestado = prestamos.Sum(p => p.Capital);
                decimal totalGanancia = prestamos.Sum(p => Math.Round(p.Capital * (p.TasaAnual / 100m), 2));

                return new ReporteFinancieroDto
                {
                    TotalPrestado = totalPrestado,
                    TotalGanancia = totalGanancia
                };
            }
        }

        public List<ReporteMoraDto> ObtenerMorasPorCliente()
        {
            using (var db = new AppDbContext())
            {
                return db.Pagos
                    .Where(p => p.Mora > 0)
                    .GroupBy(p => p.Prestamo.Cliente.NombreCompleto)
                    .Select(g => new ReporteMoraDto
                    {
                        Cliente = g.Key,
                        CantidadMoras = g.Count()
                    })
                    .ToList();
            }
        }

        public List<ReporteMorosoDto> ObtenerClientesMorosos(int clienteId)
        {
            using (var db = new AppDbContext())
            {
                return db.Pagos
                    .Where(p => p.Mora > 0)
                    .GroupBy(p => new
                    {
                        p.Prestamo.Cliente.ClienteId,
                        p.Prestamo.Cliente.NombreCompleto,
                        p.Prestamo.Cliente.Correo,
                        p.Prestamo.Cliente.Telefono
                    })
                    .Where(g => g.Count() >= 3)
                    .Select(g => new ReporteMorosoDto
                    {
                        ClienteId = g.Key.ClienteId,
                        NombreCompleto = g.Key.NombreCompleto,
                        Correo = g.Key.Correo,
                        Telefono = g.Key.Telefono
                    })
                    .ToList();
            }
        }

        public List<ReporteMorosoDto> ObtenerClienteMorosoPorId(int clienteId)
        {
            using (var db = new AppDbContext())
            {
                return db.Pagos
                    .Where(p => p.Mora > 0 && p.Prestamo.ClienteId == clienteId)
                    .GroupBy(p => new
                    {
                        p.Prestamo.Cliente.ClienteId,
                        p.Prestamo.Cliente.NombreCompleto,
                        p.Prestamo.Cliente.Correo,
                        p.Prestamo.Cliente.Telefono
                    })
                    .Where(g => g.Count() >= 3)
                    .Select(g => new ReporteMorosoDto
                    {
                        ClienteId = g.Key.ClienteId,
                        NombreCompleto = g.Key.NombreCompleto,
                        Correo = g.Key.Correo,
                        Telefono = g.Key.Telefono
                    })
                    .ToList();
            }
        }


        public List<ReporteAmortizacionDto> ObtenerTablaAmortizacion(decimal monto, int meses)
    {
        var tabla = LoanCalculator.GenerarTablaAmortizacion(monto, meses);

        return tabla.Select(x => new ReporteAmortizacionDto
        {
            Mes = x.Mes,
            Cuota = x.Cuota,
            Interes = x.Interes,
            Capital = x.Capital,
            Saldo = x.Saldo
        }).ToList();
    }

    public List<ReporteAmortizacionDto> ObtenerTablaAmortizacionPorCliente(int clienteId)
    {
        using (var db = new AppDbContext())
        {
            var prestamo = db.Prestamos
                .Where(p => p.ClienteId == clienteId)
                .OrderByDescending(p => p.FechaInicio)
                .FirstOrDefault();

            if (prestamo == null)
                return new List<ReporteAmortizacionDto>();

            var tabla = LoanCalculator.GenerarTablaAmortizacion(
                prestamo.Capital,
                prestamo.PlazoMeses,
                prestamo.TasaAnual
            );

            return tabla.Select(x => new ReporteAmortizacionDto
            {
                Mes = x.Mes,
                Cuota = x.Cuota,
                Interes = x.Interes,
                Capital = x.Capital,
                Saldo = x.Saldo
            }).ToList();
        }
    }

        internal object ObtenerClientesMorosos()
        {
            throw new NotImplementedException();
        }
    }
}