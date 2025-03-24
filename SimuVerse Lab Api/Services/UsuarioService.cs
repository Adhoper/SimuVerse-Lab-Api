using Azure;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;

namespace SimuVerse_Lab_Api.Services
{
    public class UsuarioService:IUsuarioService
    {
        private readonly SimuVerseLabContext _context;
        public UsuarioService(SimuVerseLabContext context)
        {
            this._context = context;
        }

        //public async Task<Response<GetUsuarioDTO>> GetUsuario()
        //{
        //    var result = new Response<GetUsuarioDTO>();
        //    try
        //    {
        //        result.DataList = _context.GetUsuarioDTO.FromSqlInterpolated($"dbo.GetUsuario").ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Errors.Add(ex.Message);
        //    }

        //    return result;
        //}

        //public async Task<Response<SetUserResult>> SetUsuario(SetUsuario model)
        //{
        //    //var result = new Response();
        //    var result = new Response<SetUserResult>();
        //    var passHash = Utilidades.HashPassword(model.Contrasena);
        //    try
        //    {

        //        var resp = _context.SetUserResult
        //            .FromSqlInterpolated($"dbo.SetUsuario {model.Usuario},{model.Nombre},{model.Apellido},{model.Correo},{passHash},{model.Direccion},{model.Telefono}").ToList();

        //        result.SingleData = resp.FirstOrDefault();

        //        if (result.SingleData.EstatusRegistro == "CORRECTO")
        //        {
        //            result.Message = result.SingleData.Result;
        //            result.Successful = true;
        //        }
        //        else
        //        {
        //            result.Message = result.SingleData.Result;
        //            result.Successful = false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Errors.Add(ex.Message);
        //        result.Message = "No se ha podido registrar sus datos";
        //        result.Successful = false;

        //    }

        //    return result;
        //}
    }
}
