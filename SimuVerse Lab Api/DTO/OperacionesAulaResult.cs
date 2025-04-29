using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.DTO
{
    [Keyless]
    public class OperacionesAulaResult
    {
        public int Succeded { get; set; }
        public string Message { get; set; }
    }
}
