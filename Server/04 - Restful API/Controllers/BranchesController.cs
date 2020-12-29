using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase, IDisposable
    {
        private readonly BranchesLogic logic;
        public BranchesController(BranchesLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IActionResult GetAllBranches()
        {
            try
            {
                List<BranchModel> branches = logic.GetAllBranches();
                return Ok(branches);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneBranch(int id)
        {
            try
            {
                BranchModel branch = logic.GetOneBranch(id);
                if (branch == null)
                    return NotFound($"id {id} not found");

                return Ok(branch);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult AddBranch(BranchModel branchModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));
                BranchModel addeBranch = logic.AddBranch(branchModel);
                return Created("api/CarsType/" + addeBranch.ID, addeBranch);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFullBranch(int id, BranchModel branchModel)
        {
            try
            {
                branchModel.ID = id;
                BranchModel updatedBranch = logic.UpdateFullBranch(branchModel);
                if (updatedBranch == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedBranch);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePartialBranch(int id, BranchModel branchModel)
        {
            try
            {
                branchModel.ID = id;
                BranchModel updatedBranch = logic.UpdatePartialBranch(branchModel);
                if (updatedBranch == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedBranch);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            logic.DeletBranch(id);
            return NoContent();
        }
        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
