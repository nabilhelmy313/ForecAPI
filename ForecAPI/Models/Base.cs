namespace ForecAPI.Models
{
    public class Base:BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Guid ForceId { get; set; }
        public virtual Force? Force { get; set; }
        public virtual ICollection<BaseSection>? BaseSection { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<MPR>  MPRs{ get; set; }
    }
}
