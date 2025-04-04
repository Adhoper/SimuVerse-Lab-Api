using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Models
{
    [Keyless]
    public class GetLaboratorio
    {
        public int IdLaboratorio { get; set; }
        public string NombreLaboratorio { get; set; }
        public string Estatus { get; set; }

    }
}
