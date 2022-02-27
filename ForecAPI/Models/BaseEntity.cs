using System.ComponentModel.DataAnnotations;

namespace ForecAPI.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Last_Modify_Date { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
