using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getallcustomer")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("getbyidcustomer")]
        public IActionResult GetById(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("addcustomer")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("deletecustomer")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPost("updatecustomer")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
