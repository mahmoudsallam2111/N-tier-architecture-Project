
namespace ISP.BL
{
    public class ReadCentralWithGovernarateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ReadGovernarateDTO Governorate { get; set; }
    }
}
