namespace SistemaCitas.Interfaces
{
    public interface INotificador
    {
        void Enviar(Models.Cita cita);
        string Tipo();
    }
}