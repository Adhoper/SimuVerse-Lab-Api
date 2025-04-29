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
        public DbSet<HistorialExpInstitucionDto> HistorialExpInstitucionDto { get; set; }
        public DbSet<HistorialExpPersonalDto> HistorialExpPersonalDto { get; set; }
        public DbSet<HistorialExpProfesorDto> HistorialExpProfesorDto { get; set; }
        public DbSet<GetUsuariosPorInstitucion> GetUsuariosPorInstitucion { get; set; }
        public DbSet<GetDashboardAdministrativo> GetDashboardAdministrativo { get; set; }
        public DbSet<GetDashboardEstudiante> GetDashboardEstudiante { get; set; }
        public DbSet<GetDashboardProfesor> GetDashboardProfesor { get; set; }
        public DbSet<GetAulaAdministrativo> GetAulaAdministrativo { get; set; }
        public DbSet<OperacionesAulaResult> OperacionesAulaResult { get; set; }
        public DbSet<GetAllUsuarios> GetAllProfesores { get; set; }
        public DbSet<GetAulasProfesores> GetAulasProfesores { get; set; }
        public DbSet<GetAulasPorEstudiante> GetAulasPorEstudiante { get; set; }

    }
}
