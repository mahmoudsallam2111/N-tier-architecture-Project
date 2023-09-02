using System.Security.Claims;

namespace ISP.BL.Dtos.Users;
public class TokenDto
{
    public TokenDto(string Token, DateTime ExpireDate , List<string> permissions, string name)
    {
        this.Token = Token;
        this.ExpireDate = ExpireDate;
        this.Permissions = permissions;
        Name = name;
    }
    public string Token { get; set; }  
    public DateTime ExpireDate { get; set; }
    public List<string> Permissions { get; set; }
    public string Name { get; set; }
}
