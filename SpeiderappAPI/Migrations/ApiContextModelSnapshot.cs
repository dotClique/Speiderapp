﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpeiderappAPI.Database;

namespace SpeiderappAPI.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SpeiderappAPI.Models.Category", b =>
                {
                    b.Property<long>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Requirement", b =>
                {
                    b.Property<long>("RequirementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AuthorID")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("RequirementID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Requirements");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Requirement");

                    b.HasData(
                        new
                        {
                            RequirementID = -2L,
                            AuthorID = -1L,
                            Description = "Actually chop wood",
                            PublishTime = new DateTime(2021, 10, 7, 19, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RequirementID = -5L,
                            AuthorID = -1L,
                            Description = "Stoff-handling",
                            PublishTime = new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RequirementID = -6L,
                            AuthorID = -3L,
                            Description = "Sytråd-shopping",
                            PublishTime = new DateTime(2021, 10, 7, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SpeiderappAPI.Models.RequirementPrerequisite", b =>
                {
                    b.Property<long>("RequirerID")
                        .HasColumnType("bigint");

                    b.Property<long>("RequireeID")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAdvisory")
                        .HasColumnType("boolean");

                    b.HasKey("RequirerID", "RequireeID");

                    b.HasIndex("RequireeID");

                    b.ToTable("RequirementPrerequisites");

                    b.HasData(
                        new
                        {
                            RequirerID = -1L,
                            RequireeID = -2L,
                            IsAdvisory = false
                        },
                        new
                        {
                            RequirerID = -4L,
                            RequireeID = -5L,
                            IsAdvisory = true
                        },
                        new
                        {
                            RequirerID = -4L,
                            RequireeID = -6L,
                            IsAdvisory = false
                        });
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Resource", b =>
                {
                    b.Property<long>("ResourceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RequirementID")
                        .HasColumnType("bigint");

                    b.HasKey("ResourceID");

                    b.HasIndex("RequirementID");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            ResourceID = -1L,
                            Description = "Oversikt over aktiviteter og merker i KMSpeideren",
                            Location = "https://kmspeider.no/aktivitetsbanken",
                            Name = "Aktivitetsbanken",
                            RequirementID = -1L
                        });
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Tag", b =>
                {
                    b.Property<long>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CategoryID")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.TaggedWith", b =>
                {
                    b.Property<long>("BadgeID")
                        .HasColumnType("bigint");

                    b.Property<long>("TagID")
                        .HasColumnType("bigint");

                    b.HasKey("BadgeID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("TaggedWiths");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = -1L,
                            Email = "ocrispe0@jugem.jp",
                            FirstName = "Ozzie",
                            LastName = "Crispe"
                        },
                        new
                        {
                            UserID = -2L,
                            Email = "adandye@hexun.com",
                            FirstName = "Aggi",
                            LastName = "Dandy"
                        },
                        new
                        {
                            UserID = -3L,
                            Email = "gspottiswood2@psu.com",
                            FirstName = "Gerry",
                            LastName = "Spottiswood"
                        });
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Badge", b =>
                {
                    b.HasBaseType("SpeiderappAPI.Models.Requirement");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Badge");

                    b.HasData(
                        new
                        {
                            RequirementID = -1L,
                            AuthorID = -1L,
                            Description = "This is a cool badge for chucking wood.",
                            PublishTime = new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "3aas!2d=",
                            Title = "Woodchuck"
                        },
                        new
                        {
                            RequirementID = -3L,
                            AuthorID = -2L,
                            Description = "Beskrivende test-tekst",
                            PublishTime = new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "http://placekitten.com/g/200/300",
                            Title = "Testing"
                        },
                        new
                        {
                            RequirementID = -4L,
                            AuthorID = -1L,
                            Description = "Hobby-baserte aktiviteter for alle aldre",
                            PublishTime = new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "http://placekitten.com/g/200/200",
                            Title = "Hobby"
                        });
                });

            modelBuilder.Entity("SpeiderappAPI.Models.MultipleChoice", b =>
                {
                    b.HasBaseType("SpeiderappAPI.Models.Requirement");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("MultipleChoice");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.UserDefined", b =>
                {
                    b.HasBaseType("SpeiderappAPI.Models.Requirement");

                    b.HasDiscriminator().HasValue("UserDefined");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Requirement", b =>
                {
                    b.HasOne("SpeiderappAPI.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.RequirementPrerequisite", b =>
                {
                    b.HasOne("SpeiderappAPI.Models.Requirement", "Requiree")
                        .WithMany("RequiredBy")
                        .HasForeignKey("RequireeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeiderappAPI.Models.Requirement", "Requirer")
                        .WithMany("Requiring")
                        .HasForeignKey("RequirerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requiree");

                    b.Navigation("Requirer");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Resource", b =>
                {
                    b.HasOne("SpeiderappAPI.Models.Requirement", "Requirement")
                        .WithMany("Resources")
                        .HasForeignKey("RequirementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Tag", b =>
                {
                    b.HasOne("SpeiderappAPI.Models.Category", "Category")
                        .WithMany("Tags")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.TaggedWith", b =>
                {
                    b.HasOne("SpeiderappAPI.Models.Badge", "Badge")
                        .WithMany("TaggedWiths")
                        .HasForeignKey("BadgeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpeiderappAPI.Models.Tag", "Tag")
                        .WithMany("TaggedWiths")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badge");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Category", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Requirement", b =>
                {
                    b.Navigation("RequiredBy");

                    b.Navigation("Requiring");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Tag", b =>
                {
                    b.Navigation("TaggedWiths");
                });

            modelBuilder.Entity("SpeiderappAPI.Models.Badge", b =>
                {
                    b.Navigation("TaggedWiths");
                });
#pragma warning restore 612, 618
        }
    }
}
