using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP.DAL
{
    public class User:IdentityUser
    {
        [Required]
        public bool Status { get; set; } = true;

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }       
        public Branch? Branch { get; set; }
        
    }
}
