using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;
using Newtonsoft.Json;

namespace SimuVerse_Lab_Api.Services
{
    public class AulaService : IAulaService
    {
        private readonly SimuVerseLabContext _context;
        public AulaService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        public async Task<Response<GetAulaAdministrativo>> GetAulaAdministrativo(int IdInstitucion)
        {
            var result = new Response<GetAulaAdministrativo>();
            try
            {
                result.DataList = _context.GetAulaAdministrativo.FromSqlInterpolated($"dbo.sp_GetAulasAdministrativo {IdInstitucion}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
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

        public async Task<Response<OperacionesAulaResult>> SetAula(SetAulaDTO model)
        {
   
            var result = new Response<OperacionesAulaResult>();
            try
            {

                var resp = _context.OperacionesAulaResult
                    .FromSqlInterpolated($"dbo.sp_CrearAula {model.NombreAula},{model.Capacidad},{model.IdInstitucion}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.Succeded == 1)
                {
                    result.Successful = true;
                    result.Message = result.SingleData.Message;
                }
                else
                {
                    result.Successful = false;
                    result.Message = result.SingleData.Message;
                }


            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "Fallo al insertar el aula";
                result.Successful = false;

            }

            return result;
        }

        public async Task<Response<OperacionesAulaResult>> UpdateAula(UpdateAulaDTO model)
        {
            var result = new Response<OperacionesAulaResult>();
            try
            {

                var resp = _context.OperacionesAulaResult
                    .FromSqlInterpolated(@$"dbo.sp_EditarAula {model.IdAula},{model.NombreAula},
        {model.Capacidad},{model.Estatus}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.Succeded == 1)
                {
                    result.Successful = true;
                    result.Message = result.SingleData.Message;
                }
                else
                {
                    result.Successful = false;
                    result.Message = result.SingleData.Message;
                }


            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "Fallo al actualizar el aula";
                result.Successful = false;

            }

            return result;
        }


        public async Task<Response<OperacionesAulaResult>> ChangeEstatusAula(int IdAula)
        {
            var result = new Response<OperacionesAulaResult>();
            try
            {

                var resp = _context.OperacionesAulaResult
                    .FromSqlInterpolated($"dbo.sp_CambiarEstatusAula {IdAula}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.Succeded == 1)
                {
                    result.Successful = true;
                    result.Message = result.SingleData.Message;
                }
                else
                {
                    result.Successful = false;
                    result.Message = result.SingleData.Message;
                }


            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "Fallo al inactivar el aula";
                result.Successful = false;

            }

            return result;
        }

        public async Task<Response<OperacionesAulaResult>> SetAsignarProfesorAula(AsignarUsuarioAulaDTO model)
        {
            var result = new Response<OperacionesAulaResult>();
            try
            {

                var resp = _context.OperacionesAulaResult
                    .FromSqlInterpolated($"dbo.sp_AsignarProfesorAula {model.IdAula},{model.IdUsuario}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.Succeded == 1)
                {
                    result.Successful = true;
                    result.Message = result.SingleData.Message;
                }
                else
                {
                    result.Successful = false;
                    result.Message = result.SingleData.Message;
                }


            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "Fallo al asignar el profesor al aula";
                result.Successful = false;

            }

            return result;
        }

        public async Task<Response<OperacionesAulaResult>> SetAsignarEstudianteAula(List<AsignarUsuarioAulaDTO> model)
        {
            var result = new Response<OperacionesAulaResult>();
            var errores = new List<string>();

            try
            {
                foreach (var estudiante in model)
                {
                    var resp = _context.OperacionesAulaResult
                        .FromSqlInterpolated($"dbo.sp_AsignarEstudiantesAula {estudiante.IdAula}, {estudiante.IdUsuario}")
                        .ToList();

                    var respuesta = resp.FirstOrDefault();

                    if (respuesta != null && respuesta.Succeded == 0)
                    {
                        errores.Add($"Error con estudiante ID {estudiante.IdUsuario}: {respuesta.Message}");
                    }
                }

                if (errores.Count == 0)
                {
                    result.Successful = true;
                    result.Message = "Todos los estudiantes fueron asignados correctamente.";
                }
                else
                {
                    result.Successful = false;
                    result.Message = "Algunos estudiantes no pudieron ser asignados.";
                    result.Errors = errores;
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Message = "Fallo general al asignar estudiantes al aula.";
                result.Successful = false;
            }

            return result;
        }

        public async Task<Response<GetAulasProfesores>> GetAulasProfesores(int IdUsuario)
        {
            var result = new Response<GetAulasProfesores>();

            try
            {
                var aulas = await _context.GetAulasProfesores
                    .FromSqlInterpolated($"dbo.sp_GetAulasProfesor {IdUsuario}")
                    .ToListAsync();

                foreach (var aula in aulas)
                {
                    if (!string.IsNullOrWhiteSpace(aula.Estudiantes))
                    {
                        aula.ListaEstudiantes = JsonConvert.DeserializeObject<List<EstudianteDto>>(aula.Estudiantes);
                    }
                    else
                    {
                        aula.ListaEstudiantes = new List<EstudianteDto>();
                    }
                }

                result.DataList = aulas;
                result.Successful = true;
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
                result.Successful = false;
            }

            return result;
        }

        public async Task<Response<GetAulasPorEstudiante>> GetAulasPorEstudiante(int IdUsuario)
        {
            var result = new Response<GetAulasPorEstudiante>();
            try
            {
                result.DataList = _context.GetAulasPorEstudiante.FromSqlInterpolated($"dbo.sp_GetAulasPorEstudiante {IdUsuario}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
