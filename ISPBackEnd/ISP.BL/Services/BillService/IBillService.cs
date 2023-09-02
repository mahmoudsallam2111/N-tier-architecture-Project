using ISP.BL.Dtos.Bill;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public interface IBillService
    {
        int BillGenerationSP();
       Task<ReadBillDTO?> GetNextMonthBill(int Nmonth, string ClientId);

        IEnumerable<ReadBillwithClientDTO> GetNopaid_bilist();
        void paidBill(int id);

        IEnumerable<ReadBillDTO> getClientBills(string Ssid, bool condition);
    }
}
