using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain.Strategies
{
    public interface ITeamBuildingStrategy
    {
        public List<Team> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
