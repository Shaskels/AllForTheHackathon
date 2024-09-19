using System.Runtime.InteropServices;
using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class RandomWishlistsGenerator : IWishlistsGenerator
    {
        public void MakeWishlists(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            var juniorsForShaffle = new List<Junior>(juniors);
            var teamLeadersForShaffle = new List<TeamLead>(teamLeads);
            for (int i = 0; i < Constants.NumberOfTeams; i++)
            {
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(juniorsForShaffle));
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(teamLeadersForShaffle));
                teamLeads[i].Wishlist.InsertRange(0,juniorsForShaffle);
                juniors[i].Wishlist.InsertRange(0,teamLeadersForShaffle);
            }
        }
    }
}
