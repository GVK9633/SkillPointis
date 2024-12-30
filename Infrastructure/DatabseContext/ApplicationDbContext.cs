using Core.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> user { get; set; }
    }
}
