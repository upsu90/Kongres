﻿// <auto-generated />
using System;
using Kongres.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kongres.Api.Infrastructure.Migrations
{
    [DbContext(typeof(KongresDbContext))]
    [Migration("20201120143752_Add Description, OtherAuthors into ScienceWork and change Rating to byte")]
    partial class AddDescriptionOtherAuthorsintoScienceWorkandchangeRatingtobyte
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<uint?>("ReviewersScienceWorkId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ReviewersScienceWorkId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ReviewersScienceWork", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("ScienceWorkId")
                        .HasColumnType("int unsigned");

                    b.Property<uint?>("UserId")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ScienceWorkId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewersScienceWorks");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScienceWork", b =>
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainAuthorId");

                    b.ToTable("ScienceWorks");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScienceWorkInfo", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<uint?>("ScienceWorkId")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("Version")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("ScienceWorkId");

                    b.ToTable("ScienceWorkInfos");
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

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Specialization")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("University")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                    b.HasOne("Kongres.Api.Domain.Entities.ReviewersScienceWork", "ReviewersScienceWork")
                        .WithMany()
                        .HasForeignKey("ReviewersScienceWorkId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ReviewersScienceWork", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.ScienceWork", "ScienceWork")
                        .WithMany()
                        .HasForeignKey("ScienceWorkId");

                    b.HasOne("Kongres.Api.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScienceWork", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.User", "MainAuthor")
                        .WithMany()
                        .HasForeignKey("MainAuthorId");
                });

            modelBuilder.Entity("Kongres.Api.Domain.Entities.ScienceWorkInfo", b =>
                {
                    b.HasOne("Kongres.Api.Domain.Entities.ScienceWork", "ScienceWork")
                        .WithMany()
                        .HasForeignKey("ScienceWorkId");
                });
#pragma warning restore 612, 618
        }
    }
}
