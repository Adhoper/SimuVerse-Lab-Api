using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface ILaboratorioService
    {
        Task<Response<GetLaboratorio>> GetLaboratorio();
    }
}
