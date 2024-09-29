using AllForTheHackathon.Domain.Strategies;

namespace AllForTheHackathon.Domain
{
    public class HRManager
    {
        private IWishlistsGenerator _wishlistsGenerator;
        private ITeamBuildingStrategy _buildingStrategy;
        public HRManager(ITeamBuildingStrategy strategy, IWishlistsGenerator wishlistsGenerator)
        {
            _wishlistsGenerator = wishlistsGenerator;
            _buildingStrategy = strategy;
        }

        public List<Team> HoldAHackathon(Hackathon hackathon)
        {
            _wishlistsGenerator.MakeWishlists(hackathon.Juniors, hackathon.TeamLeads);
            return hackathon.Hold(_buildingStrategy);
        }
    }
}
