using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Services
{
    public class ExperimentoService : IExperimentoService
    {
        private readonly SimuVerseLabContext _context;
        public ExperimentoService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        public async Task<Response<GetExperimentos>> GetExperimentos(int IdLaboratorio)
        {
            var result = new Response<GetExperimentos>();
            try
            {
                result.DataList = _context.GetExperimentos.FromSqlInterpolated($"dbo.GetExperimentos {IdLaboratorio}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<SetResultadoExperimentoResult>> SetResultadoExperimento(SetResultadoExperimento model)
        {

            var result = new Response<SetResultadoExperimentoResult>();
            try
            {

                var resp = _context.SetResultadoExperimentoResult
                    .FromSqlInterpolated(@$"dbo.SetResultadoExperimento {model.IdUsuario},
            {model.IdExperimento},{model.IdLaboratorio},{model.IdAula},{model.Puntaje},{model.TiempoTotalSegundos}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.EstatusInsertar == "CORRECTO")
                {
                    result.Message = result.SingleData.Result;
                    result.Successful = true;
                }
                else
                {
                    result.Message = result.SingleData.Result;
                    result.Successful = false;
                }

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "No se ha podido registrar el resultado del experimento";
                result.Successful = false;

            }

            return result;
        }

        public async Task<Response<HistorialExpInstitucionDto>> HistorialExpInstitucion(int IdInstitucion)
        {
            var result = new Response<HistorialExpInstitucionDto>();
            try
            {
                result.DataList = _context.HistorialExpInstitucionDto.FromSqlInterpolated($"dbo.sp_ObtenerHistorialExpPorInstitucion {IdInstitucion}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<HistorialExpPersonalDto>> HistorialExpPersonal(int IdUsuario)
        {
            var result = new Response<HistorialExpPersonalDto>();
            try
            {
                result.DataList = _context.HistorialExpPersonalDto.FromSqlInterpolated($"dbo.sp_ObtenerHistorialExpPersonal {IdUsuario}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<HistorialExpProfesorDto>> HistorialExpProfesor(int IdUsuario)
        {
            var result = new Response<HistorialExpProfesorDto>();
            try
            {
                result.DataList = _context.HistorialExpProfesorDto.FromSqlInterpolated($"dbo.sp_ObtenerHistorialExpPorProfesor {IdUsuario}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
