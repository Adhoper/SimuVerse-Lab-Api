using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Services
{
    public class LaboratorioService:ILaboratorioService
    {
        private readonly SimuVerseLabContext _context;
        public LaboratorioService(SimuVerseLabContext context)
        {
            this._context = context;
        }
        public async Task<Response<GetLaboratorio>> GetLaboratorio()
        {
            var result = new Response<GetLaboratorio>();
            try
            {
                result.DataList = _context.GetLaboratorio.FromSqlInterpolated($"dbo.GetLaboratorios").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
