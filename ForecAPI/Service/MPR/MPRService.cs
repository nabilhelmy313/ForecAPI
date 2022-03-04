using AutoMapper;
using ForecAPI.Application;
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
        public MPRService(IMPRRepository mPRRepository, IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService, IAttachmentRepository attachmentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mPRRepository = mPRRepository;
            _fileService = fileService;
            _attachmentRepository = attachmentRepository;
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
                var result = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int> { Success = result > 0, Message = result > 0 ? "تمت العملية بنجاح" : "لم تتم العملية بنجاح" };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        //public async Task<ServiceResponse<CollectionResponse<GetMPRsDto>>> GetAllMPRDto()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
