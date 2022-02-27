using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForecAPI.Repoitories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ForceDbContext _dbContext;
        public BaseRepository(ForceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbContext.Set<T>().ToListAsync();
            else
                return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate = null) =>
                        predicate == null
                ? _dbContext.Set<T>().CountAsync()
                : _dbContext.Set<T>().Where(predicate).CountAsync();
        public virtual T FindByID(Guid Id)
        {
            return _dbContext.Set<T>().FirstOrDefault(z => z.Id == Id);

        }
        public virtual void Create(T obj)
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Added;
        }
        public virtual async Task CreateRangeAsync(IEnumerable<T> objList)
        {
            await _dbContext.AddRangeAsync(objList);
        }
        public virtual void Delete(T obj)
        {
            _dbContext.Set<T>().Where(o=>o.Is_Deleted==true);
        }

    }
}
