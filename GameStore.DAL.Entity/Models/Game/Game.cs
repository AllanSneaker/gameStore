using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entity.Models.Game
{
	public class Game
	{
		public int Id { get; set; }
        [Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public uint Views { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public virtual ICollection<GenreGame> GenreGames { get; set; }
        public virtual ICollection<PlatformTypeGame> PlatformTypeGames { get; set; }

        public Game()
        {
            GenreGames = new List<GenreGame>();
            PlatformTypeGames = new List<PlatformTypeGame>();
        }
    }
}
