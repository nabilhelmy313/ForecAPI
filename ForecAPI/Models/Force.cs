namespace ForecAPI.Models
{
    public class Force
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ForceCode { get; set; }
        public ICollection<Base>? Bases { get; set; }
    }
}
