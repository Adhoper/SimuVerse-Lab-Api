using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using ALQUILER_VIDEOJUEGOS_BACK.Models;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IAulaService
    {
        Task<Response<GetAulasEstudiante>> GetAulasEstudiante(GetAulaEstudianteDTO model);
        Task<Response<GetAulaAdministrativo>> GetAulaAdministrativo(int IdInstitucion);
        Task<Response<OperacionesAulaResult>> SetAula(SetAulaDTO model);
        Task<Response<OperacionesAulaResult>> UpdateAula(UpdateAulaDTO model);
        Task<Response<OperacionesAulaResult>> ChangeEstatusAula(int IdAula);
        Task<Response<GetAulasProfesores>> GetAulasProfesores(int IdUsuario);
        Task<Response<OperacionesAulaResult>> SetAsignarProfesorAula(AsignarUsuarioAulaDTO model);
        Task<Response<OperacionesAulaResult>> SetAsignarEstudianteAula(List<AsignarUsuarioAulaDTO> model);
        Task<Response<GetAulasPorEstudiante>> GetAulasPorEstudiante(int IdUsuario);
    }
}
