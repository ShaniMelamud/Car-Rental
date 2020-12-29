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
    public class RentalsController : ControllerBase, IDisposable
    {
        private readonly RentalsLogic logic;
        public RentalsController(RentalsLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        [Route("full-rentals")]

        public IActionResult GetAllFullRentals()
        {
            try
            {
                List<FullRentalModel> rentals = logic.GetAllFullRentals();
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllRentals()
        {
            try
            {
                List<RentalModel> rentals = logic.GetAllRentals();
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("add/{id}")]
        public IActionResult GetOneRental(int id)
        {
            try
            {
                RentalModel rental = logic.GetOneRental(id);
                if (rental == null)
                    return NotFound($"id {id} not found");

                return Ok(rental);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("userRentals/{id}")]
        public IActionResult GetRentalsForUser([FromRoute] int id)
        {
            try
            {
                List<RentalModel> rentals = logic.GetRentalsForUser(id);
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPost]
        public IActionResult AddRental(RentalModel rentalModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));
                RentalModel addedRental = logic.AddRental(rentalModel);
                return Created("api/CarsType/" + addedRental.ID, addedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFullRental(int id, RentalModel rentalModel)
        {
            try
            {
                rentalModel.ID = id;
                RentalModel updatedRental = logic.UpdateFullRental(rentalModel);
                if (updatedRental == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePartialRental(int id, RentalModel rentalModel)
        {
            try
            {
                rentalModel.ID = id;
                RentalModel updatedRental = logic.UpdatePartialRental(rentalModel);
                if (updatedRental == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRental(int id)
        {
            logic.DeleteRental(id);
            return NoContent();
        }

        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
