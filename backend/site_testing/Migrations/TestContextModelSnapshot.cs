﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using site_testing.Model;

#nullable disable

namespace site_testing.Migrations
{
    [DbContext(typeof(TestContext))]
    partial class TestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("site_testing.Model.CompletedTest", b =>
                {
                    b.Property<int>("IdCompletedTest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCompletedTest"));

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("IdCompletedTest");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("completedTest");
                });

            modelBuilder.Entity("site_testing.Model.Test", b =>
                {
                    b.Property<int>("Idtest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Idtest"));

                    b.Property<string>("NameTest")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Idtest");

                    b.ToTable("test");
                });

            modelBuilder.Entity("site_testing.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("test_site.Answer", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionIdQuestion")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionTestId")
                        .HasColumnType("integer");

                    b.Property<int>("Mark")
                        .HasColumnType("integer");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId", "QuestionIdQuestion", "QuestionTestId");

                    b.ToTable("answer");
                });

            modelBuilder.Entity("test_site.Question", b =>
                {
                    b.Property<int>("IdQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdQuestion"));

                    b.Property<string>("Question1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("IdQuestion");

                    b.HasIndex("TestId");

                    b.ToTable("question");
                });

            modelBuilder.Entity("site_testing.Model.CompletedTest", b =>
                {
                    b.HasOne("site_testing.Model.Test", "Test")
                        .WithMany("CompletedTests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("site_testing.Model.User", "User")
                        .WithMany("CompletedTests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("test_site.Answer", b =>
                {
                    b.HasOne("test_site.Question", "QuestionNavigation")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionNavigation");
                });

            modelBuilder.Entity("test_site.Question", b =>
                {
                    b.HasOne("site_testing.Model.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("site_testing.Model.Test", b =>
                {
                    b.Navigation("CompletedTests");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("site_testing.Model.User", b =>
                {
                    b.Navigation("CompletedTests");
                });

            modelBuilder.Entity("test_site.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}