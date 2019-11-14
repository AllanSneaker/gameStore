using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Exceptions;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models.Game;

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

        public async Task UpdateAsync(GameDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var game = await Database.GameRepository.GetAsync(entity.Id);

            if (game == null)
                throw new ItemNotFoundException("Game not found");

            game.Name = entity.Name;
            game.Price = entity.Price;
            game.Views = entity.Views;
            

            Database.GameRepository.Update(game);
            await Database.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await Database.GameRepository.GetAsync(id);

            if (game == null)
                throw new ItemNotFoundException("The item not found");

            Database.GameRepository.Delete(game);

            await Database.SaveAsync();
        }
    }
}