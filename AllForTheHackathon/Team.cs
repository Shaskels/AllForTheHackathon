using AllForTheHackathon.Employees;

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
    }
}
