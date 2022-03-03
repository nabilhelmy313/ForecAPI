namespace ForecAPI.Dtos.General
{
    public class RegisterUserDto
    {
        public double Rank { get; set; }
        public string IDNumber { get; set; }
        public string Village { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Job { get; set; }
        public string State { get; set; }
        public Guid ForceId { get; set; }
        public Guid BaseId { get; set; }
        public Guid BaseSectionId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

    }
}
