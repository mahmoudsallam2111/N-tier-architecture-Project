
namespace ISP.BL.Dtos.Users;
public class LoginDto
{
    
    public required string UserName { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
