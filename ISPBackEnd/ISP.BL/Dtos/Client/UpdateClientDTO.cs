using System.ComponentModel.DataAnnotations;

namespace ISP.BL
{
    public class UpdateClientDTO
    {

        [Required(ErrorMessage = "the client ssn must not be empty")]
       // [MaxLength(14)]
        public string SSID { get; set; } 
        [Required]
     //   [Range(1,Int32.MaxValue,ErrorMessage ="Package is required and must be bigger than zero")]
        public int PackageId { get; set; }
    }
}
