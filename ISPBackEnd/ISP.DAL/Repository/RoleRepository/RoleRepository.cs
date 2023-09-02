using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repository.RoleRepository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly ISPContext Context;
        public RoleRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await Context.Set<Role>().Where(r => r.Status == true && r.Name != "SuperAdmin").ToListAsync();
           
        }

        public async Task<Role?> GetByID(string id)
        {
            return await Context.Set<Role>().FirstOrDefaultAsync(r => r.Status == true && r.Id == id);
        }
        public async Task<string?> GetByName(string id)
        {
            var role = await Context.Set<Role>().FirstOrDefaultAsync(r => r.Status == true && r.Id == id);
            if (role == null)
            {
                return null;
            }

            return role.Name;
        }

        
    }
}
