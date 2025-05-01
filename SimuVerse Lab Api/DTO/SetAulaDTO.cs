using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.DTO
{
    [Keyless]
    public class SetAulaDTO
    {
        public string NombreAula { get; set; }
        public int Capacidad { get; set; }
        public int IdInstitucion { get; set; }
    }
}
