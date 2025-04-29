using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimuVerse_Lab_Api.Context;
using SimuVerse_Lab_Api.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimuVerse_Lab_Api.Services
{
    public class AutenticacionService:IAutenticacionService
    {
        private readonly SimuVerseLabContext _context;
        private readonly string secretKey;
        public AutenticacionService(IConfiguration configuracion,SimuVerseLabContext context)
        {
            this._context = context;
            secretKey = configuracion.GetSection("settings").GetSection("secretkey").ToString();
        }

        public async Task<Response<LoginUsuarioInfo>> LoginUsuario(string identificadorUsuario)
        {
            var result = new Response<LoginUsuarioInfo>();
            try
            {

                var usuariologin = _context.LoginUsuario.FromSqlInterpolated($"dbo.LoginUsuarioInfo {identificadorUsuario}").ToList();
                result.SingleData = usuariologin.FirstOrDefault();

            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<Response> ValidarAutenticacion([FromBody] UsuarioLoginDTO data)
        {
            var result = new Response<LoginUsuarioInfo>();
            var token = new Response<TokenGot>();
            //data.IdentificadorUsuario = data.IdentificadorUsuario.ToLower();
            try
            {
                result = await LoginUsuario(data.IdentificadorUsuario);
                var passHash = Utilidades.HashPassword(data.Contrasena);

                if (result.SingleData != null)
                {
                    if ((data.IdentificadorUsuario.ToLower() == result.SingleData.Correo) && passHash.SequenceEqual(result.SingleData.Contrasena))
                    {
                        token.Message = "Inicio de Sesión Correcto";
                        var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                        var claims = new ClaimsIdentity();

                        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, data.IdentificadorUsuario));
                        claims.AddClaim(new Claim("Scope", result.SingleData.NombreRol));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = claims,
                            Expires = DateTime.UtcNow.AddHours(3),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                        string tokencreado = tokenHandler.WriteToken(tokenConfig);

                        token.SingleData = new TokenGot
                        {
                            IdUsuario = result.SingleData.IdUsuario
                            ,
                            Correo = result.SingleData.Correo
                                                        ,
                            Nombre = result.SingleData.Nombre
                            ,
                            Apellido = result.SingleData.Apellido
                            ,
                            IdRol = result.SingleData.IdRol
                            ,
                            NombreRol = result.SingleData.NombreRol
                            ,
                            IdInstitucion = result.SingleData.IdInstitucion
                            ,
                            NombreInstitucion = result.SingleData.NombreInstitucion
                            ,
                            Token = tokencreado
                        };

                        token.Successful = true;

                        return token;
                    }
                    else
                    {
                        token.Message = "Su contraseña es incorrecta.";
                        token.SingleData = new TokenGot { Token = "" };

                        token.Successful = false;

                        return token;
                    }

                }
                else
                {
                    if (result.Errors.Any())
                    {
                        token.Successful = false;
                        token.Message = result.Errors[0];
                    }
                    else
                    {
                        token.Successful = false;
                        token.Message = "El correo ingresado no existe";
                    }

                }

            }
            catch (Exception ex)
            {
                token.Errors.Add(ex.Message);
            }

            return token;
        }
    }
}
