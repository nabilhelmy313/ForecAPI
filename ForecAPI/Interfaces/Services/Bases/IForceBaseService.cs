using ForecAPI.Application;
using ForecAPI.Dtos.Bases;
using ForecAPI.Dtos.General;
using ForecAPI.Service;

namespace ForecAPI.Interfaces.Services.Bases
{
    public interface IForceBaseService
    {
        Task<ServiceResponse<CollectionResponse<GetAllBasesDto>>> GetAllForceBases(PaginationDto pagination, string search, string forceId);
        Task<ServiceResponse<int>> AddEditForceBase(AddBaseDto addBaseDto);
    }
}
