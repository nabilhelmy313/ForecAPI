using ForecAPI.Models;

namespace ForecAPI.Interfaces.Repositories
{
    public interface IMPRRepository:IBaseRepository<MPR>
    {
        Task<(List<MPR>, int)> GetAllMPRWithPagination(Dtos.General.PaginationDto pagination, string statusCode, string mprType);
    }
}
