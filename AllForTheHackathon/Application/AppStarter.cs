using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AllForTheHackathon.Domain;

namespace AllForTheHackathon.Application
{
    public class AppStarter(AverageCalculator averageCalculator, OneHackathonHolder oneHackathonHolder,
        HackathonWriter hackathonWriter, IOptions<Settings> options) : IHostedService
    {
        private bool _running = true;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync);
            return Task.CompletedTask;
        }

        public void RunAsync()
        {
            Settings settings = options.Value;
            string mode = settings.Mode;
            switch (mode)
            {
                case "1":
                    oneHackathonHolder.HoldOneHackathon(settings);
                    break;
                case "2":
                    hackathonWriter.WriteLineHackathon(settings);
                    break;
                case "3":
                    averageCalculator.AverageForAllHackathons();
                    break;
                default:
                    Console.WriteLine("There is no such mode");
                    break;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
