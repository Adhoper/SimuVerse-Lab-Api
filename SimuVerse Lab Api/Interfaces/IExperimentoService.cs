using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using ALQUILER_VIDEOJUEGOS_BACK.Models;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IExperimentoService
    {
        Task<Response<GetExperimentos>> GetExperimentos(int IdLaboratorio);
        Task<Response<SetResultadoExperimentoResult>> SetResultadoExperimento(SetResultadoExperimento model);
    }
}
