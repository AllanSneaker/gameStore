
namespace GameStore.DAL.Entity.Models.Game
{
   public class GenreGame
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
