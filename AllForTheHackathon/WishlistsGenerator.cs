using System.Runtime.InteropServices;

namespace AllForTheHackathon
{
    public class WishlistsGenerator
    {
        public static void GetWishlists(List<Junior> juniors, List<TeamLead> teamLeads)
        {

            for (int i = 0; i < Consts.NumberOfTeams; i++)
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
