using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetDashboardEstudiante
    {
        public string NombreAula { get; set; }
        public int CantidadLaboratorios { get; set; }
    }
}
