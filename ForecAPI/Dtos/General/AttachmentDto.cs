namespace ForecAPI.Dtos.General
{
    public class AttachmentDto
    {
        public Guid Id { get; set; }
        public string RowId { get; set; }
        public string FileName { get; set; }
        public string FileTypeCode { get; set; }
        public string MIMEType { get; set; }
        public long FileLength { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public string TableName { get; set; }
    }
}
