using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
  public class UpdatePackageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
     
        public string Type { get; set; } = string.Empty;

        public double Price { get; set; }
        public double purchasePrice { get; set; }
        public string Note { get; set; } = string.Empty;

        public int ProviderId{ get; set; }
    }
}
