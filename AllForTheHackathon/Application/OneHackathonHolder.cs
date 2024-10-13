using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain;
using AllForTheHackathon.Infrastructure.IsSuccess;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Application
{
    public class OneHackathonHolder
    {
        private IRegistrar _registrar;
        private IWishlistsGenerator _wishlistsGenerator;
        private ISaver _saver;
        private HRDirector _hrDirector;
        private HRManager _hrManager;

        public OneHackathonHolder(ISaver saver, HRDirector hrDirector, HRManager hrManager, IRegistrar registrar,
        IWishlistsGenerator wishlistsGenerator) 
        { 
            _saver = saver;
            _hrDirector = hrDirector;
            _hrManager = hrManager;
            _registrar = registrar;
            _wishlistsGenerator = wishlistsGenerator;
        }

        public void HoldOneHackathon(Settings settings)
        {
            List<Junior> juniors = _registrar.RegisterParticipants<Junior>(settings.FileWithJuniors);
            List<TeamLead> teamLeads = _registrar.RegisterParticipants<TeamLead>(settings.FileWithTeamLeads);
            List<Wishlist> juniorsWishlists = _wishlistsGenerator.MakeWishlistsForJuniors(juniors, teamLeads);
            List<Wishlist> teamLeadsWishlists = _wishlistsGenerator.MakeWishlistsForTeamLeads(juniors, teamLeads);
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
            List<Team> teams = _hrManager.HoldAHackathon(hackathon, juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);
            foreach (Team team in teams)
            {
                Console.WriteLine(team);
            }
            double harmonicMean = _hrDirector.CalculateTheHarmonicMean(teams);

            _saver.SaveEmployees(juniors, teamLeads);
            _saver.SaveWishlists(juniorsWishlists, teamLeadsWishlists);
            hackathon.TeamLeads = teamLeads;
            hackathon.Juniors = juniors;
            hackathon.Result = harmonicMean;
            hackathon.Teams = teams;
            _saver.SaveHackathon(hackathon);

            Console.WriteLine("Hamonic Mean: " + harmonicMean);
            Console.WriteLine();
        }
    }
}
