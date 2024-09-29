using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain
{
    public interface IWishlistsGenerator
    {
        public void MakeWishlists(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
