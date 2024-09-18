using AllForTheHackathon.Exeptions;
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
                services.AddTransient<ITeamBuildingStrategy, StrategyFromWiki>();
                services.AddTransient<IWishlistsGenerator, RandomWishlistsGenerator>();
                services.AddTransient<IRegistrar, RegistrarFromFiles>();
                services.AddSingleton((s) => new Hackathon(Consts.FileWithJuniors, Consts.FileWithTeamLeads,
                    s.GetRequiredService<ITeamBuildingStrategy>(), s.GetRequiredService<IRegistrar>()));
                services.AddSingleton((s) => new HRManager(s.GetRequiredService<Hackathon>(),
                    s.GetRequiredService<IWishlistsGenerator>()));
                services.AddSingleton<HRDirector>();

            }).Build();

            host.Start();

            HRManager hrManager;
            try
            {
                hrManager = host.Services.GetRequiredService<HRManager>();
            }
            catch(RegistrationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var hrDirector = host.Services.GetRequiredService<HRDirector>();
            List<Team> teams;
            for (int i = 0; i < Consts.NumberOfHackathons; i++)
            {
                teams = hrManager.HoldAHackathon();
                Console.WriteLine("Hamonic Mean: " + hrDirector.CalculateTheHarmonicMean(teams));
                Console.WriteLine();
            }
            Console.WriteLine("Average Value: " + hrDirector.CalculateTheAverageValue());
        }
    }
}
