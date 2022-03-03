using ForecAPI.Dtos.General;
using ForecAPI.Models;

namespace ForecAPI.Interfaces.Repositories
{
    public interface IBaseSectionRepository:IBaseRepository<BaseSection>
    {
        Task<(List<BaseSection>, int)> GetAllForceBases(PaginationDto pagination, string search, string baseId);
    }
}
