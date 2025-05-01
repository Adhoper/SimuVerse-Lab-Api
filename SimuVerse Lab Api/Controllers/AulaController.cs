using ALQUILER_VIDEOJUEGOS_BACK.Models;
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

        [HttpGet("get-all-aulas/{IdInstitucion}")]
        public async Task<IActionResult> GetAulaAdministrativo(int IdInstitucion)
        {
            return Ok(await _Service.GetAulaAdministrativo(IdInstitucion));
        }

        [HttpPost("get-aulas-estudiante")]
        public async Task<IActionResult> GetAulasEstudiante(GetAulaEstudianteDTO model)
        {
            return Ok(await _Service.GetAulasEstudiante(model));
        }

        [HttpPost("set-aula")]
        public async Task<IActionResult> SetAula(SetAulaDTO model)
        {
            return Ok(await _Service.SetAula(model));
        }

        [HttpPost("update-aula")]
        public async Task<IActionResult> UpdateAula(UpdateAulaDTO model)
        {
            return Ok(await _Service.UpdateAula(model));
        }

        [HttpPost("change-estatus-aula/{IdAula}")]
        public async Task<IActionResult> ChangeEstatusAula(int IdAula)
        {
            return Ok(await _Service.ChangeEstatusAula(IdAula));
        }

        [HttpPost("asignar-profesor-aula")]
        public async Task<IActionResult> SetAsignarProfesorAula(AsignarUsuarioAulaDTO model)
        {
            return Ok(await _Service.SetAsignarProfesorAula(model));
        }

        [HttpPost("asignar-estudiantes-aula")]
        public async Task<IActionResult> SetAsignarEstudianteAula(List<AsignarUsuarioAulaDTO> model)
        {
            return Ok(await _Service.SetAsignarEstudianteAula(model));
        }

        [HttpGet("get-aula-profesores/{IdUsuario}")]
        public async Task<IActionResult> GetAulasProfesores(int IdUsuario)
        {
            return Ok(await _Service.GetAulasProfesores(IdUsuario));
        }

        [HttpGet("get-aulas-por-estudiantes/{IdUsuario}")]
        public async Task<IActionResult> GetAulasPorEstudiante(int IdUsuario)
        {
            return Ok(await _Service.GetAulasPorEstudiante(IdUsuario));
        }
    }
}
