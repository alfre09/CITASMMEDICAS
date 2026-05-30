using System;
using SistemaCitas.Models;
using SistemaCitas.Repositories;
using SistemaCitas.Services;
using SistemaCitas.Notificaciones;

namespace SistemaCitas
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CitaRepositoryMemoria();
            var notificador = new NotificadorEmail();
            var servicio = new ServicioCitas(repo, notificador);

            var especialidad = new Especialidad("E01", "Cardiología", "Enfermedades del corazón");
            var medico = new Medico("M01", "Carlos Pérez", "809-111-1111",
                                          "cperez@clinica.com", "MAT-001", especialidad);
            var paciente = new Paciente("P01", "Alfre Acosta", "809-222-2222",
                                          "alfre@mail.com", new DateTime(1995, 5, 15));

            Console.WriteLine("=== Sistema de Gestión de Citas Médicas ===\n");

            var fechaCita = DateTime.Now.AddDays(3);
            var cita = servicio.Agendar(paciente, medico, fechaCita);
            Console.WriteLine($"\nCita agendada: {cita.Id}");
            Console.WriteLine($"Estado: {cita.Estado}\n");

            var citas = servicio.ConsultarPorPaciente("P01");
            Console.WriteLine($"Citas del paciente {paciente.Nombre}: {citas.Count}");

            servicio.Cancelar(cita.Id);
            Console.WriteLine($"\nCita cancelada. Estado: {cita.Estado}");

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}