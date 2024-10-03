using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure.IsSuccess;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Application
{
    public class AppStarter(HRDirector hrDirector, HRManager hrManager, IRegistrar registrar,
        IWishlistsGenerator wishlistsGenerator, IOptions<Settings> options, ApplicationContext context) : IHostedService
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
                    HoldOneHackathon(settings);
                    break;
                case "2":
                    WriteLineHackathon(settings);
                    break;
                case "3":
                    AverageForAllHackathons();
                    break;
                default:
                    Console.WriteLine("There is no such mode");
                    break;
            }
        }

        private void HoldOneHackathon(Settings settings)
        {
            List<Junior> juniors = registrar.RegisterParticipants<Junior>(settings.FileWithJuniors);
            List<TeamLead> teamLeads = registrar.RegisterParticipants<TeamLead>(settings.FileWithTeamLeads);
            List<Wishlist> juniorsWishlists = wishlistsGenerator.MakeWishlistsForJuniors(juniors, teamLeads);
            List<Wishlist> teamLeadsWishlists = wishlistsGenerator.MakeWishlistsForTeamLeads(juniors, teamLeads);
            if (!IsRegistrationSuccess.IsSuccess)
            {
                Console.WriteLine("Registration failed");
                return;
            }
            if (juniors.Count != teamLeads.Count)
            {
                Console.WriteLine("Number of teamleads and juniors should be the same");
                return;
            }
            Hackathon hackathon = new Hackathon();
            List<Team> teams = hrManager.HoldAHackathon(hackathon, juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }
            double harmonicMean = hrDirector.CalculateTheHarmonicMean(teams);

            DBSaver dBSaver = new DBSaver();
            dBSaver.SaveAllData(context, hackathon, harmonicMean, juniors, teamLeads,
                juniorsWishlists, teamLeadsWishlists, teams);

            Console.WriteLine("Hamonic Mean: " + harmonicMean);
            Console.WriteLine();
        }

        private void WriteLineHackathon(Settings settings)
        {
            Hackathon? hackathon = context.Hackathons.Find(settings.HackathonId);
            if (hackathon != null)
            {
                Console.WriteLine(hackathon);
            }
        }

        private void AverageForAllHackathons()
        {
            List<Hackathon> hackathons = context.Hackathons.ToList();
            double average = hrDirector.CalculateTheAverageValue(hackathons);
            Console.WriteLine($"{hackathons.Count} hackathons found");
            Console.WriteLine($"Average mean: {average}");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
