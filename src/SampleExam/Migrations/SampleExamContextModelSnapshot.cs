﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
 
using SampleExam.Infrastructure.Data;

namespace SampleExam.Migrations
{
    [DbContext(typeof(SampleExamContext))]
    partial class SampleExamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SampleExam.Domain.AnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsRight");

                    b.Property<char>("Key");

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId", "Key")
                        .IsUnique();

                    b.ToTable("AnswerOptions");
                });

            modelBuilder.Entity("SampleExam.Domain.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPublished")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("PassPercentage");

                    b.Property<int>("TimeInMinutes");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SampleExam.Domain.ExamTag", b =>
                {
                    b.Property<int>("ExamId");

                    b.Property<string>("TagId");

                    b.Property<DateTime>("CreatedAt");

                    b.HasKey("ExamId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ExamTags");
                });

            modelBuilder.Entity("SampleExam.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("SampleExam.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("ExamId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(3000);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SampleExam.Domain.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("SampleExam.Domain.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SampleExam.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("GenderId");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsEmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Middlename")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false");

                    b.HasIndex("GenderId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SampleExam.Domain.UserExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime?>("EndedAt");

                    b.Property<int>("ExamId");

                    b.Property<DateTime>("StartedtedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExams");
                });

            modelBuilder.Entity("SampleExam.Domain.UserExamQuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnswerOptionId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserExamId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerOptionId");

                    b.HasIndex("UserExamId", "AnswerOptionId")
                        .IsUnique();

                    b.ToTable("UserExamQuestionAnswers");
                });

            modelBuilder.Entity("SampleExam.Domain.UserExamResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsPassed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("NoAnswerCount");

                    b.Property<int>("QuestionCount");

                    b.Property<int>("RightAnswerCount");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserExamId");

                    b.Property<int>("WrongAnswerCount");

                    b.HasKey("Id");

                    b.HasIndex("UserExamId");

                    b.ToTable("UserExamResults");
                });

            modelBuilder.Entity("SampleExam.Domain.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Text");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Sample value 1",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SampleExam.Domain.AnswerOption", b =>
                {
                    b.HasOne("SampleExam.Domain.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.Exam", b =>
                {
                    b.HasOne("SampleExam.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.ExamTag", b =>
                {
                    b.HasOne("SampleExam.Domain.Exam", "Exam")
                        .WithMany("ExamTags")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SampleExam.Domain.Tag", "Tag")
                        .WithMany("ExamTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.Question", b =>
                {
                    b.HasOne("SampleExam.Domain.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.RefreshToken", b =>
                {
                    b.HasOne("SampleExam.Domain.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.User", b =>
                {
                    b.HasOne("SampleExam.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.UserExam", b =>
                {
                    b.HasOne("SampleExam.Domain.Exam", "Exam")
                        .WithMany("UserExams")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SampleExam.Domain.User", "User")
                        .WithMany("UserExams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.UserExamQuestionAnswer", b =>
                {
                    b.HasOne("SampleExam.Domain.AnswerOption", "AnswerOption")
                        .WithMany()
                        .HasForeignKey("AnswerOptionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SampleExam.Domain.UserExamResult", b =>
                {
                    b.HasOne("SampleExam.Domain.UserExam", "UserExam")
                        .WithMany()
                        .HasForeignKey("UserExamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
