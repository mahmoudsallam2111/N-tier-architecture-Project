using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Permissions.Branch.View)]
   
    public class BranchController : CustomControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        [HttpGet]
        [Authorize(Permissions.Branch.View)]
        public async Task<ActionResult<List<ReadBranchDTO>>> GetAll()
        {
            var BranchList = await branchService.GetAll();
            return BranchList;
        }


        [HttpGet]
        [Route("{id}")]
        [Authorize(Permissions.Branch.View)]
        public async Task<ActionResult<ReadBranchDTO> >GetById(int id)
        {
            var Branch = await branchService.GetById(id);
            if (Branch ==null)
            {
                return NotFound();
            }
            return Branch;
        }

        [HttpPost]
        [Authorize(Permissions.Branch.Create)]
        public async Task<ActionResult<ReadBranchDTO>> Add( [Required] WriteBranchDTO writeBranchDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return  await branchService.AddBranch(writeBranchDTO);
        }




        [HttpPut]
        [Route("{id}")]
        [Authorize(Permissions.Branch.Edit)]
        public async Task<IActionResult> Edit(int id , UpdateBranchDTO updateBranchDTO)
        {
            if (id !=updateBranchDTO.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

           var updatedbranch =   await branchService.UpdateBranch(id, updateBranchDTO);
            if (updatedbranch == null)
            {

                return NotFound();
            }

            return  NoContent(); 
            
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Permissions.Branch.Delete)]
        public async Task<ActionResult<ReadBranchDTO>> Delete(int id)
        {
            var getBranch = await branchService.DeleteBranch(id);
            if (getBranch == null)
            {
                return Problem(detail: "the object dees not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }           
            return getBranch;
        }




    }
}
