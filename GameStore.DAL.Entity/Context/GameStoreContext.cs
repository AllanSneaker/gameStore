using GameStore.DAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public DbSet<Comment> Comments { get; set; }

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

            modelBuilder.Entity<Game>()
                .HasMany(c => c.Comments);


            var plt1 = new PlatformType() { Id = 1, Type = "Windows" };
            var plt2 = new PlatformType() { Id = 2, Type = "IOS" };

            var g1 = new Genre() { Id = 1, Name = "Action" };
            var g2 = new Genre() { Id = 2, Name = "Sport" };

            var comment = new Comment() { Id = 1, GameId = 1, Content = "comment", Publisher = "nickname", Created = DateTime.Today };
            var comment2 = new Comment() { Id = 2, GameId = 1, Content = "comment2", Publisher = "nickname", Created = DateTime.Today };

            var game = new Game()
            {
                Id = 1,
                Name = "Need for Speed: Most Wanted",
                Views = 5,
                Description = "Street racing with interesting plot",
                Price = 123m
            };

            var game2 = new Game()
            {
                Id = 2,
                Name = "Pro Evolution Soccer 2020",
                Views = 5,
                Description = "Simulator of most popular sport at now day"
            };
            
            modelBuilder.Entity<Comment>().HasData(comment, comment2);
            modelBuilder.Entity<Game>().HasData(game, game2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
