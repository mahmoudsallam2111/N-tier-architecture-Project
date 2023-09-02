using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [Authorize(Permissions.Central.View)]

    public class CentralController : CustomControllerBase
    {
        private readonly ICentalService centalService;

        public CentralController(ICentalService centalService)
        {
            this.centalService = centalService;
        }


        
         [HttpGet]
        [Authorize(Permissions.Central.View)]
        public async Task<ActionResult<List<ReadCentralWithGovernarateDTO>>> getallwithgov()
        {
            var CentralList = await centalService.GetAllwithgov();
            return CentralList;
        }


        [HttpGet]
        [Route("{Id}")]
        [Authorize(Permissions.Central.View)]
        public async Task<ActionResult<ReadCentralDTO>> GetById(int Id)
        {
            var Cental = await centalService.GetById(Id);
            if (Cental == null)
            {
                return NotFound();
            }
            return Cental;
        }



        [HttpGet]
        [Route("GetByName/{Name}")]
        [Authorize(Permissions.Central.View)]
        public async Task<ActionResult<ReadCentralDTO>> GetByName(String Name)
        {
            var Cental = await centalService.GetByName(Name);
            if (Cental == null)
            {
                return NotFound();
            }
            return Cental;
        }


        [HttpPost]
        [Authorize(Permissions.Central.Create)]
        public async Task<ActionResult<ReadCentralDTO>> Add([Required] WriteCentralDTO writeCentralDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await centalService.Insert(writeCentralDTO);
        }




        [HttpPut]
        [Route("{Id}")]
        [Authorize(Permissions.Central.Edit)]
        public async Task<ActionResult<ReadCentralDTO>> Edit(int Id, UpdateCentralDTO updateCentralDTO)
        {
            if (Id != updateCentralDTO.Id) { 
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await centalService.Edit(Id, updateCentralDTO);

           return NoContent();


        }

        [HttpDelete("{id}")]
        [Authorize(Permissions.Central.Delete)]
        public async Task<ActionResult<ReadCentralDTO>> Delete(int id)
        {
            var getCentral = await centalService.Delete(id);            
            if (getCentral == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            
            return getCentral;
        }


    }
}
