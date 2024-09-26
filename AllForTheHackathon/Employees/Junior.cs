namespace AllForTheHackathon.Employees
{
    public class Junior : Employee
    {
        public List<TeamLead> Wishlist { get; private set; } = new List<TeamLead>();
        public Junior(int id, string name) : base(id, name)
        {
        }

        public Junior(int id, string name, List<TeamLead> teamLeads) : base(id, name)
        {
            Wishlist = teamLeads;
        }
    }
}
