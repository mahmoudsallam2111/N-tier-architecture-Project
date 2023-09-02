using System.ComponentModel.DataAnnotations.Schema;

namespace ISP.DAL
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

       public string? Note { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public float Amount { get; set; }

        public bool? Status { get; set; } = true;

         public DateTime? PaymentDate { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public string? UserId { get; set; } = string.Empty;

        public User? User  { get; set; } 

        [ForeignKey("Client")]
        public string? ClientSSn { get; set; }
        public Client? Client { get; set; }

    }
}
