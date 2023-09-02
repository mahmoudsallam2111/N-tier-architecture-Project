using ISP.API.Constants;
using ISP.BL;
using ISP.BL.Services.SharedService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [AllowAnonymous]
    public class SharedController : CustomControllerBase
    {
        private readonly Ishardservice shardservice;

        public SharedController(Ishardservice shardservice)
        {
            this.shardservice = shardservice;
        }


        [HttpGet]
       // [Authorize(Permissions.Client.View)]
        public IActionResult ClientCount()
        {
            var count = shardservice.countsystemuser();
            return Ok(count);
        }
    }
}
