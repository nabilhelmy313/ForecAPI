using ForecAPI.Dtos.BaseSections;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Services.BaseSections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForecAPI.Controllers.BaseSections
{
    [Route("api/[controller]")]
    [AllowAnonymous]
   
    public class BaseSectionController : ApiControllersBase
    {
        private readonly IBaseSectionService _BaseSectionService;
        public BaseSectionController(IBaseSectionService BaseSectionService)
        {
            _BaseSectionService = BaseSectionService;
        }
        [HttpGet("GetAllBaseSections")]
        public async Task<IActionResult> GetAllBaseSections([FromQuery]PaginationDto pagination, string? search, string? BaseId)
        {
            var res = await _BaseSectionService.GetAllBaseSecions(pagination, search, BaseId);
            return Ok(res);
        }
        [HttpPost("AddEditBaseSection")]
        public async Task<IActionResult> AddEditBaseSection([FromBody] AddBaseSectionDto addBaseSection)
        {
            var res = await _BaseSectionService.AddEditBaseSection(addBaseSection);
            return Ok(res);
        }
    }
}
