using System.Runtime.InteropServices;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain
{
    public class RandomWishlistsGenerator : IWishlistsGenerator
    {
        public List<Wishlist> MakeWishlistsForJuniors(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            List<Wishlist> juniorsWishlists = new List<Wishlist>();
            var teamLeadersForShaffle = new List<TeamLead>(teamLeads);
            for (int i = 0; i < juniors.Count; i++)
            {
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(teamLeadersForShaffle));
                Wishlist wishlist = new Wishlist();
                wishlist.Employees.InsertRange(0, teamLeadersForShaffle);
                wishlist.Employee = juniors[i];
                juniorsWishlists.Add(wishlist);
            }
            return juniorsWishlists;
        }

        public List<Wishlist> MakeWishlistsForTeamLeads(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            List<Wishlist> teamLeadsWishlists = new List<Wishlist>();
            var juniorsForShaffle = new List<Junior>(juniors);
            for (int i = 0; i < teamLeads.Count; i++)
            {
                Random.Shared.Shuffle(CollectionsMarshal.AsSpan(juniorsForShaffle));
                Wishlist wishlist = new Wishlist();
                wishlist.Employees.InsertRange(0, juniorsForShaffle);
                wishlist.Employee = teamLeads[i];
                teamLeadsWishlists.Add(wishlist);
            }
            return teamLeadsWishlists;
        }
    }
}
