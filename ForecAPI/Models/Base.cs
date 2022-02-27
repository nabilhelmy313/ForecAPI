namespace ForecAPI.Models
{
    public class Base:BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Guid ForceId { get; set; }
        public Force? Force { get; set; }
        public ICollection<BaseSection>? BaseSection { get; set; }
    }
}
