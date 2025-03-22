using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qubik.Hackathon.API.Data;
using Qubik.Hackathon.API.DTOs;

namespace Qubik.Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenerController : ControllerBase
    {
        private HackathonDbContext Context { get; set; }
        public ListenerController(HackathonDbContext context)
        {

            Context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Task()
        {
            return Ok("Ok");
        }

        [HttpPost("{address}")]
        public async Task<IActionResult> SaveTransactionsResponse([FromRoute] string address, [FromBody] GetTransactionsResponse transactionsData)
        {
            try
            {


                var company = Context.Companies
                                        .Include(company => company.Transactions)
                                        .Include(company => company.Milestones)
                                        .FirstOrDefault(company => company.Address == address);

                foreach (var transaction in transactionsData.Transactions)
                {
                    foreach (var transfer in transaction.Transactions)
                    {
                        //If the transaction did not exist already
                        if(company.Transactions.All(tx => tx.TxId != transfer.Transaction.TxId))
                        {
                            Context.Transactions.Add(new Models.Transaction(transfer.Transaction, transfer.Timestamp, company.Id));
                            //Check if this transaction validates any milestone
                            var validatedMilestone = company
                                        .Milestones
                                        .FirstOrDefault(milestone =>
                                                milestone.ValidatorRecipientAddress == transfer.Transaction.DestId
                                                && milestone.ValidationAmount == transfer.Transaction.Amount);
                            if (validatedMilestone != null)
                            {
                                validatedMilestone.PassDate = DateTime.UtcNow;
                                Context.Milestones.Update(validatedMilestone);
                            }
                        }
                    }
                }

                Context.SaveChanges();

            }
            catch (Exception ex)
            {

            }

            return Ok("Ok");
        }
    }
}
