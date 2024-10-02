using AllForTheHackathon.Domain.Employees;
using AllForTheHackathon.Domain.Strategies;

namespace AllForTheHackathon.Domain
{
    public class Hackathon
    {
        public int Id { get; set; }
        public List<Junior> Juniors { get; set; } = new();
        public List<TeamLead> TeamLeads { get; set; } = new();
        public decimal Result { get; set; }
        public List<Team> Teams { get; set; } = new();

        public Hackathon()
        {
        }

        public List<Team> Hold(ITeamBuildingStrategy strategy, List<Junior> juniors, List<TeamLead> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists)
        {
            return strategy.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists);
        }

        public override string ToString()
        {
            string result = "Juniors:\n";
            foreach (var junior in Juniors)
            {
                result += junior.ToString() + "\n";
            }
            result += "TeamLeads:\n";
            foreach (var teamLead in TeamLeads)
            {
                result += teamLead.ToString() + "\n";
            }
            result += "Teams:\n";
            foreach(var team in Teams)
            {
                result += team.ToString() + "\n";
            }
            result += "Harmonic mean:" + Result.ToString();
            return result;
        }
    }
}