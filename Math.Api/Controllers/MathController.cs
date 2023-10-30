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
}
