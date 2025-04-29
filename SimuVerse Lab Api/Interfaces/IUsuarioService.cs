using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using ALQUILER_VIDEOJUEGOS_BACK.Models;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IUsuarioService
    {
        Task<Response<GetAllUsuarios>> GetAllProfesores();
        Task<Response<GetAllUsuarios>> GetAllEstudiantes();
        Task<Response<SetUserResult>> SetUsuario(SetUsuario setUsuario);
        Task<Response<GetUsuariosPorInstitucion>> GetUsuariosPorInstitucion(int IdInstitucion);
    }
}
