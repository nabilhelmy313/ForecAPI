using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Dtos.MPR;
using ForecAPI.Service;

namespace ForecAPI.Interfaces.Services.MPR
{
    public interface IMPRService
    {
        Task<ServiceResponse<int>> AddEditMPRForOrginator(AddMPRDto addMPRDto);
        Task<ServiceResponse<int>> CancleMprByOrginator(Guid MprId);
        Task<ServiceResponse<int>> OCLOGReplay(OCLOGReplayDto oCLOGReplayDto);
        Task<ServiceResponse<CollectionResponse<GetMPRsDto>>> GetAllMPRDto(PaginationDto pagination, Guid userId);
    }
}
