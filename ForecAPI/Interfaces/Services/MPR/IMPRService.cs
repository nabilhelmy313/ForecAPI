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
        Task<ServiceResponse<int>> UsersReplayOnMPR(ReplayDto oCLOGReplayDto, Guid userId);
        Task<ServiceResponse<CollectionResponse<GetMPRsDto>>> GetAllMPRs(PaginationDto pagination, Guid userId);
        Task<ServiceResponse<GetMPRDetailDto>> GetMPRDetail(Guid mprId);
    }
}
