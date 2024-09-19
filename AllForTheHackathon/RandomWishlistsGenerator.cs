using System.Runtime.InteropServices;
using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class RandomWishlistsGenerator : IWishlistsGenerator
    {
        public void MakeWishlists(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            for (int i = 0; i < Сonstants.NumberOfTeams; i++)
            {
                var juniorsForShaffle = new List<Junior>(juniors);
                var teamLeadersForShaffle = new List<TeamLead>(teamLeads);
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(juniorsForShaffle));
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(teamLeadersForShaffle));
                teamLeads[i].Wishlist = juniorsForShaffle;
                juniors[i].Wishlist = teamLeadersForShaffle;
            }
        }
    }
}
