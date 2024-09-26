using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AllForTheHackathon.Strategies;
using AllForTheHackathon.Exсeptions;
using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class AppStarter(HRDirector hrDirector, HRManager hrManager, IRegistrar registrar) : IHostedService
    {
        private bool _running = true;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync);
            return Task.CompletedTask;
        }
        public void RunAsync()
        {
            List<Team> teams;
            for (int i = 0; i < Constants.NumberOfHackathons; i++)
            {
                List<Junior> junior = registrar.RegisterParticipants<Junior>(Constants.FileWithJuniors);
                List<TeamLead> teamLeads = registrar.RegisterParticipants<TeamLead>(Constants.FileWithTeamLeads);
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
