namespace ForecAPI.Models
{
    public class Force:BaseEntity
    {
        public string? Name { get; set; }
        public string? ForceCode { get; set; }
        public virtual ICollection<Base>? Bases { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
