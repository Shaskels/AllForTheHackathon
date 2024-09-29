using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure.IsSuccess;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Application
{
    public class AppStarter(HRDirector hrDirector, HRManager hrManager, IRegistrar registrar, IOptions<Settings> consts) : IHostedService
    {
        private bool _running = true;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync);
            return Task.CompletedTask;
        }
        public void RunAsync()
        {
            Settings constants = consts.Value;
            List<Team> teams;
            for (int i = 0; i < constants.NumberOfHackathons; i++)
            {
                List<Junior> junior = registrar.RegisterParticipants<Junior>(constants.FileWithJuniors);
                List<TeamLead> teamLeads = registrar.RegisterParticipants<TeamLead>(constants.FileWithTeamLeads);
                if (!IsRegistrationSuccess.IsSuccess)
                {
                    Console.WriteLine("Registration failed");
                    return;
                }
                if (junior.Count != teamLeads.Count)
                {
                    Console.WriteLine("Number of teamleads and juniors should be the same");
                    return;
                }
                Hackathon hackathon = new Hackathon(junior, teamLeads);
                teams = hrManager.HoldAHackathon(hackathon);

                foreach (Team team in teams)
                {
                    Console.WriteLine(team);
                }
                Console.WriteLine("Hamonic Mean: " + hrDirector.CalculateTheHarmonicMean(teams));
                Console.WriteLine();
            }
            Console.WriteLine("Average Value: " + hrDirector.CalculateTheAverageValue());
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
