using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL;

public class GovernorateRepository : GenericRepository<Governorate>, IGovernorateRepository
{
    private readonly ISPContext context;
    public GovernorateRepository(ISPContext Context) : base(Context)
    {
        this.context = Context;
    }

    public void Delete(Governorate governarate)
    {
        context.Remove(governarate);
    }
    public new async Task<Governorate> GetCentralsAndBranches(int Code)
    {
        return await context.Set<Governorate>().Include(g=>g.Centrals).Include(g => g.Branches)
            .Where(g=>g.Code==Code).FirstOrDefaultAsync();

    }
   
}
