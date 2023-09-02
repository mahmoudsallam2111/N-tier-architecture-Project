using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        private readonly ISPContext context;

        public ProviderRepository(ISPContext Context) : base(Context)
        {
            context = Context;
        }

        public Provider? GetProviderswithoffer_package(int id)
        {
            return  context.Providers
                .AsSplitQuery()
               .Include(o => o.offers)
               .Include(p => p.Packages)
               .Where(a => a.Id == id)
               .FirstOrDefault();
        }
    }
}
