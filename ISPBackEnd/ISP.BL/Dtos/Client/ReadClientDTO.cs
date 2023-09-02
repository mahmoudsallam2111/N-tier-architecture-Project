
using ISP.BL.Dtos.ClientOffer;
using ISP.BL.Dtos.Offer;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class ReadClientDTO
    {

        public string SSID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Tel{ get; set; } = string.Empty;
        public ReadGovernarateDTO? Governorate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ReadProviderDTO Provider { get; set; }
        public ReadPackageDTO? Package { get; set; }
        public ReadClientOfferDTO? ClientOffers { get; set; }
        public ReadCentralDTO? Central { get; set; }
        public ReadBranchDTO? Branch { get; set; }
        public int? PackageIp { get; set; }
        public string RouterSerial { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? OrderNumber { get; set; }
        public int? PortSlot { get; set; }
        public int? Slot { get; set; }
        public int? PortBlock { get; set; }
        public int? Block { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int? VPI { get; set; }
        public int? VCI { get; set; }
        public string? OperationOrderNumber { get; set; }= string.Empty;
        public DateTime OperationOrderDate { get; set; }
        public float PrePaid { get; set; }
        public float InstallationFee { get; set; }
        public float ContractFee { get; set; }


    }
}
