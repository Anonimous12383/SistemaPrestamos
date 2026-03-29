using SisemaPrestamo.Models;
using System.Collections.Generic;

namespace PrestamosApp.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal Sueldo { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}