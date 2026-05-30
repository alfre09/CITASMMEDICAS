using System;

namespace SistemaCitas.Models
{
    public class Paciente : Persona
    {
        public DateTime FechaNacimiento { get; set; }

        public Paciente(string id, string nombre, string telefono, string email, DateTime fechaNacimiento)
            : base(id, nombre, telefono, email)
        {
            FechaNacimiento = fechaNacimiento;
        }
    }
}