﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models;

namespace GameStore.DAL.Entity.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreContext context) : base(context)
        {
            
        }
    }
}