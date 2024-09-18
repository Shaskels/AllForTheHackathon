using AllForTheHackathon.Employees;
using AllForTheHackathon.Strategies;

namespace AllForTheHackathon
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; set; }
        public List<TeamLead> TeamLeads { get; set; }

        private ITeamBuildingStrategy _strategy;

        public Hackathon(string fileNameWithJuniors, string fileNameWithTeamLeaders, ITeamBuildingStrategy strategy, IRegistrar registrar) 
        {
            (Juniors, TeamLeads) = registrar.RegisterParticipants(fileNameWithJuniors, fileNameWithTeamLeaders);
            _strategy = strategy;
        }


        public List<Team> Hold()
        {
            return _strategy.BuildTeams(Juniors, TeamLeads);
        }

    }
}