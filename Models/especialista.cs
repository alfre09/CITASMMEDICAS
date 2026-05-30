namespace SistemaCitas.Models
{
    public class Especialidad
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Especialidad(string id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}