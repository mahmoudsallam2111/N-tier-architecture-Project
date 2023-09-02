using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WritePackageDTO
    {
        public required string Name { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;

        public required double Price { get; set; }
        public double purchasePrice { get; set; }
        public string? Note { get; set; } = string.Empty;



        [Required]
        public required int ProviderId { get; set; }


    }
}
