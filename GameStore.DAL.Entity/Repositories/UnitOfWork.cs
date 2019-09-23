using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;

namespace GameStore.DAL.Entity.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGameRepository _gameRepository;
        private readonly GameStoreContext _context;

        public UnitOfWork(GameStoreContext context)
        {
            _context = context;
        }

        //public IGenericRepository<Game> GameRepository =>
        //    _gameRepository ?? (_gameRepository = new GameRepository(_context));
        public IGameRepository GameRepository =>
            _gameRepository ?? (_gameRepository = new GameRepository(_context));

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
