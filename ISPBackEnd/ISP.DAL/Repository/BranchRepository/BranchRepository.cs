using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Repository.BranchRepository
{
    public class BranchRepository : GenericRepository<Branch>,IBranchRepository
    {
        private readonly ISPContext Context;
        public BranchRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }
        public new async Task<IEnumerable<Branch>> GetAll()
        {
            return await Context.Set<Branch>().Include(b => b.Governorate).Include(b=>b.User)
                .ToListAsync();
        }
        //public new async Task<Branch?> GetByID(int id)
        //{
        //    return await Context.Set<Branch>().Include(b => b.Governorate).Include(b=> b.User).FirstOrDefaultAsync(p => p.Id == id);
        //}

    }
}
