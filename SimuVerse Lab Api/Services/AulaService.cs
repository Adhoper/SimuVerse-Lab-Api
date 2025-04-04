using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Services
{
    public class AulaService : IAulaService
    {
        private readonly SimuVerseLabContext _context;
        public AulaService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        public async Task<Response<GetAulasEstudiante>> GetAulasEstudiante(GetAulaEstudianteDTO model)
        {
            var result = new Response<GetAulasEstudiante>();
            try
            {
                result.DataList = _context.GetAulasEstudiante.FromSqlInterpolated($"dbo.GetAulasEstudiante {model.IdUsuario},{model.IdInstitucion},{model.IdRol}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
