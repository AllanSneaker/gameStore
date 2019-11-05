using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Entity.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameStoreContext context) : base(context)
        {

        }
    }
}
