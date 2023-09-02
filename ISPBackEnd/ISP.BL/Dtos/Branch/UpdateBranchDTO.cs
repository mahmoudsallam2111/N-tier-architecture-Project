using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class UpdateBranchDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;


  
        public string tel1 { get; set; } = string.Empty;
       
        public string tel2 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{8}$")]
        public string phone1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{8}$")]
        public string phone2 { get; set; } = string.Empty;
 
        public int? Fax { get; set; }

        public string? ManagerId { get; set; } 


    }
}
