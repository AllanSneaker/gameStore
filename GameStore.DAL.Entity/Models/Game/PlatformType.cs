using System.Collections.Generic;

namespace GameStore.DAL.Entity.Models.Game
{
    public class PlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<PlatformTypeGame> PlatformTypeGames { get; set; }

        public PlatformType()
        {
            PlatformTypeGames = new List<PlatformTypeGame>();
        }
    }
}
