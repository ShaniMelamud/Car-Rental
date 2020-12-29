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

    public class CarsController : ControllerBase
    {
        private readonly CarsLogic logic;
        public CarsController(CarsLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult GetAllCars()
        {
            try
            {
                List<CarModel> cars = logic.GetAllCars();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
