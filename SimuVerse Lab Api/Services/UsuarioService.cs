using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using ALQUILER_VIDEOJUEGOS_BACK.Models;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SimuVerseLabContext _context;
        public UsuarioService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        public async Task<Response<GetUsuariosPorInstitucion>> GetUsuariosPorInstitucion(int IdInstitucion)
        {
            var result = new Response<GetUsuariosPorInstitucion>();
            try
            {
                result.DataList = _context.GetUsuariosPorInstitucion.FromSqlInterpolated($"dbo.get_usuarios_por_institucion {IdInstitucion}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<GetAllUsuarios>> GetAllProfesores(int IdInstitucion)
        {
            var result = new Response<GetAllUsuarios>();
            try
            {
                result.DataList = _context.GetAllProfesores.FromSqlInterpolated($"dbo.sp_GetAllProfesores {IdInstitucion}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<GetAllUsuarios>> GetAllEstudiantes(int IdInstitucion)
        {
            var result = new Response<GetAllUsuarios>();
            try
            {
                result.DataList = _context.GetAllProfesores.FromSqlInterpolated($"dbo.sp_GetEstudiantes {IdInstitucion}").ToList();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response<SetUserResult>> SetUsuario(SetUsuario model)
        {
            //var result = new Response();
            var result = new Response<SetUserResult>();
            var passHash = Utilidades.HashPassword(model.Contrasena);
            try
            {

                var resp = _context.SetUserResult
                    .FromSqlInterpolated($"dbo.SetUsuario {model.Nombre},{model.Apellido},{model.Correo},{passHash},{model.IdRol},{model.IdInstitucion}").ToList();

                result.SingleData = resp.FirstOrDefault();

                if (result.SingleData.EstatusRegistro == "CORRECTO")
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
                result.Message = "No se ha podido registrar sus datos";
                result.Successful = false;

            }

            return result;
        }
    }
}
