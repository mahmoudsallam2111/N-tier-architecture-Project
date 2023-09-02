using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class UpdateProviderDTO
    {
        public required int Id { get; set; }

        [Required(ErrorMessage ="Provider Name can not be empty")]
        public  string Name { get; set; } = string.Empty;
      
    }
}
