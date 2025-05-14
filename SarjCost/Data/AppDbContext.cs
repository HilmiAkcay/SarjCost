using Microsoft.EntityFrameworkCore;
using SarjCost.Data.Entity;

namespace SarjCost.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExternalLogin> ExternalLogins { get; set; }

    }
}
