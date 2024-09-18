using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public interface ITeamBuildingStrategy
    {
        public List<Team> GetTeams(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
