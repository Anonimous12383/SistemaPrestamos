using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrestamosApp.Entidades
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public decimal MontoPrestado { get; set; }
        public decimal TasaInteresAnual { get; set; }
        public int Meses { get; set; }
        public decimal InteresGenerado { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal CuotaMensual { get; set; }
        public decimal SaldoPendiente { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string Estado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}