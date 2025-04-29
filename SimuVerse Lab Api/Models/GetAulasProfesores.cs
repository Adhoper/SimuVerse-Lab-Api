using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetAulasProfesores
    {
        public int IdAula { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Estatus { get; set; }
        public string Estudiantes { get; set; } // <-- aquí recibe directo el JSON
        [NotMapped]
        public List<EstudianteDto> ListaEstudiantes { get; set; } // este sí es el objeto deserializado
        public int CantidadEstudiantes { get; set; }
    }

    public class EstudianteDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Estatus { get; set; }
    }
}
