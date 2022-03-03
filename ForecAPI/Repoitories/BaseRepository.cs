using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ForecAPI.Repoitories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ForceDbContext _forceDbContext;
        public BaseRepository(ForceDbContext forceDbContext)
        {
            _forceDbContext = forceDbContext;
        }
        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _forceDbContext.Set<T>().ToListAsync();
            else
                return await _forceDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _forceDbContext.Set<T>().ToList();
            else
                return _forceDbContext.Set<T>().Where(predicate).ToList();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate = null) =>
                        predicate == null
                ? _forceDbContext.Set<T>().CountAsync()
                : _forceDbContext.Set<T>().Where(predicate).CountAsync();
        public virtual T FindByID(Guid Id)
        {
            return _forceDbContext.Set<T>().FirstOrDefault(z => z.Id == Id);

        }
        public virtual void Create(T obj)
        {
            _forceDbContext.Attach(obj);
            _forceDbContext.Entry(obj).State = EntityState.Added;
        }
        public virtual async Task CreateRangeAsync(IEnumerable<T> objList)
        {
            await _forceDbContext.AddRangeAsync(objList);
        }
        public virtual void Delete(T obj)
        {
            _forceDbContext.Set<T>().Where(o=>o.Is_Deleted==true);
        }

    }
}
