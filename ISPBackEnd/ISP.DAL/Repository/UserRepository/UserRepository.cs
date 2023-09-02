using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ISPContext context;

        public UserRepository(ISPContext Context) : base(Context)
        {
            context = Context;
        }

        public int EmployeeCount()
        {
            return context.Users.Count();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Set<User>().Include(b => b.Branch).Where(u => u.Id != "1").ToListAsync();
            
        }
        public async Task<string?> GetRoleNameByUserID(string userId)
        {
            var userRole = await context.UserRoles.FirstOrDefaultAsync(r => r.UserId == userId);
            if (userRole == null)
                return null;

            var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.RoleId);
            if (role == null)
                 return null;
            
            return role.Name;
        }

        public async Task<User> GetUserById(string id)
        {
            return await context.Set<User>().Include(p => p.Branch).FirstOrDefaultAsync(p => p.Id == id);
        }

       
    }
}
