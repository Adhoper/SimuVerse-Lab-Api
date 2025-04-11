using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetExperimentos
    {
        public int IdExperimento { get; set; }
        public string NombreExperimento { get; set; }
        public string Descripcion { get; set; }
        public int IdLaboratorio { get; set; }
        public string Estatus { get; set; }
        public string ExperimentoScene { get; set; }
        public string Objetivo { get; set; }
    }
}
