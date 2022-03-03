using Microsoft.AspNetCore.Identity;

namespace ForecAPI.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public DateTime Create_Date { get; set; }
        public DateTime? Last_Modify_Date { get; set; }
        public double Rank { get; set; }
        public string IDNumber { get; set; }
        public string Village { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string State { get; set; }
        public Guid ForceId { get; set; }
        public Guid BaseId { get; set; }
        public Guid BaseSectionId { get; set; }
        public virtual Force Force { get; set; }
        public virtual Base Base { get; set; }
        public virtual BaseSection BaseSection { get; set; }

    }
}
