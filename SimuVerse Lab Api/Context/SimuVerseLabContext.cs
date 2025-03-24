using Microsoft.EntityFrameworkCore;

namespace SimuVerse_Lab_Api.Context
{
    public class SimuVerseLabContext:DbContext
    {
        public SimuVerseLabContext(DbContextOptions options) :base (options)
        {
            
        }
    }
}
