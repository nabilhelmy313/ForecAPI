using AutoMapper;
using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Dtos.MPR;
using ForecAPI.Enums;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Interfaces.Services.General;
using ForecAPI.Interfaces.Services.MPR;
using System.Net.Mime;

namespace ForecAPI.Service.MPR
{
    public class MPRService : BaseService, IMPRService
    {
        private readonly IMPRRepository _mPRRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        public MPRService(IApplicationUserRepository applicationUserRepository,IMPRRepository mPRRepository, IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService, IAttachmentRepository attachmentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mPRRepository = mPRRepository;
            _fileService = fileService;
            _attachmentRepository = attachmentRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<ServiceResponse<int>> AddEditMPRForOrginator(AddMPRDto addMPRDto)
        {
            try
            {
                if (addMPRDto.Id != null)
                {
                    var mprDb = _mPRRepository.FindByID(Guid.Parse(addMPRDto.Id));
                    if (mprDb == null) return new ServiceResponse<int> { Success = false, Message = "لا يوجد بيانات" };
                    _mapper.Map<AddMPRDto, ForecAPI.Models.MPR>(addMPRDto, mprDb);
                    if (addMPRDto.File != null)
                    {
                        var x = await UploadMprFile(true, Guid.Parse(addMPRDto.Id), addMPRDto);
                        if (!x.Key) return new ServiceResponse<int> { Success = false, Message = x.Value };
                    }
                }
                else
                {
                    var mpr = _mapper.Map<ForecAPI.Models.MPR>(addMPRDto);
                    mpr.Status = MPRStausEnum.ORGACCPT.ToString();
                    var count = _mPRRepository.GetAll().Count();
                    mpr.Address_For_Delivery = string.Concat(addMPRDto.AddressForDelivery, "/MPR/", count + 1, DateTime.Now.Year);
                    _mPRRepository.Create(mpr);
                    if (addMPRDto.File != null)
                    {
                        var x = await UploadMprFile(false, mpr.Id, addMPRDto);
                        if (!x.Key) return new ServiceResponse<int> { Success = false, Message = x.Value };
                    }
                }
                var result = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int> { Success = result > 0, Message = result > 0 ? "تمت العملية بنجاح" : "لم تتم العملية بنجاح" };

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task<KeyValuePair<bool, string>> UploadMprFile(bool isEdit, Guid mprId, AddMPRDto addMPRDto)
        {
            if (isEdit)
            {
                var attacment = await _attachmentRepository.GetAttachmentsByRowId(mprId);
                _attachmentRepository.DeleteFile(attacment.FirstOrDefault().Id);
            }
            var stream = new MemoryStream(addMPRDto.File);
            var extention = addMPRDto.FileName.Split('.')[1];
            var file = new FormFile(stream, 0, addMPRDto.File.Length, mprId.ToString() + "." + extention, mprId.ToString() + "." + extention)
            {
                Headers = new HeaderDictionary(),
                ContentType = addMPRDto.ContentType,
            };
            ContentDisposition cd = new ContentDisposition { FileName = file.FileName };
            file.ContentDisposition = cd.ToString();
            var x = await _fileService.UploadFile(addMPRDto.UserId, null, new List<IFormFile> { file }, "MPR", "", "MPR", 200000000);
            return x;

        }
    
        public async Task<ServiceResponse<int>> CancleMprByOrginator(Guid MprId)
        {
            try
            {
               
                var mprDb = _mPRRepository.FindByID(MprId);
                if (mprDb == null) return new ServiceResponse<int> { Success = false, Message = "لا يوجد بيانات" };
                mprDb.Status= MPRStausEnum.ORGCANCLE.ToString();
                mprDb.Is_Deleted = true;
                var result = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int> { Success = result > 0, Message = result > 0 ? "تمت العملية بنجاح" : "لم تتم العملية بنجاح" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<int>> UsersReplayOnMPR(ReplayDto replayDto, Guid userId)
        {
            try
            {
                var userRoles = await _applicationUserRepository.GetUserRoles(userId);
                var mprDb = _mPRRepository.FindByID(Guid.Parse(replayDto.Id));
                if (mprDb == null) return new ServiceResponse<int> { Success = false, Message = "لا يوجد بيانات" };
                if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_LOG))
                {
                    if (mprDb.Status != MPRStausEnum.ORGACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    mprDb.Type_Code = replayDto.MPRType;
                    if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.OCLOGACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.OCLOGRETURN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_DEPO))
                {
                    if (mprDb.Status != MPRStausEnum.OCLOGACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.OCDEPOACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.OCDEPORETRURN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_HQ))
                {
                    if (mprDb.Status != MPRStausEnum.OCLOGACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.OCHQACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.OCHQRETRUN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.D_FINANCE))
                {
                    if (mprDb.Status != MPRStausEnum.OCHQACCPT.ToString()&& mprDb.Status != MPRStausEnum.OCDEPOACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    if (replayDto.IsFinalAccpt.Value)
                        mprDb.Status = MPRStausEnum.DFINANCEFINALACCPT.ToString();
                    else if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.DFINANCEACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.DFINANCERETRUN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.D_LOG))
                {
                    if (mprDb.Status != MPRStausEnum.DFINANCEACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    if (replayDto.IsFinalAccpt.Value)
                        mprDb.Status = MPRStausEnum.DLOGDENGFINALACCPT.ToString();
                    else if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.DLOGDENGACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.DLOGDENGRETUN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.SERVICE_COMMANDER))
                {
                    if (mprDb.Status != MPRStausEnum.DLOGDENGACCPT.ToString()) return new ServiceResponse<int> { Success = false, Message = "لا يمكن الاجابة" };
                    if (replayDto.IsFinalAccpt.Value)
                        mprDb.Status = MPRStausEnum.COMMANDERFINALACCPT.ToString();
                    else if (replayDto.IsAccept)
                        mprDb.Status = MPRStausEnum.COMMANDERACCPT.ToString();
                    else
                    {
                        mprDb.Status = MPRStausEnum.COMMANDERRETRUN.ToString();
                        mprDb.Feedback = replayDto.Feedback;
                    }
                }
                var result = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int> { Success = result > 0, Message = result > 0 ? "تمت العملية بنجاح" : "لم تتم العملية بنجاح" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ServiceResponse<CollectionResponse<GetMPRsDto>>> GetAllMPRs(PaginationDto pagination,Guid userId)
        {
            try
            {
                var userRoles = await _applicationUserRepository.GetUserRoles(userId);
                var mprs =new List<ForecAPI.Models.MPR>();
                int length = 0;
                if (userRoles.Any(a=>a.RoleId.ToString()== RolesIdsClass.Originator)|| userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_LOG))
                  (mprs,length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.ORGACCPT.ToString(), null);
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_DEPO))
                    (mprs, length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.OCLOGACCPT.ToString(), MprTypeEnum.GENRL.ToString());
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.OC_HQ))
                    (mprs, length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.OCLOGACCPT.ToString(), MprTypeEnum.TECHN.ToString());
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.D_FINANCE))
                {
                    (mprs, length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.OCDEPOACCPT.ToString(), MprTypeEnum.GENRL.ToString());
                    var othermprs = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.OCHQACCPT.ToString(), MprTypeEnum.TECHN.ToString());
                    mprs.AddRange(othermprs.Item1);
                    length = length + othermprs.Item2;
                }
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.D_LOG))
                    (mprs, length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.DFINANCEACCPT.ToString(), MprTypeEnum.GENRL.ToString());
                else if (userRoles.Any(a => a.RoleId.ToString() == RolesIdsClass.SERVICE_COMMANDER))
                    (mprs, length) = await _mPRRepository.GetAllMPRWithPagination(pagination, MPRStausEnum.DLOGDENGACCPT.ToString(), MprTypeEnum.GENRL.ToString());

                if(length==0||mprs==null) return new ServiceResponse<CollectionResponse<GetMPRsDto>> { Success = false, Message = "لا يوجد بيانات" };
                var mprsDtos = _mapper.Map<List<GetMPRsDto>>(mprs);
                return new ServiceResponse<CollectionResponse<GetMPRsDto>> { Success = true,Data=new CollectionResponse<GetMPRsDto>(mprsDtos,length) };


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ServiceResponse<GetMPRDetailDto>> GetMPRDetail(Guid mprId)
        {
            try
            {
                var mprDb = _mPRRepository.FindByID(mprId);
                if (mprDb == null) return new ServiceResponse<GetMPRDetailDto> { Success = false, Message = "لا يوجد بيانات" };
                var dto = _mapper.Map<GetMPRDetailDto>(mprDb);
                return new ServiceResponse<GetMPRDetailDto> { Success = true, Data =dto };

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
