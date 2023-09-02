using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class ReadBillDTO
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public float Amount { get; set; }
        public bool IsPaid { get; set; }

        public string? Note { get; set; } = string.Empty;
        public DateTime? PaymentDate { get; set; } 

        public string? UserId { get; set; } = string.Empty;
        public ReadClientDTO? Client { get; set; }

    }
}
