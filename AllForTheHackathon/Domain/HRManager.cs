using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain.Strategies;
using AllForTheHackathon.Infrastructure;

namespace AllForTheHackathon.Domain
{
    public class HRManager
    {
        private ITeamBuildingStrategy _buildingStrategy;
        public HRManager(ITeamBuildingStrategy strategy)
        {
            _buildingStrategy = strategy;
        }

        public List<Team> HoldAHackathon(Hackathon hackathon, List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists)
        {
            return hackathon.Hold(_buildingStrategy, juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);
        }
    }
}
