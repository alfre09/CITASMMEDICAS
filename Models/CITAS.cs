using System;

namespace SistemaCitas.Models
{
    public enum EstadoCita
    {
        Programada,
        Cancelada,
        Reprogramada,
        Completada
    }

    public class Cita
    {
        public string Id { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoCita Estado { get; set; }

        public Cita(string id, Paciente paciente, Medico medico, DateTime fecha)
        {
            Id = id;
            Paciente = paciente;
            Medico = medico;
            Fecha = fecha;
            Estado = EstadoCita.Programada;
        }

        public void Cancelar()
        {
            Estado = EstadoCita.Cancelada;
        }

        public void Reprogramar(DateTime nuevaFecha)
        {
            Fecha = nuevaFecha;
            Estado = EstadoCita.Reprogramada;
        }
    }
}