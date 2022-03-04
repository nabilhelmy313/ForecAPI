namespace ForecAPI.Dtos.Bases
{
    public class AddBaseDto
    {
        public string? Id { get; set; }
        public Guid ForceId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
    }
}
