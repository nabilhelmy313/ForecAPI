using System.Linq.Expressions;

namespace ForecAPI.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<int> Count(Expression<Func<T, bool>>? predicate = null);
        T FindByID(Guid Id);
        void Create(T obj);
        Task CreateRangeAsync(IEnumerable<T> objList);
        void Delete(T obj);
    }
}
