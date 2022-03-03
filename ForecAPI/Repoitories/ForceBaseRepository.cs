using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;

namespace ForecAPI.Repoitories
{
    public class ForceBaseRepository:BaseRepository<Base>,IForceBaseRepository
    {
        public ForceBaseRepository(ForceDbContext dbContext):base(dbContext)
        {

        }
    }
}
