using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Models;
using ForecAPI.Models.General;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Repoitories.General
{
    public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
    {

        public AttachmentRepository(ForceDbContext forceDbContext) : base(forceDbContext)
        {

        }

        public void DeleteFile(Guid attachmentId)
        {
            var attachment = _forceDbContext.Attachments.FirstOrDefault(a => a.Id == attachmentId);
            attachment.Is_Deleted = false;
        }

        public async Task<List<Attachment>> GetAttachmentsByRowId(Guid rowId)
        {
            var attachment = await _forceDbContext.Attachments.Where(a => a.Row_Id == rowId.ToString() && !a.Is_Deleted).ToListAsync();
            return attachment;
        }
    }
 }
