using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("getallcolor")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Succeeded)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }

        [HttpGet("getbyidcolor")]
        public IActionResult GetById(int colorId)
        {
            var result = _colorService.GetColor(colorId);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("addcolor")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }

        [HttpPost("deletecolor")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Remove(color);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpPost("updatecolor")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Succeeded)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
