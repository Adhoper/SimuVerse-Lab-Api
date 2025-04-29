using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetDashboardAdministrativo
    {
        public int CantidadAulas { get; set; }
        public int CantidadLaboratorios { get; set; }
        public int CantidadProfesores { get; set; }
        public int CantidadEstudiantes { get; set; }
    }
}
