using System;

namespace PrestamosApp.Entidades
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int PrestamoId { get; set; }
        public int NumeroCuota { get; set; }
        public DateTime? FechaPago { get; set; }
        public decimal MontoAnterior { get; set; }
        public decimal InteresPagado { get; set; }
        public decimal CapitalPagado { get; set; }
        public decimal Cuota { get; set; }
        public decimal Mora { get; set; }
        public decimal NuevoMontoDeuda { get; set; }
        public int MesesRestantes { get; set; }
        public decimal TotalInteresesAcumulados { get; set; }
        public decimal TasaPrestamo { get; set; }
        public bool FuePagado { get; set; }

        public virtual Prestamo Prestamo { get; set; }
    }
}