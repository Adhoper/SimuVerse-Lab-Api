using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetAllUsuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Estatus { get; set; }
    }
}
