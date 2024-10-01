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
                    Mode1(settings);
                    Mode2(settings);
                    break;
                case "2":
                    Mode2(settings);
                    break;
                case "3":
                    Mode3();
                    break;
                default:
                    Console.WriteLine("There is no such mode");
                    break;
            }

        }

        private void Mode1(Settings settings)
        {
            for (int i = 0; i < settings.NumberOfHackathons; i++)
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

                decimal harmonicMean = hrDirector.CalculateTheHarmonicMean(teams);

                DBSaver dBSaver = new DBSaver();
                dBSaver.SaveAllData(context, hackathon, harmonicMean, juniors, teamLeads, juniorsWishlists,
                    teamLeadsWishlists, teams);

                Console.WriteLine("Hamonic Mean: " + harmonicMean);
                Console.WriteLine();
            }
            Console.WriteLine("Average Value: " + hrDirector.CalculateTheAverageValue());
        }

        private void Mode2(Settings settings)
        {
            Hackathon? hackathon = context.Hackathons.Find(settings.HackathonId);
            if (hackathon != null)
            {
                Console.WriteLine(hackathon.TeamLeads);
                Console.WriteLine(hackathon.Juniors);
                Console.WriteLine(hackathon.Teams);
                Console.WriteLine(hackathon.Result);
            }

        }
        private void Mode3()
        {
            List<Hackathon> hackathons = context.Hackathons.ToList();
            decimal sum = 0;
            foreach (Hackathon hackathon in hackathons)
            {
                sum += hackathon.Result;
            }
            Console.WriteLine(sum/hackathons.Count);
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
