using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental
{
    [Route("api/[controller]")]
    [EnableCors("EntireWorld")]
    //[Authorize]
    public class CarsDataController : ControllerBase, IDisposable
    {
        private readonly CarDataLogic logic;
        public CarsDataController(CarDataLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult GetAllCarsData()
        {
            try
            {
                List<CarDataModel> carsData = logic.GetAllCarsData();
                return Ok(carsData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneCarData(int id)
        {
            try
            {
                CarDataModel carData = logic.GetOneCarData(id);
                if (carData == null)
                    return NotFound($"id {id} not found");

                return Ok(carData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddCarData(CarDataModel carDataModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));
                CarDataModel addedCarData = logic.AddCarData(carDataModel);
                return Created("api/CarsType/" + addedCarData.ID, addedCarData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFullCarData(int id, CarDataModel carDataModel)
        {
            try
            {
                carDataModel.ID = id;
                CarDataModel updatedCarData = logic.UpdateFullCarData(carDataModel);
                if (updatedCarData == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedCarData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePartialCarData([FromRoute]int id, [FromBody]CarDataModel carDataModel)
        {
            try
            {
                carDataModel.ID = id;
                CarDataModel updatedCarData = logic.UpdatePartialCarData(carDataModel);
                if (updatedCarData == null)
                    return NotFound($"id {id} not found");

                return Ok(updatedCarData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCarData(int id)
        {
            logic.DeleteCarData(id);
            return NoContent();
        }

        public void Dispose()
        {
            logic.Dispose();
        }
    }
}
