using ForecAPI.Models.General;

namespace ForecAPI.Interfaces.Repositories.General
{
    public interface IAttachmentRepository:IBaseRepository<Attachment>
    {
        Task<List<Attachment>> GetAttachmentsByRowId(Guid rowId);
        void DeleteFile(Guid attachmentId);
    }
}
