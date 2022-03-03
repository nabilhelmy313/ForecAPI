using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Repoitories
{
    public class BaseSectionReposiroty: BaseRepository<BaseSection>, IBaseSectionRepository
    {
        public BaseSectionReposiroty(ForceDbContext forceDbContext) : base(forceDbContext)
        {

        }
        public async Task<(List<BaseSection>, int)> GetAllForceBases(PaginationDto pagination, string search, string baseId)
        {
            var forceBases = _forceDbContext.BaseSections.Where(a=>!a.Is_Deleted).OrderByDescending(a => a.Create_Date);
            if (!string.IsNullOrEmpty(search)) forceBases = forceBases.Where(a => a.Name.Contains(search)).OrderByDescending(a => a.Create_Date);
            if (!string.IsNullOrEmpty(baseId)) forceBases = forceBases.Where(a => a.BaseId == Guid.Parse(baseId)).OrderByDescending(a => a.Create_Date);
            int length = forceBases.Count();
            if (pagination.PageSize == -1 && pagination.PageNumber == -1) return (await forceBases.Include(a => a.Base).ToListAsync(), length);
            return (await forceBases.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).Include(a => a.Base).ToListAsync(), length);
        }
    }
}
