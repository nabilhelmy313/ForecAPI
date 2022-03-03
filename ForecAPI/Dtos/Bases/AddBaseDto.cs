namespace ForecAPI.Dtos.Bases
{
    public class AddBaseDto
    {
        public string? Id { get; set; }
        public Guid ForceId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
