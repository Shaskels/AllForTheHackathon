using AllForTheHackathon.Employees;

namespace AllForTheHackathon
{
    public interface IRegistrar
    {
        public (List<Junior>, List<TeamLead>) RegisterParticipants(string fileNameWithJuniors, string fileNameWithTeamLeaders);
    }
}
