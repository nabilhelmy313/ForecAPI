using ForecAPI.Application;
using ForecAPI.Dtos.MPR;

namespace ForecAPI.Interfaces.Services.MPR
{
    public interface IMPRService
    {
        Task<ServiceResponse<int>> AddEditMPRForOrginator(AddMPRDto addMPRDto);
        Task<ServiceResponse<int>> CancleMprByOrginator(Guid MprId);
    }
}
