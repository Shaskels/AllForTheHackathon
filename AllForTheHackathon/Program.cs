using AllForTheHackathon.Strategies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AllForTheHackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddHostedService<AppStarter>();
                services.AddSingleton<ITeamBuildingStrategy, GaleShapleyStrategy>();
                services.AddSingleton<IWishlistsGenerator, RandomWishlistsGenerator>();
                services.AddSingleton<IRegistrar, RegistrarFromCSVFiles>();
                services.AddTransient<Hackathon>();
                services.AddSingleton<HRManager>();
                services.AddSingleton<HRDirector>();
            }).Build();
            host.Run();
        }
    }
}
