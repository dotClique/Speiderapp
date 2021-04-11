using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpeiderappAPI.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Badge> BadgeList => Set<Badge>();
        public DbSet<User> Users => Set<User>();
        private IConfiguration Configuration { get; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedWith> TaggedWiths { get; set; }

        public DBContext(DbContextOptions options, IConfiguration configuration) : base(options)
            => Configuration = configuration;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasKey(c => new { c.Id, c.CategoryId });
            modelBuilder.Entity<TaggedWith>()
                .HasKey(c => new {c.BadgeId, c.TagId});
        }

    }
}
