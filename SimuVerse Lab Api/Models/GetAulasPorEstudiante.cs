using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetAulasPorEstudiante
    {
        public int IdAula { get; set; }
        public string NombreAula { get; set; }
        public string Profesor { get; set; }
    }
}
