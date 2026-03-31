using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamosApp.Entidades
{
    [Table("Prestamos")]
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public int ClienteId { get; set; }
        public decimal Capital { get; set; }
        public int PlazoMeses { get; set; }
        public decimal TasaAnual { get; set; }
        public decimal Cuota { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; }
        public decimal SaldoPendiente { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}