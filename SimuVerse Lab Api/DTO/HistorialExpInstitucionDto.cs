using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.DTO
{
    [Keyless]
    public class HistorialExpInstitucionDto
    {
        public int IdResultado { get; set; }
        public decimal Puntaje { get; set; }
        public decimal TiempoTotalSegundos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreExperimento { get; set; } = string.Empty;
        public string NombreLaboratorio { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public int IdRol { get; set; }
    }
}
