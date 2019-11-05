using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;
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
        public async Task AddComment(int gameId, CommentDto entity)
        {
            //if (entity == null)
            //    throw new ArgumentNullException();

            var game = Database.GameRepository.GetAsync(gameId);
            var comment = _autoMapper.Map<Comment>(entity);

            //comment.Game = game ?? throw new ItemNotFoundException();

            Database.CommentRepository.Create(comment);
            await Database.SaveAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetAllComments(int gameId)
        {
            var game = Database.GameRepository.GetAsync(gameId);
            //if (game == null)
            //    throw new ItemNotFoundException();

            return _autoMapper.Map<IEnumerable<CommentDto>>(Database.CommentRepository.FindAsync(x => x.Game.Id == game.Id));
        }

        public Task Reply(int commentId, CommentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
