using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorioController : Controller
    {
        private readonly ILaboratorioService _Service;
        public LaboratorioController(ILaboratorioService Service)
        {
            this._Service = Service;
        }

        [HttpGet("get-all-laboratorios")]
        public async Task<IActionResult> GetLaboratorios()
        {
            return Ok(await _Service.GetLaboratorio());
        }
    }
}
