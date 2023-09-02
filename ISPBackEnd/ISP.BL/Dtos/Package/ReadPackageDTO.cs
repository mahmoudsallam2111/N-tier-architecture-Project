using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
  public class ReadPackageDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        [Required]
        public required string Type { get; set; } = string.Empty;

        public required double Price { get; set; }
        public double purchasePrice { get; set; }
        public string Note { get; set; } = string.Empty;

        public required bool IsActive { get; set; }


        [Required]
        public required string ProviderName { get; set; }

       
        public ReadProviderDTO provider { get; set; }


    }
}
