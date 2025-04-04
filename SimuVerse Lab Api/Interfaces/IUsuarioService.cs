using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using ALQUILER_VIDEOJUEGOS_BACK.Models;

namespace SimuVerse_Lab_Api.Interfaces
{
    public interface IUsuarioService
    {
        //Task<Response<GetUsuarioDTO>> GetUsuario();
        Task<Response<SetUserResult>> SetUsuario(SetUsuario setUsuario);
        //Task<Response> UpdateUsuario(UpdateUsuario updateUsuario);
    }
}
