
namespace ISP.DAL.Repository.UserRepository
{
    public interface IUserRepository :IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<string?> GetRoleNameByUserID(string userId);

       int EmployeeCount();
       
    }
}
