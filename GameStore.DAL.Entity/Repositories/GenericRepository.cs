using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DAL.Entity.Context;
using GameStore.DAL.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Entity.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal GameStoreContext _context;

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

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            TEntity exist = await _context.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return exist;
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
