using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
   public class WriteGovernarateDTO
    {
        public required int Code { get; set; }

        [StringLength(50 , ErrorMessage ="name of Governarate must not exceed 50 characters")]
        public required string Name { get; set; }
       // public required bool Status { get; set; } = true;
    }
}
