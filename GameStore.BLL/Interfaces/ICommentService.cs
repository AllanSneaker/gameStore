using GameStore.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllComments(int gameId);
        Task AddComment(int gameId, CommentDto entity);
    }
}
