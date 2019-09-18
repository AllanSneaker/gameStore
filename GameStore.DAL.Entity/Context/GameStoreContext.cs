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
    }
}
