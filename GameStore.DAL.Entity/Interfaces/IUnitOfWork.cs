using System;
using System.Threading.Tasks;

namespace GameStore.DAL.Entity.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task SaveAsync();
    }
}