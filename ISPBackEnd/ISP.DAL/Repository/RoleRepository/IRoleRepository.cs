
namespace ISP.DAL.Repository.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
         Task<Role?> GetByID(string id);
         Task<string?> GetByName(string id);
         
    }
}
