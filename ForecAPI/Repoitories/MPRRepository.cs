using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;

namespace ForecAPI.Repoitories
{
    public class MPRRepository:BaseRepository<MPR>, IMPRRepository
    {
        public MPRRepository(ForceDbContext forceDbContext):base(forceDbContext)
        {

        }
    }
}
