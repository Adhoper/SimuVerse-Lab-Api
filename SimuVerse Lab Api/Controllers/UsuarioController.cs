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

        //[HttpGet("get-all-usuario")]
        //public async Task<IActionResult> GetUsuario()
        //{
        //    return Ok(await _Service.GetUsuario());
        //}
    }
}
