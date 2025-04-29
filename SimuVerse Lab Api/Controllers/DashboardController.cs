using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _Service;
        public DashboardController(IDashboardService Service)
        {
            this._Service = Service;
        }

        [HttpGet("get-dashboard-administrativo/{IdInstitucion}")]
        public async Task<IActionResult> GetDashboardAdministrativo(int IdInstitucion)
        {
            return Ok(await _Service.GetDashboardAdministrativo(IdInstitucion));
        }

        [HttpGet("get-dashboard-profesor/{IdUsuario}")]
        public async Task<IActionResult> GetDashboardProfesor(int IdUsuario)
        {
            return Ok(await _Service.GetDashboardProfesor(IdUsuario));
        }

        [HttpGet("get-dashboard-estudiante/{IdUsuario}")]
        public async Task<IActionResult> GetDashboardEstudiante(int IdUsuario)
        {
            return Ok(await _Service.GetDashboardEstudiante(IdUsuario));
        }
    }
}
