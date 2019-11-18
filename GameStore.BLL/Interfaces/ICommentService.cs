using GameStore.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllCommentsAsync(int gameId);
        Task AddCommentAsync(int gameId, CommentDto entity);
    }
}
