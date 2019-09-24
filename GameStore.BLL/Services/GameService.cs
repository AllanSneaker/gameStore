using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;

namespace GameStore.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IMapper _autoMapper;
        IUnitOfWork Database { get; }

        public GameService(IMapper autoMapper, IUnitOfWork database)
        {
            _autoMapper = autoMapper;
            Database = database;
        }

        public async Task<IEnumerable<GameDto>> GetAllGames()
        {
            return _autoMapper.Map<IEnumerable<GameDto>>(await Database.GameRepository.GetAllAsync());
        }
    }
}