using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpeiderappAPI.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Badge> BadgeList => Set<Badge>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedWith> TaggedWiths { get; set; }

        private IConfiguration Configuration { get; }

        public DBContext(DbContextOptions options, IConfiguration configuration) : base(options)
            => Configuration = configuration;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaggedWith>()
                .HasKey(c => new { c.BadgeId, c.TagId });
        }
    }
}
