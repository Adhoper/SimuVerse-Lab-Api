using ALQUILER_VIDEOJUEGOS_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _Service;
        public UsuarioController(IUsuarioService Service)
        {
            this._Service = Service;
        }

        [HttpGet("get-all-profesor")]
        public async Task<IActionResult> GetAllProfesores()
        {
            return Ok(await _Service.GetAllProfesores());
        }

        [HttpGet("get-all-estudiantes")]
        public async Task<IActionResult> GetAllEstudiantes()
        {
            return Ok(await _Service.GetAllEstudiantes());
        }

        [HttpGet("get-usuarios-institucion/{IdInstitucion}")]
        public async Task<IActionResult> GetUsuariosPorInstitucion(int IdInstitucion)
        {
            return Ok(await _Service.GetUsuariosPorInstitucion(IdInstitucion));
        }

        [HttpPost("set-usuario")]
        public async Task<IActionResult> SetUsuario(SetUsuario model)
        {
            return Ok(await _Service.SetUsuario(model));
        }

    }
}
