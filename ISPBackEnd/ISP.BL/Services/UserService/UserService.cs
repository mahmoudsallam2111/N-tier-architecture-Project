
using ISP.BL.Dtos.Users;
using ISP.DAL.Repository.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ISP.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Components.Web;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, UserManager<User> userManager,
            RoleManager<Role> roleManager, IConfiguration configuration, IMapper mapper)
        {

            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        
        public async Task<List<ReadUserDto>> GetAll()
        {

            var users = await userRepository.GetAllUsers();

            List<ReadUserDto> readUserDto = new List<ReadUserDto>();

            foreach (var user in users)
            {
                var role = await GetRole(user);
                var roleClaims = await GetRoleClaims(role);

                readUserDto.Add(new ReadUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    PhoneNumber = user.PhoneNumber!,
                    Email = user.Email!,
                    Status = user.Status,

                    Branch = new ReadBranchByUser
                    {
                        Id = user.Branch!.Id,
                        Name = user.Branch.Name,

                    },

                    Role = new ReadRoleByUser
                    {
                        Id = role!.Id,
                        Name = role.Name!,
                        Claims = roleClaims
                    }

                });
            }

            return readUserDto;
        }

        public async Task<ReadUserDto> GetById(string id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
                return null;


            var role = await GetRole(user);
            var roleClaims = await GetRoleClaims(role);


            return new ReadUserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                PhoneNumber = user.PhoneNumber!,
                Email = user.Email!,
                Status = user.Status,

                Branch = new ReadBranchByUser
                {
                    Id = user.Branch!.Id,
                    Name = user.Branch.Name,

                },

                Role = new ReadRoleByUser
                {
                    Id = role!.Id,
                    Name = role.Name!,
                    Claims = roleClaims
                }

            };
        }

        public async Task<Role> GetRole(User user)
        {
            var getRoleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            return await roleManager.FindByNameAsync(getRoleName);
        }

        public async Task<List<string>> GetRoleClaims(Role role)
        {


            var roleClaims = await roleManager.GetClaimsAsync(role);

            List<string> permissions = new List<string>();

            foreach (var permission in roleClaims)
                permissions.Add(permission.Value);

            return permissions;

        }

        public async Task<bool> Update(string id, UpdateUserDto updateUserDto)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
                return false;

            if (user.Status == false)
                return false;

            user.Id = id;
            user.UserName = updateUserDto.UserName;
            user.NormalizedUserName = updateUserDto.UserName.ToUpper();
            user.BranchId = updateUserDto.Branch;
            user.Email = updateUserDto.Email;
            user.NormalizedEmail = updateUserDto.Email.ToUpper();
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.PasswordHash = user.PasswordHash;
            user.Status = true;
            userRepository.Update(user);
            userRepository.SaveChange();

            ////Update Role////
            var oldRoleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var oldRole = await roleManager.FindByNameAsync(oldRoleName);

            if (oldRole!.Id != updateUserDto.Role)
            {
                //Get User Claims
                var userClaims = await userManager.GetClaimsAsync(user);

                //Delete User claims
                await userManager.RemoveClaimsAsync(user, userClaims);

                //Get Role  to Remove  
                var roleName = await userRepository.GetRoleNameByUserID(id);
                await userManager.RemoveFromRoleAsync(user, roleName!);

                //Add new Role
                var newRole = await roleManager.FindByIdAsync(updateUserDto.Role);
                var addRole = userManager.AddToRoleAsync(user, newRole!.Name!);
                if (addRole != null)
                    return false;

                //Get Role claims
                var roleClaims = await roleManager.GetClaimsAsync(newRole);
                List<string> permissions = new List<string>();
                foreach (var permission in roleClaims)
                    permissions.Add(permission.Value);


                var claims = new List<Claim>
                {

                new Claim("Id", user.Id),
                new Claim("Name", user.UserName),
                new Claim("RoleName", roleName),

                };
                claims.AddRange(roleClaims);

                var isAddedClaims = await userManager.AddClaimsAsync(user, claims);
                if (isAddedClaims == null)
                    return false;

            }

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var UserFromDB = await userRepository.GetUserById(id);
            if (UserFromDB == null)
                return false;

            if (UserFromDB.Status == true)
                UserFromDB.Status = false;


            userRepository.Update(UserFromDB);
            userRepository.SaveChange();
            return true;
        }

        public async Task<int> UserRegister(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                NormalizedEmail = registerDto.Email.ToUpper(),
                PhoneNumber = registerDto.PhoneNumber,
                EmailConfirmed = true,
                BranchId = registerDto.BranchId,
                Status = true,

            };


            //Check User Role
            var checkRole = await roleManager.FindByIdAsync(registerDto.RoleId);
            if (checkRole == null)
                return 1;

            //Check User Email
            var getUser = await userManager.FindByEmailAsync(registerDto.Email);
            if (getUser != null)
                return 2;


            //Create User
            var created = userManager.CreateAsync(user, registerDto.Password);
            if (!created.Result.Succeeded)
                return 3;

            //Add Role To User
            var addedRole = userManager.AddToRoleAsync(user, checkRole.Name);
            if (!addedRole.Result.Succeeded)
                return 4;

            return 0;
        }

        public async Task<TokenDto> Login(LoginDto loginData)
        {
            var user = await userManager.FindByNameAsync(loginData.UserName);

            if (user == null)
                return null!;

            var isAuthenticated = await userManager.CheckPasswordAsync(user, loginData.Password);

            if (isAuthenticated == false)
                return null!;

            //Get User Claims
            var userClaims = await userManager.GetClaimsAsync(user);

            //Delete User claims
            await userManager.RemoveClaimsAsync(user, userClaims);

            //Get Role   
            var roleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
                return null!;

            //Get Role claims
            var roleClaims = await roleManager.GetClaimsAsync(role);
            List<string> permissions = new List<string>();
            foreach (var permission in roleClaims)
                permissions.Add(permission.Value);


            var claims = new List<Claim>
            {

                new Claim("Id", user.Id),
                new Claim("Name", user.UserName),
                new Claim("RoleName", roleName),

            };

            claims.AddRange(roleClaims);

            await userManager.AddClaimsAsync(user, claims);



            // Secret Key
            var secretKeyString = configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);


            // Create secretKey, Algorithm 
            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);


            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(claims: claims, expires: expireDate, signingCredentials: signingCredentials);


            // Casting Token 
            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(tokenHandler.WriteToken(token), expireDate, permissions.ToList(),user.UserName);
        }

        public async Task<bool> CheckEmail(string email)
        {
            var getUser = await userManager.FindByEmailAsync(email);
            if (getUser == null)
               return false!;

            return true;
        }

        public async Task<List<ReadManagerDto>> GetAllManagers()
        {
            var managers = await userManager.GetUsersInRoleAsync("Manager");
            return mapper.Map<List<ReadManagerDto>>(managers);
        }
    }
}
