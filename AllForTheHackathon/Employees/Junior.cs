namespace AllForTheHackathon.Employees
{
    public class Junior : Employee
    {
        public List<TeamLead> Wishlist { get; set; } = new List<TeamLead>();
        public Junior(int id, string name) : base(id, name)
        {
        }

    }
}
