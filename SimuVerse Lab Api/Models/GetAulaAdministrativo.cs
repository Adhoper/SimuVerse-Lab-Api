using System.ComponentModel.DataAnnotations;

namespace SimuVerse_Lab_Api.Models
{
    public class GetAulaAdministrativo
    {
        [Key]
        public int IdAula { get; set; }
        public string Nombre { get; set; }
        public string? Profesor { get; set; }
        public int Capacidad { get; set; }
        public int CantidadEstudiantes { get; set; }
        public string Estatus { get; set; }
    }
}
