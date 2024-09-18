using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; set; }
        public List<TeamLead> TeamLeads { get; set; }

        private ITeamBuildingStrategy _strategy;

        public Hackathon(string fileNameWithJuniors, string fileNameWithTeamLeaders, ITeamBuildingStrategy strategy) 
        {
            (Juniors, TeamLeads) = Registrar.RegisterParticipants(fileNameWithJuniors, fileNameWithTeamLeaders);
            _strategy = strategy;
        }


        public List<Team> Hold()
        {
            return _strategy.GetTeams(Juniors, TeamLeads);
        }

    }
}