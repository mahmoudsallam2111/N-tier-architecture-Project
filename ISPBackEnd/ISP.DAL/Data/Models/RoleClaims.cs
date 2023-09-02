using Microsoft.AspNetCore.Identity;
namespace ISP.DAL.Data.Models
{
    public class RoleClaims<Role> : IdentityRoleClaim<Role> where Role : IEquatable<Role>
    {
    }
}
