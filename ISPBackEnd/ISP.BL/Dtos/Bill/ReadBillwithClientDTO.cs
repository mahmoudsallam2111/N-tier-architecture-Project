using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Dtos.Bill
{
    public class ReadBillwithClientDTO
    {

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public float Amount { get; set; }
        public bool IsPaid { get; set; }

        public string? UserId { get; set; } = string.Empty;
        public string? ClientSSn { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
    }
}
