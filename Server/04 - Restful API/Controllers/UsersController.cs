using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    [Authorize]
    public class UsersController : ControllerBase, IDisposable
    {
        private readonly UsersLogic logic;
        public UsersController(UsersLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<UserModel> users = logic.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneUser(int id)
        {
            try
            {
                UserModel user = logic.GetOneUser(id);
                if (user == null)
                    return NotFound($"id {id} not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));
                UserModel addedUser = logic.AddUser(userModel);
                return Created("api/CarsType/" + addedUser.ID, addedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFullUser(int id, UserModel userModel)
        {
            try
            {
                userModel.ID = id;
                UserModel updatedUser = logic.UpdateFullUser(userModel);
                if (updatedUser == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePartialUser(int id, UserModel userModel)
        {
            try
            {
                userModel.ID = id;
                UserModel updatedUser = logic.UpdatePartialUser(userModel);
                if (updatedUser == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedUser);
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
            logic.DeleteUser(id);
            return NoContent();
        }
        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
