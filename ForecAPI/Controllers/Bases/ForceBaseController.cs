using ForecAPI.Dtos.Bases;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForecAPI.Controllers.Bases
{
    [Route("api/[controller]")]
    [AllowAnonymous]

    public class ForceBaseController : ApiControllersBase
    {
        private readonly IForceBaseService _forceBaseService;
        public ForceBaseController(IForceBaseService forceBaseService)
        {
            _forceBaseService = forceBaseService;
        }
        [HttpGet("GetAllForceBases")]
        public async Task<IActionResult> GetAllForceBases([FromQuery]PaginationDto pagination, string? search,string? ForceId)
        {
            var res = await _forceBaseService.GetAllForceBases(pagination, search,ForceId);
            return Ok(res);
        }
        [HttpPost("AddEditForceBase")]
        public async Task<IActionResult> AddEditForceBase([FromBody] AddBaseDto addBaseDto)
        {
            var res = await _forceBaseService.AddEditForceBase(addBaseDto);
            return Ok(res);
        }
    }
}
