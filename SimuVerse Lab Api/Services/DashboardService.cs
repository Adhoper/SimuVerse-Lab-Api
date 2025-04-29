using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly SimuVerseLabContext _context;
        public DashboardService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        public async Task<Response<GetDashboardAdministrativo>> GetDashboardAdministrativo(int IdInstitucion)
        {
            var result = new Response<GetDashboardAdministrativo>();
            try
            {
                var data = _context.GetDashboardAdministrativo.FromSqlInterpolated($"dbo.sp_GetDashboardAdministrativo {IdInstitucion}").ToList();
                result.SingleData = data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<GetDashboardEstudiante>> GetDashboardEstudiante(int IdUsuario)
        {
            var result = new Response<GetDashboardEstudiante>();
            try
            {
                result.DataList = _context.GetDashboardEstudiante.FromSqlInterpolated($"dbo.sp_GetDashboardEstudiante {IdUsuario}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<GetDashboardProfesor>> GetDashboardProfesor(int IdUsuario)
        {
            var result = new Response<GetDashboardProfesor>();
            try
            {
                result.DataList = _context.GetDashboardProfesor.FromSqlInterpolated($"dbo.sp_GetDashboardProfesor {IdUsuario}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
