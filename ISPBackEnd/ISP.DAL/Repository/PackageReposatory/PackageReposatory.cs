using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public class PackageReposatory: GenericRepository<Package>, IPackageReposatory
    {
        ISPContext Context;
        public PackageReposatory(ISPContext Context):base(Context)
        {
            this.Context = Context;
        }
        public new async Task<IEnumerable<Package>> GetAll()
        {
            return await Context.Set<Package>().Include(P => P.Provider)
                .ToListAsync();
        }
        public new async Task<Package?> GetByID(int id)
        {
            return await Context.Set<Package>().Include(P => P.Provider).FirstOrDefaultAsync(p => p.Id == id);
        }

        public new  async Task Add(Package package)
        {
            await Context.Set<Package>().AddAsync(package);
        }

        public new void Delete(Package package)
        {
            Context.Set<Package>().Remove(package);
        }


        public new void SaveChange()
        {
            //context.Set<TEntity>().SavedChanges();
            Context.SaveChanges();
        }

        public new void Update(Package package)
        {
            Context.Set<Package>().Update(package);
        }

    }
}
