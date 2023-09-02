using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SSn { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public bool Isactive { get; set; } = true;
        public string Status { get; set; } = string.Empty;

        [ForeignKey("Governarate")]
        public int GovernarateCode  { get; set; }
        public Governorate? Governarate { get; set; }

        [StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        public ClientOffers? ClientOffers { get; set; }


        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }


        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package? Package { get; set; }


        [ForeignKey("Central")]
        public int CentralId { get; set; }
        public Central? Central { get; set; }

        public int? IpPackage { get; set; }

        public DateTime Contractdate { get; set; } = DateTime.Now;
        public string Mobile1 { get; set; } = string.Empty;

        public  string Mobile2 { get; set; } = string.Empty;

        public string LineOwner { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }


        public string RouterSerial { get; set; } = string.Empty;

        public string? OrderNumber { get; set; }

        public int? PortSlot { get; set; }

      
        public int? PortBlock { get; set; }

    
        public string userName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public int? VPI { get; set; }
        public int? VCI { get; set; }

        public string? OrderWorkNumber { get; set; }

        public DateTime Orderworkdate { get; set; }

        public float PrePaid { get; set; }

        public float installationFee { get; set; }
        public float ContractFee { get; set; }

        public int? Slotnum { get; set; }


        public int? Blocknum { get; set; }

        [ForeignKey("Distributer")]
        public string? DisstrubtorId { get; set; }
        public User? Distributer { get; set; }

        public ICollection<Bill> Bills = new HashSet<Bill>();

    }


}
