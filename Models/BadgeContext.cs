using Microsoft.EntityFrameworkCore;

namespace SpeiderappAPI.Models
{
    public class BadgeContext : DbContext
    {
        public BadgeContext(DbContextOptions<BadgeContext> options)
            : base(options)
        {
        }

        public DbSet<Badge> Badges { get; set; }
    }
}
