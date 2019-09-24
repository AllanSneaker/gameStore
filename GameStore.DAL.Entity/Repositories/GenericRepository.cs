using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entity.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly GameStoreContext _context;

        public GenericRepository(GameStoreContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            TEntity exist =  _context.Set<TEntity>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
            }

            return exist;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
