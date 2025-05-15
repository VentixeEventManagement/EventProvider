using EventProvider.Data.Contexts;
using EventProvider.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context = context;
        protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _db.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _db.FirstOrDefaultAsync(expression);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _db.ToListAsync();
            return entities;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _db.AnyAsync(expression);
            return result;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _db.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            try
            {
                _db.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
