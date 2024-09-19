using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public class Team
    {
        public Junior Junior { get; set; }
        public int SatisfactionOfJunior { get; set; }
        public TeamLead TeamLeader { get; set; }
        public int SatisfactionOfTeamLeader { get; set; }

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
