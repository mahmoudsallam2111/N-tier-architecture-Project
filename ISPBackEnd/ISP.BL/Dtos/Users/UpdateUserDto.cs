namespace ISP.BL.Dtos.Users
{
    public class UpdateUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int Branch { get; set; }
        public string Role { get; set; } =string.Empty;
    }
}
