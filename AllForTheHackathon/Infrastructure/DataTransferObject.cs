using AllForTheHackathon.Domain;
using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Infrastructure
{
    public class DataTransferObject
    {
        public List<Junior> Juniors { get; private set; }
        public List<TeamLead> TeamLeads { get; private set; }
        public List<Wishlist> TeamLeadsWishlists { get; private set; }
        public List<Wishlist> JuniorsWishlists { get; private set; }
        public List<Team> Teams { get; private set; }

        public DataTransferObject(List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists, List<Team> teams) 
        {
            Juniors = juniors;
            TeamLeads = teamLeads;
            TeamLeadsWishlists = teamLeadsWishlists;
            JuniorsWishlists = juniorsWishlists;
            Teams = teams;
        }
    }
}
