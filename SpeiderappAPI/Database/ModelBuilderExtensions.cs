using System;
using Microsoft.EntityFrameworkCore;
using SpeiderappAPI.Models;

namespace SpeiderappAPI.Database
{
    public static class ModelBuilderExtensions
    {
        // Inserts test data
        public static void Seed(this ModelBuilder modelBuilder)
        {
            User ozzie = new(-1L, "ocrispe0@jugem.jp", "Ozzie", "Crispe");
            modelBuilder.Entity<User>().HasData(
                ozzie,
                new User(-2L, "adandye@hexun.com", "Aggi", "Dandy"),
                new User(-3L, "gspottiswood2@psu.com", "Gerry", "Spottiswood")
            );

            Badge woodchuck = new("", "", "", DateTime.Now)
            {
                RequirementID = -1L,
                Title = "Woodchuck",
                Image = "3aas!2d=",
                Description = "This is a cool badge for chucking wood.",
                PublishTime = DateTime.Now,
                AuthorID = ozzie.UserID,
            };
            modelBuilder.Entity<Badge>().HasData(
                woodchuck,
                new Badge("Testing", "http://placekitten.com/g/200/300", "Beskrivende test-tekst", DateTime.Now) { RequirementID = -3L, AuthorID = -2L },
                new Badge("Hobby", "http://placekitten.com/g/200/200", "Hobby-baserte aktiviteter for alle aldre", DateTime.UtcNow.AddDays(-3)) { RequirementID = -4L, AuthorID = ozzie.UserID }
            );

            Requirement chopWood = new("", DateTime.Now)
            {
                RequirementID = -2L,
                Description = "Actually chop wood",
                PublishTime = DateTime.Now,
                AuthorID = ozzie.UserID
            };
            modelBuilder.Entity<Requirement>().HasData(
                chopWood,
                new Requirement("Stoff-handling", DateTime.Now.AddDays(-2)) { RequirementID = -5L, AuthorID = ozzie.UserID },
                new Requirement("Sytråd-shopping", DateTime.Now.AddHours(-15)) {RequirementID = -6L, AuthorID = -3L}
            );

            var prerequisite = new { RequirerID = woodchuck.RequirementID, RequireeID = chopWood.RequirementID, IsAdvisory = false };
            modelBuilder.Entity<RequirementPrerequisite>().HasData(
                prerequisite,
                new RequirementPrerequisite(true) { RequirerID = -4L, RequireeID = -5L },
                new RequirementPrerequisite(false) {RequirerID = -4L, RequireeID = -6L}
            );

            Resource aktivitetsbanken = new(-1L, "Aktivitetsbanken", "Oversikt over aktiviteter og merker i KMSpeideren", "https://kmspeider.no/aktivitetsbanken")
            {
                ResourceID = -1L,
                RequirementID = -1L
            };
            modelBuilder.Entity<Resource>().HasData(
                aktivitetsbanken
            );

        }
    }
}
