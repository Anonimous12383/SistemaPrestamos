using System;
using System.Collections.Generic;
using System.Linq;

namespace PrestamosApp.Calculations
{
    public static class LoanCalculator
    {
        public static decimal ObtenerTasaAnual(int meses)
        {
            if (meses <= 12)
                return 0.1325m;

            if (meses <= 24)
                return 0.15m;

            return 0.30m;
        }

        public static decimal CalcularTasaMensual(decimal tasaAnual)
        {
            return Math.Round((decimal)Math.Pow((double)(1 + tasaAnual), 1.0 / 12.0) - 1, 8);
        }

        public static decimal CalcularInteresSimple(decimal monto, decimal tasaAnual, int meses)
        {
            decimal tiempoEnAnios = meses / 12m;
            return Math.Round(monto * tasaAnual * tiempoEnAnios, 2);
        }

        public static decimal CalcularMontoTotal(decimal monto, decimal interes)
        {
            return Math.Round(monto + interes, 2);
        }

        public static decimal CalcularCuotaMensual(decimal monto, decimal tasaAnual, int meses)
        {
            if (meses <= 0)
                throw new ArgumentException("El plazo debe ser mayor que cero.");

            decimal tasaMensual = CalcularTasaMensual(tasaAnual);

            if (tasaMensual == 0)
                return Math.Round(monto / meses, 2);

            decimal potencia = (decimal)Math.Pow((double)(1 + tasaMensual), meses);
            decimal cuota = monto * (tasaMensual * potencia) / (potencia - 1);

            return Math.Round(cuota, 2);
        }

        public static decimal CalcularMora(decimal cuotaMensual)
        {
            return Math.Round(cuotaMensual * 0.10m, 2);
        }

        public class AmortizacionItem
        {
            public int Mes { get; set; }
            public decimal SaldoAnterior { get; set; }
            public decimal Cuota { get; set; }
            public decimal Interes { get; set; }
            public decimal Capital { get; set; }
            public decimal Saldo { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal TasaAnual { get; set; }
        }

        public static List<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses, decimal tasaAnual)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto debe ser mayor que cero.");

            if (meses <= 0)
                throw new ArgumentException("Los meses deben ser mayores que cero.");

            var tabla = new List<AmortizacionItem>();

            decimal saldo = monto;
            decimal tasaMensual = CalcularTasaMensual(tasaAnual);
            decimal cuota = CalcularCuotaMensual(monto, tasaAnual, meses);
            decimal interesesAcumulados = 0m;

            for (int i = 1; i <= meses; i++)
            {
                decimal saldoAnterior = saldo;
                decimal interes = Math.Round(saldoAnterior * tasaMensual, 2);
                decimal capital = Math.Round(cuota - interes, 2);

                if (i == meses)
                {
                    capital = saldoAnterior;
                    cuota = Math.Round(capital + interes, 2);
                }

                saldo = Math.Round(saldoAnterior - capital, 2);
                if (saldo < 0) saldo = 0;

                interesesAcumulados = Math.Round(interesesAcumulados + interes, 2);

                tabla.Add(new AmortizacionItem
                {
                    Mes = i,
                    SaldoAnterior = saldoAnterior,
                    Cuota = cuota,
                    Interes = interes,
                    Capital = capital,
                    Saldo = saldo,
                    MesesRestantes = meses - i,
                    TotalInteresesAcumulados = interesesAcumulados,
                    TasaMensual = tasaMensual,
                    TasaAnual = tasaAnual
                });
            }

            return tabla;
        }

        public static IEnumerable<AmortizacionItem> GenerarTablaAmortizacion(decimal monto, int meses)
        {
            decimal tasaAnual = ObtenerTasaAnual(meses);
            return GenerarTablaAmortizacion(monto, meses, tasaAnual);
        }

        public class PagoCalculado
        {
            public decimal MontoAnterior { get; set; }
            public decimal Cuota { get; set; }
            public decimal InteresAPagar { get; set; }
            public decimal CapitalPagado { get; set; }
            public decimal NuevoMontoAdeudado { get; set; }
            public int MesesRestantes { get; set; }
            public decimal TotalInteresesAcumulados { get; set; }
            public decimal TasaMensual { get; set; }
            public decimal TasaAnual { get; set; }
        }

        public static PagoCalculado CalcularPagoDelMes(
            decimal montoAnterior,
            int mesesRestantes,
            decimal interesesAcumuladosPrevios,
            decimal abonoExtra)
        {
            if (mesesRestantes <= 0)
                mesesRestantes = 1;

            decimal tasaAnual = ObtenerTasaAnual(mesesRestantes);
            decimal tasaMensual = CalcularTasaMensual(tasaAnual);
            decimal cuota = CalcularCuotaMensual(montoAnterior, tasaAnual, mesesRestantes);

            decimal interes = Math.Round(montoAnterior * tasaMensual, 2);
            decimal capital = Math.Round(cuota - interes, 2);

            if (abonoExtra > 0)
                capital += abonoExtra;

            decimal nuevoMonto = Math.Round(montoAnterior - capital, 2);

            return new PagoCalculado
            {
                MontoAnterior = montoAnterior,
                Cuota = cuota,
                InteresAPagar = interes,
                CapitalPagado = capital,
                NuevoMontoAdeudado = nuevoMonto < 0 ? 0 : nuevoMonto,
                MesesRestantes = Math.Max(mesesRestantes - 1, 0),
                TotalInteresesAcumulados = Math.Round(interesesAcumuladosPrevios + interes, 2),
                TasaMensual = tasaMensual,
                TasaAnual = tasaAnual
            };
        }
    }
}