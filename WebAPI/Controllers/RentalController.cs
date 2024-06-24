namespace WebAPI.Controllers
{
  using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;  
        }
        [HttpGet("getallrental")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("getbyidrental")]
        public IActionResult GetById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("addrental")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("deleterental")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPost("updaterental")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}

}
