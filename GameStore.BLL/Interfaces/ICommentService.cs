using GameStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllComments(int gameId);
        Task AddComment(int gameId, CommentDto entity);
        Task Reply(int commentId, CommentDto entity);
    }
}
