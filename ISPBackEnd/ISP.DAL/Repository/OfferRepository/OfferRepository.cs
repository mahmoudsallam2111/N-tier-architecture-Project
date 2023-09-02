
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repository.OfferRepository
{
    public class OfferRepository: GenericRepository<Offer>, IOfferRepository
    {
        private readonly ISPContext Context;
        public OfferRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }
        public new async Task<IEnumerable<Offer>> GetAll()
        {
            return await Context.Set<Offer>().Include(o => o.Provider)
                .ToListAsync();
        }
        public new async Task<Offer?> GetByID(int id)
        {
            return await Context.Set<Offer>().Include(o => o.Provider).FirstOrDefaultAsync(o => o.Id == id);
        }
        public new void Update(Offer Offer)
        {
            Context.Set<Offer>().Update(Offer);
        }
    }
}
