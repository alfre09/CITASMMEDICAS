using System.Collections.Generic;
using SistemaCitas.Models;

namespace SistemaCitas.Interfaces
{
    public interface ICitaRepository
    {
        void Guardar(Cita cita);
        List<Cita> BuscarPorPaciente(string pacienteId);
        List<Cita> BuscarPorMedico(string medicoId);
        Cita BuscarPorId(string id);
    }
}