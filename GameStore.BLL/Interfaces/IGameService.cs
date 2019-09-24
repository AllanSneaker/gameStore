using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.DTO;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllGames();
    }
}