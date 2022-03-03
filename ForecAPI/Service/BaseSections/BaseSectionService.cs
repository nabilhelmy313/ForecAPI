using AutoMapper;
using ForecAPI.Application;
using ForecAPI.Dtos.BaseSections;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Interfaces.Services.BaseSections;
using ForecAPI.Models;

namespace ForecAPI.Service.BaseSections
{
    public class BaseSectionService:BaseService, IBaseSectionService
    {
        private readonly IMapper _mapper;
        private readonly IBaseSectionRepository _baseSectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BaseSectionService(IMapper mapper, IBaseSectionRepository baseSectionRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _baseSectionRepository = baseSectionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<CollectionResponse<GetAllBaseSectionsDto>>> GetAllBaseSecions(PaginationDto pagination, string search, string baseId)
        {
            try
            {
                (var baseSections, int length) = await _baseSectionRepository.GetAllForceBases(pagination, search, baseId);
                if (length == 0 || baseSections == null) return new ServiceResponse<CollectionResponse<GetAllBaseSectionsDto>> { Data = null, Success = false, Message = "لا يوجد بيانات" };
                var baseSectionsDto = _mapper.Map<List<GetAllBaseSectionsDto>>(baseSections);
                return new ServiceResponse<CollectionResponse<GetAllBaseSectionsDto>> { Data = new CollectionResponse<GetAllBaseSectionsDto>(baseSectionsDto, length), Success = true };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ServiceResponse<int>> AddEditBaseSection(AddBaseSectionDto addBaseDto)
        {
            try
            {
                if (addBaseDto.Id != null)
                {
                    var baseSection = _baseSectionRepository.FindByID(Guid.Parse(  addBaseDto.Id));
                    if (baseSection == null) return new ServiceResponse<int> { Data = 0, Success = false, Message = "لا يوجد بيانات" };
                    baseSection.Name = addBaseDto.Name;
                    baseSection.Is_Deleted = addBaseDto.IsDeleted;
                }
                else
                {
                    var baseSectionDb = _mapper.Map<BaseSection>(addBaseDto);
                    _baseSectionRepository.Create(baseSectionDb);
                }
                var result = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int> { Data = result, Success = true, Message = "تمت العملية بنجاح" };

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
