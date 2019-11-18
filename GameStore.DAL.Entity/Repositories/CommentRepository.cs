using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;

namespace GameStore.DAL.Entity.Repositories
{
    public class CommentRepository : GenericRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context) : base(context)
        {

        }
    }
}
