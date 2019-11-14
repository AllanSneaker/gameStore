
namespace GameStore.DAL.Entity.Models.Game
{
    public class PlatformTypeGame
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int PlatformTypeId { get; set; }
        public PlatformType PlatformType { get; set; }
    }
}
