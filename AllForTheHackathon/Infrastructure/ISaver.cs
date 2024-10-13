using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Infrastructure
{
    public interface ISaver
    {
        public void SaveEmployees(List<Junior> juniors, List<TeamLead> teamLeads);
        public void SaveWishlists(List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists);
        public void SaveHackathon(Hackathon hackathon);
    }
}
