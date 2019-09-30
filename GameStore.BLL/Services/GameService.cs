using System;
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
        private IUnitOfWork Database { get; }

        public GameService(IMapper autoMapper, IUnitOfWork database)
        {
            _autoMapper = autoMapper;
            Database = database;
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            return _autoMapper.Map<IEnumerable<GameDto>>(await Database.GameRepository.GetAllAsync());
        }

        public async Task<GameDto> GetAsync(int id)
        {
            return _autoMapper.Map<GameDto>(await Database.GameRepository.GetAsync(id));
        }

        public async Task<GameDto> CreateAsync(GameDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var game = _autoMapper.Map<Game>(entity);

            Database.GameRepository.Create(game);
            await Database.SaveAsync();
            return entity;
        }

        public Task UpdateAsync(GameDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}