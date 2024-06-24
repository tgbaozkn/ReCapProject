using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getalluser")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("getbyiduser")]
        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("adduser")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("deleteuser")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPost("updateuser")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }

}

