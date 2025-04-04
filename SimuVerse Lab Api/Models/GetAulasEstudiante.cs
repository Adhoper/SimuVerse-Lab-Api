using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetAulasEstudiante
    {
        public int IdAula { get; set; }
        public string NombreAula { get; set; }
    }
}
