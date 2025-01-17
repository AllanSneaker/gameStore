﻿// <auto-generated />
using System;
using GameStore.DAL.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.DAL.Entity.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20190926114947_GameMigration")]
    partial class GameMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new { Id = 1, CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Street racing with interesting plot", Name = "Need for Speed: Most Wanted", Price = 123m, PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Views = 5 },
                        new { Id = 2, CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Simulator of most popular sport at now day", Name = "Pro Evolution Soccer 2020", Price = 0m, PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Views = 5 }
                    );
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.GenreGame", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("GenreId");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreGames");
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.PlatformType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("PlatformTypes");
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.PlatformTypeGame", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("PlatformTypeId");

                    b.HasKey("GameId", "PlatformTypeId");

                    b.HasIndex("PlatformTypeId");

                    b.ToTable("PlatformTypeGames");
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.Genre", b =>
                {
                    b.HasOne("GameStore.DAL.Entity.Models.Game.Genre", "Parent")
                        .WithMany("SubGenres")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.GenreGame", b =>
                {
                    b.HasOne("GameStore.DAL.Entity.Models.Game.Game", "Game")
                        .WithMany("GenreGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.DAL.Entity.Models.Game.Genre", "Genre")
                        .WithMany("GenreGames")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.DAL.Entity.Models.Game.PlatformTypeGame", b =>
                {
                    b.HasOne("GameStore.DAL.Entity.Models.Game.Game", "Game")
                        .WithMany("PlatformTypeGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.DAL.Entity.Models.Game.PlatformType", "PlatformType")
                        .WithMany("PlatformTypeGames")
                        .HasForeignKey("PlatformTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
