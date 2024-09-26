using AllForTheHackathon.Employees;
using AllForTheHackathon.Strategies;

namespace AllForTheHackathon
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; private set; }
        public List<TeamLead> TeamLeads { get; private set; }

        public Hackathon(List<Junior> juniors, List<TeamLead> teamLeads) 
        {
            Juniors = juniors;
            TeamLeads = teamLeads;
        }

        public List<Team> Hold(ITeamBuildingStrategy strategy)
        {
            return strategy.BuildTeams(Juniors, TeamLeads);
        }
    }
}