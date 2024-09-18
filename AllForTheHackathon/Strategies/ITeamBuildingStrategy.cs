using AllForTheHackathon.Employees;

namespace AllForTheHackathon.Strategies
{
    public interface ITeamBuildingStrategy
    {
        public List<Team> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
