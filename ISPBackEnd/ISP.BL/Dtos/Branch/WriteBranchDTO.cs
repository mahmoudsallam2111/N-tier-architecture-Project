using System.ComponentModel.DataAnnotations;
namespace ISP.BL
{
    public class WriteBranchDTO


    {
        public int Id { get; set; }
        [StringLength(50 , ErrorMessage ="Name must not exceeds 50 characters")]
        public required string Name { get; set; } = string.Empty;




        public string tel1 { get; set; } = string.Empty;
  
        public string tel2 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{8}$")]
        public string phone1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{8}$")]
        public string phone2 { get; set; } = string.Empty;

       

        public int? Fax { get; set; }

        public  string? ManagerId { get; set; } 


        public int GovernorateCode { get; set; }
    }
}
