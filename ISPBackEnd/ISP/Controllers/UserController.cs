using ISP.API.Constants;
using ISP.BL.Dtos.Users;
using ISP.BL.Services.UserPermissionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Role.View)]
   
    public class UserController : Controller
    {
        #region Con

       
        private readonly IUserService userService; 
    
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        #endregion
                                                   
        #region User Register 
        [HttpPost]
        [Authorize(Permissions.Role.Create)]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
           var isRegister = await userService.UserRegister(registerDto);
            if (isRegister == 1)
                return Problem(detail: "Error in checkRole", statusCode: 404,
                   title: "error", type: "null reference");

            if (isRegister == 2)
                return Problem(detail: "Error in getUser(Email is Existing!) ", statusCode: 404,
                  title: "error", type: "null reference");

            if (isRegister == 3)
                return Problem(detail: "Error in Ceeading Password!", statusCode: 404,
                  title: "error", type: "null reference");

            if (isRegister == 4)
                return Problem(detail: "Error in Adding Role! ", statusCode: 404,
                  title: "error", type: "null reference");

            return Ok();
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginData)
        {
            var isLogin = await userService.Login(loginData);

            if (isLogin == null)            
                return Unauthorized();


            return isLogin;

            
        }

        #endregion

        [HttpGet]
        [Authorize(Permissions.Role.View)]
        public async Task<ActionResult<List<ReadUserDto>>> GetAll()
        {
            return await userService.GetAll();

        }
        [HttpGet("GetAllManagers")]
        //[Authorize(Permissions.Role.View)]
        [AllowAnonymous]
        public async Task<ActionResult<List<ReadManagerDto>>> GetAllManagers()
        {
            return await userService.GetAllManagers();

        }

        [HttpGet("{id}")]
        [Authorize(Permissions.Role.View)]
        public async Task<ActionResult<ReadUserDto>> GetById(string id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


        [HttpPut("{id}")]
        [Authorize(Permissions.Role.Edit)]
        public async Task<ActionResult> Edit(string id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            var updated = await userService.Update(id, updateUserDto);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpDelete("{id}")]
        [Authorize(Permissions.Role.Delete)]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteUser = await userService.Delete(id);

            if (deleteUser == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            return Ok();
          }
        [HttpGet("CheckEmail/{email}")]
        [AllowAnonymous]
        //[Authorize(Permissions.Role.View)]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            return await userService.CheckEmail(email);
        }
    }
}
