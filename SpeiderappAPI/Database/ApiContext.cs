using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SpeiderappAPI.Models;

namespace SpeiderappAPI.Database
{
    public class ApiContext : DbContext
    {
        public DbSet<Badge> Badges { get; set; } = null!;
        public DbSet<MultipleChoice> MultipleChoices { get; set; } = null!;
        public DbSet<UserDefined> UserDefineds { get; set; } = null!;
        public DbSet<Requirement> Requirements { get; set; } = null!;
        public DbSet<RequirementPrerequisite> RequirementPrerequisites { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TaggedWith> TaggedWiths { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;

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
