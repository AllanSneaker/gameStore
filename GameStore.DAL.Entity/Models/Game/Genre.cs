using System.Collections.Generic;

namespace GameStore.DAL.Entity.Models.Game
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GenreGame> GenreGames { get; set; }
        public virtual ICollection<Genre> SubGenres { get; set; }
        public int? ParentId { get; set; }
        public virtual Genre Parent { get; set; }

        public Genre()
        {
            GenreGames = new List<GenreGame>();
        }
    }
}
