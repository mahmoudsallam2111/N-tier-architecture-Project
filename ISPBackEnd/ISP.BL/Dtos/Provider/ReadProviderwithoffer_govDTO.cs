using ISP.BL.Dtos.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL;

public class ReadProviderwithoffer_govDTO
{

 
   public IEnumerable<ReadOfferDto> offers { get; set; } = new List<ReadOfferDto>();
   public IEnumerable<ReadPackageDTO> Packages { get; set; } = new List<ReadPackageDTO>();

}
