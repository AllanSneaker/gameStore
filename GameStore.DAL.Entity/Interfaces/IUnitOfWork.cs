using System;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Models;

namespace GameStore.DAL.Entity.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        //IGenericRepository<Game> GameRepository { get; }
        Task SaveAsync();
    }
}