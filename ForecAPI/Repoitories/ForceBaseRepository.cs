using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Repoitories
{
    public class ForceBaseRepository:BaseRepository<Base>,IForceBaseRepository
    {
        public ForceBaseRepository(ForceDbContext forceDbContext) :base(forceDbContext)
        {

        }
        public async Task<(List<Base>, int)> GetAllForceBases(PaginationDto pagination, string search,string forceId)
        {
            var forceBases = _forceDbContext.Bases.Where(a => !a.Is_Deleted).OrderByDescending(a => a.Create_Date);
            if (!string.IsNullOrEmpty(search)) forceBases = forceBases.Where(a => a.Name.Contains(search)).OrderByDescending(a => a.Create_Date);
            if (!string.IsNullOrEmpty(forceId)) forceBases = forceBases.Where(a => a.ForceId==Guid.Parse(forceId)).OrderByDescending(a => a.Create_Date);
            int length = forceBases.Count();
            if (pagination.PageSize == -1 && pagination.PageNumber == -1) return (await forceBases.Include(a=>a.Force).ToListAsync(), length);
            return (await forceBases.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).Include(a => a.Force).ToListAsync(), length);
        }

    }
}
