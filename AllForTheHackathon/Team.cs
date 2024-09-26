using AllForTheHackathon.Employees;
using System.Xml.Linq;

namespace AllForTheHackathon
{
    public class Team
    {
        public Junior Junior { get; private set; }
        public int SatisfactionOfJunior { get; private set; }
        public TeamLead TeamLeader { get; private set; }
        public int SatisfactionOfTeamLeader { get; private set; }

        public Team(Junior junior, int satisfactionOfJunior, TeamLead teamLeader, int satisfactionOfTeamLeader)
        {
            Junior = junior;
            TeamLeader = teamLeader;
            SatisfactionOfJunior = satisfactionOfJunior;
            SatisfactionOfTeamLeader = satisfactionOfTeamLeader;
        }

        public override string ToString()
        {
            return $"{Junior.ToString(), -25}{SatisfactionOfJunior.ToString(), -4}{TeamLeader.ToString(), -25}{SatisfactionOfTeamLeader.ToString()}";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Team);
        }
        public bool Equals(Team other)
        {
            if (other != null && Junior.Equals(other.Junior) 
                && TeamLeader.Equals(other.TeamLeader) 
                && SatisfactionOfJunior == other.SatisfactionOfJunior
                && SatisfactionOfTeamLeader == other.SatisfactionOfTeamLeader)
                return true;
            return false;
        }
    }
}
