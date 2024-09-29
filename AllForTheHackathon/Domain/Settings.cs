namespace AllForTheHackathon.Domain
{
    public class Settings
    {
        public int NumberOfHackathons { get; set; }
        public int NumberOfTeams { get; set; }
        public string FileWithJuniors { get; set; } = string.Empty;
        public string FileWithTeamLeads { get; set; } = string.Empty;
    }
}
