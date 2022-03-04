namespace ForecAPI.Interfaces.Services.General
{
    public interface IFileService
    {
        Task<KeyValuePair<bool, string>> UploadFile(Guid rowId, Guid? scondRowId, List<IFormFile> UploadFiles, string TableName, string fileTypeCode, string FolderName, int fileMaxSize = 2);
    }
}
