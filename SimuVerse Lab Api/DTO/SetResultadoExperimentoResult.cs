using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.DTO
{
    [Keyless]
    public class SetResultadoExperimentoResult
    {
        public string EstatusInsertar { get; set; }
        public string Result { get; set; }
    }
}
