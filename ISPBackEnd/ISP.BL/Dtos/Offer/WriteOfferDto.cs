
using System.ComponentModel.DataAnnotations;

namespace ISP.BL.Dtos.Offer
{
    public class WriteOfferDto
    {   
             

        public string Name { get; set; } = string.Empty;

        [Range(1, Int32.MaxValue, ErrorMessage = "Provider Id is Required and Must be Bigger than Zero")]
        public int ProviderId { get; set; }
        public double Discount { get; set; }
        public bool IsPercent { get; set; }
        public double CancelFee { get; set; }
        public double SuspendFee { get; set; }
        public int NumberOfFreeMonths { get; set; }
        public int NumberOfMonths { get; set; }
        public bool FreeMonthsFirst { get; set; }
        public bool IsTotalBill { get; set; }
        public bool FreeRouter { get; set; }
        public double RouterPrice { get; set; }
        //public double FineOfSuspensed { get; set; }   

    }
}
