
namespace ISP.BL.Dtos.Users
{
    public class ReadRoleByUser
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<string> Claims { get; set; } = new List<string>();
    }
}
