namespace SistemaCitas.Models
{
    public class Medico : Persona
    {
        public string Matricula { get; set; }
        public Especialidad Especialidad { get; set; }

        public Medico(string id, string nombre, string telefono, string email, string matricula, Especialidad especialidad)
            : base(id, nombre, telefono, email)
        {
            Matricula = matricula;
            Especialidad = especialidad;
        }
    }
}