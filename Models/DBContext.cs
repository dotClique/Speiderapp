using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpeiderappAPI.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Badge> BadgeList => Set<Badge>();
        private IConfiguration Configuration { get; }

        public DBContext(DbContextOptions options, IConfiguration configuration) : base(options)
            => Configuration = configuration;
    }
}
