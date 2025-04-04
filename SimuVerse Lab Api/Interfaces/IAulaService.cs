using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IAulaService
    {
        Task<Response<GetAulasEstudiante>> GetAulasEstudiante(GetAulaEstudianteDTO model);
    }
}
