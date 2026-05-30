namespace SistemaCitas.Models
{
    public abstract class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        protected Persona(string id, string nombre, string telefono, string email)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }
    }
}