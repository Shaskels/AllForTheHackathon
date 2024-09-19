using AllForTheHackathon.Employees;
using AllForTheHackathon.Strategies;

namespace AllForTheHackathon
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; set; }
        public List<TeamLead> TeamLeads { get; set; }

        private ITeamBuildingStrategy _strategy;

        public Hackathon(ITeamBuildingStrategy strategy, IRegistrar registrar) 
        {
            Juniors = registrar.RegisterParticipants<Junior>(AllForTheHackathon.Сonstants.FileWithJuniors);
            TeamLeads = registrar.RegisterParticipants<TeamLead>(AllForTheHackathon.Сonstants.FileWithTeamLeads);
            _strategy = strategy;
        }


        public List<Team> Hold()
        {
            return _strategy.BuildTeams(Juniors, TeamLeads);
        }

    }
}