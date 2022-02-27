using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;

namespace ForecAPI.Repoitories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ForceDbContext _dbContext;
        public UnitOfWork(ForceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
