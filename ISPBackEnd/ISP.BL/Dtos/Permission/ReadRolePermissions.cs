
using System.Security.Claims;

namespace ISP.BL.Dtos.Permission
{
    public class ReadRolePermissions
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public List<ReadPermissions> claims { get; set;} = new List<ReadPermissions>();
    }
}
