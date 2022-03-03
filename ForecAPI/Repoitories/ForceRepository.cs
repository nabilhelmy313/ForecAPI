using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;

namespace ForecAPI.Repoitories
{
    public class ForceRepository:BaseRepository<Force>, IForceRepository
    {
        public ForceRepository(ForceDbContext dbContext):base(dbContext)
        {

        }
    }
}
