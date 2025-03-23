using Qubik.Hackathon.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Qubik.Hackathon.API.DTOs
{
    public class EmailListenerResponse
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

    public static EmailListenerResponse MilestoneAchievedResponse(Company company, Milestone milestone)
        {
            return new EmailListenerResponse()
            {
                To = company.InvestorEmailAddress,
                Subject = $"{company.Name} has achieved the {milestone.Name} Milestone",
                Text = @$"<header>
                        <h1>{company.Name} has achieved the {milestone.Name} Milestone!</h1>
                        <p>Another step forward for your investment.</p>
                      </header>

                      <main>
                        <p class=""highlight"">
                          ✅ Milestone successfully completed!
                        </p>
                      </main>
                      <footer>
                          Qubik Ltd. 2025
                      </footer>"
            };
        }

        public static EmailListenerResponse BudgetReleasedResponse(Company company, Milestone milestone)
        {
            return new EmailListenerResponse()
            {
                To = company.CeoEmailAddress,
                Subject = $"Your investor has release the budget for Milestone {milestone.Name}",
                Text = @$"<header>
                        <h1>Your investor has release the budget for Milestone {milestone.Name}!</h1>
                        <p>Another step forward for your roadmap.</p>
                      </header>

                      <main>
                        <p class=""highlight"">
                          ✅ Budget successfully achieved!
                        </p>
                      </main>
                      <footer>
                          Qubik Ltd. 2025
                      </footer>"
            };
        }
    }
}
