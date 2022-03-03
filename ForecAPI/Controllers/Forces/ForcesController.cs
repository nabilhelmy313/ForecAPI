using ForecAPI.Dtos.Forces;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Services.Forces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForecAPI.Controllers.Forces
{
    [Route("api/[controller]")]
    [AllowAnonymous]

    public class ForcesController : ApiControllersBase
    {
        private readonly IForceService _forceService;
        public ForcesController(IForceService forceService)
        {
            _forceService = forceService;
        }
        [HttpGet("GetAllForces")]
        public async Task<IActionResult> GetAllForces([FromQuery]PaginationDto pagination,string? search)
        {
            var res =await _forceService.GetAllForces(pagination, search);
            return Ok(res);
        }
        [HttpPost("AddEditForce")]
        public async Task<IActionResult> AddEditForce([FromBody] AddForceDto addForceDto)
        {
            var res = await _forceService.AddEditForce(addForceDto);
            return Ok(res);
        }
    }
}
