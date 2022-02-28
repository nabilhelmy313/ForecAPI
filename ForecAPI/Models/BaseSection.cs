namespace ForecAPI.Models
{
    public class BaseSection
    {
        public Guid Id { get; set; }
        public Guid BaseId { get; set; }
        public string? Code { get; set; }
        public virtual Base? Base { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
