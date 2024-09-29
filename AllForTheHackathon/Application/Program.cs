using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Strategies;
using AllForTheHackathon.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AllForTheHackathon.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureHostConfiguration(options =>
            {
                options.AddJsonFile("./Resources/appsettings.json");
            }).ConfigureServices((builder, services) =>
            {
                services.AddHostedService<AppStarter>();
                services.Configure<Constants>(builder.Configuration);
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
