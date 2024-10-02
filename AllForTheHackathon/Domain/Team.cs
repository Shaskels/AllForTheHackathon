using AllForTheHackathon.Domain.Employees;

namespace AllForTheHackathon.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public Employee? Junior { get; set; }
        public int SatisfactionOfJunior { get; set; }
        public Employee? TeamLeader { get; set; }
        public int SatisfactionOfTeamLeader { get; set; }
        public int HackathonId { get; set; }
        public Hackathon? Hackathon { get; set; }

        public Team(int satisfactionOfJunior, int satisfactionOfTeamLeader)
        {
            SatisfactionOfJunior = satisfactionOfJunior;
            SatisfactionOfTeamLeader = satisfactionOfTeamLeader;
        }

        public Team(Employee junior, int satisfactionOfJunior, Employee teamLead, int satisfactionOfTeamLeader) 
        {
            Junior = junior;
            SatisfactionOfJunior= satisfactionOfJunior;
            TeamLeader = teamLead;
            SatisfactionOfTeamLeader= satisfactionOfTeamLeader;
        }

        public override string ToString()
        {
            return $"{Junior.ToString(),-25}{SatisfactionOfJunior.ToString(),-4}{TeamLeader.ToString(),-25}{SatisfactionOfTeamLeader.ToString()}";
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
