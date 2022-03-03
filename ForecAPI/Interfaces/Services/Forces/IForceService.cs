using ForecAPI.Application;
using ForecAPI.Dtos.Forces;
using ForecAPI.Dtos.General;
using ForecAPI.Service;

namespace ForecAPI.Interfaces.Services.Forces
{
    public interface IForceService
    {
        Task<ServiceResponse<CollectionResponse<GetAllForcesDto>>> GetAllForces(PaginationDto pagination, string search);
        Task<ServiceResponse<int>> AddEditForce(AddForceDto addForceDto);
    }
}
