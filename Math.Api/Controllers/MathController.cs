using Math.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Math.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class MathController : ControllerBase
{
    [HttpGet("add")]
    public async Task<IActionResult> AddAsync([FromQuery]long a, 
        long b,
        [FromServices]IMathService service)
    {
        var result = await service.AddAsync(a, b);
        return Ok(new { result = result });
    }


    [HttpGet("sub")]
    public async Task<IActionResult> SubAsync([FromQuery] long a,
        long b,
        [FromServices] IMathService service)
    {
        var result = await service.SubAsync(a, b);
        return Ok(new { result = result });
    }


    [HttpGet("mul")]
    public async Task<IActionResult> MulAsync([FromQuery] long a,
        long b,
        [FromServices] IMathService service)
    {
        var result = await service.MulAsync(a, b);
        return Ok(new { result = result });
    }
}
