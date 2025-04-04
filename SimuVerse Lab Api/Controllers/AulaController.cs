using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : Controller
    {
        private readonly IAulaService _Service;
        public AulaController(IAulaService Service)
        {
            this._Service = Service;
        }

        [HttpPost("get-aulas-estudiante")]
        public async Task<IActionResult> GetAulasEstudiante(GetAulaEstudianteDTO model)
        {
            return Ok(await _Service.GetAulasEstudiante(model));
        }
    }
}
