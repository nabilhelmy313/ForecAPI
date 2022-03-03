using ForecAPI.Application;
using ForecAPI.Dtos.BaseSections;
using ForecAPI.Dtos.General;
using ForecAPI.Service;

namespace ForecAPI.Interfaces.Services.BaseSections
{
    public interface IBaseSectionService
    {
        Task<ServiceResponse<CollectionResponse<GetAllBaseSectionsDto>>> GetAllBaseSecions(PaginationDto pagination, string search, string baseId);
        Task<ServiceResponse<int>> AddEditBaseSection(AddBaseSectionDto addBaseDto);
    }
}
