using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qubik.Hackathon.API.Data;
using System.Net;

namespace Qubik.Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private HackathonDbContext Context { get; set; }
        public CompanyController(HackathonDbContext context)
        {
            Context = context;
        }

        [HttpGet("{address}")]
        public async Task<IActionResult> Task([FromRoute] string address)
        {
            var company = Context.Companies
                                        .Include(company => company.Transactions)
                                        .Include(company => company.Milestones)
                                        .FirstOrDefault(company => company.Address == address);
            return Ok(company);
        }
    }
}
