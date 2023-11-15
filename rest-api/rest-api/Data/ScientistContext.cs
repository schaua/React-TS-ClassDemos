using Microsoft.EntityFrameworkCore;
using rest_api.Models;

namespace ScientistAPI.Data
{
    public class ScientistContext : DbContext
    {
        public ScientistContext(DbContextOptions<ScientistContext> options) : base(options)
        {
        }

        public DbSet<Scientist> Scientists { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
