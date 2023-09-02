namespace ISP.BL.Dtos.Users;
public class RegisterDto
{
    public required string UserName { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string  PhoneNumber { get; set; }= string.Empty;
    public required string RoleId { get; set; } = string.Empty;
    public int? BranchId { get; set; }


}
