using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SpeiderappAPI.Models;

namespace SpeiderappAPI.Database
{
    public class ApiContext : DbContext
    {
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<RequirementPrerequisite> RequirementPrerequisites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedWith> TaggedWiths { get; set; }
        public DbSet<Resource> Resources { get; set; }

        private IConfiguration _configuration { get; }

        public ApiContext(DbContextOptions options, IConfiguration configuration) : base(options)
            => _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaggedWith>().HasKey(tw => new { tw.BadgeID, tw.TagID });

            modelBuilder.Entity<RequirementPrerequisite>().HasKey(rp => new {rp.RequirerID, rp.RequireeID});

            modelBuilder.Entity<Requirement>()
                .HasMany(r => r.RequiredBy)
                .WithOne(rp => rp.Requiree);

            modelBuilder.Entity<Requirement>()
                .HasMany(r => r.Requiring)
                .WithOne(rp => rp.Requirer);

            modelBuilder.Entity<Requirement>()
                .HasDiscriminator(r => r.Discriminator);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Requirement)
                .WithMany(b => b.Resources);

            modelBuilder.Seed();
        }
    }
}
