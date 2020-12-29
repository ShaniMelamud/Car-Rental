using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRental
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireWorld")]
    [Authorize]
    public class CarsTypeController : ControllerBase, IDisposable
    {
        private readonly CarsTypeLogic logic;
        private readonly ILogger<CarsTypeController> logger;
        public CarsTypeController(CarsTypeLogic logic, ILogger<CarsTypeController> logger)
        {
            this.logger = logger;
            this.logic = logic;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllCarsType()
        {
            try
            {
                List<CarTypeModel> carsTypes = logic.GetAllCarsTypes();

                logger.LogInformation("Sending all Cars Types back to user. CarsTypes count: " + carsTypes.Count);

                return Ok(carsTypes);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in CarsTypeController.GetAllCarsTypes()");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneCarType(int id)
        {
            try
            {
                CarTypeModel carType = logic.GetOneCarType(id);
                if (carType == null)
                    return NotFound($"id {id} not found");

                return Ok(carType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddCarType([FromForm]CarTypeModel carTypeModel)
        {
            try
            {
                logger.LogInformation("Car Type has been added: " + carTypeModel);
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));
                CarTypeModel addedCarType = logic.AddCarType(carTypeModel);
                return Created("api/CarsType/" + addedCarType.ID, addedCarType);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in CarsTypeController.AddCarType()");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("images/{fileName}")]
        [AllowAnonymous]
        public IActionResult GetImage(string fileName)
        {
            try
            {
                FileStream fileStream = System.IO.File.OpenRead("Uploads/" + fileName);

                return File(fileStream, "image/jpeg");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFullCarType([FromRoute] int id, CarTypeModel carTypeModel)
        {
            try
            {
                carTypeModel.ID = id;
                CarTypeModel updatedCarType = logic.UpdateFullCarType(carTypeModel);
                if (updatedCarType == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedCarType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePartialCarType([FromRoute]int id, CarTypeModel carTypeModel)
        {
            try
            {
                carTypeModel.ID = id;
                CarTypeModel updatedCarType = logic.UpdatePartialCarType(carTypeModel);
                if (updatedCarType == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedCarType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCarType(int id)
        {
            logic.DeleteCarType(id);
            return NoContent();
        }
        [HttpGet]
        [Route("activity_cars/{start}/{end}")]
        [AllowAnonymous]
        public IActionResult GetActivityCars([FromRoute]DateTime start, [FromRoute]DateTime end)
        {
            try
            {
                List<CarDataModel> carsTypes = logic.CheckCarsActivity(start, end);
                return Ok(carsTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
