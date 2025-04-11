using ALQUILER_VIDEOJUEGOS_BACK.DTO;
using Microsoft.EntityFrameworkCore;
using SimuVerse_Lab_Api.DTO;
using SimuVerse_Lab_Api.Models;

namespace SimuVerse_Lab_Api.Context
{
    public class SimuVerseLabContext:DbContext
    {
        public SimuVerseLabContext(DbContextOptions options) :base (options)
        {
            
        }

        public DbSet<LoginUsuarioInfo> LoginUsuario { get; set; }
        public DbSet<SetUserResult> SetUserResult { get; set; }
        public DbSet<GetLaboratorio> GetLaboratorio { get; set; }
        public DbSet<GetAulasEstudiante> GetAulasEstudiante { get; set; }
        public DbSet<GetExperimentos> GetExperimentos { get; set; }
        public DbSet<SetResultadoExperimentoResult> SetResultadoExperimentoResult { get; set; }
    }
}
