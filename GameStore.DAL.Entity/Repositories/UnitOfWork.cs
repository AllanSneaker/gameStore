﻿using System;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;

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

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
