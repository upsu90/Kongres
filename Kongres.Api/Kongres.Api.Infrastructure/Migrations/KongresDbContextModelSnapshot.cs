﻿// <auto-generated />
using System;
using Kongres.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kongres.Api.Infrastructure.Migrations
{
    [DbContext(typeof(KongresDbContext))]
    partial class KongresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Kongres.Api.Domain.Entities.Answer", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("File")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint?>("ReviewId")
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("UserId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.Review", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateReview")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("File")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint unsigned");

                    b.Property<uint?>("ReviewerId")
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("VersionOfScientificWorkId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("VersionOfScientificWorkId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ReviewersScienceWork", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("ScientificWorkId")
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("UserId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ScientificWorkId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewersScienceWorks");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.Role", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScientificWork", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint?>("MainAuthorId")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OtherAuthors")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Specialization")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("MainAuthorId");

                    b.ToTable("ScientificWorks");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScientificWorkFile", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint?>("ScientificWorkId")
                        .HasColumnType("int unsigned");

                    b.Property<byte>("Version")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ScientificWorkId");

                    b.ToTable("ScientificWorkFiles");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.User", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Degree")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Specialization")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("University")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.UserRole", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("RoleId")
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("UserId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.Answer", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.HasOne("Kongres.Api.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.Review", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId");

                    b.HasOne("Kongres.Api.Domain.Entities.ScientificWorkFile", "VersionOfScientificWork")
                        .WithMany()
                        .HasForeignKey("VersionOfScientificWorkId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ReviewersScienceWork", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.ScientificWork", "ScientificWork")
                        .WithMany()
                        .HasForeignKey("ScientificWorkId");

                    b.HasOne("Kongres.Api.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScientificWork", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.User", "MainAuthor")
                        .WithMany()
                        .HasForeignKey("MainAuthorId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScientificWorkFile", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.ScientificWork", "ScientificWork")
                        .WithMany()
                        .HasForeignKey("ScientificWorkId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Kongres.Api.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
