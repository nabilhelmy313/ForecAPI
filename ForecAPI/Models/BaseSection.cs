namespace ForecAPI.Models
{
    public class BaseSection
    {
        public Guid Id { get; set; }
        public Guid BaseId { get; set; }
        public string? Code { get; set; }
        public Base? Base { get; set; }
    }
}
