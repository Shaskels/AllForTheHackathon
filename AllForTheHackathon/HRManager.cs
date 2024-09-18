using System.Runtime.InteropServices;

namespace AllForTheHackathon
{
    public class HRManager
    {
        private Hackathon _hackathon;
        private IWishlistsGenerator _wishlistsGenerator;
        public HRManager(Hackathon hackathon, IWishlistsGenerator wishlistsGenerator)
        {
            _hackathon = hackathon;
            _wishlistsGenerator = wishlistsGenerator;

        }

        public List<Team> HoldAHackathon()
        {
            _wishlistsGenerator.MakeWishlists(_hackathon.Juniors, _hackathon.TeamLeads);
            return _hackathon.Hold();
        }

    }
}
