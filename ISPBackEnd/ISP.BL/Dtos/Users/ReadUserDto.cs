namespace ISP.BL.Dtos.Users
{
    public class ReadUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Status { get; set; }
        public ReadBranchByUser? Branch { get; set; } 
        public ReadRoleByUser? Role  { get; set; } 
       


    }
}
