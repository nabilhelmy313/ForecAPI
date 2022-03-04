namespace ForecAPI.Service.General
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using ForecAPI.Interfaces.Services.General;
    using ForecAPI.Interfaces.Repositories.General;
    using ForecAPI.Dtos.General;
    using ForecAPI.Models.General;

    namespace NvgEvents.Application.Services.Moltaqa.General
    {
        public class FileService : IFileService
        {
            private readonly SettingsModel _keys;
            private readonly IAttachmentRepository _attachmentRepository;
            private readonly IMapper _mapper;
            private IHostingEnvironment Environment;
            private IConfiguration _configuration;

            public FileService(SettingsModel _settingsModel, IConfiguration configuration,
                IAttachmentRepository attachmentRepository, IMapper mapper, IHostingEnvironment _Environment)
            {
                _keys = _settingsModel;
                _attachmentRepository = attachmentRepository;
                _mapper = mapper;
                Environment = _Environment;
                _configuration = configuration;
                _keys = configuration.GetSection("Settings").Get<SettingsModel>();
            }
            public async Task<KeyValuePair<bool, string>> UploadFile(Guid rowId, Guid? scondRowId, List<IFormFile> UploadFiles, string TableName, string fileTypeCode, string FolderName, int fileMaxSize = 2000)
            {
                //if (!_keys.AllowRegister)
                //    return new KeyValuePair<bool, string>();
                string message = "";
                if (UploadFiles.Count == 0)
                    return new KeyValuePair<bool, string>(false,"Can not upload");

                try
                {
                    for (int i = 0; i < UploadFiles.Count; i++)
                    {
                        if (!CheckFile(UploadFiles[i], out message, fileMaxSize))
                            return new KeyValuePair<bool, string>(false, message);
                        #region set attachment model
                        var model = new AttachmentDto()
                        {
                            RowId = rowId.ToString(),
                            Id = Guid.NewGuid(),
                            //SecondRowId = scondRowId,
                            FileName = UploadFiles[i].FileName,
                            FileExtension = Path.GetExtension(UploadFiles[i].FileName),
                            FileLength = UploadFiles[i].Length,
                            MIMEType = UploadFiles[i].ContentType,
                            TableName = TableName
                        };

                        //if (MemiTypes.GetTypeByMemi(model.MIMEType).ToString()!= fileTypeCode )
                        //    return new KeyValuePair<bool, string>(false, CultureHelper.GetResourceMessage(CommonResource.ResourceManager, nameof(CommonResource.Supportedextensions)));

                        //model.FilePath = $"\\Moltaqa\\{model.Id.ToString() + model.FileExtension}";
                        //string wwwPath = this.Environment.WebRootPath;
                        //string contentPath = this.Environment.ContentRootPath;

                        string path = Path.Combine(this.Environment.WebRootPath, FolderName);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        model.FilePath = path;
                        #endregion
                        if (!Directory.Exists(Path.GetDirectoryName(model.FilePath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(model.FilePath));
                        string fileName = Path.GetFileName(UploadFiles[i].FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            UploadFiles[i].CopyTo(stream);

                        }
                        var attachment = _mapper.Map<Attachment>(model);
                        attachment.File_Type_Code = "000";
                        //Domain.Enums.MemiTypes.GetTypeByMemi(model.MIMEType).ToString();
                        attachment.File_Path = FolderName + "/" + UploadFiles[i].FileName;
                        _attachmentRepository.Create(attachment);
                    }
                    return new KeyValuePair<bool, string>(true, "Success");

                }
                catch (Exception ex)
                {
                    return new KeyValuePair<bool, string>(false, ex.Message);
                }
            }



            private bool CheckFile(IFormFile uploadedFile, out string message, int fileMaxSize)
            {
                if (uploadedFile.Length > fileMaxSize)
                {
                    message = "حجم الملف غير مسموح به";
                    return false;
                }
                message = "";
                return true;
            }



        }
    }

}
