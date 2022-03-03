namespace ForecAPI.Dtos.BaseSections
{
    public class AddBaseSectionDto
    {
        public string? Id { get; set; }
        public Guid BaseId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
