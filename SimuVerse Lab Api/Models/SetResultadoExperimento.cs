namespace SimuVerse_Lab_Api.Models
{
    public class SetResultadoExperimento
    {
        public int IdUsuario { get; set; }
        public int IdExperimento { get; set; }
        public int IdLaboratorio { get; set; }
        public int? IdAula { get; set; }
        public float Puntaje { get; set; }
        public float TiempoTotalSegundos { get; set; }
    }
}
