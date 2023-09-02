using ISP.API.Constants;
using ISP.BL.Dtos.Offer;
using ISP.BL.Services.OfferService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Offer.View)]
   
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpPost]
        [Authorize(Permissions.Offer.Create)]
        public async Task<ActionResult<ReadOfferDto>> Add([Required] WriteOfferDto writeOfferDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await offerService.Insert(writeOfferDto);
        }

        [HttpGet]
       [Authorize(Permissions.Offer.View)]
        public async Task<ActionResult<List<ReadOfferDto>>> GetAll()
        {
            return await offerService.GetAll();
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(Permissions.Offer.View)]
        public async Task<ActionResult<ReadOfferDto>> GetById(int Id)
        {
            var offer = await offerService.GetById(Id);
            if (offer == null)
            {
                return NotFound();
            }
            return offer;
        }

        [HttpPut]
        [Route("{Id}")]
        [Authorize(Permissions.Offer.Edit)]
        public async Task<ActionResult<ReadOfferDto>> Edit(int Id, UpdataOfferDto updataOfferDto)
        {
            if (Id != updataOfferDto.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }
            await offerService.Edit(Id, updataOfferDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Permissions.Offer.Delete)]
        public async Task<ActionResult<ReadOfferDto>> Delete(int id)
        {
            var deletedOffer = await offerService.Delete(id);

            if (deletedOffer == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            
            return deletedOffer;
        }

    }
}
