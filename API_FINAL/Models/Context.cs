using Microsoft.EntityFrameworkCore;

namespace API_FINAL.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { 

        }

      public  DbSet<Login> Login { get; set; }

      public  DbSet<Registration> Registration { get; set; }
    }
}
