using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AllForTheHackathon.Strategies;

namespace AllForTheHackathon
{
    public class AppStarter(HRDirector hrDirector, HRManager hrManager, ITeamBuildingStrategy strategy, IRegistrar registrar) : IHostedService
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
                teams = hrManager.HoldAHackathon(new Hackathon(strategy,registrar));
                Console.WriteLine("Hamonic Mean: " + hrDirector.CalculateTheHarmonicMean(teams));
                Console.WriteLine();
            }
            Console.WriteLine("Average Value: " + hrDirector.CalculateTheAverageValue());
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
