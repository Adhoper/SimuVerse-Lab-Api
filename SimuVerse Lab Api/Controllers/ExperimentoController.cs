using ALQUILER_VIDEOJUEGOS_BACK.Models;
using Microsoft.AspNetCore.Mvc;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentoController : Controller
    {
        private readonly IExperimentoService _Service;
        public ExperimentoController(IExperimentoService Service)
        {
            this._Service = Service;
        }

        [HttpGet("get-experimentos/{IdLaboratorio}")]
        public async Task<IActionResult> GetExperimentos(int IdLaboratorio)
        {
            return Ok(await _Service.GetExperimentos(IdLaboratorio));
        }

        [HttpPost("set-resultado-experimento")]
        public async Task<IActionResult> SetResultadoExperimento(SetResultadoExperimento model)
        {
            return Ok(await _Service.SetResultadoExperimento(model));
        }

        [HttpGet("get-historial-experimento-personal/{IdUsuario}")]
        public async Task<IActionResult> HistorialExpPersonal(int IdUsuario)
        {
            return Ok(await _Service.HistorialExpPersonal(IdUsuario));
        }

        [HttpGet("get-historial-experimento-institucion/{IdInstitucion}")]
        public async Task<IActionResult> HistorialExpInstitucion(int IdInstitucion)
        {
            return Ok(await _Service.HistorialExpInstitucion(IdInstitucion));
        }

        [HttpGet("get-historial-experimento-profesor/{IdUsuario}")]
        public async Task<IActionResult> HistorialExpProfesor(int IdUsuario)
        {
            return Ok(await _Service.HistorialExpProfesor(IdUsuario));
        }
    }
}
