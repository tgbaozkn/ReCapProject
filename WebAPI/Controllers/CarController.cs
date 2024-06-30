using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getallcar")]
        public IActionResult GetAll()
        {
            var result = _carService.GetCars();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("getbyidcar")]
        public IActionResult GetById(int carId)
        {
            var result = _carService.Get(carId);
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpPost("addcar")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("deletecar")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPost("updatecar")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
