using Microsoft.AspNetCore.Identity;

namespace ForecAPI.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public DateTime Create_Date { get; set; }
        public DateTime? Last_Modify_Date { get; set; }
        public double Rank { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
