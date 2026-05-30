using System;
using SistemaCitas.Models;

namespace SistemaCitas.Notificaciones
{
    public class NotificadorEmail : Interfaces.INotificador
    {
        public void Enviar(Cita cita)
        {
            Console.WriteLine($"[EMAIL] Recordatorio enviado a {cita.Paciente.Email}");
            Console.WriteLine($"  Cita con Dr. {cita.Medico.Nombre} el {cita.Fecha:dd/MM/yyyy HH:mm}");
        }

        public string Tipo() => "Email";
    }
}