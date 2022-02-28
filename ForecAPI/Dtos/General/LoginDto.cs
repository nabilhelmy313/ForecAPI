using ForecAPI.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace ForecAPI.Dtos.General
{
    public class LoginDto
    {
        [Required(ErrorMessageResourceName = "اسم المستخدم مطلوب")]
        public string UserName { get; set; }

        [Required]
        [ValidatePassword()]
        public string Password { get; set; }
    }

}
