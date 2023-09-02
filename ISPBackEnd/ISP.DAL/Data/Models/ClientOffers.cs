using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    [PrimaryKey(nameof(ClientSSn) , nameof(OfferId)) ]
    public class ClientOffers
    {
        [ForeignKey("Client")]
        public string ClientSSn { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }

        public Client? Client { get; set; }
        public Offer? Offer { get; set; }
        public int MonthsLeft { get; set; }
        public int FreeMonthsLeft { get; set; }

        public double RouterPrice { get; set; }
    }
}
