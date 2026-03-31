using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamosApp.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal SueldoMensual { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public object Activo { get; internal set; }
        public object Sueldo { get; internal set; }
    }
}