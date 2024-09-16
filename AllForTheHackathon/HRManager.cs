using System.Runtime.InteropServices;

namespace AllForTheHackathon
{
    public class HRManager
    {
        private Hackathon _hackathon;
        public HRManager(Hackathon hackathon)
        {
            _hackathon = hackathon;
        }

        public List<Team> HoldAHackathon()
        {
            WishlistsGenerator.GetWishlists(_hackathon.Juniors, _hackathon.TeamLeads);
            return _hackathon.Hold();
        }

    }
}
