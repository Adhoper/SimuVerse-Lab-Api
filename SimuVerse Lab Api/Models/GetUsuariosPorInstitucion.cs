using System.ComponentModel.DataAnnotations;

namespace SimuVerse_Lab_Api.Models
{
    public class GetUsuariosPorInstitucion
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreRol { get; set; } = string.Empty;
        public string NombreInstitucion { get; set; } = string.Empty;
    }
}
