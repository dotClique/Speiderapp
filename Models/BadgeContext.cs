using Microsoft.EntityFrameworkCore;

namespace SpeiderappAPI.Models
{
    public class BadgeContext : DbContext
    {
        public DbSet<Badge> BadgeList => Set<Badge>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("");
    }
}