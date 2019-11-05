using System;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Models;

namespace GameStore.DAL.Entity.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task SaveAsync();
    }
}