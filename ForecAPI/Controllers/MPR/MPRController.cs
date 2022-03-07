using ForecAPI.Dtos.General;
using ForecAPI.Dtos.MPR;
using ForecAPI.Interfaces.Services.MPR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForecAPI.Controllers.MPR
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPRController : ApiControllersBase
    {
        private readonly IMPRService _iMPRService;
        public MPRController(IMPRService iMPRService)
        {
            _iMPRService = iMPRService;
        }

        [HttpGet("GetAllMPRs")]
        public async Task<IActionResult> GetAllMPRs(PaginationDto pagination)
        {
            var res = await _iMPRService.GetAllMPRs(pagination, Guid.Parse(CurrentUserId));
            return Ok(res);
        }

        [HttpPost("AddEditMPRForOrginator")]
        public async Task<IActionResult> AddEditMPRForOrginator([FromBody] AddMPRDto addMPRDto)
        {
            var res = await _iMPRService.AddEditMPRForOrginator(addMPRDto);
            return Ok(res);
        }
        [HttpPut("CancleMprByOrginator")]
        public async Task<IActionResult> CancleMprByOrginator(Guid MprId)
        {
            var res = await _iMPRService.CancleMprByOrginator(MprId);
            return Ok(res);
        }
        [HttpPost("UsersReplayOnMPR")]

        public async Task<IActionResult> UsersReplayOnMPR([FromBody] ReplayDto oCLOGReplayDto)
        {
            var res = await _iMPRService.UsersReplayOnMPR(oCLOGReplayDto, Guid.Parse(CurrentUserId));
            return Ok(res);
        }
        [HttpGet("GetMPRDetailDto")]
        public async Task<IActionResult> GetMPRDetail(Guid mprId)
        {
            var res = await _iMPRService.GetMPRDetail(mprId);
            return Ok(res);
        }
    }
}
