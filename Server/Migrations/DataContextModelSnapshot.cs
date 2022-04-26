﻿// <auto-generated />
using System;
using GamificationApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamificationApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamificationApp.Shared.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("A")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoodAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TestID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GoodAnswers")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfQuestions")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.Property<int>("TestTimeInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestID");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Question", b =>
                {
                    b.HasOne("GamificationApp.Shared.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamificationApp.Shared.Models.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Score", b =>
                {
                    b.HasOne("GamificationApp.Shared.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamificationApp.Shared.Models.User", null)
                        .WithMany("Scores")
                        .HasForeignKey("UserId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Subject", b =>
                {
                    b.HasOne("GamificationApp.Shared.Models.User", "RelatedTeacher")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedTeacher");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Test", b =>
                {
                    b.HasOne("GamificationApp.Shared.Models.Subject", null)
                        .WithMany("RelatedTests")
                        .HasForeignKey("TestID");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Subject", b =>
                {
                    b.Navigation("RelatedTests");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("GamificationApp.Shared.Models.User", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
