using System.ComponentModel.DataAnnotations.Schema;

namespace ForecAPI.Models
{
    public class BaseSection
    {
        public Guid Id { get; set; }
        [ForeignKey("BaseId")]
        public Guid BaseId { get; set; }
        public string? Code { get; set; }
        public virtual Base? Base { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
