using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _autoMapper;
        private IUnitOfWork Database { get; }
        public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _autoMapper = mapper;
            Database = unitOfWork;
        }
        public Task AddComment(int gameId, CommentDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentDto>> GetAllComments(int gameId)
        {
            var game = Database.GameRepository.GetAsync(gameId);
            //if (game == null)
            //    throw new ItemNotFoundException();

            return _autoMapper.Map<IEnumerable<CommentDto>>(Database.CommentRepository.Find(x => x.Game.Id == game.Id));
        }

        public Task Reply(int commentId, CommentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
