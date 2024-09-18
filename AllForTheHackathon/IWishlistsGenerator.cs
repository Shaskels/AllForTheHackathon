using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public interface IWishlistsGenerator
    {
        public void MakeWishlists(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
