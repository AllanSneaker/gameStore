using GameStore.DAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.DAL.Entity.Context
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Id = 1,
                    Name = "Need for Speed: Most Wanted",
                    Views = 5,
                    Description = "Street racing with interesting plot"
                },
                new Game()
                {
                    Id = 2,
                    Name = "Pro Evolution Soccer 2020",
                    Views = 5,
                    Description = "Simulator of most popular sport at now day"
                }
            );
        }
    }
}
