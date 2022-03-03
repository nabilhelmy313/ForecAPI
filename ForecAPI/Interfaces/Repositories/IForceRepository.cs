using ForecAPI.Dtos.General;
using ForecAPI.Models;

namespace ForecAPI.Interfaces.Repositories
{
    public interface IForceRepository:IBaseRepository<Force>
    {
        Task<(List<Force>, int)> GetAllForces(PaginationDto pagination, string search);
    }
}
