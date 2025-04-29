using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.DTO
{
    [Keyless]
    public class UpdateAulaDTO
    {
        public int IdAula { get; set; }
        public string NombreAula { get; set; }
        public int Capacidad { get; set; }
        public string Estatus { get; set; }
    }
}
