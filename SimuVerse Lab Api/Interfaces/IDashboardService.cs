using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IDashboardService
    {
        Task<Response<GetDashboardAdministrativo>> GetDashboardAdministrativo(int IdInstitucion);
        Task<Response<GetDashboardEstudiante>> GetDashboardEstudiante(int IdUsuario);
        Task<Response<GetDashboardProfesor>> GetDashboardProfesor(int IdUsuario);
    }
}
