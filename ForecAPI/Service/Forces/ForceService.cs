using AutoMapper;
using ForecAPI.Application;
using ForecAPI.Dtos.Forces;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Interfaces.Services.Forces;
using ForecAPI.Models;

namespace ForecAPI.Service.Forces
{
    public class ForceService:BaseService, IForceService
    {
        private readonly IMapper _mapper;
        private readonly IForceRepository _forceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ForceService(IMapper mapper, IForceRepository forceRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _forceRepository = forceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<CollectionResponse<GetAllForcesDto>>> GetAllForces(PaginationDto pagination,string search)
        {
            try
            {
                (var forces, int length) = await _forceRepository.GetAllForces(pagination, search);
                if(length==0||forces==null) return new ServiceResponse<CollectionResponse<GetAllForcesDto>> { Data = null, Success = false, Message ="لا يوجد بيانات" };
                var forcesDto = _mapper.Map<List<GetAllForcesDto>>(forces); 
                return new ServiceResponse<CollectionResponse<GetAllForcesDto>> { Data = new CollectionResponse<GetAllForcesDto>(forcesDto,length), Success = true };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ServiceResponse<int>> AddEditForce(AddForceDto addForceDto)
        {
            try
            {
                if (addForceDto.Id != null)
                {
                    var force = _forceRepository.FindByID(Guid.Parse( addForceDto.Id));
                    if(force==null) return new ServiceResponse<int> { Data = 0, Success = false, Message = "لا يوجد بيانات" };
                    force.Name = addForceDto.Name;
                    force.Is_Deleted = addForceDto.IsDeleted;
                }
                else
                {
                    var forceDb = _mapper.Map<Force>(addForceDto);
                    _forceRepository.Create(forceDb);                
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
