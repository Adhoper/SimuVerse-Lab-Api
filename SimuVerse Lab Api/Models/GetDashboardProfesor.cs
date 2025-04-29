using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetDashboardProfesor
    {
        public string NombreAula { get; set; }
        public int CantidadEstudiantes { get; set; }
        public int CantidadLaboratorios { get; set; }
    }
}
