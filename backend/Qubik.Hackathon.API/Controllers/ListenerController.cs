using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qubik.Hackathon.API.DTOs;

namespace Qubik.Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Task()
        {
            return Ok("Ok");
        }

        [HttpPost("{address}")]
        public async Task<IActionResult> SaveTransactionsResponse([FromRoute] string address, [FromBody] GetTransactionsResponse transactionsData)
        {
            return Ok("Ok");
        }
    }
}
