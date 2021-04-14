using Microsoft.EntityFrameworkCore;

namespace SpeiderappAPI.Models
{
    public static class ModelBuilderExtensions
    {
        // Inserts test data
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User(1, "ocrispe0@jugem.jp", "Ozzie", "Crispe"),
                new User(2, "adandye@hexun.com", "Aggi", "Dandy"),
                new User(3, "gspottiswood2@psu.com", "Gerry", "Spottiswood")
            );
        }
    }
}
