using System.Collections.Generic;
using System.Linq;
using SistemaCitas.Models;

namespace SistemaCitas.Repositories
{
    public class CitaRepositoryMemoria : Interfaces.ICitaRepository
    {
        private readonly List<Cita> _citas = new List<Cita>();

        public void Guardar(Cita cita)
        {
            var existente = _citas.FirstOrDefault(c => c.Id == cita.Id);
            if (existente != null)
                _citas.Remove(existente);
            _citas.Add(cita);
        }

        public List<Cita> BuscarPorPaciente(string pacienteId) =>
            _citas.Where(c => c.Paciente.Id == pacienteId).ToList();

        public List<Cita> BuscarPorMedico(string medicoId) =>
            _citas.Where(c => c.Medico.Id == medicoId).ToList();

        public Cita BuscarPorId(string id) =>
            _citas.FirstOrDefault(c => c.Id == id);
    }
}