using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Provider.View)]
    
    public class ProviderController : CustomControllerBase
    {
        private readonly IProviderService providerService;

        public ProviderController(IProviderService providerService)
        {
            this.providerService = providerService;
        }

        [HttpGet]
        [Authorize(Permissions.Provider.View)]
        public async Task<ActionResult<List<ReadProviderDTO>>> GetAll()
        {
            var ProviderList = await providerService.GetAll();
            return ProviderList;
        }


        [HttpGet]
        [Route(("{id}/Offers&Packages"))]
        [Authorize(Permissions.Provider.View)]
        public  ActionResult<ReadProviderwithoffer_govDTO> GetAllwithoff_gov(int id)
        {
            var Provider = providerService.GetProviderswithoffer_package(id);
            if (Provider ==null)
            {
                return NotFound();
            }
            return Provider;
        }


        [HttpGet]
        [Route("{Id}")]
        [Authorize(Permissions.Provider.View)]
        public async Task<ActionResult<ReadProviderDTO>> GetById(int Id)
        {
            var Provider= await providerService.GetById(Id);
            if (Provider == null)
            {
                return NotFound();
            }
            return Provider;
        }    


        [HttpPost]
        [Authorize(Permissions.Provider.Create)]
        public async Task<ActionResult<ReadProviderDTO>> Add([Required] WriteProviderDTO writeProviderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await providerService.Insert(writeProviderDTO);
        }




        [HttpPut]
        [Route("{Id}")]
        [Authorize(Permissions.Provider.Edit)]
        public async Task<ActionResult<ReadProviderDTO>> Edit(int Id, UpdateProviderDTO updateProviderDTO)
        {
            if (Id != updateProviderDTO.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

           var updatedprovider =  await providerService.Edit(Id, updateProviderDTO);

            if (updatedprovider == null)
            {
                return NotFound();
            }

            return NoContent();

           
        }

        [HttpDelete("{id}")]
        [Authorize(Permissions.Provider.Delete)]
        public async Task<ActionResult<ReadProviderDTO>> Delete(int id)
        {
            var Providertodelete = await providerService.Remove(id);

            if (Providertodelete == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }
            
            return Ok(Providertodelete);
        }







    }
}
