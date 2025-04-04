using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : Controller
    {
        private readonly IAutenticacionService _Service;
        public AutenticacionController(IAutenticacionService Service)
        {
            this._Service = Service;
        }

        [HttpPost]
        [Route("ValidarAutenticacion")]
        public async Task<Response> ValidarAutenticacion([FromBody] UsuarioLoginDTO data)
        {
            return await _Service.ValidarAutenticacion(data);
        }
    }
}
