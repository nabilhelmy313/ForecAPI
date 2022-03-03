using ForecAPI.Dtos.General;
using ForecAPI.Models;

namespace ForecAPI.Interfaces.Repositories
{
    public interface IForceBaseRepository:IBaseRepository<Base>
    {
        Task<(List<Base>, int)> GetAllForceBases(PaginationDto pagination, string search, string forceId);
    }
}
