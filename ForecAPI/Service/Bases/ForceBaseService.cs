using AutoMapper;
using ForecAPI.Application;
using ForecAPI.Dtos.Bases;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Interfaces.Services.Bases;
using ForecAPI.Models;

namespace ForecAPI.Service.Bases
{
    public class ForceBaseService : BaseService, IForceBaseService
    {
        private readonly IMapper _mapper;
        private readonly IForceBaseRepository _forcebaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ForceBaseService(IMapper mapper, IForceBaseRepository forcebaseRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _forcebaseRepository = forcebaseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<CollectionResponse<GetAllBasesDto>>> GetAllForceBases(PaginationDto pagination, string search,string forceId)
        {
            try
            {
                (var forceBases, int length) = await _forcebaseRepository.GetAllForceBases(pagination, search,forceId);
                if (length == 0 || forceBases == null) return new ServiceResponse<CollectionResponse<GetAllBasesDto>> { Data = null, Success = false, Message = "لا يوجد بيانات" };
                var forcesBasesDto = _mapper.Map<List<GetAllBasesDto>>(forceBases);
                return new ServiceResponse<CollectionResponse<GetAllBasesDto>> { Data = new CollectionResponse<GetAllBasesDto>(forcesBasesDto, length), Success = true };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ServiceResponse<int>> AddEditForceBase(AddBaseDto addBaseDto)
        {
            try
            {
                if (addBaseDto.Id != null)
                {
                    var force = _forcebaseRepository.FindByID(Guid.Parse(addBaseDto.Id));
                    if (force == null) return new ServiceResponse<int> { Data = 0, Success = false, Message = "لا يوجد بيانات" };
                    if (addBaseDto.IsDeleted) force.Is_Deleted = addBaseDto.IsDeleted;
                    else
                    {
                        force.Name = addBaseDto.Name;
                        force.Code = addBaseDto.Code;
                    }
                }
                else
                {
                    var forceBaseDb = _mapper.Map<Base>(addBaseDto);
                    _forcebaseRepository.Create(forceBaseDb);
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
