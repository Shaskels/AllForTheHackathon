using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AllForTheHackathon
{
    public class AppStarter(HRDirector hrDirector, HRManager hrManager, IHost host) : IHostedService
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
            for (int i = 0; i < Сonstants.NumberOfHackathons; i++)
            {
                teams = hrManager.HoldAHackathon(host.Services.GetRequiredService<Hackathon>());
                Console.WriteLine("Hamonic Mean: " + hrDirector.CalculateTheHarmonicMean(teams));
                Console.WriteLine();
            }
            Console.WriteLine("Average Value: " + hrDirector.CalculateTheAverageValue());
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}
