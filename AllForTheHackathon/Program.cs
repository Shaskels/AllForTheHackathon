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
                services.AddTransient<ITeamBuildingStrategy, GaleShapleyStrategy>();
                services.AddSingleton<IWishlistsGenerator, RandomWishlistsGenerator>();
                services.AddSingleton<IRegistrar, RegistrarFromCSVFiles>();
                services.AddTransient((s) => new Hackathon(s.GetRequiredService<ITeamBuildingStrategy>(), 
                    s.GetRequiredService<IRegistrar>()));
                services.AddSingleton((s) => new HRManager(s.GetRequiredService<IWishlistsGenerator>()));
                services.AddSingleton<HRDirector>();
            }).Build();

            host.Run();


        }
    }
}
