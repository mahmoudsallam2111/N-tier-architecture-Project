using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public interface IBillRepository: IGenericRepository<Bill>
    {
        int BillGenerationSP();
        Bill? GetNextMonthBill(int Nmonth , string ClientId);

        void paidBill(int id);

        IEnumerable<Bill> GetNopaid_bilist();

        IEnumerable<Bill> getClientBills(string Ssid, bool condition);
    }
}
