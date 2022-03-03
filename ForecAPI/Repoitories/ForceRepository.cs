using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Repoitories
{
    public class ForceRepository:BaseRepository<Force>, IForceRepository
    {
        public ForceRepository(ForceDbContext _forceDbContext) :base(_forceDbContext)
        {

        }

        public async Task<(List<Force>,int)> GetAllForces(PaginationDto pagination,string search)
        {
            var forces = _forceDbContext.Forces.Where(a => !a.Is_Deleted).OrderByDescending(a=>a.Create_Date);
            if (!string.IsNullOrEmpty(search)) forces = forces.Where(a => a.Name.Contains(search)).OrderByDescending(a => a.Create_Date);
            int length = forces.Count();
            if (pagination.PageSize == -1 && pagination.PageNumber == -1) return (await forces.ToListAsync(), length);
            return (await forces.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync(), length);
        }

    }
}
