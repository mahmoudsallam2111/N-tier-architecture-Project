using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        ISPContext Context;
        public ClientRepository(ISPContext Context) : base(Context)
        {

            this.Context = Context;
        }
        public new async Task<IEnumerable<Client>> GetAll()
        {


            return await Context.Set<Client>().Include(c => c.Governarate)
                .Include(c => c.Provider)
                .Include(c => c.Package)
                .Include(c => c.Central)
                .Include(c => c.Branch)
                .Include(c=>c.ClientOffers).ThenInclude(o=>o.Offer)
                .ToListAsync();
        }
        public new async Task<Client?> GetByID(string ssn)
        {
            return await Context.Set<Client>()
                .Include(P => P.Provider)
                .Include(c => c.Package)
                .Include(c => c.Central)
                .Include(c => c.Branch)

                .Include(g => g.Governarate)
                .Include(o => o.ClientOffers)
                .ThenInclude(o => o.Offer)
                .FirstOrDefaultAsync(c => c.SSn == ssn);
        }
     
        public new void Update(Client Client)
        {
            Context.Set<Client>().Update(Client);
        }
        public new async Task Add(Client Client)
        {

            await Context.Set<Client>().AddAsync(Client);
        }

        public int ClientCount()
        {
            return Context.Clients.Count();
              
        }
    }
}