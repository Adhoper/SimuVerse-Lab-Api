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

        [HttpPost("ValidarAutenticacion")]
        public async Task<IActionResult> ValidarAutenticacion([FromBody] UsuarioLoginDTO data)
        {
            var result = await _Service.ValidarAutenticacion(data);

            // Siempre devuelve 200 OK con el resultado, aunque sea error lógico (como contraseña incorrecta)
            return Ok(result);
        }


    }
}
