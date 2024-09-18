using Microsoft.EntityFrameworkCore;
using TravelGuide.Context;
using System.Linq.Expressions;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Repositories.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private MyDbContext _db;
        private DbSet<T> _dbSet;
        public BaseRepository(MyDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task<T> AddItem(T item)
        {
            await _dbSet.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> caretiria = null, string[] Includes = null)
        {
            IQueryable<T> query = _dbSet;

            if(Includes != null)
            {
                foreach (var include in Includes) 
                { 
                    query = query.Include(include).AsSplitQuery();
                }
            }


            if(caretiria != null)
            {
                return await query.Where(caretiria).ToListAsync();
            }
           
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateItem(T item)
        {
            _dbSet.Update(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}
