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

        [HttpPost("{address}")]
        public async Task<IActionResult> SaveTransactionsResponse([FromRoute] string address, [FromBody] GetTransactionsResponse transactionsData)
        {
            var emailListenerResponse = new List<EmailListenerResponse>();

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
                        if (company.Transactions.All(tx => tx.TxId != transfer.Transaction.TxId))
                        {
                            Context.Transactions.Add(new Models.Transaction(transfer.Transaction, transfer.Timestamp, company.Id));
                            //Check if this transaction validates any milestone
                            var validatedMilestone = company
                                        .Milestones
                                        .FirstOrDefault(milestone =>
                                                milestone.ValidatorRecipientAddress == transfer.Transaction.DestId
                                                && milestone.ValidationAmount == transfer.Transaction.Amount);
                            if (validatedMilestone != null && validatedMilestone.ValidatedAt.HasValue == false)
                            {
                                validatedMilestone.ValidatedAt = DateTimeOffset.FromUnixTimeMilliseconds(transfer.Timestamp).UtcDateTime;
                                Context.Milestones.Update(validatedMilestone);
                                emailListenerResponse.Add(EmailListenerResponse.MilestoneAchievedResponse(company, validatedMilestone));
                            }
                            //Check if this transaction is an investment
                            var investedMilestone = company.Milestones.FirstOrDefault(milestone => milestone.ValidationAmount == transfer.Transaction.Amount);
                            if (transfer.Transaction.SourceId == company.InvestorIdentity && investedMilestone != null && investedMilestone.ReleaseDate.HasValue == false)
                            {
                                investedMilestone.AmountReleased = transfer.Transaction.Amount.Value;
                                investedMilestone.ReleaseDate = DateTimeOffset.FromUnixTimeMilliseconds(transfer.Timestamp).UtcDateTime;
                                emailListenerResponse.Add(EmailListenerResponse.BudgetReleasedResponse(company, investedMilestone));
                            }

                        }
                    }
                }

                Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return Ok(emailListenerResponse);
        }
    }
}
