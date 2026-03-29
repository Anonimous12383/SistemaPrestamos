using System;

namespace SisemaPrestamo.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public decimal Monto { get; set; }

        public decimal Interes { get; set; }

        public decimal MontoTotal { get; set; }

        public int Meses { get; set; }

        public DateTime Fecha { get; set; }
    }
}