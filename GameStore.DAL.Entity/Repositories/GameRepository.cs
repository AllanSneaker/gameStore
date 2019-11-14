using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models.Game;

namespace GameStore.DAL.Entity.Repositories
{
    public class GameRepository : GenericRepository<Game, int>, IGameRepository
    {
        public GameRepository(GameStoreContext context) : base(context)
        {
            
        }
    }
}
