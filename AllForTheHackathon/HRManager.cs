using AllForTheHackathon.Strategies;
namespace AllForTheHackathon
{
    public class HRManager
    {
        private IWishlistsGenerator _wishlistsGenerator;
        public HRManager(IWishlistsGenerator wishlistsGenerator)
        {
            _wishlistsGenerator = wishlistsGenerator;
        }

        public List<Team> HoldAHackathon(Hackathon hackathon)
        {
            _wishlistsGenerator.MakeWishlists(hackathon.Juniors, hackathon.TeamLeads);
            return hackathon.Hold();
        }
    }
}
