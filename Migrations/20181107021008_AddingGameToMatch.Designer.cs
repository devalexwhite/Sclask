﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sclask.Models;

namespace sclask.Migrations
{
    [DbContext(typeof(SclaskDbContext))]
    [Migration("20181107021008_AddingGameToMatch")]
    partial class AddingGameToMatch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("sclask.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KFactor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("sclask.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("GameId");

                    b.Property<int>("PlayerAId");

                    b.Property<float>("PlayerAPrediction");

                    b.Property<int>("PlayerBId");

                    b.Property<float>("PlayerBPrediciton");

                    b.Property<int>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerAId");

                    b.HasIndex("PlayerBId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("sclask.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ProfilePhoto");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("sclask.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<int>("PlayerId");

                    b.Property<float>("Score");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("sclask.Models.Match", b =>
                {
                    b.HasOne("sclask.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sclask.Models.Player", "PlayerA")
                        .WithMany()
                        .HasForeignKey("PlayerAId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sclask.Models.Player", "PlayerB")
                        .WithMany()
                        .HasForeignKey("PlayerBId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sclask.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sclask.Models.Rating", b =>
                {
                    b.HasOne("sclask.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sclask.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
