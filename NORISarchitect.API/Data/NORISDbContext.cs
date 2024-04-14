using Microsoft.EntityFrameworkCore;
using NORISarchitect.API.Projects.Models;

namespace NORISarchitect.API.Data
{
    public class NORISDbContext : DbContext
    {
        public NORISDbContext(DbContextOptions<NORISDbContext> options) : base (options) { }
        
        public DbSet<Project> Projects { get; set; }

    }
}
