using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [Authorize(Permissions.Client.View)]
    
    public class ClientController : CustomControllerBase
    {
        private readonly IClientservice clientservice;

        public ClientController(IClientservice clientservice)
        {
            this.clientservice = clientservice;
        }

        [HttpGet]
        [Authorize(Permissions.Client.View)]

        public async Task<ActionResult<List<ReadClientDTO>>> GetAll()
        {
            var ClientList = await clientservice.GetAll();
            return ClientList;
        }


        [HttpGet]
        [Route("{SSn}")]
        [AllowAnonymous]
        //[Authorize(Permissions.Client.View)]
        public async Task<ActionResult<ReadClientDTO>> GetById(string SSn)
        {
            var client = await clientservice.GetById(SSn);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }


       

        [HttpPost]
        [Authorize(Permissions.Client.Create)]
        public async Task<ActionResult<ReadClientDTO>> Add([Required] WriteClientDTO writeClientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await clientservice.AddClient(writeClientDTO);
        }




        [HttpPut]
        [Route("{SSn}")]
        [Authorize(Permissions.Client.Edit)]
        public async Task<ActionResult<ReadClientDTO>> Edit(string SSn, UpdateClientDTO updateClientDTO)
        {
            if (SSn != updateClientDTO.SSID)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await clientservice.UpdateClient(SSn, updateClientDTO);
            return NoContent();

        }



        [HttpDelete("{SSn}")]
        [Authorize(Permissions.Client.Delete)]
        public async Task<ActionResult<ReadClientDTO>> Delete(string SSn)
        {
            var getClient = await clientservice.DeleteClient(SSn);

            if (getClient == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
           
            return getClient;
        }




    }
}
