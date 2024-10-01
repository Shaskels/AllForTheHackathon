using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain
{
    public interface IWishlistsGenerator
    {
        public List<Wishlist> MakeWishlistsForJuniors(List<Junior> juniors, List<TeamLead> teamLeads);
        public List<Wishlist> MakeWishlistsForTeamLeads(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
