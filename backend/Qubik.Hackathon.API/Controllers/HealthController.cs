using Microsoft.AspNetCore.Mvc;

namespace Qubik.Hackathon.API.Controllers;

[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Ok");
    }
}