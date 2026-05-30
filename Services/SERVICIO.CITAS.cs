using System;
using System.Collections.Generic;
using SistemaCitas.Models;
using SistemaCitas.Interfaces;

namespace SistemaCitas.Services
{
    public class ServicioCitas
    {
        private readonly ICitaRepository _repo;
        private readonly INotificador _notificador;

        public ServicioCitas(ICitaRepository repo, INotificador notificador)
        {
            _repo = repo;
            _notificador = notificador;
        }

        public Cita Agendar(Paciente paciente, Medico medico, DateTime fecha)
        {
            if (Validador.CamposVacios(paciente.Nombre, medico.Nombre))
                throw new ArgumentException("Datos del paciente o médico incompletos.");

            if (!Validador.FechaValida(fecha))
                throw new ArgumentException("La fecha debe ser futura.");

            if (!Validador.DisponibilidadValida(fecha, medico.Id, _repo))
                throw new InvalidOperationException("El médico no está disponible en ese horario.");

            var cita = new Cita(Guid.NewGuid().ToString(), paciente, medico, fecha);
            _repo.Guardar(cita);
            _notificador.Enviar(cita);
            return cita;
        }

        public void Cancelar(string citaId)
        {
            var cita = _repo.BuscarPorId(citaId);
            if (cita == null) throw new ArgumentException("Cita no encontrada.");
            cita.Cancelar();
            _repo.Guardar(cita);
        }

        public Cita Reprogramar(string citaId, DateTime nuevaFecha)
        {
            if (!Validador.FechaValida(nuevaFecha))
                throw new ArgumentException("La nueva fecha debe ser futura.");

            var cita = _repo.BuscarPorId(citaId);
            if (cita == null) throw new ArgumentException("Cita no encontrada.");

            if (!Validador.DisponibilidadValida(nuevaFecha, cita.Medico.Id, _repo))
                throw new InvalidOperationException("El médico no está disponible en ese horario.");

            cita.Reprogramar(nuevaFecha);
            _repo.Guardar(cita);
            _notificador.Enviar(cita);
            return cita;
        }

        public List<Cita> ConsultarPorPaciente(string pacienteId) =>
            _repo.BuscarPorPaciente(pacienteId);

        public List<Cita> ConsultarPorMedico(string medicoId) =>
            _repo.BuscarPorMedico(medicoId);
    }
}