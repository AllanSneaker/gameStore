using GameStore.DAL.Entity.Models;
using GameStore.DAL.Entity.Models.Game;

namespace GameStore.DAL.Entity.Interfaces
{
    public interface IGameRepository : IGenericRepository<Game, int>
    {
    }
}