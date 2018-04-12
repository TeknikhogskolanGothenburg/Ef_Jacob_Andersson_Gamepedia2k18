﻿// <auto-generated />
using System;
using GamepediaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace GamepediaApp.Data.Migrations
{
    [DbContext(typeof(GamepediaContext))]
    partial class GamepediaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamepediaApp.Domain.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2);

                    b.Property<byte[]>("FlagImage")
                        .HasColumnType("image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("GamepediaApp.Domain.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Launch");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("GamepediaApp.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CountryId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("NickName");

                    b.Property<string>("Role");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GamepediaApp.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Founded");

                    b.Property<string>("Name");

                    b.Property<byte[]>("TeamLogo")
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GamepediaApp.Domain.TeamPlayer", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("GamepediaApp.Domain.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("GameName");

                    b.Property<int>("PriceMoney");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TeamId")
                        .HasColumnName("TeamWinnerId");

                    b.Property<string>("Tier");

                    b.Property<string>("TournamentName");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("GamepediaApp.Domain.TournamentMap", b =>
                {
                    b.Property<int>("TournamentId");

                    b.Property<int>("MapId");

                    b.HasKey("TournamentId", "MapId");

                    b.HasIndex("MapId");

                    b.ToTable("TournamentMaps");
                });

            modelBuilder.Entity("GamepediaApp.Domain.Player", b =>
                {
                    b.HasOne("GamepediaApp.Domain.Country", "TheCountry")
                        .WithMany("Players")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamepediaApp.Domain.Team", b =>
                {
                    b.HasOne("GamepediaApp.Domain.Country", "TheCountry")
                        .WithMany("Teams")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamepediaApp.Domain.TeamPlayer", b =>
                {
                    b.HasOne("GamepediaApp.Domain.Player", "Player")
                        .WithMany("Teams")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamepediaApp.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamepediaApp.Domain.Tournament", b =>
                {
                    b.HasOne("GamepediaApp.Domain.Country", "TheCountry")
                        .WithMany("Tournaments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamepediaApp.Domain.Team", "TheTeam")
                        .WithMany("Tournaments")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamepediaApp.Domain.TournamentMap", b =>
                {
                    b.HasOne("GamepediaApp.Domain.Map", "Map")
                        .WithMany("Tournaments")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamepediaApp.Domain.Tournament", "Tournament")
                        .WithMany("Maps")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
