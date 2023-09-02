using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class BillRepository : GenericRepository<Bill>,IBillRepository
    {
        private readonly ISPContext context;

        public BillRepository(ISPContext Context):base(Context)
        {
            context = Context;
        }
        public int BillGenerationSP()
        {
            var bill = context.Database.ExecuteSqlRaw("sp_generateBills");
            return bill;
        }

        public IEnumerable<Bill> getClientBills(string Ssid, bool condition)
        {
            var billlist = context.Bills.
                AsSingleQuery().
                Include(c=>c.Client).
                Where(s => s.ClientSSn == Ssid && s.IsPaid == condition).ToList();
            return billlist;
        }

        public Bill? GetNextMonthBill(int Nmonth, string ClientId)
        {
            var billparams = new[]
             {
                   new SqlParameter("@NextMonth",Nmonth),
                   new SqlParameter("@ClientId", ClientId),

             };

            var billobj = context.Bills.FromSqlRaw("sp_GetNextMonthBill @NextMonth,@ClientId", billparams)
                .AsEnumerable()
                .FirstOrDefault();

            return billobj;
        }

        public IEnumerable<Bill> GetNopaid_bilist()
        {
            return context.Bills.
                AsSplitQuery().
                Include(c => c.Client).
                Where(a=>a.IsPaid==false)
                .ToList();
        }

        public void paidBill(int id)
        {
            var billtopaid = context.Bills.Where(a => a.Id == id).FirstOrDefault();
            billtopaid.IsPaid = true;
            context.SaveChanges();
        }
    }
}
