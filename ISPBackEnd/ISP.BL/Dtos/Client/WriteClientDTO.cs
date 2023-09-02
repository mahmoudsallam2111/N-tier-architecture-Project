using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WriteClientDTO
    {

  
        public  string SSID { get; set; }

        [StringLength(50 , ErrorMessage ="client name must not exceed 50 character")]
        public required string name { get; set; } = string.Empty;


        [MaxLength(11)]
        public  string tel { get; set; } = string.Empty;
        public int governorateCode { get; set; }


        [StringLength(100)]
        public string address { get; set; } = string.Empty;

        [EmailAddress]
        public string email { get; set; } = string.Empty;


        public int? providerId { get; set; }
        public int? packageId { get; set; }
      
        public int? centralId { get; set; }

        public int? branchId { get; set; }
    
        public int packageIp { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string routerSerial { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{8}$")]
        public string phone { get; set; } = string.Empty;
        public int? orderNumber { get; set; }

        public int? portSlot { get; set; }

        public int? slot { get; set; }
        public int? portBlock { get; set; }
        public int? block { get; set; }
        [StringLength(50)]
        public string userName { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        public int? vpi { get; set; }
        public int? vci { get; set; }
        public int? operationOrderNumber { get; set; }
        public int OfferId { get; set; }

        public DateTime operationOrderDate { get; set; }

        public double prePaid { get; set; }

        public required double installationFee { get; set; }
        public required double contractFee { get; set; }

 


        
    }
}
