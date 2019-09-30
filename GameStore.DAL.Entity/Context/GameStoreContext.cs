using GameStore.DAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GameStore.DAL.Entity.Models.Game;

namespace GameStore.DAL.Entity.Context
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreGame> GenreGames { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<PlatformTypeGame> PlatformTypeGames { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //GenreGame
            modelBuilder.Entity<GenreGame>().HasKey(gg => new { gg.GameId, gg.GenreId });

            //PlatformTypeGame
            modelBuilder.Entity<PlatformTypeGame>().HasKey(gg => new { gg.GameId, gg.PlatformTypeId });

            //Game
            modelBuilder.Entity<GenreGame>()
                .HasOne(x => x.Game)
                .WithMany(x => x.GenreGames)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            //Genre
            modelBuilder.Entity<GenreGame>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.GenreGames)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            //Game
            modelBuilder.Entity<PlatformTypeGame>()
                .HasOne(x => x.Game)
                .WithMany(x => x.PlatformTypeGames)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            //PlatformType
            modelBuilder.Entity<PlatformTypeGame>()
                .HasOne(x => x.PlatformType)
                .WithMany(x => x.PlatformTypeGames)
                .HasForeignKey(x => x.PlatformTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            
            var plt1 = new PlatformType(){Id = 1, Type = "Windows"};
            var plt2 = new PlatformType() { Id = 2, Type = "IOS" };

            var g1 = new Genre(){Id = 1, Name = "Action" };
            var g2 = new Genre() { Id = 2, Name = "Sport" };

            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Id = 1,
                    Name = "Need for Speed: Most Wanted",
                    Views = 5,
                    Description = "Street racing with interesting plot",
                    Price = 123m

                },
                new Game()
                {
                    Id = 2,
                    Name = "Pro Evolution Soccer 2020",
                    Views = 5,
                    Description = "Simulator of most popular sport at now day",
                    //PlatformTypeGames = new List<PlatformTypeGame>()
                    //{
                    //    new PlatformTypeGame()
                    //    {
                    //       PlatformType = plt1
                    //    },
                    //    new PlatformTypeGame()
                    //    {
                    //        PlatformType = plt2
                    //    }
                    //},
                    //GenreGames = new List<GenreGame>()
                    //{
                    //    new GenreGame()
                    //    {
                    //        Genre = g1
                    //    },
                    //    new GenreGame()
                    //    {
                    //        Genre = g2
                    //    }
                    //}
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
