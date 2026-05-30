using System;

namespace SistemaCitas.Services
{
    public static class Validador
    {
        public static bool CamposVacios(params string[] campos)
        {
            foreach (var campo in campos)
                if (string.IsNullOrWhiteSpace(campo)) return true;
            return false;
        }

        public static bool FechaValida(DateTime fecha)
        {
            return fecha > DateTime.Now;
        }

        public static bool DisponibilidadValida(DateTime fecha, string medicoId,
            Interfaces.ICitaRepository repo)
        {
            var citas = repo.BuscarPorMedico(medicoId);
            foreach (var cita in citas)
            {
                if (cita.Estado != Models.EstadoCita.Cancelada &&
                    Math.Abs((cita.Fecha - fecha).TotalMinutes) < 30)
                    return false;
            }
            return true;
        }
    }
}